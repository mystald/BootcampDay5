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
    public class CourseController : ControllerBase
    {
        private ICourse _course;
        private IMapper _mapper;

        public CourseController(ICourse course, IMapper mapper)
        {
            _course = course ?? throw new System.ArgumentNullException(nameof(course));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get(string name)
        {
            IEnumerable<Course> result;

            if (name == null)
            {
                result = await _course.GetAll();
            }
            else
            {
                result = await _course.GetByName(name);
            }

            return Ok(_mapper.Map<IEnumerable<CourseDto>>(result));
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            try
            {
                var result = await _course.GetById(id);

                return Ok(_mapper.Map<CourseDto>(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult<CourseDto>> Post([FromBody] CourseInsertDto value)
        {
            try
            {
                var result = await _course.Insert(_mapper.Map<Course>(value));

                return Ok(_mapper.Map<CourseDto>(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> Put(int id, [FromBody] CourseInsertDto value)
        {
            try
            {
                var result = await _course.Update(id, _mapper.Map<Course>(value));

                return Ok(_mapper.Map<CourseDto>(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseDto>> Delete(int id)
        {
            try
            {
                var result = await _course.Delete(id);

                return Ok(_mapper.Map<CourseDto>(result));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
