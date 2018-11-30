using System.Collections.Generic;
using System.Linq;
using Core.DTO;
using Core.Interface;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace Core.Services {
    public class HashtagService : IHashtagService {
        private const string ERROR_MESSAGE = "No se ha podido encontrar resultados.";
        private ApiDbContext apiDbContext;
        public HashtagService (ApiDbContext apiDbContext) {
            this.apiDbContext = apiDbContext;
        }
        public List<DTO.Hashtag> Get() {
            try {
                var hashtags = this.apiDbContext.Hashtags.Select (hashtag => new DTO.Hashtag {
                    Name = hashtag.Name,
                    Code = hashtag.Code,
                    Id = hashtag.Id
                }).ToList ();
            
                return hashtags;
            }
           catch (MySql.Data.MySqlClient.MySqlException exception)
           {
               throw new DTO.MapaSolidarioException(exception, ERROR_MESSAGE);
           }
        }
    }
}