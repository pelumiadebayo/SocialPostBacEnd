using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialPostBackEnd.Model.Response
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullmane { get; set; }
        public string Profile_Picture { get; set; }
        public bool Followed { get; set; }
    }
    public class Post
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Created_At { get; set; }
        public bool Liked { get; set; }
        public User User { get; set; }

    }
}
