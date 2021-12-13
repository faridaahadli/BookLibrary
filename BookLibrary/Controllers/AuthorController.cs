using AutoMapper;
using BookLibrary.DTOs.Author;
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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post(AuthorInsDto authorDto)
        {

            var author = await _authorService.AddAsync(_mapper.Map<Author>(authorDto));

            return Ok();

        }

        // GET api/<AuthorController>/5
        [HttpGet()]
        //just top 5 for know
        public async Task<IActionResult> GetTopEntities()
        {

            var authors = await _authorService.GetTopEntitiesByBook();

            return Ok(_mapper.Map<IEnumerable<Author>,IEnumerable<AuthorUpdDto>>(authors));
        }

    
    }
}
