﻿namespace Chess.Tests
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
        public async Task GetAllActiveGamesViewModelsAsync_WithoutAnyGames_ShouldReturnZeroViewModels()
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
            var actual = await this.gamesService.GetAllActiveGamesViewModelsAsync(1, 10);

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        }

        [Fact]
        public async Task GetAllActiveGamesViewModelsAsync_WithValidData_ShouldReturnCorrectCount()
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
            var actual = await this.gamesService.GetAllActiveGamesViewModelsAsync(1, 10);

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        }

        [Fact]
        public async Task GetAllActiveGamesViewModelsAsync_WithValidData_ShouldReturnCorrectOrder()
        {
            //Arrange
            var expectedResult = new List<string> { "Id5", "Id4", "Id2" }; ;

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
                new Game{Id = "Id1", Name = "Game1", Color = "White", IsActive = false, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id2", Name = "Game2", Color = "White", IsActive = true, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id3", Name = "Game3", Color = "White", IsActive = false, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id4", Name = "Game4", Color = "White", IsActive = true, CreatedOn = DateTime.UtcNow.AddDays(-20)},
                new Game{Id = "Id5", Name = "Game5", Color = "White", IsActive = true, CreatedOn = DateTime.UtcNow.AddDays(-5)},
            };

            await db.Games.AddRangeAsync(testingGames);
            await db.SaveChangesAsync();

            //Act
            var actual = this.gamesService.GetAllActiveGamesViewModelsAsync(1, 10).GetAwaiter().GetResult().ToList();

            //Assert
            Assert.Equal(expectedResult[0], actual[0].Id);
            Assert.Equal(expectedResult[1], actual[1].Id);
            Assert.Equal(expectedResult[2], actual[2].Id);
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
            var expectedName = "Game1";
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
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedHostFiguresColor, actual.HostFiguresColor);
            Assert.Equal(expectedHostUsername, actual.HostUsername);
            Assert.Equal(expectedHostConnectionId, actual.HostConnectionId);
            Assert.Equal(expectedGuestConnectionId, actual.GuestConnectionId);
        }

        [Fact]
        public async Task DeleteGameByIdAsync_WithInvalidGameId_ShouldThrowArgumentException()
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
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => this.gamesService.DeleteGameByIdAsync("GameId"));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task DeleteGameByIdAsync_WithValidData_ShouldDeleteGameCorrectly()
        {
            //Arrange
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

            var deletedGame = db.Games.First(x => x.IsActive == false);

            //Act
            await this.gamesService.DeleteGameByIdAsync("GameId");

            //Assert
            Assert.False(deletedGame.IsActive);
        }

        [Fact]
        public async Task GetActiveGameIdByUserIdAsync_WithoutAnyGames_ShouldReturnNull()
        {
            //Arrange
            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqHttpContext.Object, userManager.Object);

            //Act
            var result = await this.gamesService.GetActiveGameIdByUserIdAsync("UserId");

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetActiveGameIdByUserIdAsync_WithValidData_ShouldReturnCorrectGameId()
        {
            //Arrange
            var expectedResult = "GameId";

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);

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
                        Id = "UserId",
                        UserName = "User1",
                    } },
                new Game{Id = "Id2", Name = "Game2", Color = "White", IsActive = true},
                new Game{Id = "Id3", Name = "Game3", Color = "White", IsActive = true},
                new Game{Id = "Id4", Name = "Game4", Color = "White", IsActive = false},
                new Game{Id = "Id5", Name = "Game5", Color = "White", IsActive = true},
            };

            await db.Games.AddRangeAsync(testingGames);
            await db.SaveChangesAsync();

            //Act
            var result = await this.gamesService.GetActiveGameIdByUserIdAsync("UserId");

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GetTheCountForTheCreatedGamesForTheLastTenDaysAsync__WithVaildData_ShouldReturnCorrectCollectionLength()
        {
            //Arrange
            var expectedLength = 10;

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqHttpContext.Object, userManager.Object);

            //Act
            var result = await this.gamesService.GetTheCountForTheCreatedGamesForTheLastTenDaysAsync();

            //Assert
            Assert.Equal(expectedLength, result.Count);
        }

        [Fact]
        public async Task GetTheCountForTheCreatedGamesForTheLastTenDaysAsync_WithVaildData_ShouldReturnCorrectResult()
        {
            //Arrange
            var expected = new List<int> { 1, 0, 1, 0, 2, 0, 0, 0, 1, 1 };

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqHttpContext.Object, userManager.Object);

            var testingGames = new List<Game>
            {
                new Game {Id = "Id1", Name = "Game1", Color = "White", CreatedOn = DateTime.UtcNow.AddDays(-5)},
                new Game {Id = "Id2", Name = "Game2", Color = "White", CreatedOn = DateTime.UtcNow.AddDays(-5)},
                new Game {Id = "Id3", Name = "Game3", Color = "White", CreatedOn = DateTime.UtcNow.AddDays(-7)},
                new Game {Id = "Id4", Name = "Game4", Color = "White", CreatedOn = DateTime.UtcNow.AddDays(-9) },
                new Game {Id = "Id5", Name = "Game5", Color = "White", CreatedOn = DateTime.UtcNow.AddDays(-1) },
                new Game {Id = "Id6", Name = "Game6", Color = "White", CreatedOn = DateTime.UtcNow.AddDays(-10) },
                new Game {Id = "Id7", Name = "Game7", Color = "White", CreatedOn = DateTime.UtcNow.AddDays(-30) },
                new Game {Id = "Id8", Name = "Game8", Color = "White", CreatedOn = DateTime.UtcNow }
            };

            await db.Games.AddRangeAsync(testingGames);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.gamesService.GetTheCountForTheCreatedGamesForTheLastTenDaysAsync();

            //Assert
            Assert.Equal(expected[0], actual[0]);
            Assert.Equal(expected[1], actual[1]);
            Assert.Equal(expected[2], actual[2]);
            Assert.Equal(expected[3], actual[3]);
            Assert.Equal(expected[4], actual[4]);
            Assert.Equal(expected[5], actual[5]);
            Assert.Equal(expected[6], actual[6]);
            Assert.Equal(expected[7], actual[7]);
            Assert.Equal(expected[8], actual[8]);
            Assert.Equal(expected[9], actual[9]);
        }

        [Fact]
        public async Task GetGameAllViewModelsAsync_WithoutAnyGames_ShouldReturnZeroViewModels()
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
            var actual = await this.gamesService.GetGameAllViewModelsAsync();

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        }

        [Fact]
        public async Task GetGameAllViewModelsAsync_WithValidData_ShouldReturnCorrectCount()
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
            var actual = await this.gamesService.GetGameAllViewModelsAsync();

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        }

        [Fact]
        public async Task GetGameAllViewModelsAsync_WithValidData_ShouldReturnCorrectOrder()
        {
            //Arrange
            var expectedResult = new List<string> { "Id2", "Id4", "Id5" }; ;

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
                new Game{Id = "Id1", Name = "Game1", Color = "White", IsActive = false, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id2", Name = "Game2", Color = "White", IsActive = true, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id3", Name = "Game3", Color = "White", IsActive = false, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id4", Name = "Game4", Color = "White", IsActive = true, CreatedOn = DateTime.UtcNow.AddDays(-20)},
                new Game{Id = "Id5", Name = "Game5", Color = "White", IsActive = true, CreatedOn = DateTime.UtcNow.AddDays(-5)},
            };

            await db.Games.AddRangeAsync(testingGames);
            await db.SaveChangesAsync();

            //Act
            var actual = this.gamesService.GetGameAllViewModelsAsync().GetAwaiter().GetResult().ToList();

            //Assert
            Assert.Equal(expectedResult[0], actual[0].Id);
            Assert.Equal(expectedResult[1], actual[1].Id);
            Assert.Equal(expectedResult[2], actual[2].Id);
        }

        [Fact]
        public async Task GetGamesViewModelAsync_WithoutAnyGames_ShouldReturnZeroViewModels()
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
            var actual = await this.gamesService.GetGamesViewModelAsync();

            //Assert
            Assert.Equal(expectedResult, actual.Games.ToList().Count);
        }

        [Fact]
        public async Task GetGamesViewModelAsync_WithValidData_ShouldReturnCorrectCount()
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
            var actual = await this.gamesService.GetGamesViewModelAsync();

            //Assert
            Assert.Equal(expectedResult, actual.Games.ToList().Count);
        }

        [Fact]
        public async Task GetGamesViewModelAsync_WithValidData_ShouldReturnCorrectOrder()
        {
            //Arrange
            var expectedResult = new List<string> { "Id2", "Id4", "Id5" }; ;

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
                new Game{Id = "Id1", Name = "Game1", Color = "White", IsActive = false, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id2", Name = "Game2", Color = "White", IsActive = true, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id3", Name = "Game3", Color = "White", IsActive = false, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id4", Name = "Game4", Color = "White", IsActive = true, CreatedOn = DateTime.UtcNow.AddDays(-20)},
                new Game{Id = "Id5", Name = "Game5", Color = "White", IsActive = true, CreatedOn = DateTime.UtcNow.AddDays(-5)},
            };

            await db.Games.AddRangeAsync(testingGames);
            await db.SaveChangesAsync();

            //Act
            var actual = this.gamesService.GetGamesViewModelAsync().GetAwaiter().GetResult().Games.ToList();

            //Assert
            Assert.Equal(expectedResult[0], actual[0].Id);
            Assert.Equal(expectedResult[1], actual[1].Id);
            Assert.Equal(expectedResult[2], actual[2].Id);
        }
    }
}
