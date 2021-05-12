using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStaffService
    {
        IResult Add(Staff staff);
        IResult Delete(int id);
        void Update(Staff staff);
        List<Staff> GetAll();
        Staff GetById(int id);
    }
}
