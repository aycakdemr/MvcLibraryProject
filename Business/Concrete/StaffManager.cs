using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class StaffManager : IStaffService
    {
        IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        [ValidationAspect(typeof(StaffValidator))]
        public IResult Add(Staff staff)
        {
            _staffDal.Add(staff);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var value = _staffDal.Get(x => x.Id == id);
            _staffDal.Delete(value);
            return new SuccessResult();
        }

        public List<Staff> GetAll()
        {
            return _staffDal.GetAll();
        }

        public Staff GetById(int id)
        {
            return _staffDal.Get(x => x.Id == id);
        }

        public void Update(Staff staff)
        {
            _staffDal.Update(staff);
          
        }
    }
}
