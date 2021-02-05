namespace Chess.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Chess.Data;
    using Chess.Services.Mapping;
    using Chess.Web.ViewModels.InputModels.Games;
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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            //Act and assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => this.gamesService.GetGameByIdAsync("GameId"));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task GetGameByIdAsync_WithValidData_ShouldReturnCorrectGame()
        {
            //Arrange
            var expectedResult = "GameId";

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            //Act and assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => this.gamesService.DeleteGameByIdAsync("GameId"));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task DeleteGameByIdAsync_WithValidData_ShouldDeleteGameCorrectly()
        {
            //Arrange
            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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
            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

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

        [Fact]
        public async Task GetGameViewModelAsync_WithValidData_ShouldReturnCorrectViewModel()
        {
            //Arrange
            var expectedName = "GameName";
            var expectedColor = "White";
            var expectedHostName = "UserName";

            var moqUsersService = new Mock<IUsersService>();
            moqUsersService.Setup(x => x.GetCurrentUserAsync())
                .ReturnsAsync(new ApplicationUser
                {
                    Id = "UserId",
                    UserName = "UserName",
                });

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            await db.ApplicationUsers.AddAsync(new ApplicationUser
            {
                Id = "UserId",
                UserName = "UserName",
            });
            await db.SaveChangesAsync();

            var inputModel = new GameInputViewModel
            {
                Name = "GameName",
                Color = Web.ViewModels.InputModels.Enums.Color.White,
            };

            //Act
            var actual = await this.gamesService.GetGameViewModelAsync(inputModel);

            //Assert
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedColor, actual.Color);
            Assert.Equal(expectedHostName, actual.HostName);
        }

        [Fact]
        public async Task GetEnteringGameViewModelAsync_WithInvalidGameId_ShouldThrowArgumentException()
        {
            //Arrange
            var expectedErrorMessage = "Game with the given id doesn't exist!";

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            //Act and assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => this.gamesService.GetEnteringGameViewModelAsync("GameId"));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task GetEnteringGameViewModelAsync_WithValidData_ShouldReturnCorrectViewModel()
        {
            //Arrange
            var expectedId = "GameId";
            var expectedName = "GameName";
            var expectedColor = "Black";
            var expectedHostName = "HostUserName";

            var moqUsersService = new Mock<IUsersService>();
            moqUsersService.Setup(x => x.GetCurrentUserAsync())
                .ReturnsAsync(new ApplicationUser
                {
                    Id = "UserId",
                    UserName = "UserName",
                });

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            await db.Games.AddAsync(new Game
            {
                Id = "GameId",
                Color = "White",
                Name = "GameName",
                HostConnectionId = "HostConnectionId",
                HostId = "HostUserId",
                IsActive = true,
            });
            await db.ApplicationUsers.AddAsync(new ApplicationUser
            {
                Id = "HostUserId",
                UserName = "HostUserName",
            });
            await db.SaveChangesAsync();

            //Act
            var actual = await this.gamesService.GetEnteringGameViewModelAsync("GameId");

            //Assert
            Assert.Equal(expectedId, actual.Id);
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedColor, actual.Color);
            Assert.Equal(expectedHostName, actual.HostName);
        }

        [Fact]
        public async Task AddHostConnectionIdToGameAsync_WithInvalidGameId_ShouldThrowArgumentException()
        {
            //Arrange
            var expectedErrorMessage = "Game with the given id doesn't exist!";

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            //Act and assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => this.gamesService.AddHostConnectionIdToGameAsync("GameId", "HostConnectionId"));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task AddHostConnectionIdToGameAsync_WithValidData_ShouldWorkCorrectly()
        {
            //Arrange
            var expectedHostConnectionId = "HostConnectionId";

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            var game = new Game
            {
                Id = "GameId",
                Color = "White",
                Name = "GameName",
                HostConnectionId = null,
                HostId = "HostUserId",
                IsActive = true,
            };

            await db.Games.AddAsync(game);
            await db.SaveChangesAsync();

            //Act
            await this.gamesService.AddHostConnectionIdToGameAsync("GameId", "HostConnectionId");

            //Assert
            Assert.Equal(expectedHostConnectionId, game.HostConnectionId);
        }

        [Fact]
        public async Task AddGuestConnectionIdToGameAsync_WithInvalidGameId_ShouldThrowArgumentException()
        {
            //Arrange
            var expectedErrorMessage = "Game with the given id doesn't exist!";

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            //Act and assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => this.gamesService.AddGuestConnectionIdToGameAsync("GameId", "GuestConnectionId"));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task AddGuestConnectionIdToGameAsync_WithValidData_ShouldWorkCorrectly()
        {
            //Arrange
            var expectedGuestConnectionId = "GuestConnectionId";

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            var game = new Game
            {
                Id = "GameId",
                Color = "White",
                Name = "GameName",
                HostConnectionId = "HostConnectionId",
                GuestConnectionId = null,
                HostId = "HostUserId",
                IsActive = true,
            };

            await db.Games.AddAsync(game);
            await db.SaveChangesAsync();

            //Act
            await this.gamesService.AddGuestConnectionIdToGameAsync("GameId", "GuestConnectionId");

            //Assert
            Assert.Equal(expectedGuestConnectionId, game.GuestConnectionId);
        }

        [Fact]
        public async Task GetHubGameViewModelByGameIdAsync_WithInvalidGameId_ShouldThrowArgumentException()
        {
            //Arrange
            var expectedErrorMessage = "Game with the given id doesn't exist!";

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            //Act and assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => this.gamesService.GetHubGameViewModelByGameIdAsync("GameId"));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task GetHubGameViewModelByGameIdAsync_WithValidData_ShouldReturnCorrectViewModel()
        {
            //Arrange
            var expectedHostConnectionId = "HostConnectionId";
            var expectedHostName = "UserHost";
            var expectedGuestConnectionId = "GuestConnectionId";
            var expectedGuestName = "UserGuest";

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            var game = new Game
            {
                Id = "GameId",
                Color = "White",
                Name = "GameName",
                HostConnectionId = "HostConnectionId",
                HostId = "HostUserId",
                Host = new ApplicationUser
                {
                    UserName = "UserHost",
                },
                IsActive = true,
                GuestConnectionId = "GuestConnectionId",
                GuestId = "GuestUserId",
                Guest = new ApplicationUser
                {
                    UserName = "UserGuest",
                },
            };

            await db.Games.AddAsync(game);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.gamesService.GetHubGameViewModelByGameIdAsync("GameId");

            //Assert
            Assert.Equal(expectedHostName, actual.HostUsername);
            Assert.Equal(expectedHostConnectionId, actual.HostConnectionId);
            Assert.Equal(expectedGuestName, actual.GuestUsername);
            Assert.Equal(expectedGuestConnectionId, actual.GuestConnectionId);
        }

        [Fact]
        public async Task GetMyGameViewModelsAsync_WithoutAnyGames_ShouldReturnZeroViewModels()
        {
            //Arrange
            var expectedResult = 0;

            var moqUsersService = new Mock<IUsersService>();
            moqUsersService.Setup(x => x.GetCurrentUserAsync())
                .ReturnsAsync(new ApplicationUser 
                {
                    Id = "UserId",
                });
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            //Act
            var actual = await this.gamesService.GetMyGameViewModelsAsync(1, 10);

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        }

        [Fact]
        public async Task GetMyGameViewModelsAsync_WithValidData_ShouldReturnCorrectCount()
        {
            //Arrange
            var expectedResult = 3;

            var moqUsersService = new Mock<IUsersService>();
            moqUsersService.Setup(x => x.GetCurrentUserAsync())
               .ReturnsAsync(new ApplicationUser
               {
                   Id = "UserId",
               });
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            var firstTestingUser = new ApplicationUser { Id = "UserId", UserName = "FirstUserName" };
            var secondTestingUser = new ApplicationUser { Id = "SecondUserId", UserName = "SecondUserName" };

            await db.ApplicationUsers.AddAsync(firstTestingUser);
            await db.ApplicationUsers.AddAsync(secondTestingUser);

            var testingGames = new List<Game>
            {
                new Game{Id = "Id1", Name = "Game1", Color = "White", IsActive = true, Host = firstTestingUser, Guest = secondTestingUser, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id2", Name = "Game2", Color = "White", IsActive = false, Host = firstTestingUser, Guest = secondTestingUser, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id3", Name = "Game3", Color = "White", IsActive = false, Host = firstTestingUser, Guest = secondTestingUser, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id4", Name = "Game4", Color = "White", IsActive = false, Host = secondTestingUser, Guest = firstTestingUser, CreatedOn = DateTime.UtcNow.AddDays(-20)},
                new Game{Id = "Id5", Name = "Game5", Color = "White", IsActive = true, Host = secondTestingUser, Guest = firstTestingUser, CreatedOn = DateTime.UtcNow.AddDays(-5)},
            };

            await db.Games.AddRangeAsync(testingGames);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.gamesService.GetMyGameViewModelsAsync(1, 10);

            //Assert
            Assert.Equal(expectedResult, actual.Count);
        } 

        [Fact]
        public async Task GetMyGameViewModelsAsync_WithValidData_ShouldReturnCorrectOrder()
        {
            //Arrange
            var expectedResult = new List<string> { "Id4", "Id3", "Id2" }; ;

            var moqUsersService = new Mock<IUsersService>();
            moqUsersService.Setup(x => x.GetCurrentUserAsync())
               .ReturnsAsync(new ApplicationUser
               {
                   Id = "UserId",
               });
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            var firstTestingUser = new ApplicationUser { Id = "UserId", UserName = "FirstUserName" };
            var secondTestingUser = new ApplicationUser { Id = "SecondUserId", UserName = "SecondUserName" };

            await db.ApplicationUsers.AddAsync(firstTestingUser);
            await db.ApplicationUsers.AddAsync(secondTestingUser);

            var testingGames = new List<Game>
            {
                new Game{Id = "Id1", Name = "Game1", Color = "White", IsActive = true, Host = firstTestingUser, Guest = secondTestingUser, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id2", Name = "Game2", Color = "White", IsActive = false, Host = firstTestingUser, Guest = secondTestingUser, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id3", Name = "Game3", Color = "White", IsActive = false, Host = firstTestingUser, Guest = secondTestingUser, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new Game{Id = "Id4", Name = "Game4", Color = "White", IsActive = false, Host = secondTestingUser, Guest = firstTestingUser, CreatedOn = DateTime.UtcNow.AddDays(-20)},
                new Game{Id = "Id5", Name = "Game5", Color = "White", IsActive = true, Host = secondTestingUser, Guest = firstTestingUser, CreatedOn = DateTime.UtcNow.AddDays(-5)},
            };

            await db.Games.AddRangeAsync(testingGames);
            await db.SaveChangesAsync();

            //Act
            var actual = this.gamesService.GetMyGameViewModelsAsync(1, 10).GetAwaiter().GetResult().ToList();

            //Assert
            Assert.Equal(expectedResult[0], actual[0].Id);
            Assert.Equal(expectedResult[1], actual[1].Id);
            Assert.Equal(expectedResult[2], actual[2].Id);
        }

        [Fact]
        public async Task GetGameByConnectionIdAndIsActiveStatusAsync_WithInvalidConnectionId_ShouldThrowArgumentException()
        {
            //Arrange
            var expectedErrorMessage = "Game with the given connection id doesn't exist!";

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            //Act and assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => this.gamesService.GetGameByConnectionIdAndIsActiveStatusAsync("ConnectionId"));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task GetGameByConnectionIdAndIsActiveStatusAsync_WithValidData_ShouldReturnCorrectGame()
        {
            //Arrange
            var expectedResult = "GameId";

            var moqUsersService = new Mock<IUsersService>();
            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.gamesService = new GamesService(db, mapper, moqUsersService.Object);

            var testingGames = new List<Game>
            {
                new Game{Id = "GameId", Name = "Game1", Color = "White", IsActive = true, HostConnectionId = "HostConnectionId"},
                new Game{Id = "Id2", Name = "Game2", Color = "White", IsActive = true},
                new Game{Id = "Id3", Name = "Game3", Color = "White", IsActive = true},
                new Game{Id = "Id4", Name = "Game4", Color = "White", IsActive = false},
                new Game{Id = "Id5", Name = "Game5", Color = "White", IsActive = true},
            };

            await db.Games.AddRangeAsync(testingGames);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.gamesService.GetGameByConnectionIdAndIsActiveStatusAsync("HostConnectionId");

            //Assert
            Assert.Equal(expectedResult, actual.Id);
        }
    }
}
