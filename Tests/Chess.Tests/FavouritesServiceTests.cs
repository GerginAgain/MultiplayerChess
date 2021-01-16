namespace Chess.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Chess.Data;
    using Chess.Services.Mapping;
    using Common;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Services;
    using Services.Interfaces;
    using Xunit;

    public class FavouritesServiceTests
    {
        private IFavouritesService favouritesService;
        private static IMapper mapper;

        public FavouritesServiceTests()
        {
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                FavouritesServiceTests.mapper = mapper;
            }
        }

        [Fact]
        public async Task AddToFavoritesAsync_WithCurrentUserEqualsToNull_ShouldThrowAndInvalidOperationException()
        {
            //Arrange
            var expectedErrorMessage = "Current user can't be null";

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            var moqUserService = new Mock<IUsersService>();

            this.favouritesService = new FavouritesService(db, moqUserService.Object);

            //Act and assert
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => this.favouritesService.AddToFavoritesAsync(1));

            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task AddToFavoritesAsync_WithInvalidVideoId_ShouldThrowAnArgumentException()
        {
            //Arrange
            var expectedErrorMessage = "Video with the given id doesn't exist!";

            var option = new DbContextOptionsBuilder<ChessDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            var moqUserService = new Mock<IUsersService>();
            moqUserService.Setup(x => x.GetCurrentUserAsync())
                .ReturnsAsync(new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Ivan"
                });

            this.favouritesService = new FavouritesService(db, moqUserService.Object);

            var ex = await Assert.ThrowsAsync<ArgumentException>(() => this.favouritesService.AddToFavoritesAsync(1));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task AddToFavoritesAsync_WithValidData_ShouldReturnTrue()
        {
            //Arrange
            var option = new DbContextOptionsBuilder<ChessDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            var moqUserService = new Mock<IUsersService>();
            moqUserService.Setup(x => x.GetCurrentUserAsync())
                .ReturnsAsync(new ApplicationUser
                {
                    Id = "UserId",
                    UserName = "Ivan"
                });

            this.favouritesService = new FavouritesService(db, moqUserService.Object);

            var testingVideo = new Video
            {
                Id = 1,
                Title = "VideoTitle",
            };

            await db.Videos.AddAsync(testingVideo);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.favouritesService.AddToFavoritesAsync(1);
            var userFavouriteVideo = db.UserFavouriteVideos.FirstOrDefaultAsync(x => x.VideoId == 1 && x.ApplicationUserId == "UserId");

            //Assert
            Assert.True(actual);
            Assert.NotNull(userFavouriteVideo);
        }

        [Fact]
        public async Task AddToFavoritesAsync_WithVideoAlreadyInFavorites_ShouldThrowAnInvalidOperationException()
        {
            //Arrange
            var expectedErrorMessage = "The given video is already added to favorites!";

            var option = new DbContextOptionsBuilder<ChessDbContext>()
              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            var moqUserService = new Mock<IUsersService>();
            moqUserService.Setup(x => x.GetCurrentUserAsync())
                .ReturnsAsync(new ApplicationUser
                {
                    Id = "UserId",
                    UserName = "Ivan",
                    UserFavouriteVideos = new List<UserFavouriteVideo>
                    {
                        new UserFavouriteVideo{Id = 1, VideoId = 2,},
                    }
                });

            this.favouritesService = new FavouritesService(db, moqUserService.Object);

            var testingVideo = new Video
            {
                Id = 2,
                Title = "VideoTitle",
            };

            await db.Videos.AddAsync(testingVideo);
            await db.SaveChangesAsync();

            //Act and assert
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => this.favouritesService.AddToFavoritesAsync(2));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }
    }
}
