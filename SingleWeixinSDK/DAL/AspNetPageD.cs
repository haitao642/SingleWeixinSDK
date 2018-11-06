using Bee.Web;
using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AspNetPageD:BaseTable
    {
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="page">分页实体</param>
        /// <returns></returns>
        public DataTable GetList(AspNetPageM model,out int recordCount,DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            recordCount = 0;
            string strSql = "EXEC U_Get_TableDataPage @TableNames,@PrimaryKey,@Fields,@PageSize,@CurrentPage,@Filter,@Group,@Order";
            if (model.PageSize == 0) model.PageSize = 15;

            if (model.CurrentPage == 0) model.CurrentPage = 1;


            this.Sqlca.AddParameter("@TableNames", model.TableNames);
            this.Sqlca.AddParameter("@PrimaryKey", model.PrimaryKey);
            this.Sqlca.AddParameter("@Fields", model.Fields);
            this.Sqlca.AddParameter("@PageSize", model.PageSize);
            this.Sqlca.AddParameter("@CurrentPage", model.CurrentPage);
            this.Sqlca.AddParameter("@Filter", model.Filter);
            this.Sqlca.AddParameter("@Group", model.Group);
            this.Sqlca.AddParameter("@Order", model.Order);

            DataSet ds = this.Sqlca.GetDataSet(strSql);
            this.Sqlca.ClearParameter();

            DataTable dt = new DataTable();
            if (ds == null || ds.Tables.Count != 2) return dt;
            dt = ds.Tables[0];

            if (ds.Tables[1].Rows.Count > 0)
            {
                int.TryParse(ds.Tables[1].Rows[0][0].ToString().Trim(), out recordCount);
            }

            return dt;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="page">分页实体</param>
        /// <returns></returns>
        public List<T> GetList<T>(AspNetPageM model, out int recordCount, DataTrans DataTrans = null)
            where T : new()
        {
            recordCount = 0;

            DataTable dt = this.GetList(model, out recordCount,DataTrans);

            return Public.ConverTableAndList.ConvertTableToList<T>(dt);

        }
    }
}
