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
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IResult Add(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var value = _bookDal.Get(x => x.Id == id);
            _bookDal.Delete(value);
            return new SuccessResult();
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetAll();
        }

        public Book GetById(int id)
        {
            return _bookDal.Get(x=>x.Id ==id);
        }

        public List<BookWriterCategoryDto> GetDetails()
        {
            return _bookDal.GetBookDetails();
        }

        public List<BookWriterCategoryDto> SearchBook(string a)
        {
            return _bookDal.GetBookDetails(c => c.Name.Contains(a));
        }

        public void Update(Book book)
        {
            _bookDal.Update(book);
            
        }
    }
}
