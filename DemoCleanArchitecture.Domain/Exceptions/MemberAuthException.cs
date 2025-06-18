using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.Domain.Exceptions
{
    public class MemberAuthException : Exception
    {
        public MemberAuthException()
        {
        }

        public MemberAuthException(string? message) : base(message)
        {
        }
    }
    public class AccountAlreadyExistsMemberException : MemberAuthException
    {
        public AccountAlreadyExistsMemberException() : base("An account with this email already exists.")
        {

        }

    }

    public class AccountNotExistMemberException : MemberAuthException
    {
        public AccountNotExistMemberException() : base("Account not found.")
        {
        }
    }

    public class InvalidCredentialsMemberException : MemberAuthException
    {
        public InvalidCredentialsMemberException() : base("Invalid email or password.")
        {
        }
    }
    public class ForbiddenEmailMemberException : MemberAuthException
    {
        public ForbiddenEmailMemberException() : base("Email domain forbidden.")
        {
        }
    }
}