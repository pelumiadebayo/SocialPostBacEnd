using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialPostBackEnd.Model
{
    public class Like
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Post_Id { get; set; }
        public int Created_At { get; set; }
    }
}
