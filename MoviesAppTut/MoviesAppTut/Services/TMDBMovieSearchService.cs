using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MoviesAppTut.Models;
using Newtonsoft.Json;

namespace MoviesAppTut.Services
{
	 public class TMDBMovieSearchService : IMovieSearchDataService
	 {
		  private async Task<TMDBMovieSearch> GetTMDBMovieSearch(string query)
		  {
			   using (HttpClient client = new HttpClient())
			   {
					string TMDB_API_KEY = "YOUR_API_KEY";
					string URL = $"https://api.themoviedb.org/3/search/movie?api_key={TMDB_API_KEY}&query={query}";

					HttpResponseMessage response = await client.GetAsync(new Uri(URL));

					string jsonString = await response.Content.ReadAsStringAsync();

					TMDBMovieSearch result = JsonConvert.DeserializeObject<TMDBMovieSearch>(jsonString);

					if (result == null)
						 return new TMDBMovieSearch();

					return result;
			   }

		  }

		  public async Task<List<MovieInfo>> GetMovieSearch(string query)
		  {
			   var movieSearch = await GetTMDBMovieSearch(query);

			   if (movieSearch == new TMDBMovieSearch())
					return new List<MovieInfo>();

			   List<MovieInfo> movieInfos = new List<MovieInfo>();

			   foreach(var result in movieSearch.results)
			   {
					MovieInfo movieInfo = new MovieInfo
					{
						 Name = result.title,
						 Description = result.overview,
						 ReleaseYear = !string.IsNullOrEmpty(result.release_date) ? result.release_date.Substring(0, 4) : "",
						 ImageSource = $"https://image.tmdb.org/t/p/w600_and_h900_face/{result.poster_path}"
					};

					movieInfos.Add(movieInfo);
			   }


			   return movieInfos;
		  }


	 }
}
