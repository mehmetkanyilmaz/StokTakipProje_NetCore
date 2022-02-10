using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<StockService>().As<IStockService>();
            builder.RegisterType<EfStockDal>().As<IStockDal>();

            builder.RegisterType<StockGroupService>().As<IStockGroupService>();
            builder.RegisterType<EfStockGroupDal>().As<IStockGroupDal>();

            builder.RegisterType<StockBrandService>().As<IStockBrandService>();
            builder.RegisterType<EfStockBrandDal>().As<IStockBrandDal>();

            builder.RegisterType<StockModelService>().As<IStockModelService>();
            builder.RegisterType<EfStockModelDal>().As<IStockModelDal>();

            builder.RegisterType<StockMoveService>().As<IStockMoveService>();
            builder.RegisterType<EfStockMoveDal>().As<IStockMoveDal>();

            builder.RegisterType<CommonFunctionsService>().As<ICommonFunctionsService>();
        }
    }
}
