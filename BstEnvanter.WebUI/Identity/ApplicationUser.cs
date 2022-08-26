using Microsoft.AspNetCore.Identity;

namespace BstEnvanter.WebUI.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string department { get; set; }
        public string ?roomNo { get; set; }
        public string title { get; set; }

    }
}
