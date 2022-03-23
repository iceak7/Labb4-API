using Microsoft.AspNetCore.Mvc;
using Labb4_API.Models;
using Labb4_API.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private IHobbyRepository _hobbies;

        public HobbyController(IHobbyRepository hobbies)
        {
            _hobbies = hobbies;
        }
        [HttpGet("{Id:int}")]
        public IActionResult GetSingleHobby(int Id)
        {
            var result = _hobbies.GetSingle(Id);
            if (result!=null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet("ByPerson/{PersonId}")]
        public IActionResult GetHobbiesByPerson(int PersonId)
        {
            var result = _hobbies.GetHobbiesByPerson(PersonId);
            if (result !=null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateNewHobby(Hobby newHobby)
        {
            if (newHobby == null)
            {
                return BadRequest();
            }

            var createdHobby = _hobbies.Add(newHobby);
            return CreatedAtAction(nameof(GetSingleHobby), new { id = createdHobby.HobbyId }, createdHobby);



        }
    }
}
