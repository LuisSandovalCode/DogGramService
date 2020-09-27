using DogGramService.API.Http;
using DogGramService.API.Model;
using DogGramService.API.Repository.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace DogGramService.API.Business
{
    public class PhotoBusiness
    {
        readonly IPhotoRepository _photoRepository;

        public PhotoBusiness(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<GenericResponse<bool>> AddPhoto(Photo photo)
        {
            var vloResponse = new GenericResponse<bool>();
            try
            {
                vloResponse.Status = HttpStatusCode.OK;
                vloResponse.Response = await _photoRepository.AddPhoto(photo);
            }
            catch (Exception ex)
            {
                vloResponse.Status = HttpStatusCode.BadRequest;
                vloResponse.Response = false;
            }

            return vloResponse;
        }

        public async Task<GenericResponse<bool>> UpdatePhoto(string id,Photo photo)
        {
            var vloResponse = new GenericResponse<bool>();
            try
            {
                vloResponse.Status = HttpStatusCode.OK;
                vloResponse.Response = await _photoRepository.UpdatePhoto(id,photo);
            }
            catch (Exception ex)
            {
                vloResponse.Status = HttpStatusCode.BadRequest;
                vloResponse.Response = false;
            }

            return vloResponse;
        }

        public async Task<GenericResponse<bool>> AddLike(string id)
        {
            var vloResponse = new GenericResponse<bool>();
            try
            {
                vloResponse.Status = HttpStatusCode.OK;
                vloResponse.Response = await _photoRepository.AddLike(id);
            }
            catch (Exception ex)
            {
                vloResponse.Status = HttpStatusCode.BadRequest;
                vloResponse.Response = false;
            }

            return vloResponse;
        }

        public async Task<GenericResponse<IEnumerable<Photo>>> GetPhotos()
        {
            var vloResponse = new GenericResponse<IEnumerable<Photo>>();

            try
            {
                vloResponse.Status = HttpStatusCode.OK;
                vloResponse.Response = await _photoRepository.GetPhotos();
            }
            catch (Exception ex)
            {
                vloResponse.Status = HttpStatusCode.BadRequest;
                vloResponse.Response = new List<Photo>();
            }

            return vloResponse;
        }

    }
}
