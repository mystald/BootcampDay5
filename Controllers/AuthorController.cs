using AutoMapper;
using BootcampDay5.Data;
using BootcampDay5.Dtos;
using BootcampDay5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BootcampDay5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthor _author;
        private IMapper _mapper;

        public AuthorController(IAuthor author, IMapper mapper)
        {
            _author = author ?? throw new System.ArgumentNullException(nameof(author));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }
        
        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get(string name)
        {
            IEnumerable<Author> result;

            if (name == null)
            {
                result = await _author.GetAll();
            }
            else
            {
                result = await _author.GetByName(name);
            }

            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(result));
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(int id)
        {
            try
            {
                var result = await _author.GetById(id);

                return Ok(_mapper.Map<AuthorDto>(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Post([FromBody] AuthorInsertDto value)
        {
            try
            {
                var result = await _author.Insert(_mapper.Map<Author>(value));

                return Ok(_mapper.Map<AuthorDto>(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Put(int id, [FromBody] AuthorInsertDto value)
        {
            try
            {
                var result = await _author.Update(id, _mapper.Map<Author>(value));

                return Ok(_mapper.Map<AuthorDto>(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorDto>> Delete(int id)
        {
            try
            {
                var result = await _author.Delete(id);

                return Ok(_mapper.Map<AuthorDto>(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
