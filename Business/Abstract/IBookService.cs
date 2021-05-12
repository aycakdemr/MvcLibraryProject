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
    public interface IBookService
    {
        IResult Add(Book book);
        IResult Delete(int id);
        void Update(Book book);
        List<Book> GetAll();
        List<BookWriterCategoryDto> GetDetails();
        Book GetById(int id);
        List<BookWriterCategoryDto> SearchBook(string a);
    }
}
