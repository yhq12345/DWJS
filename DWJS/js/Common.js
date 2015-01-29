//弹出模态子窗口，返回子窗口返回值
function ShowModalSubWindow(pagePath,width,height)
{ 
	var subwin=window.showModalDialog(pagePath,"","dialogWidth ="+width+"px;dialogHeight = "+height+"px;help:no;status:no;");
	if(subwin!=undefined)
	{ 
		return subwin; 
	}
	else
		return null;
}

//弹出非模态子窗口，返回子窗口返回值
function ShowUnModalSubWindow(pagePath,width,height)
{ 
	var subwin=window.showModelessDialog(pagePath,"","dialogWidth ="+width+"px;dialogHeight = "+height+"px;help:no;status:no;");
	if(subwin!=undefined)
	{ 
		return subwin; 
	}
	else
		return null;
}
//弹出(带参数)模态子窗口，返回子窗口返回值
function ShowModalSubWinWithArgs(pagePath,args,width,height)
{ 
	var subwin=window.showModalDialog(pagePath,args,"dialogWidth ="+width+"px;dialogHeight = "+height+"px;help:no;status:no;");
	if(subwin!=undefined)
	{ 
		return subwin; 
	}
	else
		return null;
}
//模态及非模态窗口返回值
function ReturnResult(obj)
{ 
	window.returnValue=obj;    
    window.close();    
}
/*

function checkNum(obj)
{
	var re = /^-?[1-9]*(\.\d*)?$|^-?d^(\.\d*)?$/;
    if (!re.test(obj.value))
    {
		if(isNaN(obj.value))
		{
			return false;
        }
    }
}  

function addRow(tableID,item)
{
	var table = document.getElementById(tableID);//创建table 
	var row=table.insertRow();
	row.id="tr"+item[0];
	row.className="zy_item" ;
	row.align="center"; 
	
	var cell=row.insertCell();
	cell.innerHTML="<a href='#' onclick='Move(\""+item[0]+"\")' style='COLOR: #3333cc'>移除</a>"; 
	
	for(var i=0;i<item.length;i++)
	{
		cell=row.insertCell();
		cell.innerHTML=item[i]; 
	}
}

function removeRows(tableID)
{
	var table = document.getElementById(tableID);//创建table 
	var rowsNum=table.rows.length;
	for (var i = rowsNum - 1; i >= 0; i--) {
		table.deleteRow(i);
	}
} 
function removeRow(table,rowID)
{
	var table = document.getElementById("newTable");//创建table 
	var rowsNum=table.rows.length;
	for (var i = rowsNum - 1; i >= 0; i--) {
		if(table.rows[i].id==rowID)
        {
			table.deleteRow(i);
			break;
        }
	}
}

*/