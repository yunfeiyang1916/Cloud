//设置按钮模块对象
var button = button || {};
(function ($) {
    //列表控件对象
    button.gridList = null;
    /**
     * 显示平铺列表
     * @param  {Object} options  选项
     */
    button.showGridList = function (options) {
        var defaults = {
            //列表控件id
            gridListID: "gridList",
            //分页控件id
            gridPagerID: "gridPager",
            url: "/Admin/Button/List",
            pager: { pageIndex: 1, pageSize: 150 },
            params: { Sort: "Sort", Order: "desc" },
            loading: "数据加载中，请稍候…",
            success: null
        };
        //根据宽度来设置合理的每页显示数
        //var winWidth = $(window).width();
        ////单个图标框大概120像素，向上取整
        //var rowNum = Math.ceil(winWidth / 120);
        //defaults.pager.pageSize = rowNum * 10;
        //在这里使用递归合并defaults.pager会与options.pager合并过，下面合并参数的时候直接合并options.pager与options.params就行了
        var options = $.extend(true, defaults, options);
        //合并请求参数与分页参数
        options.params = $.extend(options.pager, options.params);
        button.gridList = $("#" + options.gridListID);
        $.ajax({
            url: options.url,
            data: options.params,
            beforeSend: function () {
                //显示正在加载遮罩层
                cloud.common.loading(true, options.loading);
            },
            success: function (data) {
                if (data.Status === 1 && data.Data) {
                    var gridList = button.gridList;
                    //先清空
                    gridList.empty();
                    $.each(data.Data, function (key, value) {
                        var content = value.Icon ? "<span class='icon'><i class='fa " + value.Icon + "'></i>" + value.Name + "</span>" : value.Name;
                        var selected = value.Selected ? "class='selected'" : "";
                        var li = "<li " + selected + " data-button=" + value.Name + " data-id=" + value.ID + ">" + content + "</li>";
                        gridList.append(li);
                    });
                    //显示分页
                    //按钮不会特别多，不需要显示分页了
                    //if (data.TotalCount && data.TotalCount > 0) {
                    //    var params = {
                    //        bootstrapMajorVersion: 3,
                    //        currentPage: data.PageIndex,
                    //        numberOfPages: data.PageSize,
                    //        totalPages: data.PageCount,
                    //        onPageChanged: function (e, oldPage, newPage) {
                    //            //设置页码为下一页的
                    //            options.pager.pageIndex = newPage;
                    //            showGridList(options);
                    //        }
                    //    };
                    //    $("#" + options.gridPagerID).bootstrapPaginator(params);
                    //}
                    //是否有回调
                    if (options.success) {
                        options.success(data);
                    }
                } else {
                    cloud.modal.alert(data.Msg, data.Status);
                }
            }
        });
    };
    /**
     * 绑定点击事件
     */
    button.bindClick = function (id) {
        //在ul上绑定带命名空间的点击事件，利用冒泡机制，在点击时判断是否是li元素触发，如果是才处理
        //事件加上命名空间，是为了不想影响该元素的其他点击事件。比如$("#gridList").trigger("click")会触发所有点击事件，
        //而$("#gridList").trigger("click.select")只会触发click.select事件;
        button.gridList.on("click.select", "li", function (e) {
            var that = $(this);
            that.toggleClass("selected");
        });
    };
    /**
     * 获取选中的按钮，以id串形式返回
     * @return {Object}  返回键值对
     */
    button.getSelectedIDs = function () {
        var gridList = button.gridList;
        var selecteds = gridList.find("li.selected");
        if (!selecteds || selecteds.length == 0) {
            //cloud.modal.alert("未选择按钮！", 0);
            return "";
        }
        var ids = "";
        $.each(selecteds, function (key, value) {
            var id = $(value).data("id");
            ids += id + ",";
        });
        //去除结尾的逗号
        ids = ids.substring(0, ids.lastIndexOf(","));
        return ids;
    };
})(jQuery);



