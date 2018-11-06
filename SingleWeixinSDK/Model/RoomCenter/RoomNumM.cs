using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RoomCenter
{
    /// <summary>
    /// T_Room_Num
    /// </summary>
    public class RoomNumM
    {
        ///<summary>
        ///Ing_pk_id
        /// </summary>
        public int Ing_pk_id { get; set; }

        ///<summary>
        ///房号
        /// </summary>
        public string str_RoomNo { get; set; }

        ///<summary>
        ///原房号
        /// </summary>
        public string str_oroomno { get; set; }

        ///<summary>
        ///楼层号
        /// </summary>
        public string str_Fk_FloorNo { get; set; }

        /// <summary>
        /// 楼层中文名
        /// </summary>
        public string FloorName { get; set; }

        /// <summary>
        /// 楼号
        /// </summary>
        public string BuildName { get; set; }

        ///<summary>
        ///客户区域
        /// </summary>
        public string str_FK_RoomRegion { get; set; }

        ///<summary>
        ///客房标志
        /// </summary>
        public string str_RmTag { get; set; }

        ///<summary>
        ///房类
        /// </summary>
        public string str_FK_Type { get; set; }

        ///<summary>
        ///占用状态
        /// </summary>
        public string str_OcStatus { get; set; }

        ///<summary>
        ///历史房态
        /// </summary>
        public string str_oldstatus { get; set; }

        ///<summary>
        ///房态
        /// </summary>
        public string str_status { get; set; }

        ///<summary>
        ///临时房状态
        /// </summary>
        public string str_tmpstatus { get; set; }

        ///<summary>
        ///人数
        /// </summary>
        public int Ing_PeopleNumber { get; set; }

        ///<summary>
        ///特殊的
        /// </summary>
        public int Ing_bedno { get; set; }

        ///<summary>
        ///房价码
        /// </summary>
        public string str_ratecode { get; set; }

        ///<summary>
        ///单价
        /// </summary>
        public decimal? dec_rate { get; set; }

        ///<summary>
        ///房间特征
        /// </summary>
        public string str_FK_Feature { get; set; }

        ///<summary>
        ///是否锁房
        /// </summary>
        public string str_locked { get; set; }

        ///<summary>
        ///维修状态
        /// </summary>
        public string str_FutStatus { get; set; }

        ///<summary>
        ///维修开始时间
        /// </summary>
        public DateTime? dt_FutBeginTime { get; set; }

        ///<summary>
        ///维修结束时间
        /// </summary>
        public DateTime? dt_FutEndTime { get; set; }

        ///<summary>
        ///维修登记时间
        /// </summary>
        public DateTime? dt_Fcdate { get; set; }

        ///<summary>
        ///维修登记人
        /// </summary>
        public string str_FEmpNo { get; set; }

        ///<summary>
        ///原住入房间人数
        /// </summary>
        public int? Ing_onumber { get; set; }

        ///<summary>
        ///住入房价人数
        /// </summary>
        public int? Ing_number { get; set; }

        ///<summary>
        ///帐号
        /// </summary>
        public string str_AccountNumber { get; set; }

        ///<summary>
        ///维修记录
        /// </summary>
        public string str_futmark { get; set; }

        ///<summary>
        ///维修时间
        /// </summary>
        public DateTime? dt_futdate { get; set; }

        ///<summary>
        ///空房天数
        /// </summary>
        public int Ing_emptyDays { get; set; }

        ///<summary>
        ///横向
        /// </summary>
        public int Ing_x { get; set; }

        ///<summary>
        ///纵向
        /// </summary>
        public int Ing_y { get; set; }

        ///<summary>
        ///宽度
        /// </summary>
        public int Ing_width { get; set; }

        ///<summary>
        ///高度
        /// </summary>
        public int Ing_height { get; set; }

        ///<summary>
        ///住客房数量
        /// </summary>
        public int Ing_n1 { get; set; }

        ///<summary>
        ///离店客房
        /// </summary>
        public int Ing_n2 { get; set; }

        ///<summary>
        ///touch_up
        /// </summary>
        public int Ing_n3 { get; set; }

        ///<summary>
        ///备注
        /// </summary>
        public string remark { get; set; }

        ///<summary>
        ///排序
        /// </summary>
        public int Ing_Seq { get; set; }

        ///<summary>
        ///修改人
        /// </summary>
        public string str_editempno { get; set; }

        ///<summary>
        ///修改时间
        /// </summary>
        public DateTime? dt_edittime { get; set; }

        ///<summary>
        ///日志编号
        /// </summary>
        public int Ing_logmark { get; set; }

        ///<summary>
        ///str_Hall
        /// </summary>
        public string str_Hall { get; set; }

        ///<summary>
        ///房间提示
        /// </summary>
        public string str_RmInfo { get; set; }

        ///<summary>
        ///维修原因
        /// </summary>
        public string str_reason { get; set; }

        ///<summary>
        ///房间说明
        /// </summary>
        public string str_Directions { get; set; }

        ///<summary>
        ///门锁房号
        /// </summary>
        public string str_ptRoomNo { get; set; }

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID { get; set; }

        /// <summary>
        /// 批量新增的房号  - 表示 至，  逗号 表示和
        /// 比如，  1000-1011 表示  1000到1011 之间所有房号
        /// 1102  表示  就这一个房间
        /// 1000-1011，1102，1201-1205    表示 1000到1011 ，  1102， 1201到1205 之间的房号
        /// </summary>
        public string str_RoomNos { get; set; }



    }
}
