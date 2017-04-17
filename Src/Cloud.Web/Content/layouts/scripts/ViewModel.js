/*****************************************************
 * Author  : 云飞扬
 * Version : 1.0.000
 * Date    :  2017-03-15
 ****************************************************/
/**==================================================视图模型js模块====================================================**/
/**
 * 视图模型，这里使用构造函数模型，用法：viewModel=new ViewModel(options);
 * @param  {Object} options  选项
 */
function ViewModel(options) {
    var self = this;
    //强制使用new构造
    if (!(self instanceof ViewModel)) {
        return new ViewModel(options);
    }
    //默认参数
    var defaults = {
        //标题
        title: "数据管理",
        //数据查询地址
        dataQueryUrl: "",
        //单条数据查询地址
        dataQueryOneUrl: "",
        //数据添加地址，视图与操作是一个地址，只是请求方式及参数不同
        dataAddUrl: "",
        //数据编辑地址，视图与操作是一个地址，只是请求方式及参数不同
        dataUpdateUrl: "",
        //数据查看详情地址
        dataDetailUrl: "",
        //数据删除地址
        dataDeleteUrl: "",
        //弹窗宽度
        modalWidth: "700px",
        //弹窗高度
        modalHeight: "440px",
        /**
         * 显示列表数据
         * @param  {Object} options  选项
         */
        showGridList: function (options) {
            //默认参数
            var defaults = {
                //表格控件id
                gridListControlID: "gridList",
                //搜索按钮控件id
                btnSearchControlID: "btnSearch",
                //动态实时获取搜索条件数据
                getSearchData: function () {
                    return { key: $("#txtKey").val() };
                },
                //获取数据的地址
                url: self.dataQueryUrl,
                height: $(window).height() - 96,
                //列模型
                colModel: [
                    { label: "主键", name: "ID", hidden: true, key: true },
                    { label: "名称", name: "Name", width: 200, align: "left" },
                    {
                        label: "更新时间", name: "UpdateDate", width: 120, align: "center",
                        formatter: "date", formatoptions: { srcformat: 'Y-m-d H:i:s', newformat: 'Y-m-d H:i:s' }
                    },
                    { label: "排序", name: "Sort", width: 50, align: "center" },
                    { label: '备注', name: 'Remark', width: 200, align: 'center', sortable: false, },
                    {
                        label: '操作', name: 'ID', width: 250, align: 'center', classes: 'operate', sortable: false,
                        /**
                         * 数据格式化
                         * 参数 value 列值 options 选项 row 行数据
                         */
                        formatter: function (value, options, row) {
                            var html = '';
                            html += '<a id="btnDetail" title="查看"  authorize="yes" onclick="viewModel.onDataDetailing(' + value + ')"><i class="fa fa-search-plus"></i>查看</a>';
                            html += '<a id="btnEdit" title="编辑"  authorize="yes" onclick="viewModel.onDataUpdating(' + value + ')"><i class="fa fa-pencil-square-o"></i>编辑</a>';
                            html += '<a id="btnDelete" title="删除" authorize="yes" onclick="viewModel.onDataDeleting(' + value + ')"><i class="fa fa-trash-o"></i>删除</a>';
                            html += '';
                            return html;
                        }
                    }
                ],
                pager: "#gridPager",
                //是否显示分页
                viewrecords: true
            };
            options = $.extend(defaults, options || {});
            var grid = cloud.grid.render(options.gridListControlID, options);
            //如果设置搜索按钮控件id，说明需要搜索事件
            if (options.btnSearchControlID) {
                //绑定搜索按钮事件
                $("#" + options.btnSearchControlID).click(function () {
                    $("#" + options.gridListControlID).jqGrid("setGridParam", {
                        postData: options.getSearchData()
                    }).trigger('reloadGrid');
                });
            }
        },
        /**
         * 表单加载数据
         * @param  {Object} options  选项
         */
        formLoad: function (options) {
            //默认参数
            var defaults = {
                //表单控件id
                formControlID: "form1",
                //参数
                params: {},
                //类型
                type: "",
                //数据加载成功后的回调
                success: function (result) {
                    //将数据反序列化绑定到表单上
                    cloud.form.deserialize(options.formControlID, result.Data);
                    //查看详情页面需要设置表单控件只读
                    if (options.type == "detail") {
                        var $form = $("#" + options.formControlID);
                        $form.find('.form-control,select,input').attr('readonly', 'readonly');
                        $form.find('div.ckbox label').attr('for', '');
                    }
                }
            };
            options = $.extend(defaults, options || {});
            //加载数据
            cloud.form.load({
                url: self.dataQueryOneUrl,
                params: options.params,
                success: options.success
            });
        },
        /**
         * 提交表单
         * @param  {String} url  地址
         */
        submitForm: function (url) {
            var formID = "form1";
            if (!cloud.form.valid(formID)) {
                return false;
            }
            cloud.form.submit({
                url: url,
                params: cloud.form.serialize(formID),
                success: function (result) {
                    cloud.common.currentWindow().$("#gridList").resetSelection();
                    cloud.common.currentWindow().$("#gridList").trigger("reloadGrid");
                }
            });
        },
        //点击Add按钮弹出“添加数据”对话框
        onDataAdding: function () {
            cloud.modal.open({
                id: "Form",
                title: "新增",
                url: self.dataAddUrl,
                width: self.modalWidth,
                height: self.modalHeight,
                callBack: function (iframeId, index, layero) {
                    //旧用法，页面带参数时有时候容易导致iframe框架中的window对象name改变
                    //top.frames[iframeId].submitForm();
                    //新用法
                    var iframe = layero.find('iframe')[0];
                    var iframeWin = iframe.contentWindow;
                    //iframeWin.submitForm();
                    //这是调用的Form页面的viewModel对象
                    iframeWin.viewModel.onDataAdded();
                }
            });
        },
        //点击“添加数据”对话框的确定按钮提交数据并关闭对话框
        onDataAdded: function () {
            return self.submitForm(self.dataAddUrl);
        },
        //点击编辑按钮弹出“修改数据”对话框
        onDataUpdating: function (id) {
            if (!id) {
                cloud.modal.alert("id不能为空！", 0);
                return;
            }
            cloud.modal.open({
                id: "Form",
                title: "编辑",
                url: self.dataUpdateUrl + "?id=" + id,
                width: self.modalWidth,
                height: self.modalHeight,
                callBack: function (iframeId, index, layero) {
                    //旧用法，页面带参数时有时候容易导致iframe框架中的window对象name改变
                    //top.frames[iframeId].submitForm();
                    //新用法
                    var iframe = layero.find('iframe')[0];
                    var iframeWin = iframe.contentWindow;
                    //iframeWin.submitForm();
                    //这是调用的Form页面的viewModel对象
                    iframeWin.viewModel.onDataUpdated();
                }
            });
        },
        //点击“编辑数据”对话框的确定按钮提交数据并关闭对话框
        onDataUpdated: function () {
            return self.submitForm(self.dataUpdateUrl);
        },
        //点击查看详情按钮弹出“详情”对话框
        onDataDetailing: function (id) {
            if (!id) {
                cloud.modal.alert("id不能为空！", 0);
                return;
            }
            cloud.modal.open({
                id: "Form",
                title: "详情",
                url: self.dataDetailUrl + "?type=detail&id=" + id,
                width: self.modalWidth,
                height: self.modalHeight,
                btn: null
            });
        },
        //点击删除按钮删除当前记录
        onDataDeleting: function (id) {
            if (!id) {
                cloud.modal.alert("id不能为空！", 0);
                return;
            }
            cloud.form.delete({
                url: self.dataDeleteUrl,
                params: { id: id },
                success: function (result) {
                    $("#gridList").resetSelection();
                    $("#gridList").trigger("reloadGrid");
                }
            });
        }
    };
    options = $.extend(defaults, options || {});
    //标题
    self.title = options.title;
    //数据查询地址
    self.dataQueryUrl = options.dataQueryUrl;
    //单条数据查询地址
    self.dataQueryOneUrl = options.dataQueryOneUrl,
    //数据添加地址
    self.dataAddUrl = options.dataAddUrl;
    //数据编辑地址
    self.dataUpdateUrl = options.dataUpdateUrl;
    //数据查看详情地址
    self.dataDetailUrl = options.dataDetailUrl;
    //数据删除地址
    self.dataDeleteUrl = options.dataDeleteUrl;
    //弹窗宽度
    self.modalWidth = options.modalWidth,
    //弹窗高度
    self.modalHeight = options.modalHeight,
    /**
     * 显示列表数据
     * @param  {Object} options  选项
     */
    self.showGridList = options.showGridList;
    /**
     * 表单加载数据
     * @param  {Object} options  选项
     */
    self.formLoad = options.formLoad;
    /**
     * 提交表单
     * @param  {String} url  地址
     */
    self.submitForm = options.submitForm;
    //点击Add按钮弹出“添加数据”对话框
    self.onDataAdding = options.onDataAdding;
    //点击“添加数据”对话框的确定按钮提交数据并关闭对话框
    self.onDataAdded = options.onDataAdded;
    //点击编辑按钮弹出“修改数据”对话框
    self.onDataUpdating = options.onDataUpdating;
    //点击“编辑数据”对话框的确定按钮提交数据并关闭对话框
    self.onDataUpdated = options.onDataUpdated;
    //点击查看详情按钮弹出“详情”对话框
    self.onDataDetailing = options.onDataDetailing;
    //点击删除按钮删除当前记录
    self.onDataDeleting = options.onDataDeleting;
}