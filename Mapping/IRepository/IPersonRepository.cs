using Mapping.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Mapping.IRepository
{
    public interface IPersonRepository
    {
        public Task<PersonDTO> Create(PersonDTO person);
        public Task<PersonDTO> Update(PersonDTO person);
        public Task<bool> Delete(int id);

        public Task<PersonDTO> Get(int id);
        public Task<List<PersonDTO>> GetAll();
    }
}
