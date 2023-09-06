using MovieStars.Models;
using System.Text.Json;

namespace MovieStars.API;

public static class Fetch {
    public static HttpClient client = new HttpClient();
    public const string API_KEY = "d194eb72915bc79fac2eb1a70a71ddd3";
    public static string Data { get; set; }
    public static PosterSet posterSet = new PosterSet();
    public static Movie movie = new Movie();
    public static CastCrew castCrew = new CastCrew();
    public static VideoSet videoSet = new VideoSet();
    public static ResultSet resultSet = new ResultSet();
    public static Person person = new Person();
    public static PersonImages personImages = new PersonImages();

    public static async Task GetTrends() {
        ClearHeaders();

        // Get the latest Movie Trends, for the last week
        // https://api.themoviedb.org/3/trending/all/day?api_key=<<api_key>>
        HttpResponseMessage response = await client.GetAsync(
            "https://api.themoviedb.org/3/trending/movie/week?api_key=" + API_KEY);

        if(response.IsSuccessStatusCode) { // 200 OK
            Data = await response.Content.ReadAsStringAsync();
            // parse the JSON into C# classes
            posterSet = JsonSerializer.Deserialize<PosterSet>(Data);
        }
        else {
            Data = null;
        }
    } // GetTrends()

    public static async Task MovieSearch(string search) {
        ClearHeaders();

        // Search for a movie based on a query string
        // https://api.themoviedb.org/3/search/movie?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US&page=1&include_adult=false&query=Ghost%20In%20The%20Shell
        HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/search/movie?api_key=" + API_KEY + "&language=en-US&page=1&include_adult=false&query=" + search);

        if(response.IsSuccessStatusCode) { // 200 OK
            Data = await response.Content.ReadAsStringAsync();
            // parse the JSON into C# classes
            resultSet = JsonSerializer.Deserialize<ResultSet>(Data);
        }
        else {
            Data = null;
        }
    } // MovieSearch()

    public static async Task MovieDetails(string movieID) {
        ClearHeaders();

        // Get the details for a specific movie, based on the movieID
        // https://api.themoviedb.org/3/movie/505642?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US
        HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/movie/" + movieID + "?api_key=" + API_KEY + "&language=en-US");

        if(response.IsSuccessStatusCode) { // 200 OK
            Data = await response.Content.ReadAsStringAsync();
            // parse the JSON into C# classes
            movie = JsonSerializer.Deserialize<Movie>(Data);
        }
        else {
            Data = null;
        }

        // Next get the cast members for the movie
        // https://api.themoviedb.org/3/movie/640146/credits?api_key=<<api_key>>&language=en-US
        response = await client.GetAsync("https://api.themoviedb.org/3/movie/" + movieID + "/credits?api_key=" + API_KEY + "&language=en-US");

        if(response.IsSuccessStatusCode) { // 200 OK
            Data = await response.Content.ReadAsStringAsync();
            // parse the JSON into C# classes
            castCrew = JsonSerializer.Deserialize<CastCrew>(Data);
        }
        else {
            Data = null;
        }

        // Last but not least let's grab the YouTube videos
        // https://api.themoviedb.org/3/movie/{movie_id}/videos?api_key=<<api_key>>&language=en-US
        response = await client.GetAsync("https://api.themoviedb.org/3/movie/" + movieID + "/videos?api_key=" + API_KEY + "&language=en-US");

        if(response.IsSuccessStatusCode) { // 200 OK
            Data = await response.Content.ReadAsStringAsync();
            // parse the JSON into C# classes
            videoSet = JsonSerializer.Deserialize<VideoSet>(Data);
        }
        else {
            Data = null;
        }
    } // MovieDetails()
    public static async Task ActorDetail(string actorID) {
        ClearHeaders();

        HttpResponseMessage response = await client.GetAsync("https://api.themoviedb.org/3/person/" + actorID + "?api_key=" + API_KEY + "&language=en-US");

        if (response.IsSuccessStatusCode) { // 200 OK
            Data = await response.Content.ReadAsStringAsync();
            // parse the JSON into C# classes
            person = JsonSerializer.Deserialize<Person>(Data);
        }
        else {
            Data = null;
        }

        // getting images
        response = await client.GetAsync($"https://api.themoviedb.org/3/person/{actorID}/images?api_key={API_KEY}&language=en-US"); // learning new ways to add string with "$"
        if (response.IsSuccessStatusCode) { // 200 OK
            Data = await response.Content.ReadAsStringAsync();
            // parse the JSON into C# classes
            personImages = JsonSerializer.Deserialize<PersonImages>(Data);
        }
        else {
            Data = null;
        }
    }
        private static void ClearHeaders() {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicationException/json"));
    } // ClearHeader()
    
} // class