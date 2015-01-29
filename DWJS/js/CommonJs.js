var CommonJs = {
    Init: function () {
        //导出按钮
        $("a.aOutPutInfo").attr({ "href": CommonJs.AddUrlParam(location.href, [{ "method": "ajax" }, { "type": "output"}]) });

        //文本溢出处理
        $("div.isOverFlow").textEllipsis({ line: 1 }).each(function (i) {
            var v = $(this).html();
            $($("div.isOverFlow").get(i)).poshytip({
                content: "<div style='width:200px;'>" + v + "</div>",
                className: CommonJs.PoshytipClassName,
                alignX: 'center',
                alignY: 'bottom',
                fade: false,
                slide: false
            });
        });

        //单体列表处理
        $thHead = $("table.tableList th[rel='tdHeadUnit']:gt(0)");
        $thHead.hide();
        $thHeadFirst = $("table.tableList th[rel='tdHeadUnit']:eq(0)");
        $thHeadFirst.append("<span><a href='javascript:void(0);' style='color:#ff0;' class='aTrUnitShow'>[更多...]</a></span>");
        $("a.aTrUnitShow").live("click", function () {
            if ($thHead.css("display") == "none") {
                CommonJs.ShowOrHideUnitInfo("show");
            } else {
                CommonJs.ShowOrHideUnitInfo("hide");
            }
        });
        CommonJs.ShowOrHideUnitInfo("hide");

        //溢出的表格滚动条处理
        CommonJs.ResizeWin();
        $("div.divScrollOverFlow").closest("td").bind("resize", function () {
            CommonJs.ResizeWin();
            return false;
        });

        //tips
        $(".tipClass").poshytip({ className: CommonJs.PoshytipClassName });
        $(".moreTipClass").poshytip({
            className: CommonJs.PoshytipClassName,
            alignX: 'center',
            alignY: 'bottom',
            fade: false,
            slide: false
        });
    },
    ResizeWin: function () {
        $("div.divScrollOverFlow").width($("div.divScrollOverFlow").closest("td").width());
    },
    ResizeWinMenuChange: function () {
        $("div.divScrollOverFlow").width($("div.divScrollOverFlow").closest("td").width() - 150);
    },
    MenuCookieName: 'MenuCookieName', //菜单展开或关闭的cookie
    PoshytipClassName: '', //Poshytip插件的主题样式类（注意需要引用对应的CSS）
    Url: '', //根路径
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
    //然后图片引用位置写上<img src='地址' onload='AutoResizeImage(100,80,this)' />即可。
    AutoResizeImage: function (maxWidth, maxHeight, objImg) {
        var img = new Image();
        img.src = objImg.src;
        var hRatio;
        var wRatio;
        var Ratio = 1;
        var w = img.width;
        var h = img.height;
        wRatio = maxWidth / w;
        hRatio = maxHeight / h;
        if (maxWidth == 0 && maxHeight == 0) {
            Ratio = 1;
        } else if (maxWidth == 0) {//
            if (hRatio < 1) Ratio = hRatio;
        } else if (maxHeight == 0) {
            if (wRatio < 1) Ratio = wRatio;
        } else if (wRatio < 1 || hRatio < 1) {
            Ratio = (wRatio <= hRatio ? wRatio : hRatio);
        }
        if (Ratio < 1) {
            w = w * Ratio;
            h = h * Ratio;
        }
        objImg.height = h;
        objImg.width = w;
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
    //单击列表上的数字进行跳转查询（把它转为查询控件的URL形式）
    goToSearch: function (url, fieldName, dataType, symbol, value, isPop, title) { //1:要跳转的页面地址 2:字段名  3:字段类型(参考搜索控件) 4:符号  5：字段值  6:若为1，则弹窗  7:弹窗标题
        var newJson = CommonJs.GetUrlParams(url);
        newJson["where"] = "-1|" + fieldName + "|" + dataType + "|" + symbol + "|" + escape(value) + "|-1|0"; //搜索控件where规则
        if (url.indexOf('?') > -1) {
            url = url.substring(0, url.indexOf('?'));
        }
        url = url + "?" + CommonJs.GetUrlByJson(newJson);
        if (isPop == "1") {
            //弹窗
            art.dialog.open(url, { title: title, width: 1100, height: 500 });
        }
        else {
            location.href = url;
        }
        return false;
    },
    //展开或隐藏
    OpenOrClose: function (obj) {
        $img = $(obj).find("img:eq(0)");
        $con = $(obj).closest(".OpenOrCloseCon");
        $dv = $con.find(".OpenOrCloseDiv");
        $dv.slideToggle("fast", function () {
            if ($dv.css("display") == "none") {
                $img.attr({ "src": CommonJs.Url + "Images/down.gif" });
            } else {
                $img.attr({ "src": CommonJs.Url + "Images/up.gif" });
            }
        });
    },
    //显示或隐藏列表中的单体信息
    ShowOrHideUnitInfo: function (type) {
        switch (type) {
            case "show":
                $(".tdUnitClass,th[rel='tdHeadUnit']").show();
                break;
            case "hide":
                $thHead = $("table.tableList th[rel='tdHeadUnit']:gt(0)");
                $thHead.hide();
                $thHeadFirst = $("table.tableList th[rel='tdHeadUnit']:eq(0)");
                $thHeadFirst.closest("table").find("tr").each(function () {
                    $(this).find(".tdUnitClass:gt(0)").hide();
                });
                break;
        }
    }
};

// $(function () {
//     CommonJs.Init();
// });