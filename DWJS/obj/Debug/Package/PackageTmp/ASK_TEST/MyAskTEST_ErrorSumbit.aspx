<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAskTEST_ErrorSumbit.aspx.cs" Inherits="DWKS.ASK_TEST.MyAskTEST_ErrorSumbit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="format-detection" content="telephone=no" />
    <link href="<%=PageBase.Url%>JqueryPlug/jquery_mobile/jquery.mobile-1.3.2.min.css"
        rel="stylesheet" type="text/css" />
    <script src="<%=PageBase.Url%>JqueryPlug/jquery_mobile/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url%>JqueryPlug/jquery_mobile/jquery.mobile-1.3.2.min.js"
        type="text/javascript"></script>
    <script src="<%=PageBase.Url%>js/aridiologfile/artDialog.source.js?skin=black" type="text/javascript"></script>
    <script src="<%=PageBase.Url%>js/aridiologfile/plugins/iframeTools.source.js" type="text/javascript"></script>
    <link href="<%=PageBase.Url%>css/admin.css" type="text/css" rel="stylesheet" />
    <link href="<%=PageBase.Url%>css/admin2.css" type="text/css" rel="stylesheet" />
    <script src="<%=PageBase.Url%>js/Common.js" type="text/javascript" language="javascript"></script>
    <script src="<%=PageBase.Url%>js/highchart/highcharts.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url%>js/GoAjax.js" type="text/javascript"></script>
    <style type="text/css">
        .titletd
        {
            font-size: 12px;
            font-weight: bold;
            width: 15%;
        }
        table tr td
        {
            font-size: 16px;
        }
        .td2_content
        {
            font-size: 16x;
        }
    </style>
    
</head>
<body>
  <div data-role="page">
       <%-- <div data-role="header">
            <h1>
                错误题目提交</h1>
        </div>--%>
        <div data-role="content">
            <form id="Form1" method="post" runat="server">
            <input type="hidden" runat="server" id="hid_OtherOption" />
            <input type="hidden" runat="server" id="hid_AnSwer" />
           
            <div>
               
                <div>
                    <table>
                        <tr>
                            <td>
                             提交人
                            </td>
                            <td class="td2_content">
                             <%=Submiter %>
                            </td>
                        </tr>
                          <tr>
                            <td>
                            提交时间
                            </td>
                            <td class="td2_content">
                               <%=SubmitTime%>
                            </td>
                        </tr>
                    <tr>
                            <td>
                            提交内容
                            </td>
                            <td>
                              <textarea id="area_Err" runat="server" ></textarea>
                            </td>
                        </tr>
                        <!--选项E的HTML输出-->
                    </table>
                </div>
            </div>
            <br />
            <div>
               
                <%--<table>
                    <tr>
                        <td class="titletd">
                            <input id="pre_btn" runat="server" type="button" src="../images/img_query.gif" value="上一题"  />&nbsp;
                        </td>
                        <td class="titletd">
                            <input id="next_btn" runat="server" type="button" src="../images/img_query.gif" value="下一题" />&nbsp;
                        </td>
                        <td class="titletd">
                            <input id="save_btn" runat="server" type="button" src="../images/img_query.gif" value="保 存"
                                onclick="funs.Save_Save(this);return false;" />&nbsp;
                        </td>
                        <td class="titletd">
                            <input id="none_done_btn" runat="server" type="button" src="../images/img_query.gif"
                                value="未完成的题" onclick="funs.Save_UnDone(this);return false;" />&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <input type="button" src="../images/img_query.gif" value="提交" onclick="funs.Save_Submit(this);return false;" />&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <input type="button" src="../images/img_query.gif" value="返回" onclick="location.href='./MyIndex.aspx';" />&nbsp;
                        </td>
                    </tr>
                </table>--%>

                 <div style="display:inline;float:left;" >
                   <%-- <input id="pre_btn" runat="server" type="button" src="../images/img_query.gif" value="上一题"  />&nbsp;
                --%>
                 </div>
                 <div style="display:inline;float:left;" >
                <%--  <input id="next_btn" runat="server" type="button" src="../images/img_query.gif" value="下一题" />&nbsp;
                    --%>
                 </div>
                 <div style="display:inline;float:left;" >
               <%--  <input id="save_btn" runat="server" type="button" src="../images/img_query.gif" value="保 存"
                                onclick="funs.Save_Save(this);return false;" />--%>
                 </div>
                 <div style="display:inline;float:left;" >
                   <%--<input id="none_done_btn" runat="server" type="button" src="../images/img_query.gif"
                                value="未完成的题" onclick="funs.Save_UnDone(this);return false;" />--%>&nbsp;
                       
                 </div>
                 <div style="clear:both;"></div>
                
                  <div style="display:inline;" >
                 <input type="button" src="../images/img_query.gif" value="提交错误信息" onclick="funs.Save_Save(this);" />
                  <%--<input type="button" src="../images/img_query.gif" value="提交" onclick="funs.Save_Submit(this);return false;" />--%>&nbsp;
                </div>

                 <div style="display:inline;" >
                   <input type="button" src="../images/img_query.gif" value="关闭" onclick="art.dialog.close();" />&nbsp;
                 </div>
            </div>
            </form>
        </div>
       <script type="text/javascript">
          
           var funs = {
               Save_Save: function (obj) {
                   var that = this;
                   $.XCLGoAjax({ data: $(obj).closest("form").serialize() + "&method=ajax&handleType=Submit", obj: obj, isLockBtn: false, isChangeBtnVal: false, successFunction: this.sFunction_Save, beforeSendMsg: "保存中..." });
               },
               sFunction_Save: function (str) {
                   art.dialog.alert('提交成功,我们会尽快处理错题！');
               }
           };
           function pagequeryValid() {
               var alertmsg = '';

               if (alertmsg != '') {
                   alert(alertmsg);
                   return false;
               }
               return true;
           }

    </script>
    </div>
</body>
</html>
