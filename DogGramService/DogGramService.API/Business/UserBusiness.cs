using DogGramService.API.Http;
using DogGramService.API.Model;
using DogGramService.API.Repository;
using DogGramService.API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DogGramService.API.Business
{
    public class UserBusiness
    {
        readonly IUserRepository _userRepository;
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GenericResponse<bool>> AddUser(User user)
        {
            var vloResponse = new GenericResponse<bool>();
            try
            {
                vloResponse.Status = HttpStatusCode.OK;
                vloResponse.Response = await _userRepository.Add(user);
            }
            catch (Exception ex)
            {
                vloResponse.Status = HttpStatusCode.BadRequest;
                vloResponse.Response = false;
            }
            return vloResponse;
        }

        public async Task<GenericResponse<bool>> DeleteUser(string id)
        {
            var vloResponse = new GenericResponse<bool>();
            try
            {
                vloResponse.Status = HttpStatusCode.OK;
                vloResponse.Response = await _userRepository.Delete(id);
            }
            catch (Exception ex)
            {
                vloResponse.Status = HttpStatusCode.BadRequest;
                vloResponse.Response = false;
            }
            return vloResponse;
        }

        public async Task<GenericResponse<bool>> UpdateUser(string id, User user)
        {
            var vloResponse = new GenericResponse<bool>();
            try
            {
                vloResponse.Status = HttpStatusCode.OK;
                vloResponse.Response = await _userRepository.Update(id,user);
            }
            catch (Exception ex)
            {
                vloResponse.Status = HttpStatusCode.BadRequest;
                vloResponse.Response = false;
            }
            return vloResponse;
        }

        public async Task<GenericResponse<User>> GetUser(string email, string password)
        {
            var vloResponse = new GenericResponse<User>();
            try
            {
                vloResponse.Status = HttpStatusCode.OK;
                vloResponse.Response = await _userRepository.Get(email,password);
            }
            catch (Exception ex)
            {
                vloResponse.Status = HttpStatusCode.BadRequest;
                vloResponse.Response = null;
            }
            return vloResponse;
        }

    }
}
