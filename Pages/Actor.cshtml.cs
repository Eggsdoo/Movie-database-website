using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieStars.API;
using MovieStars.Models;

namespace MovieStars.Pages;

public class ActorModel : PageModel {
    public string backdrop_path = "https://image.tmdb.org/t/p/w1920_and_h800_multi_faces";
    public string poster_path = "https://image.tmdb.org/t/p/w500";
    public Person? person { get; set; }
    public PersonImages? personImages { get; set; }

    public async Task OnGet(string actorID) {
        await Fetch.ActorDetail(actorID);
        person = Fetch.person;
        personImages = Fetch.personImages;
    }
}