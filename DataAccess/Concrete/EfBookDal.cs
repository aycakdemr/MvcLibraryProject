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
    public class EfBookDal : EfEntityRepositoryBase<Book, Context>, IBookDal
    {
        public List<BookWriterCategoryDto> GetBookDetails(Expression<Func<Book, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result = from books in filter == null ? context.Books : context.Books.Where(filter)
                             join writer in context.Writer
                             on books.WriterId equals writer.Id
                             join category in context.Categories
                             on books.CategoryId equals category.Id

                             select new BookWriterCategoryDto
                             {
                                 BookName = books.Name,
                                 Id = books.Id,
                                 CategoryName = category.CategoryName,
                                 NumberOfPages = books.NumberOfPages,
                                 Publisher = books.Publisher,
                                 ReleaseYear = books.ReleaseYear,
                                 Status = books.Status,
                                 WriterName = writer.WriterName,
                                 WriterLastName = writer.WriterLastName
                             };
                return result.ToList();
            }
        }
    }
}
