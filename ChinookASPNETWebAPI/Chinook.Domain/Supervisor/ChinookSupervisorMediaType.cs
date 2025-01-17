using System;
using System.Collections.Generic;
using Chinook.Domain.ApiModels;
using System.Linq;
using Chinook.Domain.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace Chinook.Domain.Supervisor
{
    public partial class ChinookSupervisor
    {
        public IEnumerable<MediaTypeApiModel> GetAllMediaType()
        {
            var mediaTypes = _mediaTypeRepository.GetAll().ConvertAll();
            foreach (var mediaType in mediaTypes)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(string.Concat((object?) "MediaType-", mediaType.Id), mediaType, cacheEntryOptions);
            }
            return mediaTypes;
        }

        public MediaTypeApiModel GetMediaTypeById(int id)
        {
            var mediaTypeApiModelCached = _cache.Get<MediaTypeApiModel>(string.Concat("MediaType-", id));

            if (mediaTypeApiModelCached != null)
            {
                return mediaTypeApiModelCached;
            }
            else
            {
                var mediaTypeApiModel = (_mediaTypeRepository.GetById(id)).Convert();
                mediaTypeApiModel.Tracks = (GetTrackByMediaTypeId(mediaTypeApiModel.Id)).ToList();

                var cacheEntryOptions =
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(string.Concat((object?) "MediaType-", mediaTypeApiModel.Id), mediaTypeApiModel, cacheEntryOptions);

                return mediaTypeApiModel;
            }
        }

        public MediaTypeApiModel AddMediaType(MediaTypeApiModel newMediaTypeApiModel)
        {
            /*var mediaType = new MediaType
            {
                Name = newMediaTypeApiModel.Name
            };*/

            var mediaType = newMediaTypeApiModel.Convert();

            mediaType = _mediaTypeRepository.Add(mediaType);
            newMediaTypeApiModel.Id = mediaType.Id;
            return newMediaTypeApiModel;
        }

        public bool UpdateMediaType(MediaTypeApiModel mediaTypeApiModel)
        {
            var mediaType = _mediaTypeRepository.GetById(mediaTypeApiModel.Id);

            if (mediaType == null) return false;
            mediaType.Id = mediaTypeApiModel.Id;
            mediaType.Name = mediaTypeApiModel.Name;

            return _mediaTypeRepository.Update(mediaType);
        }

        public bool DeleteMediaType(int id) 
            => _mediaTypeRepository.Delete(id);
    }
}