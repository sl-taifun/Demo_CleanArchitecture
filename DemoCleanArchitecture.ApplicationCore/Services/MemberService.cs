using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.ApplicationCore.Interfaces.Services;
using DemoCleanArchitecture.Domain.Constantes;
using DemoCleanArchitecture.Domain.Enums;
using DemoCleanArchitecture.Domain.Exceptions;
using DemoCleanArchitecture.Domain.Modeles;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.ApplicationCore.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public Member Login(string email, string password)
        {
            Member? member = _memberRepository.GetByEmail(email) ?? throw new Domain.Exceptions.AccountNotExistMemberException();

            String hashPassword = _memberRepository.GetHashCode(member.Id);
            if(!Argon2.Verify(hashPassword, password))
            {
                throw new InvalidCredentialsMemberException();
            }
            return member;
        }

        public Member Register(string email, string password)
        {
            if(_memberRepository.GetByEmail(email) != null)
            {
                throw new AccountAlreadyExistsMemberException();
            }

            if(EmailConstants.BlockedDomains.Any(domain => email.ToLower().EndsWith(domain)))
            {
                throw new ForbiddenEmailMemberException();
            }
           

            Member data = new Member() 
            { 
                Email = email, 
                Password = Argon2.Hash(password), 
                Role =MemberRoleEnum.USER 
            };

            data.Role = MemberRoleEnum.USER; // Default role for new members
            return _memberRepository.Create(data);
        }
    }
}
