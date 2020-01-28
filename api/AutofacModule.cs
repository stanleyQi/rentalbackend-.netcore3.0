using Autofac;
using BLL.Services;
using DAL.Functions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace api
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region 方法一
            ////注册当前程序集中以“Service”及“Repository”结尾的类,暴漏类实现的所有接口，生命周期为PerLifetimeScope

            //以“Service”及“Repository”结尾的类是利用发型实现的数据仓库的管理及业务处理的类和接口

            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

            #endregion

            #region 方法二
            //// 必须是继承了RepositoryBase接口
            //var repositoryBaseType = typeof(RepositoryBase);
            //builder.RegisterAssemblyTypes(GetAssemblyByName("DAL"))
            //    .Where(a => repositoryBaseType.IsAssignableFrom(a) && a != repositoryBaseType)
            //    .AsImplementedInterfaces();

            //// 必须是Repository结束的
            ////builder.RegisterAssemblyTypes(GetAssemblyByName("BLL"))
            ////    .Where(a => a.Name.EndsWith("Repository"))
            ////    .AsImplementedInterfaces();

            #endregion


            #region  注入controller
            //在控制器中使用依赖注入，把controller 也注入进来
            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
            .PropertiesAutowired();
            #endregion

            //单一注册
            builder.RegisterType<ApplicationService>().As<IApplicationService>();
            builder.RegisterType<ApplicationRepository>().As<IApplicationRepository>();




        }

        /// <summary>
        /// 根据程序集名称获取程序集
        /// </summary>
        /// <param name="AssemblyName">程序集名称</param>
        public static Assembly GetAssemblyByName(String AssemblyName)
        {
            return Assembly.Load(AssemblyName);
        }
   
    }
}