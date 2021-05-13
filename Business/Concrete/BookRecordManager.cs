using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookRecordManager : IBookRecordService
    {
        IBookRecordDal _bookRecordDal;

        public BookRecordManager(IBookRecordDal bookRecordDal)
        {
            _bookRecordDal = bookRecordDal;
        }

        public IResult Add(BookRecord bookRecord)
        {
            _bookRecordDal.Add(bookRecord);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var value = _bookRecordDal.Get(x => x.Id == id);
            _bookRecordDal.Delete(value);
            return new SuccessResult();
        }

        public List<BookRecord> GetAll()
        {
            return _bookRecordDal.GetAll();
        }

        public BookRecord GetById(int id)
        {
            return _bookRecordDal.Get(x => x.Id == id);
        }

        public List<BookRecordDto> GetDetails()
        {
            return _bookRecordDal.GetBookRecordsDetails();
        }

        public void Update(BookRecord bookRecord)
        {
            _bookRecordDal.Update(bookRecord);
        }
    }
}
