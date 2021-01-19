namespace Chess.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Chess.Data;
    using Chess.Services.Mapping;
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
            var actual = await this.videosService.GetAllVideosViewModelsAsync(1,10);

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        }
    }
}
