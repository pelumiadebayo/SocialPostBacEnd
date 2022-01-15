using SocialPostBackEnd.Model.Response;
using System;
using System.Collections.Generic;

namespace SocialPostBackEnd.Service
{
    public interface IServices
    {
        List<Post> Get_posts(int user_id, int[] post_ids);
        List<Post> Merge_posts(List<List<Post>> listOfPost);

    }
}
