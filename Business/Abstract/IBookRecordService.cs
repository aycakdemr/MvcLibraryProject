using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookRecordService
    {
        IResult Add(BookRecord bookRecord);
        IResult Delete(int id);
        void Update(BookRecord bookRecord);
        List<BookRecord> GetAll();
        BookRecord GetById(int id);
        List<BookRecordDto> GetDetailStatusFalse();
        List<BookRecordDto> GetDetailStatusTrue();
        List<BookRecordDto> GetDetail(int id);
    }
}
