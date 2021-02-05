namespace Chess.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;
    using Chess.Data;
    using Chess.Services.Mapping;
    using Services;
    using Services.Interfaces;   

    public class StatisticsServiceTests
    {
        private IStatisticsService statisticsService;
        private static IMapper mapper;

        public StatisticsServiceTests()
        {
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                StatisticsServiceTests.mapper = mapper;
            }
        }

        [Fact]
        public async Task GetAdministrationIndexStatisticViewModelAsync_WithValidData_ShouldReturnCorrectResult()
        {
            //Assert
            var expectedAllUsersCount = 10;
            var expectedAllGamesCount = 5;           
            var expectedAllVideosCount = 5;

            var moqUsersService = new Mock<IUsersService>();
            moqUsersService.Setup(x => x.GetCountOfAllUsersAsync())
                .ReturnsAsync(10);
            var moqGamesService = new Mock<IGamesService>();
            moqGamesService.Setup(x => x.GetCountOfAllGamesAsync())
                .ReturnsAsync(5);
            var moqVideosService = new Mock<IVideosService>();
            moqVideosService.Setup(x => x.GetCountOfAllVideosAsync())
                .ReturnsAsync(5);

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            statisticsService = new StatisticsService(moqUsersService.Object, moqGamesService.Object, moqVideosService.Object);

            //Act
            var actual = await statisticsService.GetAdministrationIndexStatisticViewModelAsync();

            //Assert
            Assert.Equal(expectedAllGamesCount, actual.AllGamesCount);
            Assert.Equal(expectedAllUsersCount, actual.AllUsersCount);
            Assert.Equal(expectedAllVideosCount, actual.AllVideosCount);
        }

        [Fact]
        public async Task GetDataPointsForCreatedGamesAsync_WithValidData_ShouldReturnCorrectCountOfDataPoints()
        {
            //Assert
            var expected = 10;

            var moqGamesService = new Mock<IGamesService>();
            moqGamesService.Setup(x => x.GetTheCountForTheCreatedGamesForTheLastTenDaysAsync())
                .ReturnsAsync(new List<int> { 1, 0, 1, 0, 2, 0, 0, 0, 1, 1 });

            var moqUsersService = new Mock<IUsersService>();
            var moqVideosService = new Mock<IVideosService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            statisticsService = new StatisticsService(moqUsersService.Object, moqGamesService.Object, moqVideosService.Object);

            //Act
            var actual = await statisticsService.GetDataPointsForCreatedGamesAsync();

            //Assert
            Assert.Equal(expected, actual.Count());
        }
    }
}
