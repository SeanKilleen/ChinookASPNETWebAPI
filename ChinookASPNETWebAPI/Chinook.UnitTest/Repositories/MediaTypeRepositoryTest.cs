﻿using Chinook.Domain.Repositories;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class MediaTypeRepositoryTest
    {
        private readonly IMediaTypeRepository _repo;

        public MediaTypeRepositoryTest(IMediaTypeRepository m) => _repo = m;

        [Fact]
        public void MediaTypeGetAll()
        {
            // Act
            var mediaTypes = _repo.GetAll();

            // Assert
            Assert.True(mediaTypes.Count > 1, "The number of media types was not greater than 1");
        }
    }
}