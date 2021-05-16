using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMemberService
    {
        IResult Add(Member member);
        IResult Delete(int id);
        void Update(Member member);
        List<Member> GetAll();
        Member GetById(int id);
        Member GetByMail(string mail);
    }
}
