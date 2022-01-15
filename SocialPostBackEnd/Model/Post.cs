﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialPostBackEnd.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int User_Id { get; set; }
        public string Image { get; set; }
        public int Created_At { get; set; }
    }
}
