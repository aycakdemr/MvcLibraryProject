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
   public interface IAuthService
    {
        IDataResult<Member> Register(MemberForRegisterDto userForRegisterDto, string password);
        IDataResult<Member> Login(MemberForLoginDto userForLoginDto);
        IResult UserExists(string email);
    }
}
