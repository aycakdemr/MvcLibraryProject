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
    public class MessageManager : IMessageService
    {
        IMessageDal messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public IResult Add(Message message)
        {
            messageDal.Add(message);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var value = messageDal.Get(x => x.Id == id);
            messageDal.Delete(value);
            return new SuccessResult();
        }

        public List<Message> GetAll()
        {
            return messageDal.GetAll();

        }

        public Message GetById(int id)
        {
            return messageDal.Get(x => x.Id == id); 
        }

        public List<Message> GetByMailReceiver(string mail)
        {
            return messageDal.GetAll(x => x.Receiver == mail);
        }

        public List<Message> GetByMailSender(string mail)
        {
            return messageDal.GetAll(x => x.Sender == mail);
        }

        public void Update(Message message)
        {
            messageDal.Update(message);
        }
    }
}
