using Model;
using Public;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
    /// <summary>
    /// 周边信息
    /// </summary>
    public class NearD
    {
        #region 周边


        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="keyword"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<ZBInfoM> bindDz(string x, string y, string keyword, int number)
        {
            string url = "http://api.map.baidu.com/telematics/v3/local?location=" + x + "," + y + "&keyWord=" + keyword + "&number=" + number + "&radius=1000&output=xml&ak=616ccf4ceb88161b48c2862b0c0929a2";

            int status = 0;

            List<ZBInfoM> list = new List<ZBInfoM>();

            string s1 = RequestUrl(url, out status);
            LogHelper.LogInfo("获取周边信息数据结果" + s1);
            string strDz = s1.Replace("<point>", ",111222111222,");
            string[] strDzs = System.Text.RegularExpressions.Regex.Split(strDz, ",111222111222,");
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < strDzs.Length; i++)
            {
                string strHead = strDzs[i].Replace("<additionalInfo>", ",111222111222,");
                string rr = System.Text.RegularExpressions.Regex.Split(strHead, ",111222111222,")[0];
                //strHead.Split(sl)[0];
                ZBInfoM m = new ZBInfoM();
                //名称
                Regex rname = new Regex(@"<name>(?<value>[\s|\S]*)</name>");
                string name = rname.Match(rr).Result("$1");
                m.name = name;

                Regex rcity = new Regex(@"<city>(?<value>[\s|\S]*)</city>");
                string city = rcity.Match(rr).Result("$1");
                m.city = city;

                Regex raddress = new Regex(@"<address>(?<value>[\s|\S]*)</address>");
                string address = raddress.Match(rr).Result("$1");
                m.address = address;

                Regex rdistance = new Regex(@"<distance>(?<value>[\s|\S]*)</distance>");
                string distance = rdistance.Match(rr).Result("$1");
                m.distance = distance;

                Regex rdistrict = new Regex(@"<district>(?<value>[\s|\S]*)</district>");
                string district = rdistrict.Match(rr).Result("$1");
                m.district = district;

                Regex rlng = new Regex(@"<lng>(?<value>[\s|\S]*)</lng>");
                string lng = rlng.Match(rr).Result("$1");
                m.lng = lng;

                Regex rlat = new Regex(@"<lat>(?<value>[\s|\S]*)</lat>");
                string lat = rlat.Match(rr).Result("$1");
                m.lat = lat;

                list.Add(m);


            }

            return list;
        }

        public static string RequestUrl(string url, out int status)
        {
            string result = string.Empty;
            status = 0;
            HttpWebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                Encoding responseEncoding = Encoding.GetEncoding(response.CharacterSet);
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), responseEncoding))
                {
                    result = sr.ReadToEnd();
                }
                status = (int)response.StatusCode;
            }
            catch (WebException wexc1)
            {
                // any statusCode other than 200 gets caught here
                if (wexc1.Status == WebExceptionStatus.ProtocolError)
                {
                    // can also get the decription: 
                    //  ((HttpWebResponse)wexc1.Response).StatusDescription;
                    status = (int)((HttpWebResponse)wexc1.Response).StatusCode;
                }
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
            return result;
        }



        //美食
        public string bindDiet(string x, string y)
        {
            x = "30.2745122312";
            y = "120.1576556537";
            //请替换AppKey以及Secret
            string appKey = "42268378";
            string secret = "041070ba5ccb491a84f757c494a936c7";
            string value = "";
            string queryString = "";

            //准备参数
            Hashtable ht = new Hashtable();
            ht.Add("format", "json");
            ht.Add("latitude", y);
            ht.Add("longitude", x);
            ht.Add("category", "美食");
            ht.Add("sort", "1");
            ht.Add("limit", "20");

            //参数按照参数名排序
            ArrayList akeys = new ArrayList(ht.Keys);
            akeys.Sort();

            //拼接字符串
            foreach (string skey in akeys)
            {
                value += skey + ht[skey].ToString();
                queryString += "&" + skey + "=" + Utf8Encode(ht[skey].ToString());
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(appKey);
            sb.Append(value);
            sb.Append(secret);
            value = sb.ToString();

            string url = "http://api.dianping.com/v1/business/find_businesses?appkey=" + appKey + "&sign=" + SHA1(value) + queryString;
            int status = 0;


            string s1 = RequestUrl(url, out status);
            string strDz = s1.Replace("business_id", ",111222111222,");

            string[] strDzs = System.Text.RegularExpressions.Regex.Split(strDz, ",111222111222,");
            //strDz.Split(sl);
            StringBuilder sb3 = new StringBuilder();

            for (int i = 1; i < strDzs.Length; i++)
            {
                string rr = strDzs[i];
                //名称
                Regex regex = new Regex(@"name(?<value>[\s|\S]*)branch_name");
                string insertValue = regex.Match(rr).Result("$1").Replace("\":\"", "").TrimEnd('"').TrimEnd(',').TrimEnd('"');
                //图片
                Regex regex1 = new Regex(@"s_photo_url(?<value>[\s|\S]*)has_coupon");
                string insertValue1 = regex1.Match(rr).Result("$1").Replace("\":\"", "").TrimEnd('"').TrimEnd(',').TrimEnd('"');


                sb3.Append(@"<li>");
                sb3.Append("<img onclick=\"window.location.href='restaurant.aspx?mapX=" + x + "&mapY=" + y + "'\" src='" + insertValue1 + "' width='65' height='65' />");
                sb3.Append(@"<p>");
                sb3.Append(insertValue);
                sb3.Append(@"</p>");
                sb3.Append(@"</li>");

                if (i > 4)
                { break; }
            }
            string rev = sb3.ToString();
            if (string.IsNullOrEmpty(rev))
            {
                rev = "暂无";
            }
            return rev;

        }

        public static string SHA1(string source)
        {
            byte[] value = Encoding.UTF8.GetBytes(source);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(value);

            string delimitedHexHash = BitConverter.ToString(result);
            string hexHash = delimitedHexHash.Replace("-", "");

            return hexHash;
        }
        private static string Utf8Encode(string value)
        {
            return HttpUtility.UrlEncode(value, System.Text.Encoding.UTF8);
        }

        #endregion
    }
}
