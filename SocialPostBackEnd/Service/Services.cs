using SocialPostBackEnd.Model.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialPostBackEnd.Service
{
    public class Services : IServices
    {
        private readonly AppDbContext _dbContext;

        public Services(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Post> Get_posts(int user_id, int[] post_ids)
        {
            var plain_post_ids = String.Join(",", post_ids);

            //get the posts from db using post_ids
            List<Model.Post> db_posts = _dbContext.Post.FromSqlRaw($"SELECT * FROM Post WHERE Id IN ({plain_post_ids})ORDER  BY CHARINDEX(CAST(Id AS VARCHAR), '{plain_post_ids}')")
                .Select(p => new Model.Post
                {
                    Id = p.Id,
                    Description = p.Description,
                    Image = p.Image,
                    Created_At = p.Created_At,
                    User_Id = p.User_Id
                    
                }).ToList();

            //initialize list of post to be returned
            List<Post> postList = new List<Post>();

            //foreach of the id in post_ids, check if a post is returned for it
            foreach (var postId in post_ids)
            {
                var postEntity = db_posts.SingleOrDefault(x => x.Id == postId);

                var post = new Post
                {
                    Id=postId
                };
                //if not null, set the value as returned from db
                if (postEntity != null)
                {
                    post.Description = postEntity.Description;
                    post.Image = postEntity.Image;
                    post.Created_At = postEntity.Created_At;

                    var user = _dbContext.Users.FromSqlRaw($"SELECT * FROM Users WHERE Id={postEntity.User_Id}").Single();
                    post.User = new User
                    {
                        Id = user.Id,
                        Username = user.Usernames,
                        Fullmane = user.Full_Name,
                        Profile_Picture = user.Profile_Picture
                    };
                    
                    var posts_like = _dbContext.Likes.FromSqlRaw($"SELECT * FROM Likes  WHERE Post_Id={post.Id} AND user_id={user_id}").ToList();
                    post.Liked = posts_like.Count > 0;

                    var followed = _dbContext.Follow.FromSqlRaw($"SELECT * FROM Follow  WHERE Follower_Id={user_id} AND Following_Id={postEntity.User_Id}").ToList();
                    post.User.Followed = followed.Count > 0;
                }

                //add each post to the post list to be returned
                postList.Add(post);

            }

            return postList;

        }

        public List<Post> Merge_posts(List<List<Post>> listOfPost)
        {
            var newList = new List<Post>();
            foreach (var list in listOfPost)
            {
                foreach (var post in list)
                {
                    newList.Add(post);
                }
            }
            newList = newList.OrderByDescending(x => x.Id).OrderByDescending(x => x.Created_At).GroupBy(p => p.Id).Select(g => g.First()).ToList();
            return newList;
        }
    }
}
