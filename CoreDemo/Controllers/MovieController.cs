using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Models;
using CoreDemo.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class MovieController : Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly IMovieService _movieService;

        public MovieController(ICinemaService cinemaService, IMovieService movieService)
        {
            _cinemaService = cinemaService;
            _movieService = movieService;
        }

        //在特定电影ID下显示电影名
        public async Task<IActionResult> Index(int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            ViewBag.Title = $"{cinema.Name}电影院上映的有：";
            ViewBag.cinemaId = cinemaId;
            return View(await _movieService.GetCinemaAsync(cinemaId));
        }

        public IActionResult Add(int cinemaId)
        {
            ViewBag.Title = "添加电影";
            return View(new Movie { CinemaId = cinemaId });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddAsync(movie);
            }

            //这里返回上面的Index时，发现有参数所以添加下参数
            return RedirectToAction("Index", new { cinemaId = movie.CinemaId });
        }
        public IActionResult Edit(int movieId)
        {
            return RedirectToAction("Index");
        }
    }
}