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
            return _bookRecordDal.GetAll(x=>x.RecordStatus ==false);
        }

        public BookRecord GetById(int id)
        {
            return _bookRecordDal.Get(x => x.Id == id);
        }
        public List<BookRecordDto> GetDetail(int id)
        {
            return _bookRecordDal.GetBookRecordsDetails(x => x.Id == id);
        }
        public BookRecordDto GetDetailById(int id)
        {
            return _bookRecordDal.GetBookRecordsDetailsById(x=>x.Id ==id);
        }


        public List<BookRecordDto> GetDetailStatusFalse()
        {
           return _bookRecordDal.GetBookRecordsDetails(x => x.RecordStatus == false);
        }

        public List<BookRecordDto> GetDetailStatusTrue()
        {
            return _bookRecordDal.GetBookRecordsDetails(x => x.RecordStatus == true);
        }

        public List<BookRecordDto> GetMembersBook(int id)
        {
            return _bookRecordDal.GetBookRecordsDetails(x => x.MemberId == id);
        }

        public void Update(BookRecord bookRecord)
        {
            bookRecord.RecordStatus = true;
            _bookRecordDal.Update(bookRecord);
        }
    }
}
