using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DogGramService.API.Business;
using DogGramService.API.Model;
using DogGramService.API.Repository.Photo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogGramService.API.Controllers
{
    [Route("api/Photo")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        readonly PhotoBusiness _photoBusiness;

        public PhotoController(IPhotoRepository photoRepository)
        {
            _photoBusiness = new PhotoBusiness(photoRepository);
        }

        [Route("AddPhoto")]
        public async Task<IActionResult> Create([FromBody]Photo photo)
        {
            try
            {
                return Ok(await _photoBusiness.AddPhoto(photo));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [Route("UpdatePhoto")]
        public async Task<IActionResult> Update([FromHeader]string id,[FromBody]Photo photo)
        {
            try
            {
                return Ok(await _photoBusiness.UpdatePhoto(id,photo));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [Route("AddLike")]
        public async Task<IActionResult> Like([FromHeader]string id)
        {
            try
            {
                return Ok(await _photoBusiness.AddLike(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

    }
}