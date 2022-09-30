using DigitalSignatureAPI.Model;
using DigitalSignatureAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalSignatureAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(long id)
        {
            return await _userRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            User newUser = await _userRepository.Create(user);

            return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(long id)
        {
            User user = await _userRepository.GetById(id);

            if (user == null)
                return NotFound();

            await _userRepository.Delete(user.Id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(long id, [FromBody] User user)
        {
            if (user.Id == id)
                return BadRequest();

            await _userRepository.Update(user);

            return NoContent();
        }
    }
}
