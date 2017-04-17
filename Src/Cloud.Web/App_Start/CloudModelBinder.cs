using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCode;

namespace Cloud.Web
{
    /// <summary>云平台模型绑定器。特殊处理XCode实体类</summary>
    public class CloudModelBinder : DefaultModelBinder
    {
        /// <summary>创建模型。对于有Key的请求，使用FindByKeyForEdit方法先查出来数据，而不是直接反射实例化实体对象</summary>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext"></param>
        /// <param name="modelType"></param>
        /// <returns></returns>
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (typeof(IEntity).IsAssignableFrom(modelType))
            {
                //实体操作工厂
                var fact = EntityFactory.CreateOperate(modelType);
                if (fact != null)
                {
                    //路由数据，理论上只有controller与action键值
                    var rvs = controllerContext.RouteData.Values;
                    //form表单数据
                    var fs = controllerContext.HttpContext.Request.Form;
                    //主键
                    var uk = fact.Unique;
                    //判断表单数据中是否包含主键数据
                    if (uk != null && fs[uk.Name]!=null)
                    {
                        //查询实体对象用于编辑
                        var entity = fact.FindByKeyForEdit(fs[uk.Name]) ?? fact.Create();
                        //提前填充动态字段的扩展属性
                        foreach (var item in fact.Fields)
                        {
                            if (item.IsDynamic && fs.AllKeys.Contains(item.Name)) entity.SetItem(item.Name, fs[item.Name]);
                        }
                        return entity;
                    }
                    return fact.Create();
                }
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
    /// <summary>云平台模型绑定器提供者，为所有XCode实体类提供实体模型绑定器</summary>
    public class CloudModelBinderProvider : IModelBinderProvider
    {
        /// <summary>获取绑定器</summary>
        /// <param name="modelType"></param>
        /// <returns></returns>
        public IModelBinder GetBinder(Type modelType)
        {
            if (typeof(IEntity).IsAssignableFrom(modelType)) return new CloudModelBinder();

            return null;
        }

        /// <summary>注册到全局模型绑定器提供者集合</summary>
        public static void Register()
        {
            XTrace.WriteLine("注册实体模型绑定器：{0}", typeof(CloudModelBinderProvider).FullName);
            ModelBinderProviders.BinderProviders.Add(new CloudModelBinderProvider());
        }
    }
}