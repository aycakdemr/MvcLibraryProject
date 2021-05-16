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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public IResult Add(Writer writer)
        {
            _writerDal.Add(writer);
            return new SuccessResult();
        }
        public IResult Delete(int id)
        {
            var value = _writerDal.Get(x => x.Id == id);
            _writerDal.Delete(value);
            return new SuccessResult();
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.Id == id);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }

    }
}
