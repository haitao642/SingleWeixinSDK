using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cust
{
    /// <summary>
    /// 档案
    /// </summary>
    public class CustM
    {
        ///<summary>
        ///档案号
        /// </summary>
        public int Ing_Pk_CustID { get; set; }

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID { get; set; }

        ///<summary>
        ///客户档案编码
        /// </summary>
        public string str_CustomerNo { get; set; }

        ///<summary>
        ///状态
        /// </summary>
        public string str_sta { get; set; }

        ///<summary>
        ///姓名
        /// </summary>
        public string str_CusName { get; set; }

        ///<summary>
        ///名
        /// </summary>
        public string str_FCusName { get; set; }

        ///<summary>
        ///姓
        /// </summary>
        public string str_LCusName { get; set; }

        ///<summary>
        ///英文名
        /// </summary>
        public string str_CusNameEng { get; set; }

        ///<summary>
        ///等级
        /// </summary>
        public string str_grade { get; set; }

        ///<summary>
        ///成员类别（F,G,C)
        /// </summary>
        public string str_CusClass { get; set; }

        ///<summary>
        ///客户类型
        /// </summary>
        public string str_CusType { get; set; }

        ///<summary>
        ///str_CusTypeGrp
        /// </summary>
        public string str_CusTypeGrp { get; set; }

        ///<summary>
        ///模板
        /// </summary>
        public string str_Mod { get; set; }

        ///<summary>
        ///编号
        /// </summary>
        public string str_taxno { get; set; }

        ///<summary>
        ///合同号
        /// </summary>
        public string str_cno { get; set; }

        ///<summary>
        ///合同类别
        /// </summary>
        public string str_cnoType { get; set; }

        ///<summary>
        ///签订人
        /// </summary>
        public string str_cnoSigner { get; set; }

        ///<summary>
        ///合同附件
        /// </summary>
        public string str_cnoAttach { get; set; }

        ///<summary>
        ///合同联系人
        /// </summary>
        public string str_cnoliason { get; set; }

        ///<summary>
        ///合同联系人电话
        /// </summary>
        public string str_cnoLiasonTel { get; set; }

        ///<summary>
        ///职位
        /// </summary>
        public string str_position { get; set; }

        ///<summary>
        ///房间
        /// </summary>
        public string str_RoomNo { get; set; }

        ///<summary>
        ///中心
        /// </summary>
        public string str_central { get; set; }

        ///<summary>
        ///来源
        /// </summary>
        public string str_cmfrom { get; set; }

        ///<summary>
        ///市场
        /// </summary>
        public string str_market { get; set; }

        ///<summary>
        ///会员
        /// </summary>
        public string str_vip { get; set; }

        ///<summary>
        ///保留
        /// </summary>
        public string str_keep { get; set; }

        ///<summary>
        ///归属部门
        /// </summary>
        public string str_belong { get; set; }

        ///<summary>
        ///性别（0:女，1:男，2:不确定）
        /// </summary>
        public string str_gender { get; set; }

        ///<summary>
        ///语言
        /// </summary>
        public string str_language { get; set; }

        ///<summary>
        ///称谓
        /// </summary>
        public string str_title { get; set; }

        ///<summary>
        ///称呼
        /// </summary>
        public string str_salutation { get; set; }

        ///<summary>
        ///生日
        /// </summary>
        public DateTime? dt_birth { get; set; }

        ///<summary>
        ///民族
        /// </summary>
        public string str_race { get; set; }

        ///<summary>
        ///宗教
        /// </summary>
        public string str_religion { get; set; }

        ///<summary>
        ///职业
        /// </summary>
        public string str_occupation { get; set; }

        ///<summary>
        ///国籍
        /// </summary>
        public string str_nation { get; set; }

        ///<summary>
        ///证件类型
        /// </summary>
        public string str_idcls { get; set; }

        ///<summary>
        ///证件号码
        /// </summary>
        public string str_ident { get; set; }

        ///<summary>
        ///证件有效期
        /// </summary>
        public DateTime? dt_identDate { get; set; }

        ///<summary>
        ///街道
        /// </summary>
        public string str_street { get; set; }

        ///<summary>
        ///邮编
        /// </summary>
        public string str_zip { get; set; }

        ///<summary>
        ///手机
        /// </summary>
        public string str_mobile { get; set; }

        ///<summary>
        ///电话
        /// </summary>
        public string str_phone { get; set; }

        ///<summary>
        ///传真
        /// </summary>
        public string str_fax { get; set; }

        /// <summary>
        /// 状态 1:有效  2:停用   0:删除
        /// </summary>
        public int? Ing_Msta { get; set; }

        ///<summary>
        ///有效期 开始
        /// </summary>
        public DateTime? dt_ArrDate { get; set; }

        ///<summary>
        ///有效期结束
        /// </summary>
        public DateTime? dt_DepDate { get; set; }

        ///<summary>
        ///信用等级
        /// </summary>
        public string str_CreditLevel { get; set; }


        ///<summary>
        ///联系人
        /// </summary>
        public string str_liason { get; set; }

        ///<summary>
        ///联系方式
        /// </summary>
        public string str_LiasonType { get; set; }

        ///<summary>
        ///说明
        /// </summary>
        public string str_comment { get; set; }

        ///<summary>
        ///备注
        /// </summary>
        public string remark { get; set; }

        ///<summary>
        ///国家1
        /// </summary>
        public string str_country { get; set; }

        ///<summary>
        ///省编号
        /// </summary>
        public string str_state { get; set; }


        ///<summary>
        ///城市
        /// </summary>
        public string str_town { get; set; }

        ///<summary>
        ///地区
        /// </summary>
        public string str_area { get; set; }

        ///<summary>
        ///city
        /// </summary>
        public string str_city { get; set; }

        ///<summary>
        ///网站
        /// </summary>
        public string str_wetsite { get; set; }

        ///<summary>
        ///email
        /// </summary>
        public string str_email { get; set; }

        ///<summary>
        ///创建者
        /// </summary>
        public string str_crtby { get; set; }

        ///<summary>
        ///创建日期
        /// </summary>
        public DateTime? dt_crttime { get; set; }

        ///<summary>
        ///修改人
        /// </summary>
        public string str_Modify { get; set; }

        ///<summary>
        ///修改日期
        /// </summary>
        public DateTime? dt_ModifyDate { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string str_Nickname { get; set; }
    }
}
