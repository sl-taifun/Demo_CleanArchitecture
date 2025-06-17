using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.Domain.Modeles
{
    public class Author
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string? Pseudo { get; set; }
        public required DateTime? BirthDate { get; set; }
    }
}
