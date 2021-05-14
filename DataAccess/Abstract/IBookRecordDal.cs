using Core.DataAccess;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IBookRecordDal : IEntityRepository<BookRecord>
    {
        List<BookRecordDto> GetBookRecordsDetails(Expression<Func<BookRecord, bool>> filter = null);
        BookRecordDto GetBookRecordsDetailsById(Expression<Func<BookRecord, bool>> filter = null);
    }
}
