using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialPostBackEnd.Model
{
    public class Follow
    {
        public int Id { get; set; }
        public int Follower_Id { get; set; }
        public int Following_Id { get; set; }        
        public int Created_At { get; set; }
    }
}
