// JavaScript Document
//title:标题   msg:内容    type:  0  确认框    1  警告框
function Dialog(title,msg,type,callback)
{
    var s="<div class='weui_dialog_confirm divdialog'><div class='weui_mask'></div><div class='weui_dialog'><div class='weui_dialog_hd'><strong class='weui_dialog_title'>"+title+"</strong></div><div class='weui_dialog_bd'>"+msg+"</div><div class='weui_dialog_ft'><a href='#' class='weui_btn_dialog default' rel='0'>取消</a><a href='#' class='weui_btn_dialog primary' rel='1'>确定</a></div></div></div>";
	
	if(type==1)
	{
	   s="<div class='weui_dialog_alert divdialog'><div class='weui_mask'></div><div class='weui_dialog'><div class='weui_dialog_hd'><strong class='weui_dialog_title'>"+title+"</strong></div><div class='weui_dialog_bd'>"+msg+"</div><div class='weui_dialog_ft'><a href='#' class='weui_btn_dialog primary' rel='2'>确定</a></div></div></div>";	
    }
	
	$(document.body).append(s);
	
	var $dialog = $('.divdialog');
    $dialog.find('.weui_btn_dialog').one('click', function () {
        $dialog.remove();
        if (callback != '' && callback != 'undefined' && callback != undefined) {
            doCallback(eval(callback), [$(this).attr("rel")]);
        }
    });
}

//这个方法做了一些操作、然后调用回调函数    
function doCallback(fn,args)    
{    
    fn.apply(this, args);  
} 

//type  0 已完成   1：数据加载中
function Toast(type)
{
	var s="<div class='divtoast'><div class='weui_mask_transparent'></div><div class='weui_toast'><i class='weui_icon_toast'></i><p class='weui_toast_content'>已完成</p></div></div>";
	
	if(type==1)
	{
	  s="<div class='weui_loading_toast divtoast'><div class='weui_mask_transparent'></div><div class='weui_toast'><div class='weui_loading'><!-- :) --><div class='weui_loading_leaf weui_loading_leaf_0'></div><div class='weui_loading_leaf weui_loading_leaf_1'></div><div class='weui_loading_leaf weui_loading_leaf_2'></div><div class='weui_loading_leaf weui_loading_leaf_3'></div><div class='weui_loading_leaf weui_loading_leaf_4'></div><div class='weui_loading_leaf weui_loading_leaf_5'></div><div class='weui_loading_leaf weui_loading_leaf_6'></div><div class='weui_loading_leaf weui_loading_leaf_7'></div><div class='weui_loading_leaf weui_loading_leaf_8'></div><div class='weui_loading_leaf weui_loading_leaf_9'></div><div class='weui_loading_leaf weui_loading_leaf_10'></div><div class='weui_loading_leaf weui_loading_leaf_11'></div></div><p class='weui_toast_content'>数据加载中</p></div></div>";	
	}
	
	$(document.body).append(s);
	
	var $dialog = $('.divtoast');
    setTimeout(function () {
                    $dialog.remove();
                    }, 1000);
}



function actionSheet(actionsheetmenu)
{
	var s="<div id='actionSheet_wrap' class='divactionSheet_wrap'><div class='weui_mask_transition' id='mask'></div><div class='weui_actionsheet' id='weui_actionsheet'><div class='weui_actionsheet_menu'>";
	s+=$("#"+actionsheetmenu).html();
	s+=" </div><div class='weui_actionsheet_action'><div class='weui_actionsheet_cell' id='actionsheet_cancel'>取消</div></div></div></div>";
	
	$(document.body).append(s);
	
	var $dialog = $('.divactionSheet_wrap');
	
	var mask = $('#mask');
                    var weuiActionsheet = $('#weui_actionsheet');
                    weuiActionsheet.addClass('weui_actionsheet_toggle');
                    mask.show().addClass('weui_fade_toggle').click(function () {
                        hideActionSheet(weuiActionsheet, mask);
                    });
                    $('#actionsheet_cancel').click(function () {
                        hideActionSheet(weuiActionsheet, mask);
                    });
					
					$dialog.find('.divweui_actionsheetmenu').click(function(){
					    doCallback(eval($(this).attr("ref")), [$(this).attr("ref1"), $(this).attr("ref2"), $(this).attr("ref3")]);
						hideActionSheet(weuiActionsheet, mask);
					})
                    weuiActionsheet.unbind('transitionend').unbind('webkitTransitionEnd');

                    function hideActionSheet(weuiActionsheet, mask) {
                        weuiActionsheet.removeClass('weui_actionsheet_toggle');
                        mask.removeClass('weui_fade_toggle');
                        weuiActionsheet.on('transitionend', function () {
                            mask.hide();$dialog.remove();
                        }).on('webkitTransitionEnd', function () {
                            mask.hide();$dialog.remove();
                        })
                    }
}