using Labb4_API.Models;
using Labb4_API.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private ILabb4_API<Person> _persons;

        public PersonController(ILabb4_API<Person> persons)
        {
            _persons = persons;
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Ok(_persons.GetAll());
        }

    }
}
