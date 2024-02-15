using BilgeCinema.Business.Dtos;
using BilgeCinema.Business.Services;
using BilgeCinema.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BilgeCinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovieRequest request)
        {
            var movieAddDto = new MovieAddDto()
            {
                Name = request.Name,
                Type = request.Type,
                UnitPrice = request.UnitPrice
            };

            var result = _movieService.AddMovie(movieAddDto);

            if (result)
                return Ok();
            else
                return StatusCode(500);


        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, UpdateMovieRequest request)
        {
            var movieUpdateDto = new MovieUpdateDto()
            {
                Id = id,
                Name = request.Name,
                Type = request.Type,
                UnitPrice = request.UnitPrice
            };

            var result = _movieService.UpdateMovie(movieUpdateDto);

            switch (result)
            {
                case 0:
                    return NotFound();

                case 1:
                    return Ok();

                default:
                    return StatusCode(500);
            }
        }


        [HttpPatch("{id}")]
        public IActionResult DiscountMovie(int id)
        {
            var result = _movieService.MakeDiscount(id);

            switch (result)
            {
                case 0:
                    return NotFound();

                case 1:
                    return Ok();

                default:
                    return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var result = _movieService.DeleteMovie(id);

            switch (result)
            {
                case 0:
                    return BadRequest();

                case 1:
                    return Ok();

                default:
                    return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {

            var movieDto = _movieService.GetMovie(id);

            if (movieDto is null)
                return NotFound();

            var response = new MovieResponse()
            {
                Id = movieDto.Id,
                Name = movieDto.Name,
                Type = movieDto.Type,
                UnitPrice = movieDto.UnitPrice,
            };

            return Ok(response);
            
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
        
            var moviesDtos = _movieService.GetAllMovies();

            var response = moviesDtos.Select(x => new MovieResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                UnitPrice = x.UnitPrice
            }).ToList();

            return Ok(response);
        
        }
    }
}

