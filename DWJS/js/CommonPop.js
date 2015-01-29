//共公弹出窗口页
var CommonPop = {
    Url: "",

    /*********常用工具开始*********/
    //清理缓存
    ClearCache: function (obj) {
        $.XCLGoAjax({ url: CommonPop.Url + "Public/Comm.aspx", data: { type: "clearCache", method: "ajax", v: Math.random() }, beforeSendMsg: "正在清理缓存，请稍后...", isRefreshSelf: true });
    },
    //退出
    LoginOut: function () {
        art.dialog.confirm("您确定要退出本系统吗？", function () {
            $.XCLGoAjax({ url: CommonPop.Url + "Login.aspx", data: { type: "loginOut", method: "ajax", v: Math.random() }, beforeSendMsg: "正在退出，请稍后...", isRefreshSelf: true });
        }, function () { });
    },
    /*********常用工具结束*********/



    /**********权限相关开始************/
    //添加角色
    Power_RoleAdd: function (obj) {
        art.dialog.open(CommonPop.Url + 'Modules/Power/RoleAdd.aspx?type=add', { title: '新建角色', width: 1000, height: 500 });
        return false;
    },
    //修改角色
    Power_RoleEdit: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Power/RoleAdd.aspx?type=update&id=' + id, { title: '修改角色——' + title, width: 1000, height: 500 });
        return false;
    },
    //删除角色
    Power_RoleDel: function (obj, ids, type) {
        if (ids == "") { art.dialog.tips("请至少选择一条记录进行操作！"); return false; }
        art.dialog.confirm("您确定要删除此信息吗？", function () {
            $.XCLGoAjax({
                obj: obj,
                type: "GET",
                data: { ids: ids, method: "ajax", type: "del" },
                url: CommonPop.Url + "Modules/Power/RoleList.aspx",
                beforeSendMsg: "正在删除中，请稍后......"
            });
        }, function () { })
    },
    //查看角色
    Power_RoleShow: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Power/RoleShow.aspx?id=' + id, { title: '查看角色——' + title, width: 1000, height: 500 });
        return false;
    },

    //添加权限
    Power_RightAdd: function (obj) {
        art.dialog.open(CommonPop.Url + 'Modules/Power/RightAdd.aspx?type=add', { title: '新建权限', width: 800, height: 300 });
        return false;
    },
    //修改权限
    Power_RightEdit: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Power/RightAdd.aspx?type=update&id=' + id, { title: '修改权限——' + title, width: 800, height: 300 });
        return false;
    },
    //删除权限
    Power_RightDel: function (obj, ids, type) {
        if (ids == "") { art.dialog.tips("请至少选择一条记录进行操作！"); return false; }
        art.dialog.confirm("您确定要删除此信息吗？", function () {
            $.XCLGoAjax({
                obj: obj,
                type: "GET",
                data: { ids: ids, method: "ajax", type: "del" },
                url: CommonPop.Url + "Modules/Power/RightList.aspx",
                beforeSendMsg: "正在删除中，请稍后......"
            });
        }, function () { })
    },

    //添加字典库
    Power_DicAdd: function (obj, id) {
        art.dialog.open(CommonPop.Url + 'Modules/Power/DicAdd.aspx?type=add&id=' + id, { title: '新建字典库', width: 800, height: 300 });
        return false;
    },
    //修改字典库
    Power_DicEdit: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Power/DicAdd.aspx?type=update&id=' + id, { title: '修改字典库——' + title, width: 800, height: 300 });
        return false;
    },
    //删除字典库
    Power_DicDel: function (obj, ids, type) {
        if (ids == "") { art.dialog.tips("请至少选择一条记录进行操作！"); return false; }
        art.dialog.confirm("您确定要删除此信息吗？", function () {
            $.XCLGoAjax({
                obj: obj,
                type: "GET",
                data: { ids: ids, method: "ajax", type: "del" },
                url: CommonPop.Url + "Modules/Power/DicList.aspx",
                beforeSendMsg: "正在删除中，请稍后......"
            });
        }, function () { })
    },
    /**********权限相关结束************/



    /*********用户信息相关开始***********/
    //添加用户
    Users_UserAdd: function (obj) {
        art.dialog.open(CommonPop.Url + 'Modules/Users/UserAdd.aspx?type=add', { title: '新建用户信息', width: 1100, height: 500 });
        return false;
    },
    //修改用户
    Users_UserEdit: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Users/UserAdd.aspx?type=update&id=' + id, { title: '修改用户信息——' + title, width: 1100, height: 500 });
        return false;
    },
    //删除用户
    Users_UserDel: function (obj, ids, type) {
        if (ids == "") { art.dialog.tips("请至少选择一条记录进行操作！"); return false; }
        art.dialog.confirm("您确定要删除此信息吗？", function () {
            $.XCLGoAjax({
                obj: obj,
                type: "GET",
                data: { ids: ids, method: "ajax", type: "del" },
                url: CommonPop.Url + "Modules/Users/UserList.aspx",
                beforeSendMsg: "正在删除中，请稍后......"
            });
        }, function () { })
    },
    //查看用户
    Users_UserShow: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Users/UserShow.aspx?id=' + id, { title: '查看用户——' + title, width: 1000, height: 500 });
        return false;
    },
    //给用户单独授权
    Users_UserShouquan: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Users/UserSetRight.aspx?type=add&id=' + id, { title: '给用户单独授权——' + title, width: 1000, height: 500 });
        return false;
    },
    /*********用户信息相关结束***********/



    /*********蓄电池管理相关开始***********/

    //基站信息添加
    Battery_SiteInfo_SiteInfoAdd: function (obj) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/SiteInfo/SiteInfoAdd.aspx?type=add', { title: '新建基站信息', width: 900, height: 450 });
        return false;
    },
    //基站信息修改
    Battery_SiteInfo_SiteInfoEdit: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/SiteInfo/SiteInfoAdd.aspx?type=update&siteInfoId=' + id, { title: '修改基站信息——' + title, width: 900, height: 450 });
        return false;
    },
    //基站信息删除
    Battery_SiteInfo_SiteInfoDel: function (obj, ids, type) {
        if (ids == "") { art.dialog.tips("请至少选择一条记录进行操作！"); return false; }
        art.dialog.confirm("您确定要删除此基站及与其相关的其它所有信息吗？", function () {
            $.XCLGoAjax({
                obj: obj,
                type: "GET",
                data: { ids: ids, method: "ajax", type: "del" },
                url: CommonPop.Url + "Modules/Battery/SiteInfo/SiteInfoList.aspx",
                isRefreshSelf: true,
                isAlertShowMsg: true,
                beforeSendMsg: "正在删除中，请稍后......"
            });
        }, function () { })
    },
    //基站信息查看
    Battery_SiteInfo_SiteInfoShow: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/SiteInfo/SiteInfoShow.aspx?siteInfoId=' + id, { title: '查看基站信息——' + title, width: 1000, height: 500 });
        return false;
    },
    //基站信息导入
    Battery_SiteInfo_SiteInfoInput: function (obj) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/SiteInfo/SiteInfoInput.aspx?type=input', { title: '导入基站信息', width: 800, height: 500 });
        return false;
    },
    //基站的电池组信息列表
    Battery_BatteryInfo_BatteryInfoList: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/BatteryInfo/BatteryInfoList.aspx?siteInfoId=' + id, { title: '查看基站电池组——' + title, width: 1200, height: 550 });
        return false;
    },
    //基站的电池组信息添加
    Battery_BatteryInfo_BatteryInfoAdd: function (obj, id) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/BatteryInfo/BatteryInfoAdd.aspx?type=add&siteInfoId=' + id, { title: '新建电池组信息', width: 1200, height: 550 });
        return false;
    },
    //基站的电池组信息修改
    Battery_BatteryInfo_BatteryInfoEdit: function (obj, id, title, type) {
        var t = "";
        if (type == "changeAll") {
            t = "替换电池组——" + title;
        } else {
            t = '修改电池组信息——' + title;
        }
        art.dialog.open(CommonPop.Url + 'Modules/Battery/BatteryInfo/BatteryInfoAdd.aspx?type=update&batteryId=' + id + '&changeType=' + type, { title: t, width: 1200, height: 550 });
        return false;
    },
    //基站的电池组信息删除
    Battery_BatteryInfo_BatteryInfoDel: function (obj, ids, type) {
        if (ids == "") { art.dialog.tips("请至少选择一条记录进行操作！"); return false; }
        art.dialog.confirm("您确定要删除此电池组及与其相关的其它所有信息吗？", function () {
            $.XCLGoAjax({
                obj: obj,
                type: "GET",
                data: { ids: ids, method: "ajax", type: "del" },
                url: CommonPop.Url + "Modules/Battery/BatteryInfo/BatteryInfoList.aspx",
                isRefreshSelf: true,
                isAlertShowMsg: true,
                beforeSendMsg: "正在删除中，请稍后......"
            });
        }, function () { })
    },
    //基站的电池组信息导入
    Battery_BatteryInfo_BatteryInfoInput: function (obj, id) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/BatteryInfo/BatteryInfoInput.aspx?type=input&siteInfoId=' + id, { title: '导入电池组信息', width: 800, height: 500 });
        return false;
    },
    //基站电池组日志列表
    Battery_BatteryInfo_BatteryChangeLogList: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/BatteryInfo/BatteryChangeLogList.aspx?batteryId=' + id, { title: '查看电池组日志——' + title, width: 1200, height: 550 });
        return false;
    },
    //基站的电池组信息_单体替换
    Battery_BatteryInfo_BatteryUnitChange: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/BatteryInfo/BatteryUnitChangeList.aspx?type=update&batteryId=' + id, { title: '查看电池组单体替换——' + title, width: 1200, height: 550 });
        return false;
    },

    //电池全容量测试列表
    Battery_VolumeTest_VolumeTestList: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/VolumeTest/VolumeTestList.aspx?batteryId=' + id, { title: '查看电池组全容量测试——' + title, width: 1200, height: 550 });
        return false;
    },
    //电池全容量测试添加
    Battery_VolumeTest_VolumeTestAdd: function (obj, id) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/VolumeTest/VolumeTestAdd.aspx?type=add&batteryId=' + id, { title: '新建全容量测试信息', width: 1200, height: 550 });
        return false;
    },
    //电池全容量测试修改
    Battery_VolumeTest_VolumeTestEdit: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/VolumeTest/VolumeTestAdd.aspx?type=update&batteryVolumeTestID=' + id, { title: '修改全容量测试信息——' + title, width: 1200, height: 550 });
        return false;
    },
    //电池全容量测试删除
    Battery_VolumeTest_VolumeTestDel: function (obj, ids, type) {
        if (ids == "") { art.dialog.tips("请至少选择一条记录进行操作！"); return false; }
        art.dialog.confirm("您确定要删除此信息吗？", function () {
            $.XCLGoAjax({
                obj: obj,
                type: "GET",
                data: { ids: ids, method: "ajax", type: "del" },
                url: CommonPop.Url + "Modules/Battery/VolumeTest/VolumeTestList.aspx",
                isRefreshSelf: true,
                isAlertShowMsg: true,
                beforeSendMsg: "正在删除中，请稍后......"
            });
        }, function () { })
    },
    //电池全容量测试导入
    Battery_VolumeTest_VolumeTestInput: function (obj, id) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/VolumeTest/VolumeTestInput.aspx?type=input&batteryId=' + id, { title: '导入全容量测试信息', width: 800, height: 500 });
        return false;
    },
    //电池全容量测试日志列表
    Battery_VolumeTest_VolumeTestChangeLogList: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/VolumeTest/VolumeTestChangeLogList.aspx?batteryVolumeTestID=' + id, { title: '电池全容量测试日志列表——' + title, width: 1200, height: 550 });
        return false;
    },
    //电池维护事件列表
    Battery_Service_BatteryServiceList: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Battery/Service/ServiceList.aspx?batteryId=' + id, { title: '查看电池组维护事件——' + title, width: 1200, height: 550 });
        return false;
    },
    /*********蓄电池管理相关结束***********/


    /**********辅助功能管理开始***********/
    //通知公告添加
    Notice_NoticeAdd: function (obj) {
        art.dialog.open(CommonPop.Url + 'Modules/Notice/NoticeAdd.aspx?type=add', { title: '添加通知公告', width: 1000, height: 500 });
        return false;
    },
    //通知公告编辑
    Notice_NoticeEdit: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Notice/NoticeAdd.aspx?type=update&noticeId=' + id, { title: '修改通知公告——' + title, width: 1000, height: 500 });
        return false;
    },
    //通知公告查看
    Notice_NoticeShow: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Notice/NoticeShow.aspx?noticeId=' + id, { title: '查看通知公告——' + title, width: 1000, height: 500 });
        return false;
    },
    //通知公告删除
    Notice_NoticeDel: function (obj, ids, type) {
        if (ids == "") { art.dialog.tips("请至少选择一条记录进行操作！"); return false; }
        art.dialog.confirm("您确定要删除此信息吗？", function () {
            $.XCLGoAjax({
                obj: obj,
                type: "GET",
                data: { ids: ids, method: "ajax", type: "del" },
                url: CommonPop.Url + "Modules/Notice/NoticeList.aspx",
                isRefreshSelf: true,
                isAlertShowMsg: true,
                beforeSendMsg: "正在删除中，请稍后......"
            });
        }, function () { })
    },
    /**********辅助功能管理结束***********/




    /***********电费管理开始*********/
    //电费基站信息添加
    Elec_ElecSiteInfo_ElecSiteInfoAdd: function (obj) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecSiteInfo/ElecSiteInfoAdd.aspx?type=add', { title: '添加基站信息', width: 1000, height: 500 });
        return false;
    },
    //电费基站信息修改
    Elec_ElecSiteInfo_ElecSiteInfoEdit: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecSiteInfo/ElecSiteInfoAdd.aspx?type=update&siteInfoId=' + id, { title: '修改基站信息——' + title, width: 1000, height: 500 });
        return false;
    },
    //电费基站信息删除
    Elec_ElecSiteInfo_ElecSiteInfoDel: function (obj, ids, type) {
        if (ids == "") { art.dialog.tips("请至少选择一条记录进行操作！"); return false; }
        art.dialog.confirm("您确定要删除此基站及与其相关的其它所有信息吗？", function () {
            $.XCLGoAjax({
                obj: obj,
                type: "GET",
                data: { ids: ids, method: "ajax", type: "del" },
                url: CommonPop.Url + "Modules/Elec/ElecSiteInfo/ElecSiteInfoList.aspx",
                isRefreshSelf: true,
                isAlertShowMsg: true,
                beforeSendMsg: "正在删除中，请稍后......"
            });
        }, function () { })
    },
    //电费基站信息查看
    Elec_ElecSiteInfo_ElecSiteInfoShow: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecSiteInfo/ElecSiteInfoShow.aspx?siteInfoId=' + id, { title: '查看基站信息——' + title, width: 800, height: 450 });
        return false;
    },
    //电费基站信息导入
    Elec_ElecSiteInfo_ElecSiteInfoInput: function (obj) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecSiteInfo/ElecSiteInfoInput.aspx?type=input', { title: '导入基站信息', width: 1000, height: 500 });
        return false;
    },

    //基站电表信息列表
    Elec_ElecMeter_ElecMeterList: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecMeter/ElecMeterList.aspx?siteInfoId=' + id, { title: '基站电表信息——' + title, width: 1200, height: 550 });
        return false;
    },
    //基站电表信息添加
    Elec_ElecMeter_ElecMeterAdd: function (obj, id) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecMeter/ElecMeterAdd.aspx?type=add&siteInfoId=' + id, { title: '添加基站电表信息', width: 1200, height: 550 });
        return false;
    },
    //基站电表信息修改
    Elec_ElecMeter_ElecMeterEdit: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecMeter/ElecMeterAdd.aspx?type=update&elecMeterID=' + id, { title: '修改基站电表信息——' + title, width: 1200, height: 550 });
        return false;
    },
    //基站电表信息查看
    Elec_ElecMeter_ElecMeterShow: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecMeter/ElecMeterShow.aspx?elecMeterID=' + id, { title: '查看基站电表信息——' + title, width: 1200, height: 550 });
        return false;
    },
    //基站电表信息删除
    Elec_ElecMeter_ElecMeterDel: function (obj, ids, type) {
        if (ids == "") { art.dialog.tips("请至少选择一条记录进行操作！"); return false; }
        art.dialog.confirm("您确定要删除此信息吗？", function () {
            $.XCLGoAjax({
                obj: obj,
                type: "GET",
                data: { ids: ids, method: "ajax", type: "del" },
                url: CommonPop.Url + "Modules/Elec/ElecMeter/ElecMeterList.aspx",
                isRefreshSelf: true,
                isAlertShowMsg: true,
                beforeSendMsg: "正在删除中，请稍后......"
            });
        }, function () { })
    },
    //基站电表信息导入
    Elec_ElecMeter_ElecMeterInput: function (obj) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecMeter/ElecMeterInput.aspx?type=input', { title: '导入电表信息', width: 1000, height: 500 });
        return false;
    },
    //基站电表信息变更记录列表
    Elec_ElecMeter_ElecMeterChangeLogList: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecMeter/ElecMeterChangeLogList.aspx?elecMeterId=' + id, { title: '电表变更记录——' + title, width: 1200, height: 550 });
        return false;
    },



    //电表缴费信息列表
    Elec_ElecMeterPay_ElecMeterPayList: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecMeterPay/ElecMeterPayList.aspx?elecMeterId=' + id, { title: '电表缴费信息列表——' + title, width: 1200, height: 550 });
        return false;
    },
    //电表缴费信息添加
    Elec_ElecMeterPay_ElecMeterPayAdd: function (obj, id) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecMeterPay/ElecMeterPayAdd.aspx?type=add&elecMeterId=' + id, { title: '电表缴费信息添加', width: 1200, height: 550 });
        return false;
    },
    //电表缴费信息修改
    Elec_ElecMeterPay_ElecMeterPayEdit: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecMeterPay/ElecMeterPayAdd.aspx?type=update&elecMeterPayId=' + id, { title: '电表缴费信息修改——' + title, width: 1200, height: 550 });
        return false;
    },
    //电表缴费信息查看
    Elec_ElecMeterPay_ElecMeterPayShow: function (obj, id, title) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecMeterPay/ElecMeterPayShow.aspx?elecMeterPayId=' + id, { title: '电表缴费信息查看——' + title, width: 1200, height: 550 });
        return false;
    },
    //电表缴费信息删除
    Elec_ElecMeterPay_ElecMeterPayDel: function (obj, ids, type) {
        if (ids == "") { art.dialog.tips("请至少选择一条记录进行操作！"); return false; }
        art.dialog.confirm("您确定要删除此信息吗？", function () {
            $.XCLGoAjax({
                obj: obj,
                type: "GET",
                data: { ids: ids, method: "ajax", type: "del" },
                url: CommonPop.Url + "Modules/Elec/ElecMeterPay/ElecMeterPayList.aspx",
                isRefreshSelf: true,
                isAlertShowMsg: true,
                beforeSendMsg: "正在删除中，请稍后......"
            });
        }, function () { })
    },
    //电表缴费信息导入
    Elec_ElecMeterPay_ElecMeterPayInput: function (obj) {
        art.dialog.open(CommonPop.Url + 'Modules/Elec/ElecMeterPay/ElecMeterInput.aspx?type=input', { title: '导入电表缴费信息', width: 1000, height: 500 });
        return false;
    }
    /***********电费管理结束**************/
};