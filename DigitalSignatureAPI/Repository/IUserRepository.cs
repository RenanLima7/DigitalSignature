using DigitalSignatureAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalSignatureAPI.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(long id);
        Task<User> Create(User user);
        Task Update(User user);
        Task Delete(long id);
    }
}
