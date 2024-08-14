using Microsoft.AspNetCore.Identity;

namespace _80_MVC_IdentityCustomize.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
