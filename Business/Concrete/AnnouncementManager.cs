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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            this.announcementDal = announcementDal;
        }

        public IResult Add(Announcement announcement)
        {
            announcementDal.Add(announcement);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var value = announcementDal.Get(x => x.Id == id);
            announcementDal.Delete(value);
            return new SuccessResult();
        }

        public List<Announcement> GetAll()
        {
            return announcementDal.GetAll();
        }

        public Announcement GetById(int id)
        {
            return announcementDal.Get(x => x.Id == id);
        }

        public void Update(Announcement announcement)
        {
            announcementDal.Update(announcement);
        }
    }
}
