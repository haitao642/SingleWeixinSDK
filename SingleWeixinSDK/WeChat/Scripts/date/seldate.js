function GetDateStr(AddDayCount) {
    var dd = new Date();
    dd.setDate(dd.getDate() + AddDayCount);//获取AddDayCount天后的日期 
    var y = dd.getFullYear();
    var m = dd.getMonth() + 1;//获取当前月份的日期 
    var d = dd.getDate();
    return y + "-" + m + "-" + d;
}


function FormatDateStr(dt) {
    var dd = new Date(dt.replace(/-/g, "/"));
    var y = dd.getFullYear();
    var m = dd.getMonth() + 1;//获取当前月份的日期 
    var d = dd.getDate();
    return m + "月" + d+"日";
}


//计算天数差的函数，通用  
function DateDiff(sDate1, sDate2) {    //sDate1和sDate2是2006-12-18格式  
    var oDate1 = new Date(sDate1.replace(/-/g, "/"));
    var oDate2 = new Date(sDate2.replace(/-/g, "/"));
    var days = oDate2.getTime() - oDate1.getTime();
    var iDays = parseInt(days / (1000 * 60 * 60 * 24));   //把相差的毫秒数转换为天数  
    return iDays
}