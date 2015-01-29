<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Web.error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>    
<head><title></title> 
</head>    
<script type="text/javascript">
        var i = 10;
        window.onload=function page_cg()
        {           
            document.getElementById("time").innerText = i;
            i--;
            if(i==0)
            {
              //  window.open("default.aspx");
              parent.parent.window.location="./login.aspx";
            }
            
            setTimeout("page_cg()",1000);
        }
    </script>
<body>
<form id="error" method="post" runat="server"> 
			<table width="99%" border="0" align="center" cellpadding="8" cellspacing="1"  height="300px">
				<tr>
					<td align="middle" valign="bottom" style="FONT-SIZE:13px">
						<img alt="" src="images/error.png" style="width: 241px; height: 62px;" /></td>
				</tr>
				<tr>
					<td align="middle" valign="center" style="FONT-SIZE:13px">
<div >
           错误:<%=errorMsg%>!5秒后跳到登陆页面 <span id="time"></span>
            <br />
            点击<a href="./login.aspx" target ="_top" >这里</a>返回登陆</div>
			</td>
				</tr>
				<tr>
					<td align="middle" valign="center" style="FONT-SIZE:13px">
						</td>
				</tr>
			</table>
			
		</form>
  
</body>    
</html>
