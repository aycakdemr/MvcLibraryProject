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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var value = _categoryDal.Get(x => x.Id == id);
            _categoryDal.Delete(value);
            return new SuccessResult();
        }

        public Category Get(int id)
        {
            return _categoryDal.Get(c => c.Id == id);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x=>x.Id ==id);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
