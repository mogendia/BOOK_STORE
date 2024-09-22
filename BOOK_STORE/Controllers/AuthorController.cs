using BOOK_STORE.Core.Dto;
using BOOK_STORE.Core.Interfaces;
using BOOK_STORE.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BOOK_STORE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _unitOfWork.Authors.GetById(id));
        }
        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll() 
        {
            return Ok(await _unitOfWork.Authors.GetAll());
        }



        [HttpPost("")]
        public IActionResult AddAuthor(AuthorDto dto)
        {
            Author author = _unitOfWork.Authors.AddAuthor(dto);
            _unitOfWork.complete();
            return Ok(author);
        }

        [HttpPut("updateAuthor")]
        public IActionResult UpdateAuhtor(AuthorDto author)
        {
            Author edit = _unitOfWork.Authors.UpdateAuthor(author);
            _unitOfWork.complete();
            return Ok(edit);
        }
       
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            bool deleted = _unitOfWork.Authors.DeleteOne(id);
            _unitOfWork.complete();
            return Ok(deleted);
        }
    }
}
