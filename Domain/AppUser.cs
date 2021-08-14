using System;

namespace Domain
{
    //TODO: inherit from IdentityUser
    public class AppUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }
}
