namespace Chess.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Chess.Data;
    using Chess.Data.Models;
    using Chess.Services.Mapping;
    using Common;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Services;
    using Services.Interfaces;
    using Xunit;

    public class PicturesServiceTests
    {
        private IPicturesService picturesService;
        private static IMapper mapper;

        public PicturesServiceTests()
        {
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                PicturesServiceTests.mapper = mapper;
            }
        }

        [Fact]
        public async Task CreatePictureAsync_ShouldCreatePicture()
        {
            //Arrange
            var expectedPictureName = "PictureName";
            var expectedPictureLink = "PictureLink";

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.picturesService = new PicturesService(db);

            //Act
            await this.picturesService.CreatePictureAsync("PictureName", "PictureLink");
            var picture = db.Pictures.FirstOrDefault(x => x.Link == expectedPictureLink);

            //Assert
            Assert.Equal(expectedPictureName, picture.Name);
            Assert.Equal(expectedPictureLink, picture.Link);
        }

        [Fact]
        public async Task GetPictureByLinkAsync_WithValidDAta_ShouldReturnCorrectPicture()
        {
            //Arrange
            var expectedPictureId = 1;
            var expectedPictureName = "PictureName";
            var expectedPictureLink = "PictureLink";

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.picturesService = new PicturesService(db);

            var testingPicture = new Picture 
            {
                Id = 1, 
                Name = "PictureName",
                Link = "PictureLink"
            };

            await db.Pictures.AddAsync(testingPicture);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.picturesService.GetPictureByLinkAsync("PictureLink");

            //Assert
            Assert.Equal(expectedPictureId, actual.Id);
            Assert.Equal(expectedPictureName, actual.Name);
            Assert.Equal(expectedPictureLink, actual.Link);
        }
    }
}
