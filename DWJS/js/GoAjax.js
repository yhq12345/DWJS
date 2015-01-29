//by:xcl @2012-10-24
//请求成功后需要返回的数据:{"msg":"提示信息","isReload":"为1则需要刷新，否则只显示提示信息不刷新页面"}
/*   (function())(Jquery) 封包的用法  */
; (function ($) { 
    $.extend({   
        XCLGoAjax:function(options){
            options = $.extend({},funs.Defaults, options);/*作为谁的集合？*/  //$.fn.extend({
            funs.Init(options);
        }
    });



    /*  var newSrc = $.extend({},{name:"asd",showName:funtion(){ alert('abc');}});**/

    var funs={
        Defaults:{
            obj:null, //指定对象
            type:"POST",// post或get
            data:null, //数据
            url:location.href, //url
            isLockBtn:true, //为true则disabled对象obj
            isChangeBtnVal:true,
            isRefreshSelf:false,// 为true刷新当前页面页不是父页面
            successFunction:null,//请求成功后执行的函数
            isAlertShowMsg:false,//true:以alert的方式弹出消息，点确定或关闭执行刷新或其它函数。false:以tips弹出消息
            beforeSendMsg:""//请求前要提示的信息
        },
        Init:function(options){
                if(options.data==null){
                    options.data=$(options.obj).closest("form").serialize() + "&method=ajax";
                }
                if(options.beforeSendMsg!=""){//写在$.ajax中时，当网络不好时，可能会卡
                    art.dialog.tips(options.beforeSendMsg, 5000000);
                }
                if (options.isLockBtn) {
                   // $(options.obj).val("提交中...").attr({ "disabled": "disabled" });
                    if(options.isChangeBtnVal){
                     $(options.obj).val("提交中...");
                    }
                    $(options.obj).attr({ "disabled": true });
                }
              $.ajax({
                type: options.type,
                data: options.data,
                dataType: "JSON",
                url: options.url,
                error: function () {
                    art.dialog.tips("抱歉，出错啦！请稍后再试！");
                    if (options.isLockBtn) {
                        $(options.obj).val("保存").removeAttr("disabled");
                    }
                },
                success: function (data) {
                    if(data.isError){
                     art.dialog.tips(data.msg);
                     return;
                    }

                    if (options.isLockBtn) {
                        //$(options.obj).val("保存").removeAttr("disabled");
                        $(options.obj).removeAttr("disabled");
                        if(options.isChangeBtnVal){
                        $(options.obj).val("保存");
                        }
                    }
                    if (data.msg != "") {
                        if(options.isAlertShowMsg){
                                var list = art.dialog.list["Tips"];
                                if(null!=list){
                                    list.close();
                                }
                                art.dialog({
                                        content: data.msg,
                                        cancelVal: '知道了',
                                        cancel:function(){
                                            funs.Refresh(options,data);
                                        }
                                });
                        }
                        else{
                                art.dialog.tips(data.msg);
                                funs.Refresh(options,data);
                        }
                    }
                    if (null != options.successFunction) {
                        var list = art.dialog.list["Tips"];
                            if(null!=list){
                                list.close();
                            }
                        options.successFunction(data);
                        return;
                    }
                }
            });
        },
       Refresh:function(options,data){
           var time=700;
           if(options.isAlertShowMsg){
            time=0;
           }
           if (data.isReload == '1') {
                setTimeout(function () {
                    if (options.isRefreshSelf) {
                       window.location= location;  //location.reload();
                    } else {
                        art.dialog.open.origin.location.reload();
                    }
                }, time);
            }
       }
    }
})(jQuery);