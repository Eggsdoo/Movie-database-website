
namespace MovieStars.Models {
    public class PersonImages {
        public PersonImages() {
            profiles = new List<Profile>();
        }
        public int id { get; set; }
        public List<Profile> profiles { get; set; }
    }
    public class Profile {
        public double aspect_ratio { get; set; }
        public int height { get; set; }
        public string? iso_639_1 { get; set; }
        public string file_path { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public int width { get; set; }


        /// GetFilePath is a method. When we call it, it will return a URL. example: https://image.tmdb.org/t/p/w500/4cpvSGrJg2hwddkTPMyDKj0c3O.jpg
        public string? GetFilePath() {
            return $"https://image.tmdb.org/t/p/w500{file_path}";
        }
    }
}
