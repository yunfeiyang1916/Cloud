/*****************************************************
 * Author  : 云飞扬
 * Version : 1.0.000
 * Date    :  2017-03-22
 ****************************************************/
/**==================================================选项卡模块====================================================**/

//云平台js模块
var tab = tab || {};
(function ($) {
    /**
     * 初始化
     * @return {Void}  
     */
    tab.init = function () {
        //给菜单点击事件绑定打开选项卡方法
        $('.menuItem').on('click', tab.addTab);
        //给选项卡关闭按钮绑定关闭选项卡方法
        $('.menuTabs').on('click', '.menuTab i', tab.closeTab);
        //给选项卡绑定激活选项卡方法
        $('.menuTabs').on('click', '.menuTab', tab.activeTab);
        //绑定左滚动选项卡事件
        $('.tabLeft').on('click', tab.scrollTabLeft);
        //绑定右滚动选项卡事件
        $('.tabRight').on('click', tab.scrollTabRight);
        //绑定重新刷新选项卡事件
        $('.tabReload').on('click', tab.refreshTab);
        //绑定关闭当前选项卡事件
        $('.tabCloseCurrent').on('click', function () {
            $('.page-tabs-content').find('.active i').trigger("click");
        });
        //绑定全部关闭事件
        $('.tabCloseAll').on('click', function () {
            $('.page-tabs-content').children("[data-id]").find('.fa-remove').each(function () {
                $('.iframe[data-id="' + $(this).data('id') + '"]').remove();
                $(this).parents('a').remove();
            });
            $('.page-tabs-content').children("[data-id]:first").each(function () {
                $('.iframe[data-id="' + $(this).data('id') + '"]').show();
                $(this).addClass("active");
            });
            $('.page-tabs-content').css("margin-left", "0");
        });
        //绑定除此之外全部关闭事件
        $('.tabCloseOther').on('click', tab.closeOtherTabs);
        //绑定选项卡全屏显示事件
        $('.fullscreen').on('click', function () {
            if (!$(this).attr('fullscreen')) {
                $(this).attr('fullscreen', 'true');
                tab.requestFullScreen();
            } else {
                $(this).removeAttr('fullscreen')
                tab.exitFullscreen();
            }
        });
    };

    /**
     * 选项卡全屏显示
     * @return {Void}  
     */
    tab.requestFullScreen = function () {
        var de = document.documentElement;
        if (de.requestFullscreen) {
            de.requestFullscreen();
        } else if (de.mozRequestFullScreen) {
            de.mozRequestFullScreen();
        } else if (de.webkitRequestFullScreen) {
            de.webkitRequestFullScreen();
        }
    };
    /**
     * 退出全屏
     * @return {Void}  
     */
    tab.exitFullscreen = function () {
        var de = document;
        if (de.exitFullscreen) {
            de.exitFullscreen();
        } else if (de.mozCancelFullScreen) {
            de.mozCancelFullScreen();
        } else if (de.webkitCancelFullScreen) {
            de.webkitCancelFullScreen();
        }
    };
    /**
     * 添加（打开）选项卡
     * @return {Void}  
     */
    tab.addTab = function () {
        $("#header-nav>ul>li.open").removeClass("open");
        var that = $(this);
        //菜单id
        var dataId = that.attr('data-id');
        if (dataId) {
            top.$.cookie('currentMenuID', dataId, { path: "/" });
        }
        var url = that.attr('href');
        var menuName = $.trim(that.text());
        if (!url || $.trim(url).length == 0) {
            return false;
        }
        //标志，如果选项卡未打卡为true
        var flag = true;
        //遍历选项卡，查看是否已经打开该选项卡
        $('.menuTab').each(function (key, value) {
            var $value = $(value);
            if ($value.data('url') == url) {
                if (!$value.hasClass('active')) {
                    $value.addClass('active').siblings('.menuTab').removeClass('active');
                    tab.scrollToTab(this);
                    $('.mainContent .iframe').each(function (k, v) {
                        var $v = $(v);
                        if ($v.data('url') == url) {
                            $v.show().siblings('.iframe').hide();
                            return false;
                        }
                    });
                }
                flag = false;
                return false;
            }
        });
        //尚未打开选项卡，打开
        if (flag) {
            var str = '<a href="javascript:;" class="active menuTab" data-id="' + dataId + '" data-url="' + url + '">' + menuName + ' <i class="fa fa-remove"></i></a>';
            $('.menuTab').removeClass('active');
            var str1 = '<iframe class="iframe" id="iframe_' + dataId + '" name="iframe_' + dataId + '"  width="100%" height="100%" src="' + url + '" frameborder="0" data-id="' + dataId + '" data-url="' + url + '" seamless></iframe>';
            $('.mainContent').find('iframe.iframe').hide();
            $('.mainContent').append(str1);
            cloud.common.loading(true);
            $('.mainContent iframe:visible').load(function () {
                cloud.common.loading(false);
            });
            $('.menuTabs .page-tabs-content').append(str);
            tab.scrollToTab($('.menuTab.active'));
        }
        return false;
    };

    /**
     * 激活选项卡
     * @return {Void}  
     */
    tab.activeTab = function () {
        var that = $(this);
        var currentId = that.data('id');
        if (!that.hasClass('active')) {
            $('.mainContent .iframe').each(function (key, value) {
                var $value = $(value);
                if ($value.data('id') == currentId) {
                    $value.show().siblings('.iframe').hide();
                    return false;
                }
            });
            that.addClass('active').siblings('.menuTab').removeClass('active');
            tab.scrollToTab(this);
        }
    };

    /**
     * 刷新选项卡
     * @return {Void}  
     */
    tab.refreshTab = function () {
        var currentId = $('.page-tabs-content').find('.active').data('id');
        var target = $('.iframe[data-id="' + currentId + '"]');
        var url = target.attr('src');
        cloud.common.loading(true);
        target.attr('src', url).load(function () {
            cloud.common.loading(false);
        });
    };

    /**
     * 除当前激活选项卡外全部关闭
     * @return {Void}  
     */
    tab.closeOtherTabs = function () {
        $('.page-tabs-content').children("[data-id]").find('.fa-remove').parents('a').not(".active").each(function () {
            $('.iframe[data-id="' + $(this).data('id') + '"]').remove();
            $(this).remove();
        });
        $('.page-tabs-content').css("margin-left", "0");
    };
    /**
     * 关闭选项卡
     * @return {Void}  
     */
    tab.closeTab = function () {
        var that = $(this);
        var closeTabId = that.parents('.menuTab').data('id');
        var currentWidth = that.parents('.menuTab').width();
        if (that.parents('.menuTab').hasClass('active')) {
            if (that.parents('.menuTab').next('.menuTab').size()) {
                var activeId = that.parents('.menuTab').next('.menuTab:eq(0)').data('id');
                that.parents('.menuTab').next('.menuTab:eq(0)').addClass('active');
                $('.mainContent .iframe').each(function (key, value) {
                    var $value = $(value);
                    if ($value.data('id') == activeId) {
                        $value.show().siblings('.iframe').hide();
                        return false;
                    }
                });
                var marginLeftVal = parseInt($('.page-tabs-content').css('margin-left'));
                if (marginLeftVal < 0) {
                    $('.page-tabs-content').animate({
                        marginLeft: (marginLeftVal + currentWidth) + 'px'
                    }, "fast");
                }
                that.parents('.menuTab').remove();
                $('.mainContent .iframe').each(function (k, v) {
                    var $v = $(v);
                    if ($v.data('id') == closeTabId) {
                        $v.remove();
                        return false;
                    }
                });
            }
            if (that.parents('.menuTab').prev('.menuTab').size()) {
                var activeId = that.parents('.menuTab').prev('.menuTab:last').data('id');
                that.parents('.menuTab').prev('.menuTab:last').addClass('active');
                $('.mainContent .iframe').each(function (key, value) {
                    var $value = $(value);
                    if ($value.data('id') == activeId) {
                        $value.show().siblings('.iframe').hide();
                        return false;
                    }
                });
                that.parents('.menuTab').remove();
                $('.mainContent .iframe').each(function (key, value) {
                    var $value = $(value);
                    if ($value.data('id') == closeTabId) {
                        $value.remove();
                        return false;
                    }
                });
            }
        }
        else {
            that.parents('.menuTab').remove();
            $('.mainContent .iframe').each(function (key, value) {
                var $value = $(value);
                if ($value.data('id') == closeTabId) {
                    $value.remove();
                    return false;
                }
            });
            tab.scrollToTab($('.menuTab.active'));
        }
        return false;
    };
    /**
     * 向右滚动选项卡
     * @return {Void}  
     */
    tab.scrollTabRight = function () {
        var marginLeftVal = Math.abs(parseInt($('.page-tabs-content').css('margin-left')));
        var tabOuterWidth = tab.calSumWidth($(".content-tabs").children().not(".menuTabs"));
        var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;
        var scrollVal = 0;
        if ($(".page-tabs-content").width() < visibleWidth) {
            return false;
        } else {
            var tabElement = $(".menuTab:first");
            var offsetVal = 0;
            while ((offsetVal + $(tabElement).outerWidth(true)) <= marginLeftVal) {
                offsetVal += $(tabElement).outerWidth(true);
                tabElement = $(tabElement).next();
            }
            offsetVal = 0;
            while ((offsetVal + $(tabElement).outerWidth(true)) < (visibleWidth) && tabElement.length > 0) {
                offsetVal += $(tabElement).outerWidth(true);
                tabElement = $(tabElement).next();
            }
            scrollVal = tab.calSumWidth($(tabElement).prevAll());
            if (scrollVal > 0) {
                $('.page-tabs-content').animate({
                    marginLeft: 0 - scrollVal + 'px'
                }, "fast");
            }
        }
    };
    /**
     * 向左滚动选项卡
     * @return {Void}  
     */
    tab.scrollTabLeft = function () {
        var marginLeftVal = Math.abs(parseInt($('.page-tabs-content').css('margin-left')));
        var tabOuterWidth = tab.calSumWidth($(".content-tabs").children().not(".menuTabs"));
        var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;
        var scrollVal = 0;
        if ($(".page-tabs-content").width() < visibleWidth) {
            return false;
        } else {
            var tabElement = $(".menuTab:first");
            var offsetVal = 0;
            while ((offsetVal + $(tabElement).outerWidth(true)) <= marginLeftVal) {
                offsetVal += $(tabElement).outerWidth(true);
                tabElement = $(tabElement).next();
            }
            offsetVal = 0;
            if (tab.calSumWidth($(tabElement).prevAll()) > visibleWidth) {
                while ((offsetVal + $(tabElement).outerWidth(true)) < (visibleWidth) && tabElement.length > 0) {
                    offsetVal += $(tabElement).outerWidth(true);
                    tabElement = $(tabElement).prev();
                }
                scrollVal = tab.calSumWidth($(tabElement).prevAll());
            }
        }
        $('.page-tabs-content').animate({
            marginLeft: 0 - scrollVal + 'px'
        }, "fast");
    };
    /**
     * 选项卡自适应
     * @return {Void}  
     */
    tab.scrollToTab = function (element) {
        var $element = $(element);
        //该选项卡左边距
        var marginLeftVal = tab.calSumWidth($element.prevAll()),
            //选项卡右边距
            marginRightVal = tab.calSumWidth($element.nextAll());
        var tabOuterWidth = tab.calSumWidth($(".content-tabs").children().not(".menuTabs"));
        var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;
        var scrollVal = 0;
        if ($(".page-tabs-content").outerWidth() < visibleWidth) {
            scrollVal = 0;
        } else if (marginRightVal <= (visibleWidth - $element.outerWidth(true) - $element.next().outerWidth(true))) {
            if ((visibleWidth - $element.next().outerWidth(true)) > marginRightVal) {
                scrollVal = marginLeftVal;
                var tabElement = element;
                while ((scrollVal - $(tabElement).outerWidth()) > ($(".page-tabs-content").outerWidth() - visibleWidth)) {
                    scrollVal -= $(tabElement).prev().outerWidth();
                    tabElement = $(tabElement).prev();
                }
            }
        } else if (marginLeftVal > (visibleWidth - $element.outerWidth(true) - $element.prev().outerWidth(true))) {
            scrollVal = marginLeftVal - $element.prev().outerWidth(true);
        }
        $('.page-tabs-content').animate({
            marginLeft: 0 - scrollVal + 'px'
        }, "fast");
    };
    /**
     * 计算宽度
     * @return {Void}  
     */
    tab.calSumWidth = function (element) {
        var width = 0;
        $(element).each(function () {
            width += $(this).outerWidth(true);
        });
        return width;
    };

})(jQuery);

$(function () {
    tab.init();
});