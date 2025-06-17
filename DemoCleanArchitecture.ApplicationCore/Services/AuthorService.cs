using DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories;
using DemoCleanArchitecture.ApplicationCore.Interfaces.Services;
using DemoCleanArchitecture.Domain.Exceptions;
using DemoCleanArchitecture.Domain.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.ApplicationCore.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;   

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public Author Create(Author data)
        {
            CheckAuthorBirthDate(data);
            Author author = _authorRepository.Create(data);
            return author;
        }

        private static void CheckAuthorBirthDate(Author data)
        {
            if (data.BirthDate is not null && data.BirthDate >= DateTime.Today)
            {
                throw new ShittyDataException(nameof(data.BirthDate), data.BirthDate);
            }
        }

        public IEnumerable<Author> GetAll(int page, int nbElement)
        {
            int limit = Math.Min(nbElement, 20); 
            int offset = (page - 1) * nbElement;

            return _authorRepository.GetAll(page, nbElement);
        }

        public Author GetById(long id)
        {
            Author? author = _authorRepository.GetById(id);
            if(author == null)
            {
                throw new AuthorNotFoundException(id);
            }
            return author;
        }

        public Author Update(Author data)
        {
            CheckAuthorBirthDate(data);
            Author author = _authorRepository.Update(data.Id, data);
            return author;
        }
    }
}
