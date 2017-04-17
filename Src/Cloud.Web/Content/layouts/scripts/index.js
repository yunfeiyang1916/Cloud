
//获取客户端数据
function getClientData() {
    $.ajax({
        url: "/Home/GetClientData",
        type: "get",
        //使用同步加载
        async: false,
        success: function (data) {
            if (data.Status === 1) {
                top.clientData = data.Data;
            } else {
                cloud.modal.alert(data.Msg, data.Status);
            }
        }
    });
}
//生成菜单Html
function renderMenuHtml() {
    var permissionManager = top.clientData ? top.clientData.PermissionManager : null;
    if (permissionManager && permissionManager.Permissions && permissionManager.Permissions.length > 0) {
        var permissions = permissionManager.Permissions;
        var html = "";
        $.each(permissions, function (key, value) {
            var row = value.Menu;
            if (row.ParentID === 0) {
                //是否可见
                if (row.Visible) {
                    var icon = row.Icon ? '<i class="fa ' + row.Icon + '"></i>' : "";
                    html += '<li>';
                    html += '<a data-id="' + row.ID + '" href="#" class="dropdown-toggle">' + icon + '<span>' + row.Name + '</span><i class="fa fa-angle-right drop-icon"></i></a>';
                    var childs = value.Childs;
                    if (childs && childs.length > 0) {
                        html += '<ul class="submenu">';
                        $.each(childs, function (k, v) {
                            var subRow = v;
                            //是否可见
                            if (subRow.Visible) {
                                var subIcon = subRow.Icon ? '<i class="fa ' + subRow.Icon + '"></i>' : "";
                                html += '<li>';
                                html += '<a class="menuItem" data-id="' + subRow.ID + '" href="' + (subRow.Url ? subRow.Url : "") + '" data-index="' + subRow.Sort + '">' + subIcon + '<span>' + subRow.Name + '</span></a>';
                                html += '</li>';
                            }
                        });
                        html += '</ul>';
                    }
                    html += '</li>';
                }
            }
        });
        $("#nav-menu").prepend(html);
    }
    //绑定父菜单的展开与折叠事件
    bindMenuCollapse();
    //绑定菜单缩放事件
    bindMenuZoom();
}
//绑定父菜单的展开与折叠事件
function bindMenuCollapse() {
    $('#sidebar-nav,#nav-col-submenu').on('click', '.dropdown-toggle', function (e) {
        e.preventDefault();
        var $item = $(this).parent();
        if (!$item.hasClass('open')) {
            $item.parent().find('.open .submenu').slideUp('fast');
            $item.parent().find('.open').toggleClass('open');
        }
        $item.toggleClass('open');
        if ($item.hasClass('open')) {
            $item.children('.submenu').slideDown('fast', function () {
                var _height1 = $(window).height() - 92 - $item.position().top;
                var _height2 = $item.find('ul.submenu').height() + 10;
                var _height3 = _height2 > _height1 ? _height1 : _height2;
                $item.find('ul.submenu').css({
                    overflow: "auto",
                    height: _height3
                })
            });
        }
        else {
            $item.children('.submenu').slideUp('fast');
        }
    });
}
//绑定菜单缩放事件
function bindMenuZoom() {
    //缩放按钮点击事件
    $("#make-small-nav").click(function (e) {
        $('#page-wrapper').toggleClass('nav-small');
    });
    //鼠标进入缩放后的父菜单触发
    $('body').on('mouseenter', '#page-wrapper.nav-small #sidebar-nav .dropdown-toggle', function (e) {
        if ($(document).width() >= 992) {
            var $item = $(this).parent();
            if ($('body').hasClass('fixed-leftmenu')) {
                var topPosition = $item.position().top;

                if ((topPosition + 4 * $(this).outerHeight()) >= $(window).height()) {
                    topPosition -= 6 * $(this).outerHeight();
                }
                $('#nav-col-submenu').html($item.children('.submenu').clone());
                $('#nav-col-submenu > .submenu').css({ 'top': topPosition });
            }

            $item.addClass('open');
            $item.children('.submenu').slideDown('fast');
        }
    });
    $('body').on('mouseleave', '#page-wrapper.nav-small #sidebar-nav > .nav-pills > li', function (e) {
        if ($(document).width() >= 992) {
            var $item = $(this);
            if ($item.hasClass('open')) {
                $item.find('.open .submenu').slideUp('fast');
                $item.find('.open').removeClass('open');
                $item.children('.submenu').slideUp('fast');
            }
            $item.removeClass('open');
        }
    });
    $('body').on('mouseenter', '#page-wrapper.nav-small #sidebar-nav a:not(.dropdown-toggle)', function (e) {
        if ($('body').hasClass('fixed-leftmenu')) {
            $('#nav-col-submenu').html('');
        }
    });
    $('body').on('mouseleave', '#page-wrapper.nav-small #nav-col', function (e) {
        if ($('body').hasClass('fixed-leftmenu')) {
            $('#nav-col-submenu').html('');
        }
    });
}
//绑定页面事件
function bindPageEvent() {
    //绑定头部搜索栏点击事件
    $('.mobile-search').click(function (e) {
        e.preventDefault();
        $('.mobile-search').addClass('active');
        $('.mobile-search form input.form-control').focus();
    });
    //鼠标弹起时移除头部搜索栏激活事件
    $(document).mouseup(function (e) {
        var container = $('.mobile-search');
        if (!container.is(e.target) && container.has(e.target).length === 0) // ... nor a descendant of the container
        {
            container.removeClass('active');
        }
    });
    //初始化主窗体高度
    $("#content-wrapper").find('.mainContent').height($(window).height() - 100);
    //绑定调整浏览器窗口大小事件
    $(window).resize(function (e) {
        $("#content-wrapper").find('.mainContent').height($(window).height() - 100);
    });
    //页面加载完毕事件
    $(window).load(function () {
        window.setTimeout(function () {
            $('#ajax-loader').fadeOut();
        }, 300);
    });
}
//写入本地存储
function writeStorage(storage, key, value) {
    if (storage) {
        try {
            localStorage.setItem(key, value);
        }
        catch (e) { console.log(e); }
    }
}
//移除class前缀
$.fn.removeClassPrefix = function (prefix) {
    this.each(function (i, el) {
        var classes = el.className.split(" ").filter(function (c) {
            return c.lastIndexOf(prefix, 0) !== 0;
        });
        el.className = classes.join(" ");
    });
    return this;
};
//皮肤切换
function toggleSkin() {
    //测试浏览器是否支持本地存储
    var storage, fail, uid;
    try {
        uid = new Date();
        (storage = window.localStorage).setItem(uid, uid);
        //存进去的值与取出来的是否相等
        fail = (storage.getItem(uid) != uid);
        storage.removeItem(uid);
        //失败，说明该浏览器不支持本地存储
        fail && (storage = false);
    } catch (e) { }
    //如果浏览器支持本地存储，则用来存储皮肤设置
    if (storage) {
        //皮肤设置
        var usedSkin = localStorage.getItem('config-skin');
        if (usedSkin != '' && usedSkin != null) {
            document.body.className = usedSkin;
            $('#skin-colors .skin-changer').removeClass('active');
            $('#skin-colors .skin-changer[data-skin="' + usedSkin + '"]').addClass('active');
        }
        else {
            //默认皮肤设置为蓝色渐变
            document.body.className = 'theme-blue-gradient';
            localStorage.setItem('config-skin', "theme-blue-gradient");
        }
    }
    else {
        document.body.className = 'theme-blue';
    }

    $('#config-tool-cog').on('click', function () {
        $('#config-tool').toggleClass('closed');
    });
    $('#config-fixed-header').on('change', function () {
        var fixedHeader = '';
        if ($(this).is(':checked')) {
            $('body').addClass('fixed-header');
            fixedHeader = 'fixed-header';
        }
        else {
            $('body').removeClass('fixed-header');
            if ($('#config-fixed-sidebar').is(':checked')) {
                $('#config-fixed-sidebar').prop('checked', false);
                $('#config-fixed-sidebar').trigger('change'); location.reload();
            }
        }
    });
    $('#skin-colors .skin-changer').on('click', function () {
        $('body').removeClassPrefix('theme-');
        $('body').addClass($(this).data('skin'));
        $('#skin-colors .skin-changer').removeClass('active');
        $(this).addClass('active');
        writeStorage(storage, 'config-skin', $(this).data('skin'));
    });
}

$(function () {
    //加载客户端数据
    getClientData();
    //生成菜单Html
    renderMenuHtml();
    //设置用户信息
    if (top.clientData && top.clientData.Admin) {
        var admin = top.clientData.Admin;
        $("#adminName").text(admin.Name);
        $("#adminInfo").text(admin.Name + ";" + admin.DisplayName);
    }
    //绑定页面事件
    bindPageEvent();
    //皮肤切换
    toggleSkin();
});
