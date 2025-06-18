using DemoCleanArchitecture.Domain.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.ApplicationCore.Interfaces.Services
{
    public interface IMemberService
    {
        Member Register(string email, string password);
        Member Login(string email,string password);
    }
}
