using Bee.Web;
using Model;
using Model.Cust;
using Model.Log;
using Model.RoomCenter;
using Public;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterD : BaseTable
    {
        public MasterD()
            : base("T_Master", "Ing_Pk_MasterID")
        { }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(MasterM model)
        {
            return true;
        }

        /// <summary>
        /// 保存 前台记录主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(MasterM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev = this.UpdateRecord<MasterM>(model, model.Ing_Pk_MasterID);
            model.Ing_Pk_MasterID = this.lngKeyID;
            return rev;
        }



        /// <summary>
        /// 检查删除
        /// </summary>
        /// <param name="lnguserid"></param>
        /// <returns></returns>
        public bool CheckDelete(int id)
        {
            return true;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="lnguserid"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {

            if (!CheckDelete(id))
            {
                return false;
            }

            return this.DeleteRecord(id);
        }
        #endregion


        /// <summary>
        /// 根据openid获取订单列表
        /// </summary>
        /// <param name="topnum"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public List<OrderM> GetOrderListByOpenid(int topnum, string openid)
        {
            ///查询全部，还是几条
            string top = string.Empty;
            if (topnum > 0)
            {
                top = string.Format(" top {0}", topnum);
            }

            string strSql = @"SELECT {0} a.Ing_Pk_MasterID,a.str_Pk_Accnt,a.Ing_StoreID,d.str_StoreName,a.str_RoomNo,a.str_ResType,
                                    a.dt_ArrDate,a.dt_DepDate,d.str_Address,a.dec_ActualRate,a.Ing_RoomNum,
                                    b.str_TypeName as RoomTypeName,c.str_CusName,c.str_mobile,a.dt_restime,a.str_Sta
                                     from T_Master a WITH (NOLOCK) 
                                    LEFT join T_Room_Type b ON a.Ing_StoreID=b.Ing_StoreID AND a.str_RoomType=b.str_TypeCode
                                    LEFT JOIN T_Cust c WITH (NOLOCK) ON a.Ing_FK_CustID=c.Ing_Pk_CustID
                                    LEFT JOIN T_Store_Info d ON a.Ing_StoreID=d.Ing_StoreID
                                    LEFT JOIN T_VipCard_Info e ON a.Ing_Fk_VipCardID=e.Ing_Pk_VipCardId
                                    WHERE e.str_wcopenid=@openid and ISNULL(e.str_wcopenid,'')<>''
                                    ORDER BY a.dt_restime DESC";
            strSql = string.Format(strSql, top);

            this.Sqlca.AddParameter("@openid", openid);

            List<OrderM> list = this.GetQueryM<OrderM>(strSql);
            this.Sqlca.ClearParameter();
            return list;
        }


        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="vipcardid">vipcardid</param>
        /// <param name="type">1: 在住 预订 挂账    0：离店   2：取消</param>
        /// <returns></returns>
        public List<OrderM> GetOrderbycardid(int vipcardid, int type)
        {
            if (type < 0 || type > 2) type = 1;
            string strSql = "";
            if (type == 1)
            {
                strSql = @"SELECT * FROM (
                                        SELECT a.Ing_Pk_MasterID,a.str_Pk_Accnt,a.Ing_StoreID,d.str_StoreName,a.str_RoomNo,a.str_ResType,a.dec_credit,
                                                                            a.dt_ArrDate,a.dt_DepDate,d.str_Address,a.dec_ActualRate,a.Ing_RoomNum,
                                                                            b.str_TypeName as RoomTypeName,c.str_CusName,c.str_mobile,a.dt_restime,a.str_Sta,a.dt_CancelTime,a.str_InterType
                                                                             from T_Master a WITH (NOLOCK) 
                                                                            LEFT join T_Room_Type b ON a.Ing_StoreID=b.Ing_StoreID AND a.str_RoomType=b.str_TypeCode
                                                                            LEFT JOIN T_Cust c WITH (NOLOCK) ON a.Ing_FK_CustID=c.Ing_Pk_CustID
                                                                            LEFT JOIN T_Store_Info d ON a.Ing_StoreID=d.Ing_StoreID
                                                                            WHERE a.Ing_Fk_VipCardID={0} AND a.str_Sta IN ('X') AND a.str_InterType='Hour'
                                                                            AND a.str_Channel='Wec' AND DATEDIFF(MINUTE,a.dt_restime,GETDATE())<30
                                                     UNION             
                                        SELECT a.Ing_Pk_MasterID,a.str_Pk_Accnt,a.Ing_StoreID,d.str_StoreName,a.str_RoomNo,a.str_ResType,a.dec_credit,
                                                                            a.dt_ArrDate,a.dt_DepDate,d.str_Address,a.dec_ActualRate,a.Ing_RoomNum,
                                                                            b.str_TypeName as RoomTypeName,c.str_CusName,c.str_mobile,a.dt_restime,a.str_Sta,a.dt_CancelTime,a.str_InterType
                                                                             from T_Master a WITH (NOLOCK) 
                                                                            LEFT join T_Room_Type b ON a.Ing_StoreID=b.Ing_StoreID AND a.str_RoomType=b.str_TypeCode
                                                                            LEFT JOIN T_Cust c WITH (NOLOCK) ON a.Ing_FK_CustID=c.Ing_Pk_CustID
                                                                            LEFT JOIN T_Store_Info d ON a.Ing_StoreID=d.Ing_StoreID
                                                                            WHERE a.Ing_Fk_VipCardID={0} AND a.str_Sta IN ('I','R','S'))t
                                                                            ORDER BY t.dt_restime DESC";
            }
            else if (type == 0)
            {
                strSql = @" SELECT a.Ing_Pk_MasterID,a.str_Pk_Accnt,a.Ing_StoreID,d.str_StoreName,a.str_RoomNo,a.str_ResType,
                                    a.dt_ArrDate,a.dt_DepDate,d.str_Address,a.dec_ActualRate,a.Ing_RoomNum,
                                    b.str_TypeName as RoomTypeName,c.str_CusName,c.str_mobile,a.dt_restime,a.str_Sta,a.dt_CancelTime,a.str_InterType
                                     from V_Master a WITH (NOLOCK) 
                                    LEFT join T_Room_Type b ON a.Ing_StoreID=b.Ing_StoreID AND a.str_RoomType=b.str_TypeCode
                                    LEFT JOIN T_Cust c WITH (NOLOCK) ON a.Ing_FK_CustID=c.Ing_Pk_CustID
                                    LEFT JOIN T_Store_Info d ON a.Ing_StoreID=d.Ing_StoreID
                                    WHERE a.Ing_Fk_VipCardID={0} AND a.str_Sta IN ('D','O')
                                    ORDER BY a.dt_restime DESC";
            }
            else
            {
                strSql = @" SELECT a.Ing_Pk_MasterID,a.str_Pk_Accnt,a.Ing_StoreID,d.str_StoreName,a.str_RoomNo,a.str_ResType,
                                    a.dt_ArrDate,a.dt_DepDate,d.str_Address,a.dec_ActualRate,a.Ing_RoomNum,
                                    b.str_TypeName as RoomTypeName,c.str_CusName,c.str_mobile,a.dt_restime,a.str_Sta,a.dt_CancelTime,a.str_InterType
                                     from V_Master a WITH (NOLOCK) 
                                    LEFT join T_Room_Type b ON a.Ing_StoreID=b.Ing_StoreID AND a.str_RoomType=b.str_TypeCode
                                    LEFT JOIN T_Cust c WITH (NOLOCK) ON a.Ing_FK_CustID=c.Ing_Pk_CustID
                                    LEFT JOIN T_Store_Info d ON a.Ing_StoreID=d.Ing_StoreID
                                    WHERE a.Ing_Fk_VipCardID={0} AND a.str_Sta IN ('X')
                                    ORDER BY a.dt_restime DESC";
            }

            strSql = string.Format(strSql, vipcardid);
            return this.GetQueryM<OrderM>(strSql);
        }

        /// <summary>
        /// 获取评论的主单记录
        /// </summary>
        /// <param name="MasterID"></param>
        /// <returns></returns>
        public OrderM GetCommentRecordByMasID(int MasterID)
        {
            string strSql = @" SELECT a.Ing_Pk_MasterID,a.str_Pk_Accnt,a.Ing_StoreID,d.str_StoreName,a.str_RoomNo,a.str_ResType,
                                    a.dt_ArrDate,a.dt_DepDate,d.str_Address,a.dec_ActualRate,a.Ing_RoomNum,
                                    a.str_RoomType,a.dt_restime,a.str_Sta,a.dt_CancelTime
                                     from V_Master a WITH (NOLOCK)
                                    LEFT JOIN T_Store_Info d ON a.Ing_StoreID=d.Ing_StoreID
                                     WHERE a.Ing_Pk_MasterID={0} AND a.str_Sta IN ('D','O')";
            strSql = string.Format(strSql, MasterID);
            return this.GetQueryM<OrderM>(strSql).FirstOrDefault();

        }


        #region 取消订单

        /// <summary>
        /// 取消  订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateX(cancelOrderM model)
        {
            MasterD dal = new MasterD();
            MasterM m = dal.GetM<MasterM>(model.id);
            if (m == null)
            {
                this.LastError = "L请选择主单";
                return false;
            }

            if (!m.str_Sta.ToUpper().Trim().Equals("R"))
            {
                this.LastError = string.Format("L状态为{0}不能取消", m.str_Sta);
                return false;
            }

            ///没有来期
            if (!m.dt_ArrDate.HasValue)
            {
                this.LastError = "L没有来期，不能取消";
                return false;
            }

            string strdate = string.Format("{0} 18:00:00", m.dt_ArrDate.Value.ToString("yyyy-MM-dd"));

            DateTime dtdate = DateTime.Now;
            if (!DateTime.TryParse(strdate, out dtdate))
            {
                this.LastError = "L没有来期，不能取消";
                return false;
            }

            ///超过来期日的18点，不能取消
            if (DateTime.Now > dtdate)
            {
                return false;
            }                

            if (!CheckUpdateX(model.id))
            {
                return false;
            }

            VipCardInfoD CardInfoD = new VipCardInfoD();
            WechatWalletD WalletD=new WechatWalletD();

            AccD acD = new AccD();
            List<AccM> listacc = acD.GetUseFulAcc(model.id);

            CommonFunc func = new CommonFunc();

            //判断是否使用了特殊优惠券
            CouponDetailsD coupD = new CouponDetailsD();
            CouponDetailsM coupM = coupD.GetCouponDetail(model.id);
           


            if (!this.Sqlca.BeginTransaction())
            {
                this.LastError = this.Sqlca.LastError;
                goto updateerr;
            }


            ///默认 取消的
            string strSql = "UPDATE T_Master SET str_Sta='X',dt_CancelTime=GETDATE(),str_memo='',dec_charge=dec_credit WHERE  Ing_Pk_MasterID={0}";

            strSql = string.Format(strSql, model.id);
            bool rev = this.Sqlca.ExecuteNonQuery(strSql);
            if (!rev)
            {
                this.LastError = this.Sqlca.LastError;
                goto updateerr;
            }
            if (coupM != null) 
            {
                coupM.Ing_Sta = 1;
                if (!coupD.UpdateRecord<CouponDetailsM>(coupM, coupM.Ing_PaperID, this.Sqlca)) 
                {
                    this.LastError = this.Sqlca.LastError;
                    goto updateerr;
                }
            }

            VipCardInfoM CardInfoM = CardInfoD.GetM<VipCardInfoM>(m.Ing_Fk_VipCardID,this.Sqlca);
            ////如果是首住优惠的订单,重置为空
            //if (CardInfoM != null && CardInfoM.Ing_FirstMaster.HasValue && m.Ing_Pk_MasterID == CardInfoM.Ing_FirstMaster.Value) 
            //{
            //    CardInfoM.Ing_FirstMaster = 0;
            //    if (!CardInfoD.UpdateRecord<VipCardInfoM>(CardInfoM, CardInfoM.Ing_Pk_VipCardId, this.Sqlca)) 
            //    {
            //        this.LastError = this.Sqlca.LastError;
            //        goto updateerr;
            //    }
            //}

            decimal TotalCharge = 0;//已使用储值金额
            decimal WalletCharge = 0;//微信钱包

            foreach (AccM m10 in listacc)
            {
                if (string.IsNullOrEmpty(m10.str_PcCode))
                {
                    continue;
                }
                ///把此条账务置无效
                m10.Ing_sta = 0;
                if (!acD.UpdateRecord<AccM>(m10, m10.Ing_Acc_Id, this.Sqlca))
                {
                    this.LastError = "L置原有账务为无效的时候出错";
                    goto updateerr;
                }

                //如果有储值支付，就加进去
                if (!string.IsNullOrEmpty(m10.str_PcCode) && m10.str_PcCode.Equals("9981")) 
                {
                    TotalCharge += m10.dec_Credit ?? 0;
                }

                if (!string.IsNullOrEmpty(m10.str_PcCode) && (m10.str_PcCode.Equals("9906") || m10.str_PcCode.Trim().Equals("9905")))
                {
                    WalletCharge += m10.dec_Credit ?? 0;
                }
                LogHelper.LogInfo(string.Format("sue微信支付返回,储值金额:{0},微信金额:{1},账务金额{2},账务id:{3},主单id:{4},pccode:{5},会员卡id:{6}"
                                            , TotalCharge, WalletCharge, m10.dec_Credit ?? 0, m10.Ing_Acc_Id, m10.Ing_Fk_MasterID, m10.str_PcCode, CardInfoM.Ing_Pk_VipCardId));

                ///插入一条负的账务
                AccM m3 = new AccM();
                if (func.CopyData(m10, m3) == 0)
                {
                    this.LastError = "L复制账务出错";
                    goto updateerr;
                }
                m3.Ing_Acc_Id = 0;
                m3.dec_TotalCharge = -m10.dec_Credit;
                m3.str_desc = string.Format("{0}--微信端取消", m3.str_desc);
                if (!acD.InsertAcct(m3, 0, this.Sqlca))
                {
                    this.LastError = "L插入取消账务出错";
                    goto updateerr;
                }

                ///如果不是储值支付 或者不是微信支付的， 直接跳过
                if (!(m10.str_PcCode.Trim().Equals("9981") || m10.str_PcCode.Trim().Equals("9905") || m10.str_PcCode.Trim().Equals("9906")))
                {
                    continue;
                }

                if (!m.Ing_Fk_VipCardID.HasValue)
                {
                    continue;
                }

                if (m.Ing_Fk_VipCardID.Value == 0)
                {
                    continue;
                }

                if (!m10.dec_Credit.HasValue)
                {
                    continue;
                }

                if (m10.dec_Credit.Value == 0)
                {
                    continue;
                }

             
                //微信预订储值支付---取消
                ParaForVipCardChargeM model1 = new ParaForVipCardChargeM();
                model1.Ing_Pk_VipCardID = m.Ing_Fk_VipCardID ?? 0;
                model1.Ing_Fk_MasterID = model.id;
                model1.chargemon = m10.dec_Credit.Value;
                model1.chargeType = 7;
                if (m10.str_PcCode.Trim().Equals("9981"))
                {
                    model1.Reamrk = "微信预订储值支付--返回";
                    if (!CardInfoD.VipCardChargeExec(model1, this.Sqlca))
                    {
                        this.LastError = "L储值支付返冲失败";
                        goto updateerr;
                    }
                }
                else
                {
                    model1.Reamrk = "微信预订微信支付--返回";
                    WechatWalletM WalletM = new WechatWalletM
                    {
                        Ing_Fk_MasterId=m.Ing_Pk_MasterID,
                        Ing_Fk_VipcardId=m.Ing_Fk_VipCardID??0,
                        str_Memo = model1.Reamrk,
                        str_Creator="Wechat",
                        dt_Create=DateTime.Now,
                        dec_Price = m10.dec_Credit??0
                       
                    };
                    if (!WalletD.UpdateRecord<WechatWalletM>(WalletM, WalletM.Ing_PKID, this.Sqlca)) 
                    {
                        this.LastError = "L微信支付返冲失败";
                        goto updateerr;
                    } 
                }




                ///如果是微信支付，把对应的支付记录的状态改成 2
                if (m10.str_PcCode.Trim().Equals("9905"))
                {
                    strSql = "UPDATE dbo.T_WxPayResult SET Ing_Sta=2 WHERE Ing_type=0 AND Ing_pkid={0} AND Ing_Sta=1";
                    strSql = string.Format(strSql, model.id);
                    rev = this.Sqlca.ExecuteNonQuery(strSql);
                    if (!rev)
                    {
                        this.LastError = this.Sqlca.LastError;
                        goto updateerr;
                    }
                }
            }
 
            if (TotalCharge > 0||WalletCharge>0) //扣减已使用的储值金额/微信钱包
            {
                strSql = "update T_VipCard_Info set dec_TotalSurplusMoney=isnull(dec_TotalSurplusMoney,0)+{0},dec_WechatPrice=isnull(dec_WechatPrice,0)+{1} where Ing_Pk_VipCardId={2}";
                strSql = string.Format(strSql, TotalCharge,WalletCharge, m.Ing_Fk_VipCardID ?? 0);
                rev = this.Sqlca.ExecuteNonQuery(strSql);
                if (!rev)
                {
                    this.LastError = this.Sqlca.LastError;
                    goto updateerr;
                }
       
            }

            ///修改所有账务状态为无效
            strSql = "UPDATE dbo.T_Acc SET Ing_sta=0 WHERE Ing_Fk_MasterID={0}";
            strSql = string.Format(strSql, model.id);
            rev = this.Sqlca.ExecuteNonQuery(strSql);
            if (!rev)
            {
                this.LastError = this.Sqlca.LastError;
                goto updateerr;
            }


            this.Sqlca.CommitTransaction();
            this.Sqlca.Close();

            WeChatCancelOrderM m1 = new WeChatCancelOrderM();
            m1.token = model.token;
            m1.Openid = model.openid;
            if (m.dt_ArrDate.HasValue)
            {
                m1.arriveDate = m.dt_ArrDate.Value.ToString("yyyy-MM-dd HH:mm");
            }
            if (m.dt_DepDate.HasValue)
            {
                m1.departureDate = m.dt_DepDate.Value.ToString("yyyy-MM-dd HH:mm");
            }
            if (m.dec_ActualRate.HasValue)
            {
                m1.pay = m.dec_ActualRate.Value.ToString("F0");
            }
            m1.remark = "欢迎你再次预订本酒店";

            StoreInfoD infoD = new StoreInfoD();
            StoreInfoM infoM = infoD.GetM<StoreInfoM>(m.Ing_StoreID ?? 0);
            if (infoM != null)
            {
                m1.hotelName = infoM.str_StoreFullName;
            }
            WeChatD weD = new WeChatD();
            weD.OrderCancel(m1);
            return true;

        updateerr:
            this.Sqlca.RollbackTransaction();
            this.Sqlca.Close();
            return false;
        }


        /// <summary>
        /// 检查取消  订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateX(int MasterID)
        {
            if (MasterID == 0)
            {
                this.LastError = "L请选择主单";
                return false;
            }

            //string strSql = "SELECT isnull(SUM(ISNULL(a.dec_Credit,0)),0) balance FROM T_Acc a where a.Ing_Fk_MasterID={0} and a.Ing_sta=1";
            //strSql = string.Format(strSql, MasterID);
            //if (this.Sqlca.GetDecimal(strSql) > 0)
            //{
            //    this.LastError = "L您取消的订单存在账务,请先处理好账务再取消!";
            //    return false;
            //}


            return true;
        }

        #endregion





        /// <summary>
        /// 得到默认房价码
        /// </summary>
        /// <param name="time"></param>
        /// <param name="lngvipcardid"></param>
        /// <returns></returns>
        public RoomRateDefaultM GetRoomRateDefault(int Ing_StoreID, DateTime time, int lngvipcardid)
        {
            string strSql = "EXEC U_Get_RoomRate_Default {0},'{1}',{2}";
            strSql = string.Format(strSql, Ing_StoreID, time.ToString("yyyy-MM-dd"), lngvipcardid);

            return this.GetQueryM<RoomRateDefaultM>(strSql).FirstOrDefault();
        }


        /// <summary>
        /// 获取房价
        /// </summary>
        /// <param name="time"></param>
        /// <param name="lngvipcardid"></param>
        /// <returns></returns>
        public RoomRateM GetRoomRate(int Ing_StoreID, DateTime time, string roomtype, string roomrate, int lngvipcardid)
        {
            string strSql = "EXEC U_Get_RoomRate {0},'{1}','{2}','{3}',{4}";
            strSql = string.Format(strSql, Ing_StoreID, time.ToString("yyyy-MM-dd"), roomtype, roomrate, lngvipcardid);

            return this.GetQueryM<RoomRateM>(strSql).FirstOrDefault();
        }


        /// <summary>
        /// 散客预订里的可用房，最大，最小房数
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public List<RoomCanUseM> GetRoomCanUse(int Ing_StoreID, DateTime date1, DateTime date2, string typecode)
        {
            if ((date1.Date - date2.Date).Days != 0) 
            {
                date2 = date2.AddDays(-1);
            }
            string strSql = "EXEC U_Get_Room_CanUse @storeid ,@bdate, @edate ,@typecode";

            //this.Sqlca.AddParameter("@channel", "WEC");
            this.Sqlca.AddParameter("@storeid", Ing_StoreID);
            this.Sqlca.AddParameter("@bdate", date1);
            this.Sqlca.AddParameter("@edate", date2);
            this.Sqlca.AddParameter("@typecode", typecode);

            List<RoomCanUseM> list = this.GetQueryM<RoomCanUseM>(strSql);

            this.Sqlca.ClearParameter();
            return list;
        }


        #region 保存预订
        /// <summary>
        /// 保存预订
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveOrder(WriteOrderM model)
        {
            if (model == null)
            {
                this.LastError = "L系统错误，请稍后重试";
                return 0;
            }

            VipCardInfoD cardinfoD = new VipCardInfoD();
            VipCardInfoM cardinfoM = new VipCardInfoM();
            cardinfoM = cardinfoD.GetM<VipCardInfoM>(model.lngvipcardid);

            if (cardinfoM == null)
            {
                this.LastError = "L会员信息出错";
                return 0;
            }

            if (model.HourID == 0)
            {
                //if (model.dec_FirstLivePrice > 0)
                //{
                //    if (cardinfoM.Ing_FirstMaster.HasValue && cardinfoM.Ing_FirstMaster.Value > 0)
                //    {
                //        this.LastError = "L你已经使用过首住优惠的资格";
                //        return 0;
                //    }
                //}
            }




            VipInfoD infoD = new VipInfoD();
            VipInfoM infoM = new VipInfoM();
            infoM = infoD.GetM<VipInfoM>(cardinfoM.Ing_Fk_VipID);

            if (infoM == null || !infoM.Ing_Fk_CustID.HasValue)
            {
                this.LastError = "L会员信息出错";
                return 0;
            }

            CustD cusD = new CustD();
            CustM cusM = new CustM();
            cusM = cusD.GetM<CustM>(infoM.Ing_Fk_CustID);

            if (cusM == null)
            {
                this.LastError = "L档案信息出错";
                return 0;
            }

            if (model.dtArr < DateTime.Now.Date)
            {
                this.LastError = "L来期不能早于今天";
                return 0;
            }

            if (model.dtDep > DateTime.Now.Date.AddDays(30))
            {
                this.LastError = "L只能预订30天之内的房间";
                return 0;
            }

            if (model.dtDep < model.dtArr)
            {
                this.LastError = "L离期不能早于来期";
                return 0;
            }


            //FirstCheckConfigD configD = new FirstCheckConfigD();
            //FirstCheckConfigM configM = new FirstCheckConfigM();
            if (model.HourID == 0)
            {                
                if (model.dec_FirstLivePrice > 0)
                {
                    //configM = configD.GetRecordByDate(model.Ing_StoreID, model.dtArr);
                    //if (configM == null)
                    //{
                    //    this.LastError = string.Format("L未配置 {0} 首住优惠的名额", model.dtArr.ToString("yyyy-MM-dd"));
                    //    return 0;
                    //}
                    //if (configM.Ing_TotalNum <= configM.Ing_UserNum)
                    //{
                    //    this.LastError = string.Format("L{0} 首住优惠的名额已经用完", model.dtArr.ToString("yyyy-MM-dd"));
                    //    return 0;
                    //}
                }
            }
            else
            {
               
                if (model.dtArr < DateTime.Now)
                {
                    this.LastError =string.Format("L当前钟点房只有在,{0}点钟前开始预订",model.dtArr.Hour);
                    return 0;
                }
            }



            #region 构造主单

            MasterM masM = new MasterM();

            masM.str_idcls = cusM.str_idcls;
            masM.str_ident = cusM.str_ident;
            masM.str_gender = cusM.str_gender;
            masM.str_street = cusM.str_street;
            masM.str_cusname = model.str_CusName;
            masM.str_mobile = model.str_mobile;


            masM.str_RoomType = model.RoomTypeCode;
            if (model.HourID == 0)
            {
                masM.str_Sta = "R";
            }
            else
            {
                masM.str_Sta = "X";
            }

            masM.Ing_FK_CustID = cusM.Ing_Pk_CustID;
            masM.Ing_StoreID = model.Ing_StoreID;
            masM.Ing_Fk_VipCardID = cardinfoM.Ing_Pk_VipCardId;
            masM.str_VipCard = cardinfoM.str_VipCard;
            masM.Ing_Fk_VipID = infoM.Ing_Pk_VipID;
            masM.dt_OperatDate = DateTime.Now;
            masM.dt_restime = DateTime.Now;
            masM.str_phone = cusM.str_phone;

            DateTime dtres = DateTime.Now;
            DateTime.TryParse(string.Format("{0} 19:00:00", model.dtArr.ToString("yyyy-MM-dd")), out dtres);
            masM.dt_ResDep = dtres;


            //masM.dt_ArrDate = model.dt_ArrDate;
            //masM.dt_DepDate = model.dt_DepDate;
            if (model.HourID == 0)
            {
                DateTime.TryParse(string.Format("{0} {1}:00:00", model.dtArr.ToString("yyyy-MM-dd"), model.Front6Hour == 1 ? "06" : "14"), out dtres);
            }
            else
            {
                dtres = model.dtArr;
            }
            masM.dt_ArrDate = dtres;

            if (model.HourID == 0)
            {
                DateTime.TryParse(string.Format("{0} 13:00:00", model.dtDep.ToString("yyyy-MM-dd")), out dtres);
            }
            else
            {
                dtres = model.dtDep;
            }
            masM.dt_DepDate = dtres;



            masM.str_RateID = model.VipRateCode;
            masM.Ing_IsHour = model.HourID;
            masM.dec_ActualRate = model.dec_ActualRate;
            if (masM.Ing_IsHour.HasValue && masM.Ing_IsHour.Value > 0)
            {
                masM.dec_ActualRate = model.totalprice;
            }

            masM.dec_discount = 1;
         



            //masM.str_Channel = "WEC";
            masM.str_memo = "";
            masM.str_Cusclass = "F";
            masM.Ing_RoomNum = 1;
            masM.Ing_GstNum = 1;
            masM.str_ApplName = cusM.str_CusName;

            if (string.IsNullOrEmpty(masM.str_ResType)) masM.str_ResType = "CR";

            masM.str_Channel = "WEC";
            masM.str_Markets = "M1";
            if (string.IsNullOrEmpty(masM.str_Markets))
            {
                masM.str_Markets = "OTH";
            }
            masM.str_resby = "WeChat";
            masM.dt_restime = DateTime.Now;

            masM.Ing_breakfast = 0;

            if (model.HourID == 0)
            {
                masM.str_InterType = "ALL";
            }
            else
            {
                masM.str_InterType = "Hour";
            }
            masM.dec_StandardRate = model.totalprice;
           
            #endregion


            if (!this.Sqlca.BeginTransaction())
            {
                goto updateerr;
            }

            masM.str_ResNo = this.GetResNo(masM.Ing_StoreID.Value, this.Sqlca);
            masM.str_Pk_Accnt = this.GetAccnt(masM.str_Cusclass, masM.Ing_StoreID.Value, this.Sqlca);

            if (string.IsNullOrEmpty(masM.str_ResNo))
            {
                this.LastError = "L生成预订号出错，请重新再试";
                goto updateerr;
            }

            if (string.IsNullOrEmpty(masM.str_Pk_Accnt))
            {
                this.LastError = "L生成订单号出错，请重新再试";
                goto updateerr;
            }

            int masID = 0;
            if (!this.UpdateRecord<MasterM>(masM, 0, this.Sqlca))
            {
                this.LastError = "L预订失败";
                goto updateerr;
            }

            masID = this.lngKeyID;

            if (model.HourID == 0)
            {
                /////首住优惠的
                //if (model.dec_FirstLivePrice > 0)
                //{
                //    cardinfoM.Ing_FirstMaster = masID;
                //    if (!cardinfoD.UpdateRecord<VipCardInfoM>(cardinfoM, cardinfoM.Ing_Pk_VipCardId, this.Sqlca))
                //    {
                //        this.LastError = "L更新首住优惠标识出错";
                //        goto updateerr;
                //    }

                //    //configM.Ing_UserNum = configM.Ing_UserNum + 1;
                //    //if (!configD.UpdateRecord<FirstCheckConfigM>(configM, configM.Ing_ID, this.Sqlca))
                //    //{
                //    //    this.LastError = "L更新首住优惠数量出错";
                //    //    goto updateerr;
                //    //}
                //}
            }

            //添加操作日志
            MasterLogM masLogM = new MasterLogM();
            MasterLogD masLogD = new MasterLogD();
            masLogM.Ing_StoreID = masM.Ing_StoreID.Value;
            masLogM.dt_LogDate = DateTime.Now;
            masLogM.str_LogThread = "新增";
            masLogM.str_LogLevel = "状态:R";
            masLogM.str_Logger = "wec";
            masLogM.str_FunC =string.Format("微信预订 {0}",model.HourID==0?"全天房":"钟点房");
            masLogM.str_LogException = "成功";
            masLogM.Ing_Fk_MasterID = masM.Ing_Pk_MasterID;
            masLogM.str_Pk_Accnt = masM.str_parentAccnt;
            masLogM.str_CusName = masM.str_cusname;
            masLogM.str_LogMessage = string.Format("会员号为:{0}微信订房", cardinfoM.str_VipCard);
            if (!masLogD.UpdateRecord<MasterLogM>(masLogM, 0, this.Sqlca))
            {
                this.LastError = "L保存日志失败";
                goto updateerr;
            }

            this.Sqlca.CommitTransaction();
            this.Sqlca.Close();


            #region 推送预订成功消息
            ///微信推送
            WeChatOrderSuccessM m1 = new WeChatOrderSuccessM();
            m1.storeid = model.Ing_StoreID;
            m1.first = string.Format("您好，您已成功预订酒店{0}！", model.HourID > 0 ? "钟点房" : "");

            StoreInfoD dal1 = new StoreInfoD();
            StoreInfoM model1 = dal1.GetM<StoreInfoM>(model.Ing_StoreID);
            if (model1 != null)
            {
                m1.first = string.Format("您好，您已成功预订{0}酒店 {1}！", model1.str_StoreName, model.HourID > 0 ? "钟点房" : "");
            }
            m1.Openid = model.openid;
            m1.token = model.token;
            m1.order = masM.str_Pk_Accnt;
            m1.Name = masM.str_cusname;
            if (masM.dt_ArrDate.HasValue)
            {
                m1.datein = masM.dt_ArrDate.Value.ToString("yyyy-MM-dd HH:mm");
            }
            if (masM.dt_DepDate.HasValue)
            {
                m1.dateout = masM.dt_DepDate.Value.ToString("yyyy-MM-dd HH:mm");
            }
            if (masM.Ing_RoomNum.HasValue)
            {
                m1.number = masM.Ing_RoomNum.Value.ToString();
            }
            m1.roomtype = masM.str_RoomType;
            RoomTypeD typeD = new RoomTypeD();
            RoomTypeM typeM = typeD.GetRoomType(masM.Ing_StoreID ?? 0, masM.str_RoomType);
            if (typeM != null)
            {
                m1.roomtype = typeM.str_TypeName;
            }
            m1.pay = masM.dec_ActualRate.Value.ToString("F2");
            m1.remark = string.Format("如非本人，请联系管理员;如需取消预订，请在18点前;");
            WeChatD weD = new WeChatD();
            weD.OrderSuccess(m1);
            #endregion


            #region 储值会员当天三间或者三间以上订单
            //int num = GetOrderNum(cardinfoM.Ing_Pk_VipCardId, masM.dt_ArrDate ?? DateTime.Now);
            //if (num >= 3)
            //{
            //    WeChatChargeMon weM = new WeChatChargeMon();
            //    weM.first = string.Format("储值会员当天三间或者三间以上订单");
            //    weM.keyword1 = "警告";
            //    weM.keyword2 = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //    weM.remark = string.Format("会员卡号:{0}，会员姓名:{1}，今日已在分店支付{2}间，当前操作员:微信端预订，请留意", cardinfoM.str_VipCard, cusM.str_CusName, num);
            //    weM.Ing_StoreID = masM.Ing_StoreID ?? 0;
            //    weD.VipOrderAll(weM);
            //}
            #endregion

            return masID;

        updateerr:
            if (!string.IsNullOrEmpty(this.LastError))
            {
                this.LastError = this.Sqlca.LastError;
            }
            this.Sqlca.RollbackTransaction();
            this.Sqlca.Close();

            return 0;
        }

        /// <summary>
        /// 根据会员卡id和日期查出一天的订单数
        /// </summary>
        /// <param name="vipcardid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int GetOrderNum(int vipcardid, DateTime date)
        {
            string strSql = @"  select ISNULL(COUNT(Ing_Pk_MasterID),0)  from T_Master
                               where (str_Sta='I' OR str_Sta='R') and Ing_Fk_VipCardID={0}
                               and DATEDIFF(DAY,dt_arrdate,'{1}')=0";
            strSql = string.Format(strSql, vipcardid, date.ToString("yyyy-MM-dd"));
            return this.Sqlca.GetInt32(strSql);
        }


        /// <summary>
        /// 得到订单号
        /// </summary>
        /// <param name="DataTrans"></param>
        /// <returns></returns>
        public string GetResNo(int Ing_StoreID, DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            string strSql = "SELECT [dbo].[mfn_GetResNo](@Ing_StoreID)";

            this.Sqlca.AddParameter("@Ing_StoreID", Ing_StoreID);

            string rev = this.Sqlca.GetString(strSql);
            this.Sqlca.ClearParameter();
            return rev;
        }

        /// <summary>
        /// 得到帐号
        /// </summary>
        /// <param name="Cusclass"></param>
        /// <param name="DataTrans"></param>
        /// <returns></returns>
        public string GetAccnt(string Cusclass, int Ing_StoreID, DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            string strSql = "SELECT [dbo].[mfn_Pk_Accnt](@Ing_StoreID,@Cusclass)";

            this.Sqlca.AddParameter("@Ing_StoreID", Ing_StoreID);
            this.Sqlca.AddParameter("@Cusclass", Cusclass);

            string rev = this.Sqlca.GetString(strSql);
            this.Sqlca.ClearParameter();
            return rev;
        }

        #endregion


        /// <summary>
        /// 微信支付插入账务
        /// </summary>
        /// <param name="Ing_Fk_MasterID"></param>
        /// <param name="dec_money"></param>
        /// <param name="BillType"></param>
        /// <param name="ResValue"></param>
        /// <param name="DataTrans"></param>
        /// <returns></returns>
        public bool WechatPayAddFeeExec(int Ing_Fk_MasterID, decimal dec_money, int BillType, out int ResValue, DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            ResValue = 0;
            string strSql = "EXEC U_Wechat_Pay_AddFee @MasterID,@dec_money,@BillType,@ResultV  output";

            this.Sqlca.AddParameter("@MasterID", Ing_Fk_MasterID);
            this.Sqlca.AddParameter("@dec_money", dec_money);
            this.Sqlca.AddParameter("@BillType", BillType);
            this.Sqlca.AddParameter("@ResultV", ResValue, ParameterDirection.Output);

            bool rev = this.Sqlca.ExecuteNonQuery(strSql);
            int ResultV = this.Sqlca.GetParameterIntValue("@ResultV");

            this.Sqlca.ClearParameter();
            return rev;
        }


        /// <summary>
        /// 根据openid，获取操作员对应的操作员ID
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public int GetSaleIDbyopenid(string openid)
        {
            string strSql = @"SELECT b.Ing_Pk_SaleID FROM dbo.T_Users a INNER JOIN dbo.T_SaleID b ON a.Ing_pk_UID=b.Ing_Pk_UID
                            WHERE ISNULL(b.Ing_StoreID,0)>0 AND ISNULL(a.str_openid,'')=@str_openid AND ISNULL(a.str_openid,'')<>''";

            this.Sqlca.AddParameter("@str_openid", openid);

            int rev = this.Sqlca.GetInt32(strSql);

            this.Sqlca.ClearParameter();
            return rev;
        }


        #region  续住
        /// <summary>
        /// 续住操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ContinueInter(ContinueInterDisplay model)
        {
            if (model == null)
            {
                this.LastError = "L参数为空，不能做此操作";
                return false;
            }

            if (model.Ing_ContinueDays < 1 || model.Ing_ContinueDays > 3)
            {
                this.LastError = "L只能续住1至3天";
                return false;
            }

            ///先输出主单信息
            MasterM mod1 = new MasterM();
            mod1 = this.GetM<MasterM>(model.Ing_MasterID);
            if (mod1 == null)
            {
                this.LastError = "L此主单不存在，不允许此操作";
                return false;
            }

            if (!mod1.Ing_Fk_VipCardID.HasValue)
            {
                this.LastError = "L必须是本人入住的才能进行此操作";
                return false;
            }


            if (string.IsNullOrEmpty(mod1.str_Sta))
            {
                this.LastError = "L此主单不是在住状态，不允许此操作";
                return false;
            }

            if (!mod1.str_Sta.ToUpper().Trim().Equals("I"))
            {
                this.LastError = "L此主单不是在住状态，不允许此操作";
                return false;
            }

            if (!mod1.Ing_StoreID.HasValue)
            {
                this.LastError = "L此主单不存在门店id，不允许此操作";
                return false;
            }

            if (!mod1.dt_ArrDate.HasValue)
            {
                this.LastError = "L此主单不存在来期，不允许此操作";
                return false;
            }


            if (!mod1.dt_DepDate.HasValue)
            {
                this.LastError = "L此主单不存在离期，不允许此操作";
                return false;
            }

            

            ContinueInterM mod2 = new ContinueInterM();
            mod2.Ing_days = model.Ing_ContinueDays;
            mod2.Ing_MasterID = model.Ing_MasterID;
            mod2.Ing_StoreID = mod1.Ing_StoreID.Value;
            mod2.dt_Odepdate = mod1.dt_DepDate.Value;
            mod1.dt_DepDate = mod1.dt_DepDate.Value.AddDays(model.Ing_ContinueDays);
            mod2.dt_depdate = mod1.dt_DepDate.Value;

            //根据房型
            mod2.dec_price = 0; //model.dec_price;
            for (int i = 0; i < model.Ing_ContinueDays; i++)
            {
                RoomRateM rateM = this.GetRoomRate(mod1.Ing_StoreID ?? 0, DateTime.Now.AddDays(i), mod1.str_RoomType, mod1.str_RateID, mod1.Ing_Fk_VipCardID??0);
                mod2.dec_price += rateM.price;
            }

            mod2.dt_Create = DateTime.Now;
            mod2.Ing_type = 0;

            ContinueInterD conD = new ContinueInterD();

            if (!this.Sqlca.BeginTransaction())
            {
                this.LastError = this.Sqlca.LastError;
                goto updateerr;
            }

            if (!this.UpdateRecord<MasterM>(mod1, mod1.Ing_Pk_MasterID, this.Sqlca))
            {
                this.LastError = "L更新主单出错";
                goto updateerr;
            }

            if (!conD.UpdateRecord<ContinueInterM>(mod2, mod2.Ing_pkid, this.Sqlca))
            {
                this.LastError = "L系统错误，请稍后再试";
                goto updateerr;
            }


            this.Sqlca.CommitTransaction();
            this.Sqlca.Close();
            return true;

        updateerr:
            this.Sqlca.RollbackTransaction();
            this.Sqlca.Close();
            return false;
        }



        /// <summary>
        /// 续住操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveTuiFang(int Ing_MasterID)
        {
            ///先输出主单信息
            MasterM mod1 = new MasterM();
            mod1 = this.GetM<MasterM>(Ing_MasterID);
            if (mod1 == null)
            {
                this.LastError = "L此主单不存在，不允许此操作";
                return false;
            }

            if (!mod1.Ing_Fk_VipCardID.HasValue)
            {
                this.LastError = "L必须是本人入住的才能进行此操作";
                return false;
            }


            if (string.IsNullOrEmpty(mod1.str_Sta))
            {
                this.LastError = "L此主单不是在住状态，不允许此操作";
                return false;
            }

            if (!mod1.str_Sta.ToUpper().Trim().Equals("I"))
            {
                this.LastError = "L此主单不是在住状态，不允许此操作";
                return false;
            }

            if (!mod1.Ing_StoreID.HasValue)
            {
                this.LastError = "L此主单不存在门店id，不允许此操作";
                return false;
            }

            if (!mod1.dt_ArrDate.HasValue)
            {
                this.LastError = "L此主单不存在来期，不允许此操作";
                return false;
            }


            if (!mod1.dt_DepDate.HasValue)
            {
                this.LastError = "L此主单不存在离期，不允许此操作";
                return false;
            }

            mod1.str_memo  =mod1.str_memo+" 在微信端做了退房提醒操作";


            ContinueInterD conD = new ContinueInterD();
            ContinueInterM mod2 = new ContinueInterM();
            mod2 = conD.GetRecord(Ing_MasterID, 1);
            if (mod2 != null)
            {
                this.LastError = "L不允许重复操作";
                return false;
            }
            mod2 = new ContinueInterM();
            mod2.Ing_MasterID = Ing_MasterID;
            mod2.Ing_StoreID = mod1.Ing_StoreID.Value;
            mod2.dt_Create = DateTime.Now;
            mod2.Ing_type = 1;

            

            if (!this.Sqlca.BeginTransaction())
            {
                this.LastError = this.Sqlca.LastError;
                goto updateerr;
            }

            if (!this.UpdateRecord<MasterM>(mod1, mod1.Ing_Pk_MasterID, this.Sqlca))
            {
                this.LastError = "L更新主单出错";
                goto updateerr;
            }

            if (!conD.UpdateRecord<ContinueInterM>(mod2, mod2.Ing_pkid, this.Sqlca))
            {
                this.LastError = "L系统错误，请稍后再试";
                goto updateerr;
            }


            this.Sqlca.CommitTransaction();
            this.Sqlca.Close();
            return true;

        updateerr:
            this.Sqlca.RollbackTransaction();
            this.Sqlca.Close();
            return false;
        }

        #endregion

        /// <summary>
        /// 续住获取所需房价
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public decimal GetRoomPriceById(ContinueInterDisplay model) 
        {
            MasterM mod1 = this.GetM<MasterM>(model.Ing_MasterID);
            if (mod1 == null) 
            {
                return 0;
            }
            decimal price = 0;
            for (int i = 0; i < model.Ing_ContinueDays; i++)
            {
                RoomRateM rateM = this.GetRoomRate(mod1.Ing_StoreID ?? 0, DateTime.Now.AddDays(i), mod1.str_RoomType, mod1.str_RateID, mod1.Ing_Fk_VipCardID ?? 0);
                price+= rateM.price;
            }
            return price;
        }
    }
}