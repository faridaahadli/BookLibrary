using AutoMapper;
using BookLibrary.DTOs;
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
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService,IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        // GET: api/<BookController>
        

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           
           var book= _mapper.Map<BookDto>(await _bookService.GetByIdAsync(id));
            return Ok(book);
        }

        [HttpGet("genre/{id}")]
        public async Task<IActionResult> GetBookByGenre(int id)
        {

            var books= await _bookService.GetBooksByGenre(id);
            return Ok(books);
        }


        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post(BookInsDto bookDto)
        {
             var book=await _bookService.AddAsync(_mapper.Map<Book>(bookDto));
             
            return Ok();

        }

        // PUT api/<BookController>/5
        [HttpPut]
        public IActionResult Update(BookUpdDto bookUpdDto)
        {
            var book=_bookService.Update(_mapper.Map<Book>(bookUpdDto));

            return Ok(book);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Remove(id);
            return Ok();
        }
    }
}
