using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWriterService
    {
        IResult Add(Writer writer);
        IResult Delete(int id);
        void Update(Writer writer);
        List<Writer> GetAll();
        Writer GetById(int id);
    }
}
