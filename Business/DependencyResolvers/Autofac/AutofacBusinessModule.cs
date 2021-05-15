using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ICategoryService>().As<CategoryManager>().SingleInstance();
            builder.RegisterType<ICategoryDal>().As<EfCategoryDal>().SingleInstance();
            builder.RegisterType<IWriterService>().As<WriterManager>().SingleInstance();
            builder.RegisterType<IWriterDal>().As<EfWriterDal>().SingleInstance();
            builder.RegisterType<IBookService>().As<BookManager>().SingleInstance();
            builder.RegisterType<IBookDal>().As<EfBookDal>().SingleInstance();
            builder.RegisterType<IStaffService>().As<StaffManager>().SingleInstance();
            builder.RegisterType<IStaffDal>().As<EfStaffDal>().SingleInstance();
            builder.RegisterType<IMemberService>().As<MemberManager>().SingleInstance();
            builder.RegisterType<IMemberDal>().As<EfMemberDal>().SingleInstance();
            builder.RegisterType<IBookRecordService>().As<BookRecordManager>().SingleInstance();
            builder.RegisterType<IBookRecordDal>().As<EfBookRecordDal>().SingleInstance();
            builder.RegisterType<IAboutService>().As<AboutManager>().SingleInstance();
            builder.RegisterType<IAboutDal>().As<EfAboutDal>().SingleInstance();
            builder.RegisterType<IContactService>().As<ContactManager>().SingleInstance();
            builder.RegisterType<IContactDal>().As<EfContactDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();


            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
