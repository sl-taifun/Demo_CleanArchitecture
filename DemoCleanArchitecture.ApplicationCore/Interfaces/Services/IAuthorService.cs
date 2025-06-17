using DemoCleanArchitecture.Domain.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.ApplicationCore.Interfaces.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAll(int page,int nbElement);
        Author GetById(long id);
        Author Create(Author data);
        Author Update(Author data);
    }
}
