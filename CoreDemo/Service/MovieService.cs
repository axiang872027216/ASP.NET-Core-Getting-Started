using CoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Service
{
    public class MovieService : IMovieService
    {
        private readonly List<Movie> _movies = new List<Movie>();

        public MovieService()
        {
            _movies.Add(new Movie
            {
                Id = 1,
                CinemaId = 1,
                Name = "Superman",
                ReleaseDate = new DateTime(2018, 10, 1),
                Starring = "Nick"

            });
            _movies.Add(new Movie
            {
                Id = 2,
                CinemaId = 1,
                Name = "Ghost",
                ReleaseDate = new DateTime(2018, 10, 1),
                Starring = "Michael Jackson"

            });
            _movies.Add(new Movie
            {
                Id = 3,
                CinemaId = 2,
                Name = "Fight",
                ReleaseDate = new DateTime(2018, 10, 1),
                Starring = "Tommy"

            });
        }
        public Task AddAsync(Movie model)
        {
            var maxId = _movies.Max(x => x.Id);
            model.Id = maxId + 1;
            _movies.Add(model);
            return Task.CompletedTask;

        }

        public Task<IEnumerable<Movie>> GetCinemaAsync(int cinemaId)
        {
            return Task.Run(() => _movies.Where(x => x.CinemaId == cinemaId));
        }
    }
}
