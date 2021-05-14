using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        IResult Add(Contact contact);
        IResult Delete(int id);
        void Update(Contact contact);
        List<Contact> GetAll();
        Contact GetById(int id);
    }
}
