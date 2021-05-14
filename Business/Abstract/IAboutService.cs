using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(About about);
        IResult Delete(int id);
        void Update(About about);
        List<About> GetAll();
        About GetById(int id);
    }
}
