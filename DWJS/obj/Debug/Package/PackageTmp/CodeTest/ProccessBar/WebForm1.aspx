<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DWKS.CodeTest.ProccessBar.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../JqueryPlug/jquery_mobile/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var prossNum = 0;
        function WatchALL() {
            $.ajax({
                type: "GET",
                url: "./GetData.aspx?Pro=ALL",
                datatype: "JOSN",
                error: function () { },
                success: function (data) {
                    if (data) {
                        data = $.parseJSON(data);
                        $('#lab_Show').text(data[0].PRO);
                    }
                }
            });
        }
        function WatchPro() {

            $.ajax({
                type: "GET",
                url: "./GetData.aspx?Pro=Watch",
                datatype: "JOSN",
                error: function () { },
                success: function (data) {
                    if (data) {
                        data = $.parseJSON(data);
                        prossNum = data.ProcessNum;

                        if (data.ProcessNum >= 100)
                            clearInterval(timer1);
                        $('#lab_Show').text(data.ProcessNum + "%");
                    }
                }
            });
        }


        function Submit() {
            WatchALL();
            prossNum = 0;
            timer1 = setInterval(WatchPro, 1000);

        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <label id="lab_Show" />

    <input type="button" value="提交" onclick="Submit();">
    </div>
    </form>
</body>
</html>
