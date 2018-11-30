using System;
using System.Collections.Generic;

namespace Core.DTO
{
    public class Post
    {
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string User { get; set; }
        public string Url { get; set; }

    }
}