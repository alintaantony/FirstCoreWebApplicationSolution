using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebApplicationProject.Models
{
    public class Movies
    {
        static List<MovieDetails> moviesList = new List<MovieDetails>();
        static Movies()
        {
            moviesList = new List<MovieDetails>()
            {
                new MovieDetails() { MovieName = "Forrest Gump", MovieGenre = "Drama" }
            };
        }
        
        public List<MovieDetails> PopulateMovies(MovieDetails movieDetails)
        {
            moviesList.Add(movieDetails);
            return moviesList;

        }

        public List<MovieDetails> GetMovies()
        {
            return moviesList;
        }

    }
}
