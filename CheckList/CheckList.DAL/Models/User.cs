using Microsoft.AspNetCore.Identity;

namespace CheckList.DAL
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
