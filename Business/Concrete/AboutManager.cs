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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public IResult Add(About about)
        {
            _aboutDal.Add(about);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var value = _aboutDal.Get(x => x.Id == id);
            _aboutDal.Delete(value);
            return new SuccessResult();
        }

        public List<About> GetAll()
        {
            return _aboutDal.GetAll();
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(x => x.Id == id);
        }

        public void Update(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
