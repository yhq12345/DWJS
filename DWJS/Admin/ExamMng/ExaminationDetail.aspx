<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminationDetail.aspx.cs" Inherits="DWKS.Admin.ExamMng.ExaminationDeTail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>类别</title>
    <link href="<%=PageBase.Url %>lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="<%=PageBase.Url %>lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet" type="text/css" />
       
    <script src="<%=PageBase.Url %>lib/jquery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/ligerUI/js/ligerui.all.js" type="text/javascript"></script>

    <link href="<%=PageBase.Url %>js/FormValid/FormValid.css" rel="stylesheet" type="text/css" />
    <link href="<%=PageBase.Url %>lib/css/common.css" rel="stylesheet" type="text/css" />

    <script src="<%=PageBase.Url %>lib/js/common.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/js/LG.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/jquery.form.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/json2.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/js/ligerui.expand.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>js/GoAjax_LigerUI.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>js/FormValid/LigerFormValid.js" type="text/javascript"></script>

    <style  type="text/css">
    .borderror
    {
    border:1px solid #f00;
    }
    .bordok
    {
    border:0px
    }
    </style>

    <!--[if IE]>
    <link href="<%=PageBase.Url %>lib/css/IECssHack.css" rel="stylesheet" type="text/css" />  
    <![endif]-->
    <script type="text/javascript">
        var win = parent.parent || window;
        $(function () {
            var tab;
        });
        function f_cancel() {
            win.LG.closeCurrentTab(null);
        }
        function OpenAlert(msg) {
            win.$.ligerDialog.alertClose(msg, false, f_cancel);
        }
        //#region 弹窗选择
        function OpenWin() {
            var c = win.$.ligerDialog.open({
                width: 1000,
                height: 500,
                top: 50,
                isResize: true,
                title: 'OMC选择',
                url: '<%=PageBase.Url %>BSCConfigMng/BSCWin/OMCSelector.aspx'
            });
        }
        function ClearSelect() {
            $('#hid_OMC_FK').val('');
            $('#lab_OMCFK').text('未关联OMC');
            win.$.ligerDialog.success('已清空OMC数据');

        }
        function OpenWinSee() {
            if ($('#hid_OMC_FK').val() == '' || $('#hid_OMC_FK').val() == '-1') {
                win.$.ligerDialog.error('未关联OMC');
            }
            else {
                top.f_addTab('OMC_See', 'OMC信息查看', '../OMCConfigMng/OMCConfigDetail.aspx?type=see&&id=' + $('#hid_OMC_FK').val());
            }
        }


        //#endregion 
        function alertmsg() {
            alert('刷新页面');
        }
    </script>
</head>
<body style="padding-bottom: 31px;">
    <form method="post" id="mainform" class="l-form" ligeruiid="mainform" action="" runat="server">
    <input type="hidden" id="hid_OMC_FK" runat="server" />
   
    <div class="l-group l-group-hasicon">
        <img src="<%=PageBase.Url %>lib/icons/32X32/communication.gif"><span>基本信息</span></div>
    <ul>
        <li style="width: 100px; text-align: left;">RNC名称：</li>
        <li style="width: 220px; text-align: left;">
            <div class="l-text" style="width: 218px;">
              <input type="text" id="txt_RNCName" name="RNCName" runat="server" class="l-text-field"
                    style="width: 214px;" valid="required" errmsg="RNC名称必填！"  />

                <div class="l-text-l"></div>
                <div class="l-text-r"></div>
            </div>
        </li>
        <li style="width: 30px;"></li>
        <li style="width: 100px; text-align: left;">RNC状态：</li>
        <li style="width: 220px; text-align: left;">
            <div class="" style="width: 218px;">
              <asp:DropDownList ID="ddl_RNCState"  runat="server" class="" style="width: 214px;" 
               valid="selected"  errmsg="RNC状态必须选择！" ></asp:DropDownList>
                <div class="l-text-l"> </div>
                <div class="l-text-r"> </div>
            </div>
        </li>
        <li style="width: 30px;"></li>
    </ul>
    <ul>
        <li style="width: 100px; text-align: left;">RNC IP：</li><li style="width: 220px; text-align: left;">
            <div class="l-text" style="width: 218px;">
             <input type="text" id="txt_RNCIP" name="RNCIP" runat="server" class="l-text-field"
                 valid="required"  errmsg="RNCIP必填！"      style="width: 214px;" />
                <div class="l-text-l"></div>
                <div class="l-text-r"></div>
             
            </div>
        </li>
        <li style="width: 30px;"></li>
        <li style="width: 100px; text-align: left;">RNC用户名：</li><li style="width: 220px; text-align: left;">
            <div class="l-text" style="width: 218px;">
                  <input type="text" id="txt_RNCUserName" name="RNCUserName" runat="server" class="l-text-field"
                     valid="required"  errmsg="RNC用户名必填！"  style="width: 214px;" />
                <div class="l-text-l"> </div>
                <div class="l-text-r"> </div>
               
            </div>
        </li>
        <li style="width: 30px;"></li>
    </ul>
    <ul>
        <li style="width: 100px; text-align: left;">RNC密码：</li><li style="width: 220px; text-align: left;">
            <div class="l-text" style="width: 218px;">
                <input type="text" id="txt_RNCPassword" name="RNCPassword" runat="server" class="l-text-field" style="width: 214px;" />
             <div class="l-text-l"> </div>
                <div class="l-text-r"> </div>
            </div>
        </li>
        <li style="width: 30px;"></li>
        <li style="width: 100px; text-align: left;">BSC版本：</li>
        <li style="width: 220px; text-align: left;">
            <div class="l-text" style="width: 218px;">
                <input type="text" id="txt_RNCVersion" name="RNCVersion" runat="server"  class="l-text-field" style="width: 214px;" />
                <div class="l-text-l">
                </div>
                <div class="l-text-r">
                </div>
            </div>
        </li>
        <li style="width: 30px;"></li>
    </ul>
    
    <div class="form-bar">
        <div class="form-bar-inner">
           
            <div class="l-dialog-btn" id="btn_submit" runat="server">
                <div class="l-dialog-btn-l">
                </div>
                <div class="l-dialog-btn-r">
                </div>
                <div class="l-dialog-btn-inner" onclick="funs.Save(this);" >
                    提交</div>
            </div>
            <div class="l-dialog-btn">
                <div class="l-dialog-btn-l">
                </div>
                <div class="l-dialog-btn-r">
                </div>
                <div class="l-dialog-btn-inner" onclick="f_cancel();">
                    取消</div>
            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">

        var funs = {
            Ini: function () { },
            Save: function (obj) {
                if (LigerValid_SubmitForm()) {
                    $.GoAjax_LigerUI({ obj: obj, ParentTabsName: "BSC_List" });
                }
            }
        };
       
    </script>

</body>
</html>
