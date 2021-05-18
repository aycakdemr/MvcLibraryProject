using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAnnouncementService
    {
        IResult Add(Announcement announcement);
        IResult Delete(int id);
        void Update(Announcement announcement);
        List<Announcement> GetAll();
        Announcement GetById(int id);
    }
}
