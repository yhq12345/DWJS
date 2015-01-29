//by:xcl @2012.8  qq:80213876
;(function ($) { 
    $.extend({
        XCLTableList:function(options){
            options = $.extend({},funs.Defaults, options);
            funs.Init(options);
            $(options.tableClass).each(function(){
                $trs=null;
                if($(this).children("tbody").length>0){//��������Զ���tbody��ǩ
                    $trs=options.trNoHoverClass==""?$(this).children().children():$(this).children().children().not(options.trNoHoverClass);
                }else{
                    $trs=options.trNoHoverClass==""?$(this).children():$(this).children().not(options.trNoHoverClass);
                }
                //��������ɫ
                if(options.trHoverColor!=""){
                    $trs.hover(function(){
                        $(this).addClass("XCLTableList_trHover");
                    },function(){
                        $(this).removeClass("XCLTableList_trHover");
                    });
                }
                //��������ɫ
                if(options.trClickColor!=""){
                    $trs.click(function(){
                        $trs.removeClass("XCLTableList_trClick");
                        $(this).addClass("XCLTableList_trClick");
                    });
                }
                //��ż����ɫ
                if(options.trEvenColor!=""){
                    $trs.each(function(i){
                        if(i%2==0){
                            $(this).addClass("XCLTableList_trEven");
                        }
                    });
                }
                if(options.trOddColor!=""){
                   $trs.each(function(i){
                        if(i%2==1){
                            $(this).addClass("XCLTableList_trOdd");
                        }
                    });
                }
                /******�����ʽ��ؽ���****/


                /******ȫѡ��ؿ�ʼ*****/
                //����ȫѡʱ
                $(options.checkAllClass).click(function(){
                    $ckAll=$(this).closest(options.tableClass).find(options.checkAllClass);
                    $ckItem=$(this).closest(options.tableClass).find(options.checkItemClass);
                    if(this.checked){
                        $ckItem.attr({"checked":true});
                    }else{
                        $ckItem.attr({"checked":false});
                    }
                    funs.GetCheckBoxIDs($ckAll,$ckItem);
                });
                //�����б��е�checkboxʱ
                $(options.checkItemClass).click(function(){
                    $ckAll=$(this).closest(options.tableClass).find(options.checkAllClass);
                    $ckItem=$(this).closest(options.tableClass).find(options.checkItemClass);
                    var flag=1;
                    $ckItem.each(function(){
                        if(!this.checked){
                            flag=0;
                            return false;
                        }
                    });
                    if(flag==1){
                        $ckAll.attr({"checked":true});
                    }else{
                        $ckAll.attr({"checked":false});
                    }
                    funs.GetCheckBoxIDs($ckAll,$ckItem);
                });
                /******ȫѡ��ؽ���*****/

            });
        }
    });
    var funs={
        Defaults:{
            tableClass:".tableList",//table��class
            trHoverColor:"#eee",//�л���ʱ����ɫ
            trClickColor:"",//�����к����ɫ
            trNoHoverClass:".noHover",//����������ɫ����class
            trEvenColor:"#ecf7fb",//ż���е���ɫ0��ʼ
            trOddColor:"#fff",//�����е���ɫ
            checkAllClass:".checkAll",//ȫѡ��ťclass
            checkItemClass:".checkItem",//ѡ����class
            checkedTrColor:"#fffec9"//ѡ���е���ɫ
        },
        Init:function(options){
            //��ʽ
            $("head").append("<style type='text/css'>.XCLTableList_trHover{background:"+options.trHoverColor+"!important;} "+
                                    ".XCLTableList_trClick{background:"+options.trClickColor+"!important;} "+
                                    ".XCLTableList_trEven{background:"+options.trEvenColor+";} "+
                                    ".XCLTableList_trOdd{background:"+options.trOddColor+";}"+
                                    ".XCLTableList_trChecked{background:"+options.checkedTrColor+"!important;}"+
                                    "</style>");
            //�����Ϊѡ��ʱ����ʱѡ��ȫѡ��
            $(options.tableClass).each(function(){
                    $ckAll=$(this).closest(options.tableClass).find(options.checkAllClass);
                    $ckItem=$(this).closest(options.tableClass).find(options.checkItemClass);
                    var isAllChecked=1;
                    $ckItem.each(function(){
                        if(!this.checked){
                            isAllChecked=0;return false;
                        }
                    });
                    if(isAllChecked==1){
                        $ckAll.attr({"checked":true});
                    }
            });
        },
        //���б��е�checkbox��value��������ʽ�浽ȫѡ��checkbox��value��
        GetCheckBoxIDs:function(ckAll,ckItem){
            var v=[];
            ckItem.each(function(){
                if(this.checked){
                    $(this).closest("tr").addClass("XCLTableList_trChecked");
                    v.push(this.value);
                }else{
                    $(this).closest("tr").removeClass("XCLTableList_trChecked");
                }
            });
            ckAll.val(v.toString());
        }
    }
})(jQuery);