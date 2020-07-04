using CoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Service
{
    public class CinemaService : ICinemaService
    {
        private readonly List<Cinema> _cinemas = new List<Cinema>();

        public CinemaService()
        {
            _cinemas.Add(new Cinema
            {
                Name = "City Cinema",
                Location = "No.123",
                Id = 1

            });
            _cinemas.Add(new Cinema
            {
                Name = "Fly Cinema",
                Location = "No.1024",
                Id = 2

            });
        }
        public Task AddAsync(Cinema model)
        {
            var maxId = _cinemas.Max(x => x.Id);
            model.Id = maxId + 1;
            _cinemas.Add(model);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return Task.Run(() => _cinemas.AsEnumerable());
        }

        public Task<Cinema> GetByIdAsync(int Id)
        {
            return Task.Run(() => _cinemas.FirstOrDefault(x => x.Id == Id));
        }

        public Task<Sales> GetSalesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
