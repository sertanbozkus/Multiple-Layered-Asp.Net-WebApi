using BilgeCinema.Business.Dtos;
using BilgeCinema.Business.Services;
using BilgeCinema.Data.Entities;
using BilgeCinema.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeCinema.Business.Managers
{
    public class MovieManager : IMovieService
    {
        private readonly IRepository<MovieEntity> _movieRepository;

        public MovieManager(IRepository<MovieEntity> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public bool AddMovie(MovieAddDto movieAddDto)
        {
            var entity = new MovieEntity()
            {
                Name = movieAddDto.Name,
                Type = movieAddDto.Type,
                UnitPrice = movieAddDto.UnitPrice
            };

            try
            {
                _movieRepository.Add(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public int DeleteMovie(int id)
        {
            var entity = _movieRepository.GetById(id);

            if (entity is null)
                return 0;

            try
            {
                _movieRepository.Delete(id);
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }

            // HasQueryFilter ile isDeleted == false eklemeyi unutma!
        }

        public List<MovieDto> GetAllMovies()
        {
            var movieEntities = _movieRepository.GetAll();

            var movieDtos = movieEntities.Select(x => new MovieDto()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                UnitPrice = x.UnitPrice,

            }).ToList();

            return movieDtos;
        }

        public MovieDto GetMovie(int id)
        {
            var entity = _movieRepository.GetById(id);

            if (entity is null)
                return null;

            var movieDto = new MovieDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = entity.Type,
                UnitPrice = entity.UnitPrice
            };

            return movieDto;
        }

        public int MakeDiscount(int id) 
        {
            var entity = _movieRepository.GetById(id);

            if (entity is null)
                return 0;

            entity.IsDiscounted = !entity.IsDiscounted;

            if (entity.IsDiscounted)
                entity.UnitPrice = entity.UnitPrice / 2;
            else
                entity.UnitPrice = entity.UnitPrice * 2;

            // 50% indirim uygulanıyor. Farklı oranlar istenirse onlar da parametre olarak gönderilmeli.

            try
            {
                _movieRepository.Update(entity);
                return 1;
            }
            catch (Exception)
            {

                return -1;
            }

        }

        public int UpdateMovie(MovieUpdateDto movieUpdateDto)
        {
            var entity = _movieRepository.GetById(movieUpdateDto.Id);
            if(entity is not null)
            {
                entity.Name = movieUpdateDto.Name;
                entity.Type = movieUpdateDto.Type;
                entity.UnitPrice = movieUpdateDto.UnitPrice;

                try
                {
                    _movieRepository.Update(entity);
                    return 1;
                }
                catch (Exception)
                {

                    return -1;
                }

            }
            else
                return 0;
          
        }
    }
}
