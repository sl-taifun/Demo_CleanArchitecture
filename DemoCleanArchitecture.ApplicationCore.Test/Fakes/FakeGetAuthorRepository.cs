using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.Domain.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.ApplicationCore.Test.Fakes
{
    internal class FakeGetAuthorRepository : IAuthorRepository
    {
        private static List<Author> _authors = new List<Author>
        {
            new Author
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Pseudo = null,
                BirthDate = new DateTime(1990, 1, 1)
            },
            new Author
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Pseudo = "janesmith",
                BirthDate = new DateTime(1985, 5, 15)
            },
            new Author
            {
                Id = 2,
                FirstName = "Stephan",
                LastName = "Ledouppe",
                Pseudo = "Froggy",
                BirthDate = new DateTime(1985, 5, 15)
            }
        };
        public Author Create(Author data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAll(int offset, int limit)
        {
            return _authors.Skip(offset).Take(limit);
        }

        public Author? GetById(long id)
        {
            return _authors.FirstOrDefault(a => a.Id == id);
        }

        public Author Update(long id, Author data)
        {
            throw new NotImplementedException();
        }
    }
}
