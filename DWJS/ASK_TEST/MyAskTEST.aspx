<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAskTEST.aspx.cs" Inherits="DWKS.ASK_TEST.MyAskTEST" %>

<!DOCTYPE html>
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
        <div data-role="header">
            <h1>
                [题目列表<%=TitleNo %>/100]</h1>
        </div>
        <div data-role="content">
            <form id="Form1" method="post" runat="server">
            <input type="hidden" runat="server" id="hid_OtherOption" />
            <input type="hidden" runat="server" id="hid_AnSwer" />
            <div>
                <h3>
                    题目</h3>
                <div id="div_content" style="font-size: 15px;">
                    <%=TitleNo%>.<%=Title_ASK %>
                </div>
            </div>
            <div>
                <h3>
                    答案
                </h3>
                <div>
                    <table>
                        <tr>
                            <td>
                                <label>
                                    <input runat="server" name="answer" id="ck_answer_A" type="checkbox" value="A" />A
                                </label>
                            </td>
                            <td class="td2_content">
                                <%=Answer_A %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    <input runat="server" name="answer" id="ck_answer_B" type="checkbox" value="B">B
                                </label>
                            </td>
                            <td class="td2_content">
                                <%= Answer_B%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    <input runat="server" name="answer" id="ck_answer_C" type="checkbox" value="C">C
                                </label>
                            </td>
                            <td class="td2_content">
                                <%= Answer_C%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    <input runat="server" name="answer" id="ck_answer_D" type="checkbox" value="D">D
                                </label>
                            </td>
                            <td class="td2_content">
                                <%= Answer_D%>
                            </td>
                        </tr>
                        <!--选项E的HTML输出-->
                    </table>
                    <table id="table_E">
                        <tr>
                            <td>
                                <label>
                                    <input runat="server" name="answer" id="ck_answer_E" type="checkbox" value="E">E
                                </label>
                            </td>
                            <td class="td2_content">
                                <%= Answer_E %>
                            </td>
                        </tr>
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
                    <input id="pre_btn" runat="server" type="button" src="../images/img_query.gif" value="上一题"  />&nbsp;
                 </div>
                 <div style="display:inline;float:left;" >
                  <input id="next_btn" runat="server" type="button" src="../images/img_query.gif" value="下一题" />&nbsp;
                    
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
                 <input type="button" src="../images/img_query.gif" value="查看答案" onclick="ShowAnswers();" />
                  <%--<input type="button" src="../images/img_query.gif" value="提交" onclick="funs.Save_Submit(this);return false;" />--%>&nbsp;
                </div>
                  <div style="display:inline;" >
                 <input type="button" src="../images/img_query.gif" value="考题有错误" onclick="OpenWin.ErrorAsk();" />
                  <%--<input type="button" src="../images/img_query.gif" value="提交" onclick="funs.Save_Submit(this);return false;" />--%>&nbsp;
                </div>
                 <div style="display:inline;" >
                   <input type="button" src="../images/img_query.gif" value="返回" onclick="location.href='<%=PageBase.Url %>ASK/MyIndex.aspx';" />&nbsp;
                 </div>
            </div>
            </form>
        </div>
        <div data-role="footer">
            <h1>
            </h1>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            if ($('#hid_OtherOption').val() != '') {
                $('#table_E').show();
            }
            else {
                $('#table_E').hide();
            }
        });

        var funs = {
            Save_Save: function (obj) {
                var that = this;
                $.XCLGoAjax({ data: $(obj).closest("form").serialize() + "&method=ajax&handleType=Save", obj: obj, isLockBtn: false, isChangeBtnVal: false, successFunction: this.sFunction_Save, beforeSendMsg: "保存中..." });
            },
            Save_Next: function (obj) {
                var that = this;
                $.XCLGoAjax({ data: $(obj).closest("form").serialize() + "&method=ajax&handleType=Save", obj: obj, isLockBtn: false, isChangeBtnVal: false, successFunction: this.sFunction_Next, beforeSendMsg: "保存中..." });
            },
            Save_Pre: function (obj) {
                var that = this;
                $.XCLGoAjax({ data: $(obj).closest("form").serialize() + "&method=ajax&handleType=Save", obj: obj, isLockBtn: false, isChangeBtnVal: false, successFunction: this.sFunction_Pre, beforeSendMsg: "保存中..." });
            },
            Save_UnDone: function (obj) {
                var that = this;
                $.XCLGoAjax({ data: $(obj).closest("form").serialize() + "&method=ajax&handleType=Save", obj: obj, isLockBtn: false, isChangeBtnVal: false, successFunction: this.sFunction_UnDone, beforeSendMsg: "保存中..." });
            },
            Save_Submit: function (obj) {
                var that = this;
                /*判断是否有未完成的题*/
                if (confirm('点击提交后无法修改,是否确定？')) {
                    $.XCLGoAjax({ data: $(obj).closest("form").serialize() + "&method=ajax&handleType=Submit", obj: obj, isLockBtn: false, isChangeBtnVal: false, successFunction: this.sFunction_Submit, beforeSendMsg: "提交中..." });
                }
            },
            sFunction_Save: function (str) {
                art.dialog.alert('保存成功');
                //alert('ss');
            },
            sFunction_Next: function (str) {
                window.location.href = './MyAskTEST.aspx?id=<%=nextid %>';
            },
            sFunction_Pre: function (str) {
                window.location.href = './MyAskTEST.aspx?id=<%=preid %>';
            },
            sFunction_UnDone: function (str) {

                var c = str.Data.Undoneid;
                if (c == "0") {
                    art.dialog({ content: "你没有未完成题!" });
                }
                else {
                    window.location.href = './MyAskTEST.aspx?id=' + c + '';
                }
            },
            sFunction_Submit: function (str) {
                art.dialog({ content: "提交成功!" });
                window.location.href = '<%=PageBase.Url %>ASK/MyIndex.aspx'; //返回欢迎页
            }

        };

        var OpenWin = {
            ErrorAsk: function () {
                art.dialog.open('<%=PageBase.Url %>ASK_TEST/MyAskTEST_ErrorSumbit.aspx?FK_ID=<%=KTBH %>', { title: '错误的提交', width: 300, height: 400 });
            }

        };

        function ShowAnswers() {

            var answers = $('#hid_AnSwer').val();
            alert("标准答案:"+answers);
        }
        function pagequeryValid() {
            var alertmsg = '';

            if (alertmsg != '') {
                alert(alertmsg);
                return false;
            }
            return true;
        }

    </script>
</body>
</html>
