using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.Domain.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.Infrastructure.Database.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }
        public Author Create(Author data)
        {
           EntityEntry<Author> elem = _context.Author.Add(data);
            _context.SaveChanges();
            return elem.Entity;
        }

        public bool Delete(long id)
        {
            Author? author = _context.Author.Single(a => a.Id == id);
            if (author == null)
            {
                return false;
            }
            _context.Remove(author);
            _context.SaveChanges();
            return true;
        }
        public IEnumerable<Author> GetAll(int offset, int limit)
        {
            return _context.Author.AsNoTracking().Skip(offset).Take(limit).ToList();
        }

        public Author? GetById(long id)
        {
            return _context.Author.AsNoTracking().SingleOrDefault(a => a.Id == id);
        }

        public Author Update(long id, Author data)
        {
            Author author = _context.Author.Single(a => a.Id == id);

            author.FirstName = data.FirstName;
            author.LastName = data.LastName;
            author.Pseudo = data.Pseudo;
            author.BirthDate = data.BirthDate;

            _context.SaveChanges();

            return author;
        }
    }
}
