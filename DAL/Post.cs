using System;

namespace DAL
{
    public class Post
    {
        const String MAIN_HASHTAG = "#MAPASOLIDARIOORT";
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Url { get; set; }

        public Post (DateTime createdAt, String description, String imageSource, String latitud, String longitud, String user, String url) {
            if (this.Validate(description, imageSource, latitud, longitud)) {
                this.CreatedAt = createdAt;
                this.Description = description;
                this.ImageSource = imageSource;
                this.Latitud = latitud;
                this.Longitud = longitud;
                this.User = user;
                this.Url = url;
            }
        }

        private Boolean Validate (String description, String imageSource, String latitud, String longitud) {
            if (!description.ToUpper().Contains(MAIN_HASHTAG)) {
                throw new InvalidPostException("El post debe contener el hashtag " + MAIN_HASHTAG);
            }

            if (Latitud.Equals("")) {
                throw new InvalidPostException("El post debe contener una latitud valida. ");
            }

            if (Longitud.Equals("")) {
                throw new InvalidPostException("El post debe contener una Longitud valida. ");
            }

            return true;
        }
    }
}