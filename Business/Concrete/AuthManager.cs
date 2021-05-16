using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IMemberService _memberService;

        public AuthManager(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public IDataResult<Member> Login(MemberForLoginDto userForLoginDto)
        {
            var userToCheck = _memberService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Member>();
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Member>();
            }

            return new SuccessDataResult<Member>(userToCheck);
        }

        public IDataResult<Member> Register(MemberForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var member = new Member
            {
                EMail = userForRegisterDto.Email,
                Name = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserName = userForRegisterDto.UserName,
                Education =userForRegisterDto.Education
               
            };
            _memberService.Add(member);
            return new SuccessDataResult<Member>(member);
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
