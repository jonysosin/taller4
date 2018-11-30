using System;
using System.Collections.Generic;
using System.Linq;
using Core.DTO;
using Core.Interface;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace Core.Services {
    public class PostService : IPostService {
        private const string ERROR_MESSAGE = "No se ha podido encontrar resultados.";
        private ApiDbContext context;
        public PostService (ApiDbContext context) {
            this.context = context;
        }

        public DTO.Post Post (DTO.Post post) {
            try {
                var parsePost = new DAL.Post(
                    post.CreatedAt,
                    post.Description,
                    post.ImageSource,
                    post.Latitud,
                    post.Longitud,
                    post.User,
                    post.Url
                );

                context.Posts.Add(parsePost);

                var hastagsList = context.Hashtags.ToList();

                foreach (var hashtag in hastagsList) {
                    if (this.ContainsHashtag(post.Description, hashtag.Name)) {
                        var id = context.Hashtags.Where (x => x.Name == hashtag.Name).Select(y => y.Id).First();
                        
                        var postHashtag = new DAL.PostHashtags {
                            PostId = parsePost.Id,
                            HashtagId = id
                        };

                        context.PostHastags.Add(postHashtag);
                    }
                }
                
                context.SaveChanges();                

                return post;
           }
           catch (MySql.Data.MySqlClient.MySqlException exception)
           {
               throw new DTO.MapaSolidarioException(exception, ERROR_MESSAGE);
           }
        }

        private Boolean ContainsHashtag (String description, String hashtag) {
            return description.ToUpper().Contains(hashtag.ToUpper());
        }

        public List<PostHashtags> Get(DateTime created_at){
           try
           {
                var posts = context.PostHastags
                .Include(post => post.Post)
                .Include(post => post.Hashtag).Where(post => post.Post.CreatedAt >= created_at)
                .ToList();
                return posts;
           }
           catch (MySql.Data.MySqlClient.MySqlException exception)
           {
               throw new DTO.MapaSolidarioException(exception, ERROR_MESSAGE);
           }
        }
    }
}