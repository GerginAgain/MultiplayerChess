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

    public class GamesServiceTests
    {
        private IGamesService gamesService;
        private static IMapper mapper;

        public GamesServiceTests()
        {
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                GamesServiceTests.mapper = mapper;
            }
        }

        [Fact]
        public async Task GetCountOfAllGamesAsync_WithoutAnyGames_ShouldReturnZero()
        {
            //Arrange
            var expectedResult = 0;

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqHttpContext.Object, userManager.Object);

            //Act
            var actual = await this.gamesService.GetCountOfAllGamesAsync();

            //Assert
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public async Task GetCountOfAllGamesAsync_WithValidData_ShouldReturnCorrectCount()
        {
            //Arrange
            var expectedResult = 4;

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);
            var moqGameService = new Mock<IGamesService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqHttpContext.Object, userManager.Object);

            var testingGames = new List<Game>
            {
                new Game{Id = "Id1", Name = "Game1", Color = "White", IsActive = true},
                new Game{Id = "Id2", Name = "Game2", Color = "White", IsActive = true},
                new Game{Id = "Id3", Name = "Game3", Color = "White", IsActive = true},
                new Game{Id = "Id4", Name = "Game4", Color = "White", IsActive = false},
                new Game{Id = "Id5", Name = "Game5", Color = "White", IsActive = true},
            };

            await db.Games.AddRangeAsync(testingGames);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.gamesService.GetCountOfAllGamesAsync();

            //Assert
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public async Task GetGameByIdAsync_WithInvalidGameId_ShouldThrowArgumentException()
        {
            //Arrange
            var expectedErrorMessage = "Game with the given id doesn't exist!";

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqHttpContext.Object, userManager.Object);

            //Act and assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => this.gamesService.GetGameByIdAsync("GameId"));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task GetGameByIdAsync_WithValidData_ShouldReturnCorrectGame()
        {
            //Arrange
            var expectedResult = "GameId";

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);
            var moqGameService = new Mock<IGamesService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqHttpContext.Object, userManager.Object);

            var testingGames = new List<Game>
            {
                new Game{Id = "GameId", Name = "Game1", Color = "White", IsActive = true},
                new Game{Id = "Id2", Name = "Game2", Color = "White", IsActive = true},
                new Game{Id = "Id3", Name = "Game3", Color = "White", IsActive = true},
                new Game{Id = "Id4", Name = "Game4", Color = "White", IsActive = false},
                new Game{Id = "Id5", Name = "Game5", Color = "White", IsActive = true},
            };

            await db.Games.AddRangeAsync(testingGames);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.gamesService.GetGameByIdAsync("GameId");

            //Assert
            Assert.Equal(expectedResult, actual.Id);
        }

        [Fact]
        public async Task GetGameDetailsViewModelAsync_WithInvalidGameId_ShouldThrowArgumentException()
        {
            //Arrange
            var expectedErrorMessage = "Game with the given id doesn't exist!";

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqHttpContext.Object, userManager.Object);

            //Act and assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => this.gamesService.GetGameDetailsViewModelAsync("GameId"));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task GetGameDetailsViewModelAsync_WithValidData_ShouldReturnCorrectViewModel()
        {
            //Arrange
            var expectedname = "Game1";
            var expectedHostFiguresColor = "White";
            var expectedHostUsername = "User1";
            var expectedHostConnectionId = "HostConnectionId";
            var expectedGuestConnectionId = "GuestConnectionId";

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);
            var moqGameService = new Mock<IGamesService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqHttpContext.Object, userManager.Object);

            var testingGames = new List<Game>
            {
                new Game
                {
                    Id = "GameId",
                    Name = "Game1",
                    Color = "White",
                    IsActive = true,
                    HostConnectionId = "HostConnectionId",
                    GuestConnectionId = "GuestConnectionId",
                    Host = new ApplicationUser
                    {
                        UserName = "User1"
                    } },
                new Game{Id = "Id2", Name = "Game2", Color = "White", IsActive = true},
                new Game{Id = "Id3", Name = "Game3", Color = "White", IsActive = true},
                new Game{Id = "Id4", Name = "Game4", Color = "White", IsActive = false},
                new Game{Id = "Id5", Name = "Game5", Color = "White", IsActive = true},
            };

            await db.Games.AddRangeAsync(testingGames);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.gamesService.GetGameDetailsViewModelAsync("GameId");

            //Assert
            Assert.Equal(expectedname, actual.Name);
            Assert.Equal(expectedHostFiguresColor, actual.HostFiguresColor);
            Assert.Equal(expectedHostUsername, actual.HostUsername);
            Assert.Equal(expectedHostConnectionId, actual.HostConnectionId);
            Assert.Equal(expectedGuestConnectionId, actual.GuestConnectionId);
        }
    }
}
