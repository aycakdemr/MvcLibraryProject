using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        IResult Add(Message message);
        IResult Delete(int id);
        void Update(Message message);
        List<Message> GetAll();
        Message GetById(int id);
        List<Message> GetByMailReceiver(string mail);
        List<Message> GetByMailSender(string mail);

    }
}
