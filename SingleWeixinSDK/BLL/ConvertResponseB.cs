using Model;
using Model.ErrorMsg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    static class ConvertResponseB
    {
        public static BaseResponseModel HandResponse(this BaseResponseModel model, String lasterror, string successmessage = "")
        {
            if (string.IsNullOrEmpty(lasterror))
            {
                model.friendlyMessage = successmessage;
                model.message = successmessage;
                return model;
            }
            if (lasterror.StartsWith("L公安上传"))
            {
                model.message = lasterror.Substring(1);
                return model;
            }

            ///现在先把数据库具体错误也弱出来，到时只要把下面这行改成 L  就行了
            if (lasterror.StartsWith("L"))
            {
                model.status = 100001;
                model.message = lasterror.Substring(1);
                model.friendlyMessage = "业务逻辑判断";
                return model;
            }

            int lngerror = 0;
            lngerror = 900100;
            ErrorItem errM = ErrorModel.GetErrorItem(lngerror);
            if (errM != null)
            {
                model.status = errM.errorId;
                model.message = errM.errorMessage;
                model.friendlyMessage = errM.errorFriendlyMessage;
            }

            return model;
        }
    }


    public class ConvertResponseB1
    {
        public ConvertResponseB1() { }


        public BaseResponseModel HandResponse(BaseResponseModel model, String lasterror, string successmessage = "")
        {
            return ConvertResponseB.HandResponse(model, lasterror);
        }
    }
}
