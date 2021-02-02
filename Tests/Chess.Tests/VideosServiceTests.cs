namespace Chess.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Chess.Data;
    using Chess.Services.Mapping;
    using Chess.Web.ViewModels.InputModels.Videos;
    using Chess.Web.ViewModels.ViewModels.Users;
    using Common;
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Services;
    using Services.Interfaces;
    using Xunit;

    public class VideosServiceTests
    {
        private IVideosService videosService;
        private static IMapper mapper;

        public VideosServiceTests()
        {
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                VideosServiceTests.mapper = mapper;
            }
        }

        [Fact]
        public async Task CreateVideoAsync_WithValidData_VideosInDatabaseShouldReturnCorrectCount()
        {
            //Arrange
            var expectedResult = 1;

            var moqPictureService = new Mock<IPicturesService>();
            moqPictureService.Setup(x => x.GetPictureByLinkAsync("pictureLink"))
                .ReturnsAsync(new Picture
                {
                    Id = 1,
                    Name = "PictureName",
                });

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            var inputModel = new AddVideoInputModel
            {
                VideoTitle = "VideoTitle",
                VideoLink = "VideoLink"
            };

            //Act
            await this.videosService.CreateVideoAsync(inputModel);

            //Assert
            Assert.Equal(expectedResult, db.Videos.ToList().Count);
        }

        [Fact]
        public async Task CreateVideoAsync_WithValidData_ShouldCreateCorrectVideo()
        {
            //Arrange
            var expectedResult = 1;

            var moqPictureService = new Mock<IPicturesService>();
            moqPictureService.Setup(x => x.GetPictureByLinkAsync("pictureLink"))
                .ReturnsAsync(new Picture
                {
                    Id = 1,
                    Name = "PictureName",
                });

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            var inputModel = new AddVideoInputModel
            {
                VideoTitle = "VideoTitle",
                VideoLink = "VideoLink"
            };

            //Act
            await this.videosService.CreateVideoAsync(inputModel);
            var video = db.Videos.First();

            //Assert
            Assert.Equal("VideoTitle", video.Title);
            Assert.Equal("VideoLink", video.Link);
        }

        [Fact]
        public async Task GetAllVideosViewModelsAsync_WithoutAnyVideos_ShouldReturnZero()
        {
            //Arrange
            var expectedResult = 0;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            //Act
            var actual = await this.videosService.GetAllVideosViewModelsAsync(1, 10);

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        }

        [Fact]
        public async Task GetAllVideosViewModelsAsync_WithoutAnyDeletedVideos_ShouldReturnCorrectCount()
        {
            //Arrange
            var expectedResult = 5;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            var testingVideos = new List<Video>
            {
                new Video{Id = 1, Title = "Video1", IsDeleted = false, Link = "link1"},
                new Video{Id = 2, Title = "Video2", IsDeleted = false, Link = "link2"},
                new Video{Id = 3, Title = "Video3", IsDeleted = false, Link = "link3"},
                new Video{Id = 4, Title = "Video4", IsDeleted = false, Link = "link4"},
                new Video{Id = 5, Title = "Video5", IsDeleted = false, Link = "link5"},
            };

            await db.Videos.AddRangeAsync(testingVideos);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.videosService.GetAllVideosViewModelsAsync(1, 10);

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        }

        [Fact]
        public async Task GetAllVideosViewModelsAsync_WithDeletedVideos_ShouldReturnCorrectCount()
        {
            //Arrange
            var expectedResult = 3;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            var testingVideos = new List<Video>
            {
                new Video{Id = 1, Title = "Video1", IsDeleted = true, Link = "link1"},
                new Video{Id = 2, Title = "Video2", IsDeleted = false, Link = "link2"},
                new Video{Id = 3, Title = "Video3", IsDeleted = true, Link = "link3"},
                new Video{Id = 4, Title = "Video4", IsDeleted = false, Link = "link4"},
                new Video{Id = 5, Title = "Video5", IsDeleted = false, Link = "link5"},
            };

            await db.Videos.AddRangeAsync(testingVideos);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.videosService.GetAllVideosViewModelsAsync(1, 10);

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        }

        [Fact]
        public async Task GetAllVideosViewModelsAsync_WithValidData_ShouldReturnCorrectOrder()
        {
            //Arrange
            var expectedResult = new List<int> { 5, 4, 2 }; ;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            var testingVideos = new List<Video>
            {
                new Video{Id = 1, Title = "Video1", IsDeleted = true, Link = "link1", CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Video{Id = 2, Title = "Video2", IsDeleted = false, Link = "link2", CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Video{Id = 3, Title = "Video3", IsDeleted = true, Link = "link3", CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Video{Id = 4, Title = "Video4", IsDeleted = false, Link = "link4", CreatedOn = DateTime.UtcNow.AddDays(-20)},
                new Video{Id = 5, Title = "Video5", IsDeleted = false, Link = "link5", CreatedOn = DateTime.UtcNow.AddDays(-5)},
            };

            await db.Videos.AddRangeAsync(testingVideos);
            await db.SaveChangesAsync();

            //Act
            var actual = this.videosService.GetAllVideosViewModelsAsync(1, 10).GetAwaiter().GetResult().ToList();

            //Assert
            Assert.Equal(expectedResult[0], actual[0].Id);
            Assert.Equal(expectedResult[1], actual[1].Id);
            Assert.Equal(expectedResult[2], actual[2].Id);
        }

        [Fact]
        public async Task GetAllVideosViewModelsAsync_WithValidDataAndNotNullUser_ShouldReturnCorrectCountOfFavoriteVideos()
        {
            //Arrange
            var expectedResult = 1;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();
            moqUsersService.Setup(x => x.GetCurrentUserAsync())
                .ReturnsAsync(new ApplicationUser
                {
                    Id = "UserId",
                    UserName = "Ivan",
                });

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            var UserFavouriteVideos = new List<UserFavouriteVideo>
                    {
                        new UserFavouriteVideo{Id = 1, VideoId = 2, ApplicationUserId = "UserId"},
                    };

            var testingVideos = new List<Video>
            {
                new Video{Id = 1, Title = "Video1", IsDeleted = true, Link = "link1", CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Video{Id = 2, Title = "Video2", IsDeleted = false, Link = "link2", CreatedOn = DateTime.UtcNow.AddDays(-25), UserFavouriteVideos = UserFavouriteVideos},
                new Video{Id = 3, Title = "Video3", IsDeleted = true, Link = "link3", CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Video{Id = 4, Title = "Video4", IsDeleted = false, Link = "link4", CreatedOn = DateTime.UtcNow.AddDays(-20)},
                new Video{Id = 5, Title = "Video5", IsDeleted = false, Link = "link5", CreatedOn = DateTime.UtcNow.AddDays(-5)},
            };

            await db.Videos.AddRangeAsync(testingVideos);
            await db.SaveChangesAsync();

            //Act
            var actual = this.videosService.GetAllVideosViewModelsAsync(1, 10).GetAwaiter().GetResult().Where(x => x.IsInFavourites == true).ToList();

            //Assert
            Assert.Equal(expectedResult, actual.Count);

        }

        [Fact]
        public async Task GetAllActiveVideosViewModelsAsync_WithoutAnyVideos_ShouldReturnZero()
        {
            //Arrange
            var expectedResult = 0;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            //Act
            var actual = await this.videosService.GetAllActiveVideosViewModelsAsync(1, 10);

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        }

        [Fact]
        public async Task GetAllActiveVideosViewModelsAsync_WithoutAnyDeletedVideos_ShouldReturnCorrectCount()
        {
            //Arrange
            var expectedResult = 5;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            var testingVideos = new List<Video>
            {
                new Video{Id = 1, Title = "Video1", IsDeleted = false, Link = "link1", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" } },
                new Video{Id = 2, Title = "Video2", IsDeleted = false, Link = "link2", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 3, Title = "Video3", IsDeleted = false, Link = "link3", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 4, Title = "Video4", IsDeleted = false, Link = "link4", CreatedOn = DateTime.UtcNow.AddDays(-20), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 5, Title = "Video5", IsDeleted = false, Link = "link5", CreatedOn = DateTime.UtcNow.AddDays(-5), Picture = new Picture{Link = "PictureLink" }},
            };

            await db.Videos.AddRangeAsync(testingVideos);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.videosService.GetAllActiveVideosViewModelsAsync(1, 10);

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        }

        [Fact]
        public async Task GetAllActiveVideosViewModelsAsync_WithDeletedVideos_ShouldReturnCorrectCount()
        {
            //Arrange
            var expectedResult = 3;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            var testingVideos = new List<Video>
            {
                new Video{Id = 1, Title = "Video1", IsDeleted = true, Link = "link1", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" } },
                new Video{Id = 2, Title = "Video2", IsDeleted = false, Link = "link2", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 3, Title = "Video3", IsDeleted = true, Link = "link3", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 4, Title = "Video4", IsDeleted = false, Link = "link4", CreatedOn = DateTime.UtcNow.AddDays(-20), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 5, Title = "Video5", IsDeleted = false, Link = "link5", CreatedOn = DateTime.UtcNow.AddDays(-5), Picture = new Picture{Link = "PictureLink" }},
            };

            await db.Videos.AddRangeAsync(testingVideos);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.videosService.GetAllActiveVideosViewModelsAsync(1, 10);

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        }

        [Fact]
        public async Task GetAllActiveVideosViewModelsAsync_WithValidData_ShouldReturnCorrectOrder()
        {
            //Arrange
            var expectedResult = new List<int> { 5, 4, 2 }; ;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            var testingVideos = new List<Video>
            {
                new Video{Id = 1, Title = "Video1", IsDeleted = true, Link = "link1", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" } },
                new Video{Id = 2, Title = "Video2", IsDeleted = false, Link = "link2", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 3, Title = "Video3", IsDeleted = true, Link = "link3", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 4, Title = "Video4", IsDeleted = false, Link = "link4", CreatedOn = DateTime.UtcNow.AddDays(-20), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 5, Title = "Video5", IsDeleted = false, Link = "link5", CreatedOn = DateTime.UtcNow.AddDays(-5), Picture = new Picture{Link = "PictureLink" }},
            };

            await db.Videos.AddRangeAsync(testingVideos);
            await db.SaveChangesAsync();

            //Act
            var actual = this.videosService.GetAllActiveVideosViewModelsAsync(1, 10).GetAwaiter().GetResult().ToList();

            //Assert
            Assert.Equal(expectedResult[0], actual[0].Id);
            Assert.Equal(expectedResult[1], actual[1].Id);
            Assert.Equal(expectedResult[2], actual[2].Id);
        }

        [Fact]
        public async Task GetLatestThreeVideosAsync_WithoutAnyVideos_ShouldReturnZeroVideosCount()
        {
            //Arrange
            var expectedResult = 0;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            //Act
            var actual = await this.videosService.GetLatestThreeVideosAsync();

            //Assert
            Assert.Equal(expectedResult, actual.Videos.Count);
        }

        [Fact]
        public async Task GetLatestThreeVideosAsync_WithoutAnyDeletedVideos_ShouldReturnCorrectCount()
        {
            //Arrange
            var expectedResult = 3;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            var testingVideos = new List<Video>
            {
                new Video{Id = 1, Title = "Video1", IsDeleted = false, Link = "link1", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" } },
                new Video{Id = 2, Title = "Video2", IsDeleted = false, Link = "link2", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 3, Title = "Video3", IsDeleted = false, Link = "link3", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 4, Title = "Video4", IsDeleted = false, Link = "link4", CreatedOn = DateTime.UtcNow.AddDays(-20), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 5, Title = "Video5", IsDeleted = false, Link = "link5", CreatedOn = DateTime.UtcNow.AddDays(-5), Picture = new Picture{Link = "PictureLink" }},
            };

            await db.Videos.AddRangeAsync(testingVideos);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.videosService.GetLatestThreeVideosAsync();

            //Assert
            Assert.Equal(expectedResult, actual.Videos.Count);
        }

        [Fact]
        public async Task GetLatestThreeVideosAsync_WithDeletedVideos_ShouldReturnCorrectCount()
        {
            //Arrange
            var expectedResult = 3;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            var testingVideos = new List<Video>
            {
                new Video{Id = 1, Title = "Video1", IsDeleted = true, Link = "link1", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" } },
                new Video{Id = 2, Title = "Video2", IsDeleted = false, Link = "link2", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 3, Title = "Video3", IsDeleted = true, Link = "link3", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 4, Title = "Video4", IsDeleted = false, Link = "link4", CreatedOn = DateTime.UtcNow.AddDays(-20), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 5, Title = "Video5", IsDeleted = false, Link = "link5", CreatedOn = DateTime.UtcNow.AddDays(-5), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 6, Title = "Video6", IsDeleted = false, Link = "link6", CreatedOn = DateTime.UtcNow.AddDays(-2), Picture = new Picture{Link = "PictureLink" }},
            };

            await db.Videos.AddRangeAsync(testingVideos);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.videosService.GetLatestThreeVideosAsync();

            //Assert
            Assert.Equal(expectedResult, actual.Videos.Count);
        }

        [Fact]
        public async Task GetLatestThreeVideosAsync_WithValidData_ShouldReturnCorrectOrder()
        {
            //Arrange
            var expectedResult = new List<int> { 5, 4, 2 }; ;

            var moqPictureService = new Mock<IPicturesService>();
            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.videosService = new VideosService(db, moqPictureService.Object, mapper, moqUsersService.Object);

            var testingVideos = new List<Video>
            {
                new Video{Id = 1, Title = "Video1", IsDeleted = true, Link = "link1", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" } },
                new Video{Id = 2, Title = "Video2", IsDeleted = false, Link = "link2", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 3, Title = "Video3", IsDeleted = true, Link = "link3", CreatedOn = DateTime.UtcNow.AddDays(-25), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 4, Title = "Video4", IsDeleted = false, Link = "link4", CreatedOn = DateTime.UtcNow.AddDays(-20), Picture = new Picture{Link = "PictureLink" }},
                new Video{Id = 5, Title = "Video5", IsDeleted = false, Link = "link5", CreatedOn = DateTime.UtcNow.AddDays(-5), Picture = new Picture{Link = "PictureLink" }},
            };

            await db.Videos.AddRangeAsync(testingVideos);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.videosService.GetLatestThreeVideosAsync();

            //Assert
            Assert.Equal(expectedResult[0], actual.Videos[0].Id);
            Assert.Equal(expectedResult[1], actual.Videos[1].Id);
            Assert.Equal(expectedResult[2], actual.Videos[2].Id);
        }
    }
}
