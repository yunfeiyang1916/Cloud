(function ($) {
    /***登陆对象*/
    $.login = {
        /**格式化登陆提示信息**/
        formMessage: function (msg) {
            $('.login_tips').find('.tips_msg').remove();
            $('.login_tips').append('<div class="tips_msg"><i class="fa fa-question-circle"></i>' + msg + '</div>');
            //2秒后清空错误信息
            //setTimeout(function () {
            //    $('.login_tips').find('.tips_msg').remove();
            //}, 2000);
        },
        loginClick: function () {
            var $username = $("#txt_account");
            var $password = $("#txt_password");
            var $code = $("#txt_code");
            if ($username.val() == "") {
                $username.focus();
                $.login.formMessage('请输入用户名/手机号/邮箱。');
                return false;
            } else if ($password.val() == "") {
                $password.focus();
                $.login.formMessage('请输入登录密码。');
                return false;
            } else if ($code.val() == "") {
                $code.focus();
                $.login.formMessage('请输入验证码。');
                return false;
            } else {
                $("#login_button").attr('disabled', 'disabled').find('span').html("loading...");
                var rememberme = $("#rememberme").prop("checked");
                $.ajax({
                    url: "/Login/Login",
                    data: { username: $.trim($username.val()), password: $.md5($.trim($password.val())), code: $.trim($code.val()), rememberme: rememberme },
                    type: "post",
                    dataType: "json",
                    success: function (data) {
                        if (data.Status === 1) {
                            $("#login_button").find('span').html("登录成功，正在跳转...");
                            window.setTimeout(function () {
                                window.location.href = "/Home/Index";
                            }, 500);
                        } else {
                            $("#login_button").removeAttr('disabled').find('span').html("登录");
                            $("#switchCode").trigger("click");
                            $code.val('');
                            $.login.formMessage(data.Msg);
                        }
                    },
                    error: function (error) {
                        $("#login_button").removeAttr('disabled').find('span').html("登录");
                        $("#switchCode").trigger("click");
                        $code.val('');
                        $.login.formMessage(error.statusText);
                    }
                });
            }
        },
        /**初始化**/
        init: function () {
            $('.wrapper').height($(window).height());
            $(".container").css("margin-top", ($(window).height() - $(".container").height()) / 2 - 50);
            $(window).resize(function (e) {
                $('.wrapper').height($(window).height());
                $(".container").css("margin-top", ($(window).height() - $(".container").height()) / 2 - 50);
            });
            /**切换验证码**/
            $("#switchCode").click(function () {
                $("#imgcode").attr("src", "/Login/GetAuthCode?time=" + Math.random());
            });
            //登陆错误
            var login_error = top.$.cookie('CookieLoginError');
            if (login_error != null) {
                switch (login_error) {
                    case "Timeout":
                        $.login.formMessage("系统登录已超时,请重新登录");
                        break;
                    case "OnLine":
                        $.login.formMessage("您的帐号已在其它地方登录,请重新登录");
                        break;
                    case "-1":
                        $.login.formMessage("系统未知错误,请重新登录");
                        break;
                }
                top.$.cookie('CookieLoginError', '', { path: "/", expires: -1 });
            }
            $("#login_button").click(function () {
                $.login.loginClick();
            });
            document.onkeydown = function (e) {
                if (!e) e = window.event;
                if ((e.keyCode || e.which) == 13) {
                    document.getElementById("login_button").focus();
                    document.getElementById("login_button").click();
                }
            }
        }
    };
    $(function () {
        $.login.init();
    });
})(jQuery);