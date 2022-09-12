using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using Mapping.IRepository;
using Mapping.Repository;
using AutoMapper;
using Mapping.DTO;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepository _service;
        private readonly IMapper _map;
        public PeopleController(IPersonRepository context, IMapper map)
        {
            _service = context;
            _map = map;
            Console.WriteLine("Init Controller");
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetPeople()
        {

            //if (_context.People == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.People.ToListAsync();
            var list = await _service.GetAll();
            if(list.Count() <= 0)
            {
                return NotFound();
            }
            return Ok(list);
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
          //if (_context.People == null)
          //{
          //    return NotFound();
          //}
          //  var person = await _context.People.FindAsync(id);

          //  if (person == null)
          //  {
          //      return NotFound();
          //  }

          //  return person;
          var person = await _service.Get(id);
            return Ok(person);
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, PersonDTO person)
        {
            //if (id != person.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(person).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PersonExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
            person.Id = id;
            return Ok(await _service.Update(person));
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(PersonDTO person)
        {
            //if (_context.People == null)
            //{
            //    return Problem("Entity set 'DemoContext.People'  is null.");
            //}
            //  _context.People.Add(person);
            //  await _context.SaveChangesAsync();

            //  return CreatedAtAction("GetPerson", new { id = person.Id }, person);
            return Ok(await _service.Create(person));
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            //if (_context.People == null)
            //{
            //    return NotFound();
            //}
            //var person = await _context.People.FindAsync(id);
            //if (person == null)
            //{
            //    return NotFound();
            //}

            //_context.People.Remove(person);
            //await _context.SaveChangesAsync();

            //return NoContent();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            //return (_context.People?.Any(e => e.Id == id)).GetValueOrDefault();
            var person = _service.Get(id);
            if(person == null)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
