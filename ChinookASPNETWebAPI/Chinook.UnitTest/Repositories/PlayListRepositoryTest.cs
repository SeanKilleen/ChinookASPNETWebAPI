﻿using Chinook.Domain.Repositories;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class PlayListRepositoryTest
    {
        private readonly IPlaylistRepository _repo;

        public PlayListRepositoryTest(IPlaylistRepository p) => _repo = p;

        [Fact]
        public void PlayListGetAll()
        {
            // Act
            var playLists = _repo.GetAll();

            // Assert
            Assert.True(playLists.Count > 1, "The number of play lists was not greater than 1");
        }
    }
}