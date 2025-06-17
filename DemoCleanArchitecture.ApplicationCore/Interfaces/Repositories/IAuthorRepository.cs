using DemoCleanArchitecture.Domain.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.ApplicationCore.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll(int offset , int limit);
        Author? GetById(long id);
        Author Create(Author data);
        Author Update(long id,Author data);
        bool Delete(long id);   
    }
}
