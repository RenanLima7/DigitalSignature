using DigitalSignature.Model;
using DigitalSignatureAPI.Model.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalSignatureAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly UserContext _context;

        public UserRepository(UserContext userContext)
        {
            _context = userContext;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task Delete(long id)
        {
            User userToDelete = await _context.Users.FindAsync(id);
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
