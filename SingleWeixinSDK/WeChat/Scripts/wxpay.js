/// <reference path="layer_mobile/layer.js" />
/// <reference path="layer_mobile/layer.js" />
wx.config({
    debug: true,// 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
    appId:$("#appId").val(),// 必填，公众号的唯一标识
    timestamp:$("#timestamp").val(),// 必填，生成签名的时间戳
    nonceStr:$("#nonceStr").val(),// 必填，生成签名的随机串
    signature:$("#signature").val(),// 必填，签名，
    jsApiList: [ 
    'checkJsApi',
    'onMenuShareTimeline',
    'onMenuShareAppMessage',
    'onMenuShareQQ',
    'onMenuShareWeibo',
    'hideMenuItems',
    'showMenuItems',
    'hideAllNonBaseMenuItem',
    'showAllNonBaseMenuItem',
    'translateVoice',
    'startRecord',
    'stopRecord',
    'onRecordEnd',
    'playVoice',
    'pauseVoice',
    'stopVoice',
    'uploadVoice',
    'downloadVoice',
    'chooseImage',
    'previewImage',
    'uploadImage',
    'downloadImage',
    'getNetworkType',
    'openLocation',
    'getLocation',
    'hideOptionMenu',
    'showOptionMenu',
    'closeWindow',
    'scanQRCode',
    'chooseWXPay',
    'openProductSpecificView',
    'addCard',
    'chooseCard',
    'openCard'
    ] 
});



// 10.1 发起一个支付请求
function choosepay(){
    var version = parseInt($("#userVersion").val());
    //if (version < 0)
    //{
    //    alert("抱歉，必须使用微信客户端打开才能使用微信支付。");
    //    return;
    //}
    //if (version < 5) {
    //    alert("抱歉，您的微信版本不支持微信支付。");
    //    return;
    //}

    // 注意：此 Demo 使用 2.7 版本支付接口实现，建议使用此接口时参考微信支付相关最新文档。
    var body=$("#body").val();  
    var detail=$("#detail").val();
    var attach=$("#attach").val();
    var product_id=$("#product_id").val();
    var goods_tag=$("#goods_tag").val();
    var openid = $("#openid").val();
	var storeid=$("#Ing_StoreID").val();
    $.ajax({
        url:'/wxpay/',
        type: 'POST',
        timeOut:60000,
        data:{
            body:body,
            detail:detail,
            attach:attach,
            total_fee: $("#total_fee").val(),//订单总金额，只能为整数
            trade_type:'JSAPI',
            goods_tag:'',//商品标记，代金券或立减优惠功能的参数
            product_id:product_id,//trade_type=NATIVE，此参数必传。此id为二维码中包含的商品ID，商户自行定义。
            openid:openid,
			storeid:storeid,
            timeStamp: $("#timestamp").val(),
            Ing_type: $("#Ing_type").val(),
            Ing_pkid: $("#Ing_pkid").val(),
            Ing_pkid1: $("#pkid1").val(),
            dec_ChargeMon: $("#hidmoney").val(),
            dec_Wechat: $("#hidwxqb").val(),
            coupondetailid: $("#coupondetailid").val(),
        nonceStr:$("#nonceStr").val()
        },
        success: function (res) {
            removeLoading();
            if (res.return_code == "SUCCESS") {
           
                var prepay_id=res.prepay_id;
                var paySign = res.paysign;
                alert("支付成功");
                wx.chooseWXPay({
                    appId: $("#appId").val(),// 必填，公众号的唯一标识
                    timestamp:$("#timestamp").val(),
                    nonceStr:$("#nonceStr").val(),
                    package: 'prepay_id='+prepay_id,
                    signType: 'MD5', 
                    paySign: paySign,
                    success: function (res1) {
                        // 支付成功后的回调函数，详细请参见：http://pay.weixin.qq.com/wiki/doc/api/index.php?chapter=7_7
                        if (res1.errMsg == "chooseWXPay:ok") { // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回    ok，但并不保证它绝对可靠。 
                            //TODO：此处为安全期间，应调用商户api查询订单状态。
                            if ($("#Ing_type").val() == "0")//预定支付
                            {
                                pay();

                            }
                            else if ($("#Ing_type").val() == "1")//会员储值
                            {
                              
                                if ($("#total_fee").val() == "50000") {
                                   
                                    Dialog("温馨提醒", "充值成功", 1, "gotoChargeShare");
                                }
                                else
                                {

                                    Dialog("温馨提醒", "充值成功", 1, "gotoshare");

                                }

                            }
                        }
                        else
                        {
                            //TODO：支付过程中用户取消的商户处理逻辑。
                            alert(res1.errMsg);
                        }
                    },
                    cancel: function (res1) {
                        alert("支付过程中用户取消");
                    },
                    fail:function(res1){
                        alert("支付失败:"+res1);
                    }
                });
            }
            else{
                alert(res.return_msg);
            }
        },
        fail:function(res){
            alert(res.responseText);
        }
    });
       
};