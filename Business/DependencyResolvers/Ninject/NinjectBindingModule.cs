using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.DependencyResolvers.Ninject
{
    public class NinjectBindingModule: NinjectModule
    {
        public override void Load()
        {
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
        }
    }
}