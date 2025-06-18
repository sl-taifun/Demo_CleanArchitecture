using DemoCleanArchitecture.Domain.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAll(int offset, int limit);
        Member? GetById(long id);
        Member? GetByEmail(string email);
        Member Create(Member data);
        Member Update(long id, Member data);
        bool Delete(long id);
        string GetHashCode(long id);
    }
}
