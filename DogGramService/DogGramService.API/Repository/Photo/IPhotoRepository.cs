using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotoUser = DogGramService.API.Model.Photo;
namespace DogGramService.API.Repository.Photo
{
    public interface IPhotoRepository
    {
        public Task<bool> AddPhoto(PhotoUser photo);
        public Task<bool> UpdatePhoto(string id,PhotoUser photo);
        public Task<bool> AddLike(string id);
        public Task<IEnumerable<PhotoUser>> GetPhotos();
    }
}
