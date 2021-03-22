using FirstCoreWebApplicationProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebApplicationProject.Controllers
{
    public class MovieController : Controller
    {
        Movies movies = new Movies();
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(MovieDetails movieDetailsInput)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    movies.PopulateMovies(movieDetailsInput);

                    return RedirectToAction("ViewMovies", "Movie");
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            return View();
        }

        public IActionResult ViewMovies()
        {
            var moviesList = movies.GetMovies().ToList();
            return View(moviesList);
        }

        public IActionResult EditMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditMovie(MovieDetails movieDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var moviesList = movies.GetMovies().ToList();
                    int flag = 0;
                    foreach (var movieListObject in moviesList)
                    {
                        if (movieListObject.MovieName == movieDetails.MovieName)
                        {
                            movieListObject.MovieGenre = movieDetails.MovieGenre;
                            flag = 0;
                            break;

                        }
                        else
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 1)
                    {
                        ViewBag.Message = "Movie not Found";
                    }
                    else
                    {
                        return RedirectToAction("ViewMovies", "Movie");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            return View();
        }

        public IActionResult DeleteMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteMovie(MovieDetails movieDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var moviesList = movies.GetMovies().ToList();
                    int flag = 0;
                    foreach (var movieListObject in moviesList)
                    {
                        if (movieListObject.MovieName == movieDetails.MovieName)
                        {
                            int index = moviesList.FindIndex(movies => movies.MovieName == movieListObject.MovieName);
                            movies.GetMovies().Remove(moviesList[index]);
                            flag = 0;
                            break;
                        }
                        else
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 1)
                    {
                        ViewBag.Message = "Movie not Found";
                    }
                    else
                    {
                        return RedirectToAction("ViewMovies", "Movie");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            return View();
        }



    }
}
