using Bee.Web;
using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CouponDetailsD:BaseTable
    {
        public CouponDetailsD()
            : base("T_CouponDetails", "Ing_PaperID")
        { }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(CouponDetailsM model)
        {            
            return true;
        }

        /// <summary>
        /// 保存 优惠券表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(CouponDetailsM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<CouponDetailsM>(model, model.Ing_PaperID);
            model.Ing_PaperID = this.lngKeyID;
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
        /// 获取有效的优惠券数量
        /// </summary>
        /// <param name="vipcardid"></param>
        /// <returns></returns>
        public int GetUseFulCount(int vipcardid)
        {
            string strSql = "SELECT COUNT(*) FROM dbo.T_CouponDetails a WHERE a.Ing_VipcardInfoID={0} AND ISNULL(a.Ing_Sta,0)=1 AND DATEDIFF(DAY,GETDATE(),ISNULL(a.dt_EndTime,GETDATE()))>=0";
            strSql = string.Format(strSql,vipcardid);

            return this.Sqlca.GetInt32(strSql);
        }

        /// <summary>
        /// 根据类型返回优惠券
        /// </summary>
        /// <param name="vipcardid">vipcardid</param>
        /// <param name="type">0:无效
        /// 1：有效   2：过期</param>
        /// <returns></returns>
        public List<CouponDetailsM> GetListbytype(int vipcardid,int type)
        {
            if (type < 0 || type > 2) type = 1;//and  (isnull(b.Ing_type,0)=0 or isnull(b.Ing_type,0)=1)  and   isnull(b.Ing_type,0)=0  and   isnull(b.Ing_type,0)=0
            string strSql = "";
            if (type == 1)
            {
                strSql = @"SELECT a.* FROM dbo.T_CouponDetails a
                          left JOIN T_CouponType b on a.Ing_CouponTypeID=b.Ing_CouponTypeID
                          WHERE a.Ing_VipcardInfoID={0} AND ISNULL(a.Ing_Sta,0)=1 AND DATEDIFF(DAY,GETDATE(),ISNULL(a.dt_EndTime,GETDATE()))>=0
                          
                           AND  DATEDIFF(DAY,GETDATE(),ISNULL(a.dt_StartTime,GETDATE()))<=0  ORDER BY a.Ing_PaperID desc";
            }
            else if (type == 2)
            {
                strSql = @"SELECT * FROM dbo.T_CouponDetails a 
                             left JOIN T_CouponType b on a.Ing_CouponTypeID=b.Ing_CouponTypeID
                             WHERE a.Ing_VipcardInfoID={0}    
                             AND ISNULL(a.Ing_Sta,0)=1 AND DATEDIFF(DAY,GETDATE(),ISNULL(a.dt_EndTime,GETDATE()))<0
                            ORDER BY a.Ing_PaperID desc";
            }
            else
            {
                strSql = @"SELECT * FROM dbo.T_CouponDetails a
                          left JOIN T_CouponType b on a.Ing_CouponTypeID=b.Ing_CouponTypeID
                         WHERE a.Ing_VipcardInfoID={0} AND ISNULL(a. Ing_IsUse,0)=1  
                            ORDER BY a.Ing_PaperID desc";
            }
            strSql = string.Format(strSql,vipcardid);

            return this.GetQueryM<CouponDetailsM>(strSql);
        }

        /// <summary>
        /// 获取最大的
        /// </summary>
        /// <returns></returns>
        public int GetMaxNum()
        {
            string strSql = "SELECT MAX(str_PaperName) FROM T_CouponDetails";
            return this.Sqlca.GetInt32(strSql);
        }


        /// <summary>
        /// 根据主单id，查找有效优惠券列表
        /// </summary>0普通优惠券,1房价变价优惠券
        /// <param name="MasterID"></param>
        /// <returns></returns>
        public List<ResultCouponM> GetCouponByMasterID(int MasterID,int type=0)
        {
            MasterD masD = new MasterD();
            MasterM masM = new MasterM();
            masM = masD.GetM<MasterM>(MasterID);

            if (masM == null)
            {
                this.LastError = "L主单异常";
                return null;
            }

            if (!masM.Ing_Fk_VipCardID.HasValue)
            {
                this.LastError = "L该主单不是会员入住，不能使用抵扣券";
                return null;
            }

            if (masM.Ing_Fk_VipCardID.Value == 0)
            {
                this.LastError = "L该主单不是会员入住，不能使用抵扣券";
                return null;
            }

       string where=" and 1=1 ";
       string  strSql = @"select '{0}' as str_RateID,isnull(d.str_InterType,'ALL') as str_InterType, b.str_PaperName,b.str_SendType,
                          a.Ing_PaperID,a.str_PaperCode,a.dec_Amount,a.dt_EndTime,a.Ing_LastNum,a.dt_StartTime
                        FROM T_CouponDetails a
                        INNER JOIN T_CouponType b on a.Ing_CouponTypeID=b.Ing_CouponTypeID
                        INNER JOIN T_CouponRange c ON b.Ing_CouponTypeID=c.Ing_CouponTypeID
                    left join T_Master d on d.Ing_Pk_MasterID={5}
                        WHERE b.Ing_type={4} AND a.Ing_VipcardInfoID={1} and a.Ing_Sta=1 AND a.Ing_LastNum>0
                        AND c.Ing_StoreID={2} AND (','+c.str_RoomCode+',' like '%,{6},%' or ','+c.str_RoomCode+',' like '%,0,%')
                        AND isnull(a.dec_Amount,0)<>0 AND isnull(a.dec_Amount,0)<{3}";
       strSql = string.Format(strSql, masM.str_RateID, masM.Ing_Fk_VipCardID ?? -1, masM.Ing_StoreID ?? -1, masM.dec_ActualRate ?? 0, type, masM.Ing_Pk_MasterID, masM.str_RoomType);
//            string strSql = @"SELECT '{1}' as str_RateID,isnull(c.str_InterType,'ALL') as str_InterType, a.str_PaperName,a.str_SendType,b.Ing_PaperID
//                              ,b.str_PaperCode,b.dec_Amount,b.dt_EndTime,b.Ing_LastNum
//                                     FROM T_CouponType a INNER JOIN T_CouponDetails b ON a.Ing_CouponTypeID=b.Ing_CouponTypeID
//                                    left join T_Master c on c.Ing_Pk_MasterID={2}
//                                    WHERE b.Ing_Sta=1 AND b.Ing_LastNum>0 AND DATEDIFF(DAY,ISNULL(b.dt_StartTime,GETDATE()),GETDATE())>=0
//                                    and DATEDIFF(DAY,GETDATE(),ISNULL(b.dt_EndTime,GETDATE()))>=0 AND b.Ing_VipcardInfoID={0} ";//and a.Ing_type={3}
//            strSql = string.Format(strSql, masM.Ing_Fk_VipCardID ?? 0, masM.str_RateID, MasterID);//,type
            if (type == 0) 
            {
                where = "AND DATEDIFF(DAY,ISNULL(a.dt_StartTime,GETDATE()),GETDATE())>=0  and DATEDIFF(DAY,GETDATE(),ISNULL(a.dt_EndTime,GETDATE()))>=0";
            }

            strSql += where;
            List<ResultCouponM> list = this.GetQueryM<ResultCouponM>(strSql);

            if (list == null || list.Count == 0)
            {
                this.LastError = "L该会员卡没有有效的抵扣券";
                return null;
            }

            return list;
        }

       
        #region 使用抵扣券

        /// <summary>
        /// 抵扣券支付的过程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CouponDetailsUseIn(ParaForCoponPayM model, DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            model.str_Remark = "微信使用抵扣券";
            string strSql = "EXEC U_CouponDetails_UseIn @Ing_StoreID,@str_PagerID,@Ing_MasterID,@str_Remark,@str_Empno,@shift";
            this.Sqlca.AddParameter("@Ing_StoreID", model.Ing_StoreID);
            this.Sqlca.AddParameter("@str_PagerID", model.PagerID);
            this.Sqlca.AddParameter("@Ing_MasterID", model.MasterID);
            this.Sqlca.AddParameter("@str_Remark", model.str_Remark);
            this.Sqlca.AddParameter("@str_Empno", "WeChat");
            this.Sqlca.AddParameter("@shift", "");

            bool rev = this.Sqlca.ExecuteNonQuery(strSql);
            if (!rev)
            {
                this.LastError = this.Sqlca.LastError;

            }
            this.Sqlca.ClearParameter();
            return rev;
        }

        /// <summary>
        /// 抵扣券支付
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CouponPay(ParaForCoponPayM model)
        {
            if (!CheckCouponPay(model))
            {
                return false;
            }

            bool rev = CouponDetailsUseIn(model);
            return rev;
        }


        /// <summary>
        /// 检查是否可以抵扣券支付
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckCouponPay(ParaForCoponPayM model)
        {

            if (model == null)
            {
                this.LastError = "L传入参数有误";
                return false;
            }

            if (model.ListPagerID.Count == 0)
            {
                ///没有选择优惠券，直接返回成功
                return true;
            }

            List<ResultCouponM> list = new List<ResultCouponM>();
            list = GetCouponByMasterID(model.MasterID);

            if (list == null)
            {
                return false;
            }


            foreach (int PagerID in model.ListPagerID)
            {
                ResultCouponM mod = list.Where(x => x.Ing_PaperID == PagerID).FirstOrDefault();
                if (mod == null)
                {
                    this.LastError = "L选择的优惠券有误";
                    return false;
                }
                if (mod.Ing_LastNum <= 0)
                {
                    this.LastError = "L选择的优惠券已用完";
                    return false;
                }
            }
           
            return true;
        }



        #endregion

        /// <summary>
        /// 通过优惠券改变房价
        /// </summary>
        /// <param name="masterid"></param>
        /// <param name="couponid"></param>
        /// <returns></returns>
        public bool CouponPrice(int masterid, int couponid)
        {
            MasterD masD = new MasterD();
            MasterM masM = masD.GetM<MasterM>(masterid);
            if (masM == null)
            {
                this.LastError="L主单不存在";
                return false;
            }
            CouponDetailsD couponD=new CouponDetailsD();
            CouponDetailsM couponM = couponD.GetM<CouponDetailsM>(couponid);
            if (couponM == null) 
            {
                this.LastError = "L优惠券不存在";
                return false;
            }
            if (!this.Sqlca.BeginTransaction())
            {
                this.LastError = this.Sqlca.LastError;
                goto updateerr;
            }
            decimal price=couponM.dec_Amount ?? 0;
         
            masM.str_memo += string.Format("|客人使用了{0}({1}),旧房价({2})=>新房价({3})",couponM.str_PaperName,couponM.Ing_PaperID,masM.dec_ActualRate??0,price);
            masM.dec_ActualRate = price;
            masM.dec_StandardRate = price;
            masM.str_Sta = "X";
            if (!masD.UpdateRecord<MasterM>(masM, masM.Ing_Pk_MasterID, this.Sqlca)) 
            {
                this.LastError = "L主单更改房价失败";
                goto updateerr;
            }
            couponM.Ing_LastNum -= 1;
            couponM.Ing_Sta = 2;
            if (!couponD.UpdateRecord<CouponDetailsM>(couponM, couponM.Ing_PaperID, this.Sqlca))
            {
                this.LastError = "L优惠券使用失败";
                goto updateerr;
            }

            //插入一条优惠券使用记录
            CouponLogD couponLogD = new CouponLogD();
            CouponLogM couponLogM = new CouponLogM {
                Ing_MasterID = masterid,
                Ing_PaperID = couponid,
                Ing_StoreID=masM.Ing_StoreID??0,
                Ing_useSta=2,
                str_PaperCode=couponM.str_PaperCode,
                str_PK_Accnt=masM.str_Pk_Accnt,
                dt_useTime=DateTime.Now
            
            };
            if (!couponLogD.UpdateRecord<CouponLogM>(couponLogM, couponLogM.Ing_LogID, this.Sqlca)) 
            {
                this.LastError = "L优惠券使用失败";
                goto updateerr;
            }

            this.Sqlca.CommitTransaction();
            this.Sqlca.Close();
            return true;
        updateerr:
            this.Sqlca.RollbackTransaction();
            this.Sqlca.Close();
            Public.LogHelper.LogInfo("微信变价出错:"+this.LastError);
            return false;
        }


        /// <summary>
        ///0赠送  生成优惠券（成为会员时根据会员卡类型生成）购买，生成优惠券(会员可以通过现金，和积分购买优惠券)
        /// </summary>
        /// <param name="vipCardId"></param>
        /// <returns></returns>
        public bool CreateCoupponDetail(CreateCoupponM model, DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            string strSql = "EXEC U_CreateCouponDetail @StoreId,@VipCardInfoId,@UserName,@CouponTypeId,@ingmonth,@price,@str_Activity";
            this.Sqlca.AddParameter("@StoreId", 0);
            this.Sqlca.AddParameter("@VipCardInfoId", model.vipCardInfoId);
            this.Sqlca.AddParameter("@UserName", "WeChat");
            this.Sqlca.AddParameter("@CouponTypeId", model.coupontypeId);
            this.Sqlca.AddParameter("@ingmonth", model.ingmonth);
            this.Sqlca.AddParameter("@price", model.price);
            this.Sqlca.AddParameter("@str_Activity", model.str_Activity);
            bool rev = this.Sqlca.ExecuteNonQuery(strSql);
            this.Sqlca.ClearParameter();
            return rev;
        }

        /// <summary>
        /// 判断该主单有没有使用变价优惠券
        /// </summary>
        /// <param name="masterid"></param>
        /// <returns></returns>
        public CouponDetailsM GetCouponDetail(int masterid)
        {
            string strSql = @"SELECT top 1 a.dt_useTime,b.* FROM T_CouponLog a
                                INNER JOIN T_CouponDetails b
                                on a.Ing_PaperID=b.Ing_PaperID
                                INNER JOIN T_CouponType c
                                on b.Ing_CouponTypeID=c.Ing_CouponTypeID
                                WHERE c.Ing_type=1 AND a.Ing_MasterID={0} AND (isnull(b.Ing_LastNum,0)=0 or b.Ing_Sta=2)
                                AND DATEDIFF(DAY,a.dt_useTime,GETDATE())>=0  ORDER BY a.Ing_LogID desc";
            strSql = string.Format(strSql, masterid);
            return this.GetQueryM<CouponDetailsM>(strSql).FirstOrDefault();

        }
    }
}
