using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.Domain.Modeles;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.Infrastructure.Database.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public Member Create(Member data)
        {
            EntityEntry<Member> entry = _context.Member.Add(data);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetAll(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public Member? GetByEmail(string email)
        {
            var member = _context.Member
                .Select(x => new { x.Email, x.Id, x.Role })
                .SingleOrDefault(m => m.Email == email);

                return member is null ? null:new Member()
                {
                    Id = member.Id,
                    Email = member.Email,
                    Password = null,
                    Role = member.Role
                };
        }

        public Member? GetById(long id)
        {
            throw new NotImplementedException();
        }

        public string GetHashCode(long id)
        {
            return _context.Member
                .First(x => x.Id == id).Password ?? throw new Exception("Member not found or password is null.");
        }

        public Member Update(long id, Member data)
        {
            throw new NotImplementedException();
        }
    }
}
