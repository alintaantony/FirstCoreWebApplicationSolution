using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebApplicationProject.Models
{
    public class MovieDetails
    {
        
        public MovieDetails()
        {

        }

        public MovieDetails(string movieName, string movieGenre)
        {
            MovieName = movieName;
            MovieGenre = movieGenre;
        }

        [Required(ErrorMessage = "Please Enter the Movie Name")]
        [DisplayName("Movie Name")]
        public string MovieName { get; set; }
        [DisplayName("Movie Genre")]
        public string MovieGenre { get; set; }

    }
}
