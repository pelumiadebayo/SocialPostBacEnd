using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialPostBackEnd.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Usernames { get; set; }
        public string Email { get; set; }
        public string Full_Name { get; set; }
        public string Profile_Picture { get; set; }
        public string Bio { get; set; }
        public int Created_At { get; set; }
    }
}
