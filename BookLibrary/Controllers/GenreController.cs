using AutoMapper;
using BookLibrary.DTOs.Genre;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _GenreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService GenreService, IMapper mapper)
        {
            _GenreService = GenreService;
            _mapper = mapper;
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post(GenreInsDto GenreDto)
        {

            var Genre = await _GenreService.AddAsync(_mapper.Map<Genre>(GenreDto));

            return Ok();

        }

        // GET api/<GenreController>/5
        [HttpGet()]
        //just top 5 for know
        public async Task<IActionResult> GetTopEntities()
        {

            var Genres = await _GenreService.GetTopEntitiesByBook();

            return Ok(_mapper.Map<IEnumerable<Genre>, IEnumerable<GenreUpdDto>>(Genres));
        }
    }
}
