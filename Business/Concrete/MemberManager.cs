using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MemberManager : IMemberService
    {
        IMemberDal _memberDal;
        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public IResult Add(Member member)
        {
            _memberDal.Add(member);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var value = _memberDal.Get(x => x.Id == id);
            _memberDal.Delete(value);
            return new SuccessResult();
        }

        public List<Member> GetAll()
        {
            return _memberDal.GetAll();
        }

        public Member GetById(int id)
        {
            return _memberDal.Get(x => x.Id == id);
        }

        public Member GetByMail(string mail)
        {
            return _memberDal.Get(x => x.EMail == mail);
        }
        public MemberForRegisterDto GetMemberDto(string mail,string password)
        {
            var value = GetByMail(mail);
            MemberForRegisterDto dto = new MemberForRegisterDto();
            dto.FirstName = value.Name;
            dto.LastName = value.LastName;
            dto.UserName = value.UserName;
            dto.Education = value.Education;
            dto.Email = value.EMail;
            dto.Password = password;
            dto.Image = value.Image;
            return dto;
        }
 

        public void UpdateDto(MemberForRegisterDto memberForRegisterDto,string password,string mail)
        {
            var value = GetByMail(mail);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            value.PasswordHash = passwordHash;
            value.PasswordSalt = passwordSalt;
            value.EMail = mail;
            value.Name = memberForRegisterDto.FirstName;
            value.LastName = memberForRegisterDto.LastName;
            value.Education = memberForRegisterDto.Education;
            value.UserName = memberForRegisterDto.UserName;
            value.PhoneNumber = memberForRegisterDto.PhoneNumber;
            value.Image = memberForRegisterDto.Image;
            _memberDal.Update(value);
        }

        public void Update(Member member)
        {
            _memberDal.Update(member);
        }


    }
}
