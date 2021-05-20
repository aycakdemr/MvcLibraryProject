using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Extensions;

namespace Business.DependencyResolvers.Ninject
{
    public class NinjectBindingModule: NinjectModule
    {
        public override void Load()
        {
            IKernel kernel = new StandardKernel();
            Kernel.Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Kernel.Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
            Kernel.Bind<IWriterService>().To<WriterManager>().InSingletonScope();
            Kernel.Bind<IWriterDal>().To<EfWriterDal>().InSingletonScope();
            Kernel.Bind<IBookService>().To<BookManager>().InSingletonScope();
            Kernel.Bind<IBookDal>().To<EfBookDal>().InSingletonScope();
            Kernel.Bind<IStaffService>().To<StaffManager>().InSingletonScope();
            Kernel.Bind<IStaffDal>().To<EfStaffDal>().InSingletonScope();
            Kernel.Bind<IMemberService>().To<MemberManager>().InSingletonScope();
            Kernel.Bind<IMemberDal>().To<EfMemberDal>().InSingletonScope();
            Kernel.Bind<IBookRecordService>().To<BookRecordManager>().InSingletonScope();
            Kernel.Bind<IBookRecordDal>().To<EfBookRecordDal>().InSingletonScope();
            Kernel.Bind<IAboutService>().To<AboutManager>().InSingletonScope();
            Kernel.Bind<IAboutDal>().To<EfAboutDal>().InSingletonScope();
            Kernel.Bind<IContactService>().To<ContactManager>().InSingletonScope();
            Kernel.Bind<IContactDal>().To<EfContactDal>().InSingletonScope();
            Kernel.Bind<ILateFeeService>().To<LateFeeManager>().InSingletonScope();
            Kernel.Bind<ILateFeeDal>().To<EfLateFeeDal>().InSingletonScope();
            Kernel.Bind<IAuthService>().To<AuthManager>().InSingletonScope();
            Kernel.Bind<IMessageService>().To<MessageManager>().InSingletonScope();
            Kernel.Bind<IMessageDal>().To<EfMessageDal>().InSingletonScope();
            Kernel.Bind<IAnnouncementDal>().To<EfAnnouncementDal>().InSingletonScope();
            Kernel.Bind<IAnnouncementService>().To<AnnouncementManager>().InSingletonScope();
            Kernel.Bind<IAdminService>().To<AdminManager>().InSingletonScope();
            Kernel.Bind<IAdminDal>().To<EfAdminDal>().InSingletonScope();
        }
    }
}