using System;
using System.Collections.Generic;

namespace Core.DTO
{
    public class HashtagList
    {
        public string Hashtag { get; set; }
        public List<Post> Posts { get; set; }
    }
}