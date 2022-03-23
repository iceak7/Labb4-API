using Microsoft.AspNetCore.Mvc;
using Labb4_API.Models;
using Labb4_API.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Labb4_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : Controller
    {
        private ILinkRepository _links;

        public LinkController(ILinkRepository links)
        {
            _links = links;
        }
        [HttpGet("{Id:int}")]
        public IActionResult GetSingleLink(int Id)
        {
            var result = _links.GetSingle(Id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet("ByPerson/{PersonId}")]
        public IActionResult GetLinksByPerson(int PersonId)
        {
            var result = _links.GetLinksByPerson(PersonId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult CreateNewLink(Link newLink)
        {
            if(newLink == null)
            {
                return BadRequest();
            }

            var createdLink = _links.Add(newLink);
            return CreatedAtAction(nameof(GetSingleLink), new { id = createdLink.LinkId }, createdLink);


 
        }
    }
}
