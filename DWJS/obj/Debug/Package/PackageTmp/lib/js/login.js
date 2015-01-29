﻿LG.login = function () {
    $(document).bind('keydown.login', function (e) {
        if (e.keyCode == 13) {
            dologin();
        }
    });

    if (!window.loginWin) {
        var loginPanle = $("<form></form>");
        loginPanle.ligerForm({
            fields: [
                { display: '用户名', name: 'LoginUserName' },
                { display: '密码', name: 'LoginPassword', type: 'password' }
            ]
        });

        window.loginWin = $.ligerDialog.open({
            width: 400,
            height: 140, top: 200,
            isResize: true,
            title: '用户登录',
            target: loginPanle,
            buttons: [
            { text: '取消', onclick: function () {

                window.loginWin.hide();
                $(document).unbind('keydown.login');
            }
            },
            { text: '登录', onclick: function () {
                dologin();
            }
            }
            ]
        });
    }
    else {
        window.loginWin.show();
    }

    function dologin() {
        var username = $("#LoginUserName").val();
        var password = $("#LoginPassword").val();
        var url = "";
        if (rootUrl != null) {
            url = rootUrl + '/validate.ashx';
        }


        $.ajax({
            type: 'post', cache: false, dataType: 'json', /*修改*/

            url: url || '../handler/validate.ashx',     /*修改*/
            data: [
                    { name: 'Action', value: 'Login' },
                    { name: 'txt_username', value: username }, /*修改*/
                    { name: 'txt_password', value: password} /*修改*/
                    ],
            success: function (result) {
                if (!result) {
                    LG.showError('登陆失败,账号或密码有误!');
                    $("#LoginUserName").focus();
                    return;
                } else {
                    location.href = location.href;
                }
            },
            error: function () {
                LG.showError('发送系统错误,请与系统管理员联系!');
            },
            beforeSend: function () {
                LG.showLoading('正在登录中...');
            },
            complete: function () {
                LG.hideLoading();
            }
        });
    }

};