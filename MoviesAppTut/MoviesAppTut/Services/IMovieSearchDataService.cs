using MoviesAppTut.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAppTut.Services
{
    public interface IMovieSearchDataService
    {
		  Task<List<MovieInfo>> GetMovieSearch(string query);
    }
}
