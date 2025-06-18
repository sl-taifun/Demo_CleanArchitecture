using DemoCleanArchitecture.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.Domain.Modeles
{
    public class Member
    {
        public long Id { get; set; }
        public required string? Password { get; set; }
        public required string Email { get; set; }

        public required MemberRoleEnum Role { get; set; }


        // Additional properties and methods can be added as needed
    }
}
