
namespace MovieStars.Models {
    public class Person {
        public bool adult { get; set; }
        public List<string> also_known_as { get; set; } = default!;
        public string biography { get; set; } = default!;
        public string? birthday { get; set; } = default!;
        public string? deathday { get; set; } = default!;
        public int gender { get; set; }
        public string? homepage { get; set; } = default!;
        public int id { get; set; }
        public string imdb_id { get; set; } = default!;
        public string known_for_department { get; set; } = default!;
        public string name { get; set; } = default!;
        public string? place_of_birth { get; set; } = default!;
        public double popularity { get; set; }
        public string? profile_path { get; set; } = default!;


        /// GetProfilePath is a method. When we call it, it will return a URL. example: https://image.tmdb.org/t/p/w500/4cpvSGrJg2hwddkTPMyDKj0c3O.jpg
        public string? GetProfilePath() {
            return $"https://image.tmdb.org/t/p/w500{profile_path}";
        }

        /// GetGender is a method. When we call it, it will return one of the following (empty, Male, FeMale)
        
        public string? GetGender() {
            /// don't think I will use it, but its here in case I do (get it? in "case") 
            switch(gender) {
                case 1:
                    return "Female";
                case 2:
                    return "Male";
                default:
                    return "";
            }
        }

        /// GetAge is a method. When we call it, it will return empty or Age if Birthday Exist

        public string? GetAge() {
            if (!string.IsNullOrEmpty(birthday)) {
                var birth = Convert.ToDateTime(birthday);
                var age = DateTime.Now.Year - birth.Year;
                return age.ToString();
            }
            return string.Empty;
        }
    }
}
