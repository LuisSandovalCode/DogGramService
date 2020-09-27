using DogGramService.API.Model;
using DogGramService.API.Repository.Interfaces;
using DogGramService.API.Utils;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGramService.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private const string COLLECTION_NAME = "users";
        readonly Context _context = null;

        public UserRepository(IOptions<Settings> setting)
        {
            _context = new Context(setting);
        }

        public async Task<bool> Add(User entity)
        {
            try
            {
                await _context
                            .GetCollection<User>(COLLECTION_NAME)
                            .InsertOneAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
               DeleteResult deleteResult = await _context
                        .GetCollection<User>(COLLECTION_NAME)
                        .DeleteOneAsync(Builders<User>.Filter.Eq("Id", id));

                return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> Get(string email, string password)
        {
            try
            {
                return await _context
                                    .GetCollection<User>(COLLECTION_NAME)
                                    .Find(user => user.Email.Equals(email) &&
                                          user.Password.Equals(password))
                                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(string id, User body)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq("Id", id);
                var update = Builders<User>.Update
                                           .Set(user => user.Name, body.Name)
                                           .Set(user => user.LastName, body.LastName)
                                           .Set(user => user.Email, body.Email)
                                           .Set(user => user.NickName, body.NickName)
                                           .Set(user => user.Password, body.Password)
                                           .CurrentDate(user => user.UpdatedOn);

                UpdateResult updateResult = await _context
                                                    .GetCollection<User>(COLLECTION_NAME)
                                                    .UpdateOneAsync(filter, update);

                return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
