/*
 * Copyright (c) 2006-2008 coderhome.net
 * All rights reserved.
 * Support : 
 *
 * Version :  1.0
 */

var FormValid = function(frm) {
    this.frm = frm;
    this.errMsg = new Array();
	this.errName = new Array();
   /*函数名:不为空*************************************/
   
    this.required = function(inputObj) {
        if (typeof(inputObj) == "undefined" || inputObj.value.trim() == "") {
            return false;
        }
		return true;
    }
     /*             :是否相同       */
    this.eqaul = function(inputObj, formElements) {
		var fstObj = inputObj;
		var sndObj = formElements[inputObj.getAttribute('eqaulName')];
		
        if (fstObj != null && sndObj != null) {
            if (fstObj.value != sndObj.value) {
               return false;
            }
        }
		return true;
    }
   /*******************小数点后的长度***********************/
        this.pointlength = function(inputObj, formElements) {
		var fstObj = inputObj;
        var value = inputObj.value;
		var numLength=parseInt(inputObj.getAttribute('pointLength')); 
		var index=value.indexOf('.');

		if(index==-1)
		{
		    return false;
		}
		else
		{
		    var str=value.substr(index+1);
		    
		    if(str.length==numLength)
		        return true;
		    else 
		        return false;    
		}
    }
    /*******************经度的选择**********************/
    this.LongLength = function(inputObj, formElements) {
    
		var fstObj = inputObj;
        var value = inputObj.value;
        
		var num=parseInt(inputObj.getAttribute('LongLength')); 

		var index=value.indexOf('.')

       
		if(index==-1)
		{
		    return false;
		}
		else
		{
		     var str_a=value.split('.');
		 
		    var str=str_a[0];

		    if(str<=122&&str>=118)
		        return true;
		    else 
		        return false;    
		}
    }
    /***************************纬度的整数长度************************/
        this.LatLength = function(inputObj, formElements) {
    
		var fstObj = inputObj;
        var value = inputObj.value;
		var num=parseInt(inputObj.getAttribute('LatLength')); 
		var index=value.indexOf('.')
       
		if(index==-1)
		{
		    return false;
		}
		else
		{
		    var str_a=value.split('.');
		    var str=str_a[0];

		    if(str<=30&&str>=26)
		        return true;
		    else 
		        return false;    
		}
    }
    
    /********************gt*******************/

    this.gt = function(inputObj, formElements) {
		var fstObj = inputObj;
		var sndObj = formElements[inputObj.getAttribute('eqaulName')];
		
        if (fstObj != null && sndObj != null && fstObj.value.trim()!='' && sndObj.value.trim()!='') {
            if (parseFloat(fstObj.value) <= parseFloat(sndObj.value)) {
                 return false;
            }
        }
		return true;
    }
/************************比较*****************************/
	this.compare = function(inputObj, formElements) {
		var fstObj = inputObj;
		var sndObj = formElements[inputObj.getAttribute('objectName')];
        if (fstObj != null && sndObj != null && fstObj.value.trim()!='' && sndObj.value.trim()!='') {
            if (!(eval(parseFloat(fstObj.value) + inputObj.getAttribute('operate') + parseFloat(sndObj.value)))) {
                 return false;
            }
        }
		return true;
	}
	//check char num
	//********************************检查最大长度*****************/
	this.limitchar=function(inputObj){ 
	    var strValue= inputObj.value.trim();
	    var maxLength=parseInt(inputObj.getAttribute('charnum'));
	    //get char num
	    var i;
	    var l = strValue.length;
	    var len; 
	    len = 0;
	    for (i=0;i<l;i++){
		    if (strValue.charCodeAt(i)>255) 
			    len+=2; 
		    else 
			    len++;		    
    	}
    	return len<=maxLength; 
	}
	
	
	
/**********************************判断最大最小长度************************/
	this.limit = function (inputObj) {
		var len = inputObj.value.length;
		if (len) {
			var minv = parseInt(inputObj.getAttribute('min'));
			var maxv = parseInt(inputObj.getAttribute('max'));
			minv = minv || 0;
			maxv = maxv || Number.MAX_VALUE;
			return minv <= len && len <= maxv;
		}
		return true;
	}
	
	
	/***********************************************是否是数字**************************************/
	this.IsNum = function (inputObj) {
		var value = inputObj.value;
		//var allow = inputObj.getAttribute('IsNum');
		if (value.trim()) {
			//return new RegExp("^.+\.(?=EXT)(EXT)$".replace(/EXT/g, allow.split(/\s*,\s*/).join("|")), "gi").test(value);
		      return new RegExp("^[0-9]*[1-9][0-9]*$").test(value);
		}
		return true;
	}
	
	
	
	this.range = function (inputObj) {
		var val = parseInt(inputObj.value);
		if (inputObj.value) {
			var minv = parseInt(inputObj.getAttribute('min'));
			var maxv = parseInt(inputObj.getAttribute('max'));
			minv = minv || 0;
			maxv = maxv || Number.MAX_VALUE;
		
			return minv <= val && val <= maxv;
		}
		return true;
	}
	
	this.selected =	 function (inputObj) { 
		var index = parseInt(inputObj.getAttribute('index')); 
		var curIndex= inputObj.selectedIndex;
		return index!=curIndex;
	}

	this.notcontain = function (inputObj) { 
		var value = inputObj.value;
		var notvalue = inputObj.getAttribute('notvalue'); 
		
		var index= value.indexOf(notvalue);
	     
		return index==-1;
	}
	
	/***要求确定ChecekedBox*****/
	this.requireChecked = function (inputObj) {
		var minv = parseInt(inputObj.getAttribute('min'));
		var maxv = parseInt(inputObj.getAttribute('max'));
		minv = minv || 1;
		maxv = maxv || Number.MAX_VALUE;
	
		var checked = 0;
		var groups = document.getElementsByName(inputObj.name);
		
		for(var i=0;i<groups.length;i++) {
			if(groups[i].checked) checked++;
			
		}
		return minv <= checked && checked <= maxv;
	}
	
	this.filter = function (inputObj) {
		var value = inputObj.value;
		var allow = inputObj.getAttribute('allow');
		if (value.trim()) {
			return new RegExp("^.+\.(?=EXT)(EXT)$".replace(/EXT/g, allow.split(/\s*,\s*/).join("|")), "gi").test(value);
		}
		return true;
	}
	
	this.isNo = function (inputObj) {
		var value = inputObj.value;
		var noValue = inputObj.getAttribute('noValue');
		return value!=noValue;
	}
	
 	this.isTelephone = function (inputObj) {
        inputObj.value = inputObj.value.trim();
        if (inputObj.value == '') {
            return true;
        } else {
            if (!RegExps.isMobile.test(inputObj.value) && !RegExps.isPhone.test(inputObj.value)) {
				return false;
			}
        }
        return true;
	}
    this.checkReg = function(inputObj, reg, msg) {
        inputObj.value = inputObj.value.trim();

        if (inputObj.value == '') {
            return true;
        } else {
            return reg.test(inputObj.value);
        }
    }

    this.passed = function() {
        if (this.errMsg.length > 0) {
            FormValid.showError(this.errMsg,this.errName,this.frm.name);
			if (this.errName[0].indexOf('[')==-1) {
            	frt = document.getElementsByName(this.errName[0])[0];
				if (frt.type=='text' || frt.type=='password') {
					frt.focus();
				}
			}
            return false;
        } else {
          return FormValid.succeed();
        }
    }

    this.addErrorMsg = function(name,str) {
        this.errMsg.push(str);
		this.errName.push(name);
    }
	
    this.addAllName = function(name) {
		FormValid.allName.push(name);
    }
    
}
FormValid.allName = new Array();


