using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCleanArchitecture.Domain.Constantes
{
    public static class EmailConstants
    {
        
        public static readonly HashSet<string> BlockedDomains = new HashSet<string>
        {
            "yopmail.com",
            "temp-mail.org",
            "mailinator.com",
            "guerrillamail.com",
            "10minutemail.com",
            "throwawaymail.com",
            "maildrop.cc",
            "moakt.cc",
            "spambog.com",
            "mailcatch.com",
            "dispostable.com",
            "getairmail.com",
            "mytrashmail.com",
            "mail-temp.com",
            "emailondeck.com",
            "easytrashmail.com",
            "fakeinbox.com",
            "trashmail.com"
        };
    }
}
