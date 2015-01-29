; var CommonJs = {
    Url:"",
    StrWhereOutPut: "", //用于导出session名
    CheckSelect: function (obj) {
        var flag = true;
        if ($(obj).find("option:selected").val() == '-1') {
            flag = false;
        }
        return flag;
    },
    //设置checkbox选中.v为字符串数组.con为jquery容器对象
    SetCheckValues: function (con, values) {
        if (values.length > 0) {
            con.find(":checkbox").each(function () {
                for (var i = 0; i < values.length; i++) {
                    if (values[i] == $(this).val()) {
                        this.checked = true;
                    }
                }
            });
        }
    },
    //设置options选中,obj:js对象
    SelectedObj: function (obj, v) {
        $ops = $(obj).find("option");
        $ops.removeAttr("selected");
        $ops.each(function () {
            if ($(this).attr("value") == v) {
                $(this).attr({ "selected": "selected" });
                return false;
            }
        });
    },
    GetPercent: function (percent) {
        return document.body.clientWidth * percent;
    },
    //获取所有URL参数，返回一个JSON
    GetUrlParams: function () {
        var m = {};
        var str = "";
        switch (arguments.length) {
            case 0:
                str = location.search; //不包含域名信息
                break;
            case 1:
                str = arguments[0];
                break;
        }
        if (str.length > 0) {
            var strUrl = [];
            strUrl = str.substring(str.indexOf('?') + 1, str.length).split('&');
            for (var i = 0; i < strUrl.length; i++) {
                var curStr = strUrl[i].split('=');
                if (curStr.length == 2) {
                    m[curStr[0]] = curStr[1];
                }
            }
        }
        return m;
    },
    //将JSON转为URL形式
    GetUrlByJson: function (json) {
        var u = "";
        for (var key in json) {
            u = u + key + "=" + escape(json[key]) + "&";
        }
        return u.substring(0, u.length - 1);
    },
    //向URL中添加新的参数（多个则为json数组形式）[{},{}]
    AddUrlParam: function (url, jsonArr) {
        var newUrl = "";
        for (var n = 0; n < jsonArr.length; n++) {
            newUrl = newUrl + CommonJs.GetUrlByJson(jsonArr[n]) + '&';
        }
        newUrl = newUrl.substring(0, newUrl.length - 1);
        if (url.indexOf('?') > -1) {
            url = url + '&' + newUrl;
        } else {
            url = url + '?' + newUrl;
        }
        return url;
    },
    Init: function () {
        //导出按钮
        $("a.aOutPutInfo").attr({ "href": CommonJs.AddUrlParam(location.href.replace(/[#]/g, ''), [{ "method": "ajax" }, { "type": "output" }, { "StrWhereOutPut": CommonJs.StrWhereOutPut}]) });
    }
};
$(function () {
    CommonJs.Init();
});