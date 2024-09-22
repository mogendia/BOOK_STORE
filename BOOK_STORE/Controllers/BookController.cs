using BOOK_STORE.Core.Dto;
using BOOK_STORE.Core.Interfaces;
using BOOK_STORE.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _unitOfWork.Books.GetById(id));
        }
        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Books.GetAll());
        }
        
        [HttpPost]
        public IActionResult AddBook([FromBody] BookDto bookDto)
        {
            if (bookDto == null)
                return BadRequest("Invalid data.");
            var book = _unitOfWork.Books.AddBook(bookDto);
            _unitOfWork.complete();
            return CreatedAtAction(nameof(AddBook), new { id = book.Id }, book);
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] BookDto bookDto )
        {
         var edit = _unitOfWork.Books.UpdateBook(bookDto);
            _unitOfWork.complete();
            return Ok(edit);
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            bool deleted = _unitOfWork.Books.DeleteOne(id);
            _unitOfWork.complete();
            return Ok(deleted);
        }

    }
}
