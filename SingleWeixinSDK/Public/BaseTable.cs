using Bee.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class BaseTable : XYBiz
    {
        public string tablename; //表名
        public string filedname; //主键名称
        private DataTrans _Sqlca;
        public int lngKeyID = 0;
        public string strPKID = "";



        /// <summary>
        /// 从一个 object 对象转化为 字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string getstringfromobject(object obj)
        {
            string rev = "";
            if (obj == null)
            {
                rev = "";
            }
            else
            {
                rev = obj.ToString().Trim();
            }
            return rev;
        }

        public BaseTable()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tbname"></param>
        /// <param name="fname"></param>
        public BaseTable(string tbname, string fname)
        {
            this.tablename = tbname;
            this.filedname = fname;
        }

        public DataTrans GetDataTrans(string appsetting)
        {
            string connection = ConfigValue.GetValue(appsetting);
            return new DataTrans(connection);
        }

        public DataTrans GetDataTrans(string appsetting, Providers_s provider)
        {
            string connection = ConfigValue.GetValue(appsetting);
            return new DataTrans(connection, provider);
        }

        /// <summary>
        /// 微信库的链接字符串
        /// </summary>
        /// <returns></returns>
        public DataTrans SqlcaWeChat()
        {
            return GetDataTrans("ConnectionStringBJWeChat");
        }
        public DataTrans SqlcaOTAPMS()
        {
            return GetDataTrans("ConnectionStringOTAPMS");
        }

        /// <summary>
        /// 微信库的链接字符串
        /// </summary>
        /// <returns></returns>
        public DataTrans SqlcaSingleOne()
        {
            string connection = "server=117.27.157.70000000;database=SingleOne;uid=bjjd;pwd=Booz!!)!_mc";
            //string connection = "server=59.60.28.86,1633;database=SingOnetest;uid=booz;pwd=booz1978.8002";
            return new DataTrans(connection);
        }


        /// <summary>
        /// 得到主键的最大值
        /// </summary>
        /// <returns></returns>
        public object GexMax(DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            string strSql = "select max({1}) from {0}";
            strSql = string.Format(strSql, tablename, filedname);


            object rev = this.Sqlca.ExecuteScalar(strSql);
            this.LastError = this.Sqlca.LastError;
            return rev;
        }



        /// <summary>
        /// 得到主键的最大值
        /// </summary>
        /// <returns></returns>
        public object GexMax(object field, object strWhere, DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            string strSql = "select max({1}) from {0} where {2}";
            strSql = string.Format(strSql, tablename, field, strWhere.ToString().Trim().Equals("") ? "1=1" : strWhere.ToString().Trim());


            object rev = this.Sqlca.ExecuteScalar(strSql);
            this.LastError = this.Sqlca.LastError;
            return rev;
        }


        /// <summary>
        /// 返回记录
        /// </summary>
        /// <param name="lngPri">主键值</param>
        /// <param name="DataTrans">DataTrans</param>
        /// <returns></returns>
        public DataTable Get(object lngPri, DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            string strSql = "select * from {0} where {1}='{2}'";
            strSql = string.Format(strSql, tablename, filedname, lngPri);

            DataTable dt = null;
            dt = this.Sqlca.GetDataTable(strSql);
            this.LastError = this.Sqlca.LastError;
            return dt;
        }


        /// <summary>
        /// 获取Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lngPri"></param>
        /// <param name="DataTrans"></param>
        /// <returns></returns>
        public T GetM<T>(object lngPri, DataTrans DataTrans = null)
            where T : new()
        {
            DataTable dt = Get(lngPri, DataTrans);
            return ConverTableAndList.ConvertTableToList<T>(dt).FirstOrDefault();
        }


        /// <summary>
        /// 返回记录
        /// </summary>
        /// <param name="DataTrans">DataTrans</param>
        /// <returns></returns>
        public DataTable GetAll(DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            string strSql = "select * from {0}";
            strSql = string.Format(strSql, tablename);


            DataTable dt = null;
            dt = this.Sqlca.GetDataTable(strSql);
            if (DataTrans == null)
            {
                this.Sqlca.Close();
            }
            this.LastError = this.Sqlca.LastError;
            return dt;
        }

        /// <summary>
        /// 取得全部Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lngPri"></param>
        /// <param name="DataTrans"></param>
        /// <returns></returns>
        public List<T> GetAllM<T>(DataTrans DataTrans = null)
           where T : new()
        {
            DataTable dt = GetAll(DataTrans);
            return ConverTableAndList.ConvertTableToList<T>(dt);
        }

        /// <summary>
        /// 根据门店号，返回记录
        /// </summary>
        /// <param name="StoreID">StoreID  0：表示所有</param>
        /// <param name="DataTrans">DataTrans</param>
        /// <returns></returns>
        public DataTable GetListByStoreID(int StoreID, DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            string strSql = "select * from {0}";
            strSql = string.Format(strSql, tablename);

            //if (StoreID > 0)
            //{
            //    strSql = string.Format("{0} where {1}={2}",strSql,strStoreFiled,StoreID);
            //}


            DataTable dt = null;
            dt = this.Sqlca.GetDataTable(strSql);
            if (DataTrans == null)
            {
                this.Sqlca.Close();
            }
            this.LastError = this.Sqlca.LastError;
            return dt;
        }

        /// <summary>
        /// 根据门店号，返回记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="StoreID"></param>
        /// <param name="DataTrans"></param>
        /// <returns></returns>
        public List<T> GetListByStoreID<T>(int StoreID, DataTrans DataTrans = null)
   where T : new()
        {
            DataTable dt = GetListByStoreID(StoreID, DataTrans);
            return ConverTableAndList.ConvertTableToList<T>(dt);
        }


        /// <summary>
        /// 返回记录
        /// </summary>
        /// <param name="lngPri">主键值</param>
        /// <param name="DataTrans">DataTrans</param>
        /// <returns></returns>
        public DataTable GetQuery(string strSql, DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            DataTable dt = null;
            dt = this.Sqlca.GetDataTable(strSql);
            if (DataTrans == null)
            {
                //this.Sqlca.Close();
            }
            this.LastError = this.Sqlca.LastError;
            return dt;
        }

        /// <summary>
        /// 得到一些主键对应的记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strids"></param>
        /// <param name="DataTrans"></param>
        /// <returns></returns>
        public List<T> GetFilterListM<T>(string strids, DataTrans DataTrans = null)
           where T : new()
        {
            string strSql = string.Format("select * from {0} where {1} in ({2})", tablename, filedname, strids);
            return GetQueryM<T>(strSql, DataTrans);
        }

        /// <summary>
        /// 取得全部Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lngPri"></param>
        /// <param name="DataTrans"></param>
        /// <returns></returns>
        public List<T> GetQueryM<T>(string strSql, DataTrans DataTrans = null)
           where T : new()
        {
            DataTable dt = GetQuery(strSql, DataTrans);
            return ConverTableAndList.ConvertTableToList<T>(dt);
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="lngPri">主键值</param>
        /// <returns></returns>
        public bool DeleteRecord(object lngPri, DataTrans DataTrans = null)
        {
            if (!CheckDelete(lngPri))
            {
                return false;
            }
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            else
            {
                if (!this.Sqlca.Open())
                {
                    this.LastError = this.Sqlca.LastError;
                    return false;
                }

                if (!this.Sqlca.BeginTransaction())
                {
                    this.LastError = this.Sqlca.LastError;
                    goto delerr;
                }
            }
            string strSql = "delete from {0} where {1}={2}";
            strSql = string.Format(strSql, tablename, filedname, lngPri);

            if (!this.Sqlca.ExecuteNonQuery(strSql))
            {
                this.LastError = this.Sqlca.LastError;
                goto delerr;
            }

            if (DataTrans == null)
            {
                this.Sqlca.CommitTransaction();
                this.Sqlca.Close();
            }
            return true;

            delerr:
            if (DataTrans == null)
            {
                this.Sqlca.RollbackTransaction();
                this.Sqlca.Close();
            }
            return false;
        }

        /// <summary>
        /// 删除时检查
        /// </summary>
        /// <param name="lngPri"></param>
        /// <returns></returns>
        public bool CheckDelete(object lngPri)
        {
            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool UpdateRecord(DataTable dt, DataTrans DataTrans = null)
        {
            if (!CheckUpdate(dt))
            {
                return false;
            }
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            else
            {
                if (!this.Sqlca.Open())
                {
                    this.LastError = this.Sqlca.LastError;
                    return false;
                }

                if (!this.Sqlca.BeginTransaction())
                {
                    this.LastError = this.Sqlca.LastError;
                    goto updateerr;
                }
            }

            string strSql = "select * from {0} where 1=2";
            strSql = string.Format(strSql, tablename);

            if (!this.Sqlca.Update(dt, strSql))
            {
                this.LastError = this.Sqlca.LastError;
                goto updateerr;
            }

            if (string.IsNullOrEmpty(dt.Rows[0][filedname].ToString().Trim().Replace("0", "")))
            {
                this.lngKeyID = this.Sqlca.PKID;
            }
            else
            {
                int.TryParse(dt.Rows[0][filedname].ToString().Trim(), out this.lngKeyID);
            }

            if (DataTrans == null)
            {
                this.Sqlca.CommitTransaction();
                this.Sqlca.Close();
            }
            return true;

            updateerr:
            if (DataTrans == null)
            {
                this.Sqlca.RollbackTransaction();
                this.Sqlca.Close();
            }
            return false;
        }

        /// <summary>
        /// 更新时检查
        /// </summary>
        /// <param name="lngPri"></param>
        /// <returns></returns>
        public bool CheckUpdate(DataTable dt)
        {
            return true;
        }

        /// <summary>
        /// 取得全部Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lngPri"></param>
        /// <param name="DataTrans"></param>
        /// <returns></returns>
        public bool UpdateRecord<T>(T model, int lngkey = 0, DataTrans DataTrans = null)
           where T : new()
        {
            List<T> list = new List<T>();
            list.Add(model);
            DataTable dt1 = this.Get(lngkey, DataTrans);
            DataTable dt = ConverTableAndList.ConvertListToTable<T>(dt1, list);
            bool rev = UpdateRecord(dt, DataTrans);
            return rev;
        }


        public new DataTrans Sqlca
        {
            get
            {
                if (this._Sqlca == null)
                {
                    DataTrans datatr = new DataTrans(Providers_s.SqlServer);
                    this._Sqlca = datatr;
                    this._Sqlca.LogName = ConfigValue.DBLogName;
                    this._Sqlca.LogErrors = ConfigValue.DBLogErrors;
                    this._Sqlca.LogSql = ConfigValue.DBLogSQL;
                    this._Sqlca.LogSqlName = ConfigValue.DBLogSQLName;
                }
                return this._Sqlca;
            }
            set
            {
                this._Sqlca = value;
            }
        }


    }
}
