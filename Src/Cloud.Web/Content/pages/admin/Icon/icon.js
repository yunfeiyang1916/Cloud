/**显示平铺列表**/
function showGridList(options) {
    var defaults = {
        //列表控件id
        gridListID: "gridList",
        //分页控件id
        gridPagerID: "gridPager",
        url: "/Admin/Icon/List",
        pager: {pageIndex: 1,pageSize: 150},
        params: {Sort:"Sort",Order:"desc"},
        loading: "数据加载中，请稍候…",
        success: null
    };
    //根据宽度来设置合理的每页显示数
    var winWidth = $(window).width();
    //单个图标框大概80像素，向上取整
    var rowNum = Math.ceil(winWidth /80);
    defaults.pager.pageSize = rowNum * 10;
    //在这里使用递归合并defaults.pager会与options.pager合并过，下面合并参数的时候直接合并options.pager与options.params就行了
    var options = $.extend(true,defaults, options);
    //合并请求参数与分页参数
    options.params = $.extend(options.pager, options.params);
    //显示正在加载遮罩层
    //cloud.common.loading(true, options.loading);
    $.ajax({
        url: options.url,
        data: options.params,
        beforeSend: function () {
            //显示正在加载遮罩层
            cloud.common.loading(true, options.loading);
        },
        success: function (data) {
            if (data.Status === 1 && data.Data) {
                var gridList = $("#"+options.gridListID);
                //先清空
                gridList.empty();
                $.each(data.Data, function (key, value) {
                    var li = "<li data-icon=" + value.Name + " data-id=" + value.ID + "><span style='text-align:center;'><i class='fa fa-2x " + value.Name + "'></i></span></li>";
                    gridList.append(li);
                });
                //显示分页
                if (data.TotalCount && data.TotalCount > 0) {
                    var params = {
                        bootstrapMajorVersion: 3,
                        currentPage: data.PageIndex,
                        numberOfPages: data.PageSize,
                        totalPages: data.PageCount,
                        onPageChanged: function (e, oldPage, newPage) {
                            //设置页码为下一页的
                            options.pager.pageIndex = newPage;
                            showGridList(options);
                        }
                    };
                    $("#"+options.gridPagerID).bootstrapPaginator(params);
                }
                //是否有回调
                if (options.success) {
                    options.success(data);
                }
            } else {
                cloud.modal.alert(data.Msg, data.Status);
            }
        }
    });
}