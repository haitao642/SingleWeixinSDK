using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public class ConverTableAndList
    {
        public static List<T> ConvertTableToList<T>(DataTable table)
            where T : new()
        {
            List<T> list = new List<T>();
            T entity = new T();
            PropertyInfo[] propinfos = entity.GetType().GetProperties();
            if (propinfos != null)
            {
                if (table != null && table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        entity = new T();
                        foreach (PropertyInfo propinfo in propinfos)
                        {
                            if (table.Columns.Contains(propinfo.Name) && table.Rows[i][propinfo.Name] != null && table.Rows[i][propinfo.Name] != DBNull.Value)
                                propinfo.SetValue(entity, ChangeType(table.Rows[i][propinfo.Name], propinfo.PropertyType), null);
                        }
                        list.Add(entity);
                    }
                }
            }
            return list;
        }

        public static List<Object> ConvertTableToList(DataTable table, Type entityType)
        {
            List<Object> list = new List<Object>();

            PropertyInfo[] propinfos = entityType.GetProperties();
            if (propinfos != null)
            {
                if (table != null && table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        Object entity = Activator.CreateInstance(entityType);
                        foreach (PropertyInfo propinfo in propinfos)
                        {
                            if (table.Columns.Contains(propinfo.Name) && table.Rows[i][propinfo.Name] != null && table.Rows[i][propinfo.Name] != DBNull.Value)
                            {
                                propinfo.SetValue(entity, ChangeType(table.Rows[i][propinfo.Name], propinfo.PropertyType), null);
                            }
                        }
                        list.Add(entity);
                    }
                }
            }
            return list;
        }

        public static DataTable ConvertListToTable<T>(List<T> list)
            where T : new()
        {
            DataTable table = new DataTable();
            T entity = new T();
            PropertyInfo[] propinfos = entity.GetType().GetProperties();
            if (propinfos != null)
            {
                //填充entity类的属性
                foreach (PropertyInfo propinfo in propinfos)
                {
                    table.Columns.Add(propinfo.Name, GetType(propinfo.PropertyType));
                }
                if (list != null && list.Count > 0)
                {
                    foreach (T item in list)
                    {
                        DataRow dr = table.NewRow();
                        foreach (PropertyInfo propinfo in propinfos)
                        {
                            dr[propinfo.Name] = propinfo.GetValue(item, null) ?? DBNull.Value;
                        }
                        table.Rows.Add(dr);
                    }
                }
                return table;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 替换类里面的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ReplaceObjStr<T>(string str, T model)
            where T : new()
        {
            T entity = new T();
            PropertyInfo[] propinfos = entity.GetType().GetProperties();
            if (propinfos == null)
            {
                return str;
            }
            foreach (PropertyInfo propinfo in propinfos)
            {
                string v = string.Empty;
                object o = propinfo.GetValue(model, null);
                if (o != null)
                {
                    v = o.ToString();
                }
                str = str.Replace(string.Format("%{0}%", propinfo.Name), v);
            }
            return str;
        }


        public static DataTable ConvertListToTable<T>(DataTable table, List<T> list)
    where T : new()
        {
            if (table.Rows.Count == 0) table.Rows.Add(table.NewRow());
            T entity = new T();
            PropertyInfo[] propinfos = entity.GetType().GetProperties();
            if (propinfos != null)
            {
                if (list != null && list.Count > 0)
                {
                    foreach (T item in list)
                    {
                        DataRow dr = table.Rows[0];
                        foreach (PropertyInfo propinfo in propinfos)
                        {
                            if (table.Columns.Contains(propinfo.Name) && propinfo.GetValue(item, null) != null)
                            {
                                if (!InvalidDate(propinfo.GetValue(item, null), propinfo.PropertyType))
                                {
                                    dr[propinfo.Name] = propinfo.GetValue(item, null);
                                }
                            }
                        }
                    }
                }
                return table;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 检查是否是无效的日期
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static bool InvalidDate(object val, Type type)
        {
            if (val == null) return true;
            DateTime dd = DateTime.Now.AddYears(1000);
            bool Isdate = false;
            Type valtype = type;
            string pptypeName = valtype.Name.ToLower();
            string pptypeName2 = valtype.FullName.ToLower();
            if (pptypeName == "datetime")
            {
                Isdate = true;
            }
            else if (pptypeName == "nullable`1")
            {
                if (pptypeName2.LastIndexOf("datetime") != -1)
                {
                    Isdate = true;
                }
            }

            if (Isdate)
            {
                DateTime.TryParse(val.ToString(), out dd);
                if (dd < DateTime.Now.AddYears(-500))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 若是枚举类型，需特殊处理
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        public static object ChangeType(object val, Type type)
        {
            Type valtype = type;
            string pptypeName = valtype.Name.ToLower();
            string pptypeName2 = valtype.FullName.ToLower();
            if (pptypeName.LastIndexOf("int") != -1)
            {
                return Convert.ToInt32(val);
            }
            else if (pptypeName == "datetime")
            {
                return Convert.ToDateTime(val);
            }
            else if (pptypeName == "string")
            {
                return Convert.ToString(val).Trim();
            }
            else if (pptypeName == "decimal")
            {
                return Convert.ToDecimal(val);
            }
            else if (pptypeName == "nullable`1")
            {

                if (pptypeName2.LastIndexOf("int") != -1)
                {
                    return Convert.ToInt32(val);
                }
                else if (pptypeName2.LastIndexOf("datetime") != -1)
                {
                    return Convert.ToDateTime(val);
                }
                else if (pptypeName2.LastIndexOf("string") != -1)
                {
                    return Convert.ToString(val).Trim();
                }
                else if (pptypeName2.LastIndexOf("decimal") != -1)
                {
                    return Convert.ToDecimal(val);
                }
            }
            return val;
        }


        /// <summary>
        /// 取类型，
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        public static Type GetType(Type type)
        {
            Type valtype = type;
            string pptypeName = valtype.Name.ToLower();
            string pptypeName2 = valtype.FullName.ToLower();

            if (pptypeName == "nullable`1")
            {

                if (pptypeName2.LastIndexOf("int") != -1)
                {
                    return typeof(Int32);
                }
                else if (pptypeName2.LastIndexOf("datetime") != -1)
                {
                    return typeof(DateTime);
                }
                else if (pptypeName2.LastIndexOf("string") != -1)
                {
                    return typeof(String);
                }
                else if (pptypeName2.LastIndexOf("decimal") != -1)
                {
                    return typeof(Decimal);
                }
            }

            return type;
        }

        private static long DateTimeToJsTime(DateTime dateTime)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (dateTime.ToUniversalTime().Ticks - dt1970.Ticks) / 10000;
        }

        private static String DateTimeToString(DateTime dateTime)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
}
