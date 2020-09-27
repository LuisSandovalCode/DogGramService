using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using DogGramService.API.Business;
using DogGramService.API.Model;
using DogGramService.API.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogGramService.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly UserBusiness _userBusiness;

        public UserController(IUserRepository userRepository)
        {
            _userBusiness = new UserBusiness(userRepository);
        }

        [Route("CreateUser")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]User user)
        {
            try
            {
                return Ok(await _userBusiness.AddUser(user));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [Route("LogIn")]
        [HttpPost]
        public async Task<IActionResult> LogInUser([FromHeader]string email,[FromHeader]string password)
        {
            try
            {
                return Ok(await _userBusiness.GetUser(email, password));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

    }
}