using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfBookRecordDal : EfEntityRepositoryBase<BookRecord, Context>, IBookRecordDal
    {
        public List<BookRecordDto> GetBookRecordsDetails(Expression<Func<BookRecord, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result = from bookrecords in filter == null ? context.BookRecords : context.BookRecords.Where(filter)
                             join book in context.Books
                             on bookrecords.BookId equals book.Id
                             join member in context.Members
                             on bookrecords.MemberId equals member.Id
                             join staff in context.Staffs
                             on bookrecords.StaffId equals staff.Id
                             select new BookRecordDto
                             {
                                 Id = bookrecords.Id,
                                 BookName = book.Name,
                                 MemberName = member.Name,
                                 StaffName =staff.StaffName,
                                 BuyingDate =bookrecords.BuyingDate,
                                 GivingDate=bookrecords.GivingDate,
                                 MemberLastName=member.LastName,


                
                             };
                return result.ToList();
            }
        }

        public BookRecordDto GetBookRecordsDetailsById(Expression<Func<BookRecord, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result = from bookrecords in filter == null ? context.BookRecords : context.BookRecords.Where(filter)
                             join book in context.Books
                             on bookrecords.BookId equals book.Id
                             join member in context.Members
                             on bookrecords.MemberId equals member.Id
                             join staff in context.Staffs
                             on bookrecords.StaffId equals staff.Id
                             select new BookRecordDto
                             {
                                 Id = bookrecords.Id,
                                 BookName = book.Name,
                                 MemberName = member.Name,
                                 StaffName = staff.StaffName,
                                 BuyingDate = bookrecords.BuyingDate,
                                 GivingDate = bookrecords.GivingDate,
                                 MemberLastName = member.LastName,



                             };
                return result.FirstOrDefault();
            }
        }
    }
}
