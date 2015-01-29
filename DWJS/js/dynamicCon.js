//动态内容区JS  by xcl

(function ($) {
    var defaults = {
        container: ".dynamicCon", //最外层的容器class
        temp: ".temp", //模板层class
        items: ".items", //具体行class
        minCount: 1, //具体行的最小数量 
        maxCount: 50, //具体行的最大数量
        addBtn: ".addBtn", //添加按钮class
        delBtn: ".delBtn"//删除按钮class
    }
    $.extend({
        DynamicCon: function (options) {
            options = $.extend(defaults, options);
            $conAll = $(options.container);
            $conAll.each(function (i) {
                $con = $(this);
                $temp = $con.find(options.temp); //模板行
                $temp.attr({ "class": options.items.substring(1, options.items.length) }).wrap("<div style='display:none'></div>");
                var tempHtml = escape($temp.parent().html());
                $temp.parent().remove();
                //添加行事件
                $con.find(options.addBtn).live("click", function () {
                    $con = $($conAll[i]);
                    if ($con.find(options.items).length == options.maxCount) {
                        alert("最多只能添加" + options.maxCount + "行！"); return false;
                    }
                    $(this).closest(options.items).after(unescape(tempHtml));
                });
                //删除行事件
                $con.find(options.delBtn).live("click", function () {
                    $con = $($conAll[i]);
                    if ($con.find(options.items).length == options.minCount) {
                        alert("最少要有" + options.minCount + "行！"); return false;
                    }
                    $(this).closest(options.items).remove();
                });
            });


        }
    });
})(jQuery);