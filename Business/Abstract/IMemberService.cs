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
    public interface IMemberService
    {
        IResult Add(Member member);
        IResult Delete(int id);
        void Update(Member member);
        void UpdateDto(MemberForRegisterDto memberForRegisterDto, string password, string mail);
        List<Member> GetAll();
        Member GetById(int id);
        Member GetByMail(string mail);
        MemberForRegisterDto GetMemberDto(string mail, string password);
    }
}
