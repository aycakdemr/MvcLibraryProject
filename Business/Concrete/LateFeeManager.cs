using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LateFeeManager : ILateFeeService
    {
        ILateFeeDal _lateFeeDal;

        public LateFeeManager(ILateFeeDal lateFeeDal)
        {
            _lateFeeDal = lateFeeDal;
        }

        public decimal TotalAmaount()
        {
            return _lateFeeDal.GetAll().Sum(x => x.Amount);
        }
    }
}
