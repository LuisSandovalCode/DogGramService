using DogGramService.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGramService.API.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Add(User entity);
        Task<bool> Update(string id, User body);
        Task<bool> Delete(string id);
        Task<User> Get(string email, string password);
    }
}
