using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        bool Login(Admin admin);
        Admin GetByMail(string mail);
        List<Admin> GetAll();
        IResult Add(Admin admin);
        IResult Delete(int id);
        void Update(Admin admin);
        Admin GetById(int id);
        bool UserCheck(string mail);
    }
}
