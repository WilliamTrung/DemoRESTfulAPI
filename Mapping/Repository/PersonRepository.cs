using AutoMapper;
using Data;
using Mapping.DTO;
using Mapping.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Mapping.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DemoContext _context;
        private readonly IMapper _map;

        public PersonRepository(DemoContext context, IMapper map)
        {
            _context = context;
            _map = map;
            Console.WriteLine("Init Repository");
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<PersonDTO> Create(PersonDTO person)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //throw new NotImplementedException();
            PersonDTO personDTO = new PersonDTO()
            {
                Name = person.Name,
                Age = person.Age,
                Created = DateTime.Now,
                Established = DateTime.Now
            };
            Person person_adding = _map.Map<Person>(personDTO);
            _context.Add(person_adding);
            await _context.SaveChangesAsync();
            return _map.Map<PersonDTO>(person_adding);
        }

        public async Task<bool> Delete(int id)
        {
            //throw new NotImplementedException();
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                _context.Remove(person);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<PersonDTO> Get(int id)
        {
            //throw new NotImplementedException();
            var person = await _context.People.FindAsync(id);
            PersonDTO personDTO = _map.Map<PersonDTO>(person);
            return personDTO;
        }

        public async Task<List<PersonDTO>> GetAll()
        {
            //throw new NotImplementedException();
            var list = await _context.People.OrderBy(p => p.Name).ToListAsync();
            var result = new List<PersonDTO>();
            list.ForEach(p => result.Add(_map.Map<PersonDTO>(p)));
            return result;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<PersonDTO> Update(PersonDTO person)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            //throw new NotImplementedException();
            Person update = _map.Map<Person>(person);
            _context.People.Update(update);
            await _context.SaveChangesAsync();
            return person;
        }
    }
}
