using DogGramService.API.Model;
using DogGramService.API.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotoUser = DogGramService.API.Model.Photo;
namespace DogGramService.API.Repository.Photo
{
    public class PhotoRepository : IPhotoRepository
    {
        const string COLLECTION_NAME = "photos";
        readonly Context _context = null;

        public PhotoRepository(IOptions<Settings> setting)
        {
            _context = new Context(setting);
        }

        public async Task<bool> AddLike(string id)
        {
            try
            {
                var filter = Builders<PhotoUser>.Filter
                                                .Eq("Id", id);
                var update = Builders<PhotoUser>.Update
                                                .Inc(photo => photo.Likes, 1);

                UpdateResult updateResult = await _context.GetCollection<PhotoUser>(COLLECTION_NAME)
                                                    .UpdateOneAsync(filter, update);

                return updateResult.IsAcknowledged && updateResult.MatchedCount > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddPhoto(PhotoUser photo)
        {
            try
            {
                await _context.GetCollection<PhotoUser>(COLLECTION_NAME)
                              .InsertOneAsync(photo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PhotoUser>> GetPhotos()
        {
            try
            {
                return await _context.GetCollection<PhotoUser>(COLLECTION_NAME)
                                     .Find(_ => true)
                                     .ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdatePhoto(string id, PhotoUser photo)
        {
            try
            {
                var filter = Builders<PhotoUser>.Filter
                                .Eq("Id", id);
                var update = Builders<PhotoUser>.Update
                                                .Set(photo => photo.URI, photo.URI);

                UpdateResult updateResult = await _context.GetCollection<PhotoUser>(COLLECTION_NAME)
                                    .UpdateOneAsync(filter, update);

                return updateResult.IsAcknowledged && updateResult.MatchedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
