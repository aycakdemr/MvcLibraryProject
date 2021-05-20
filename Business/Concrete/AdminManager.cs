using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public IResult Add(Admin admin)
        {
            _adminDal.Add(admin);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var value = _adminDal.Get(x => x.Id == id);
            _adminDal.Delete(value);
            return new SuccessResult();
        }

        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.Id == id);
        }

        public Admin GetByMail(string mail)
        {
            return _adminDal.Get(x => x.Email == mail);
        }

        public bool Login(Admin admin)
        {
            var userToCheck = GetByMail(admin.Email);
            if (userToCheck == null)
            {
                return false;
            }
            if (userToCheck.Password!= admin.Password)
            {
                return false;
            }
            return true;
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public bool UserCheck(string mail)
        {
            var value = GetByMail(mail);
            if(value == null)
            {
                return false;
            }
            return true;
        }
    }
}