FormValid.showError = function(errMsg) {
	var msg = "";
	for (i = 0; i < errMsg.length; i++) {
		msg += "- " + errMsg[i] + "\n";
	}
	alert(msg);
}

FormValid.succeed = function () {
	return true;
}
function validator(frm) {
	var formElements = frm.elements;
	var fv = new FormValid(frm);
	FormValid.allName = new Array();
	for (var i=0; i<formElements.length;i++) {
		if (formElements[i].disabled==true) continue;
		var msgs = fvCheck(formElements[i],fv,formElements);
		if (msgs.length>0) {
			for (n in msgs) {
				fv.addErrorMsg(formElements[i].name,msgs[n]);
			}
		}
	}
	return fv.passed();
}

function fvCheck(e,fv,formElements) {
	var validType = e.getAttribute('valid');
	var errorMsg = e.getAttribute('errmsg');
	if (!errorMsg) {
		errorMsg = '';
	}
	if (validType==null) return [];
	fv.addAllName(e.name);
	var vts = validType.split('|');
	var ems = errorMsg.split('|');
	var r = [];
	for (var j=0; j<vts.length; j++) {
		var curValidType = vts[j];
		var curErrorMsg = ems[j];
		var validResult;
		switch (curValidType) {
		case 'isNumber':
		case 'isEmail':
		case 'isPhone':
		case 'isMobile':
		case 'isIdCard':
		case 'isMoney':
		case 'isZip':
		case 'isQQ':
		case 'isInt':
		case 'isEnglish':
		case 'isChinese':
		case 'isUrl':
		case 'isDate':
		case 'isTime':
			validResult = fv.checkReg(e,RegExps[curValidType],curErrorMsg);
			break;
		case 'regexp':
			validResult = fv.checkReg(e,new RegExp(e.getAttribute('regexp'),"g"),curErrorMsg);
			break;
		case 'custom':
			validResult = eval(e.getAttribute('custom')+'(e,formElements)');
			break;
		default :
			validResult = eval('fv.'+curValidType+'(e,formElements)');
			break;
		}
		if (!validResult) r.push(curErrorMsg);
	}
	return r;
}
String.prototype.trim = function() {
	return this.replace(/^\s*|\s*$/g, "");
}
var RegExps = function(){};
RegExps.isNumber = /^[-\+]?\d+(\.\d+)?$/;
RegExps.isEmail = /([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)/;
RegExps.isPhone = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/;
RegExps.isMobile = /^((\(\d{2,3}\))|(\d{3}\-))?(13|15)\d{9}$/;
RegExps.isIdCard = /(^\d{15}$)|(^\d{17}[0-9Xx]$)/;
RegExps.isMoney = /^\d+(\.\d+)?$/;
RegExps.isZip = /^[1-9]\d{5}$/;
RegExps.isQQ = /^[1-9]\d{4,10}$/;
RegExps.isInt = /^[-\+]?\d+$/;
RegExps.isEnglish = /^[A-Za-z]+$/;
RegExps.isChinese =  /^[\u0391-\uFFE5]+$/;
RegExps.isUrl = /^http[s]?:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
RegExps.isDate = /^\d{4}-\d{1,2}-\d{1,2}$/;
RegExps.isTime = /^\d{4}-\d{1,2}-\d{1,2}\s\d{1,2}:\d{1,2}:\d{1,2}$/;