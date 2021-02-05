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
    using Data.Models;   
    using Services;
    using Services.Interfaces;   

    public class MovesServiceTests
    {
        private IMovesService movesService;
        private static IMapper mapper;

        public MovesServiceTests()
        {
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                MovesServiceTests.mapper = mapper;
            }
        }

        [Fact]
        public async Task AddMoveToDbAsync_WithValidData_ShouldAddMoveToDbCorrectly()
        {
            //Arrange
            var expectedMove = new Move
            {
                Id = "MoveId",
                Title = "MoveTitle",
                ApplicationUserId = "UserId",
                GameId = "GameId",
            };

            var moqUsersService = new Mock<IUsersService>();
            moqUsersService.Setup(x => x.GetCurrentUserAsync()).ReturnsAsync(new ApplicationUser { Id = "UserId" });

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.movesService = new MovesService(db, mapper, moqUsersService.Object);

            //Act
            await this.movesService.AddMoveToDbAsync("MoveTitle", "GameId");
            var resultMove = await db.Moves.FirstOrDefaultAsync(x => x.Title == "MoveTitle" && x.GameId == "GameId");

            //Assert
            Assert.Equal(expectedMove.Title, resultMove.Title);
            Assert.Equal(expectedMove.GameId, resultMove.GameId);
            Assert.Equal(expectedMove.ApplicationUserId, resultMove.ApplicationUserId);
        }

        [Fact]
        public async Task GetGameAllMovesViewModelByGameIdAsync_WithValidDAta_ShouldReturnCorrectCount()
        {
            //Arrange
            var expected = 3;

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.movesService = new MovesService(db, mapper, moqUsersService.Object);

            var testingMoves = new List<Move>
            {
                new Move{Id = "Id1", Title = "Title1", ApplicationUserId = "UserId1", GameId = "GameId1", CreatedOn = DateTime.UtcNow.AddMinutes(-25)},
                new Move{Id = "Id2", Title = "Title2", ApplicationUserId = "UserId2", GameId = "GameId1", CreatedOn = DateTime.UtcNow.AddMinutes(-20)},
                new Move{Id = "Id3", Title = "Title3", ApplicationUserId = "UserId3", GameId = "GameId2", CreatedOn = DateTime.UtcNow.AddMinutes(-5)},
                new Move{Id = "Id4", Title = "Title4", ApplicationUserId = "UserId4", GameId = "GameId1", CreatedOn = DateTime.UtcNow.AddMinutes(-18)},
            };

            await db.Moves.AddRangeAsync(testingMoves);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.movesService.GetGameAllMovesViewModelByGameIdAsync("GameId1");

            //Assert
            Assert.Equal(expected, actual.Count());
        }

        [Fact]
        public async Task GetGameAllMovesViewModelByGameIdAsync_WithValidDAta_ShouldReturnCorrectOrder()
        {
            //Arrange
            var expected = new List<string> { "Title1", "Title2", "Title4" };

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.movesService = new MovesService(db, mapper, moqUsersService.Object);

            var testingMoves = new List<Move>
            {
                new Move{Id = "Id1", Title = "Title1", ApplicationUserId = "UserId1", GameId = "GameId1", CreatedOn = DateTime.UtcNow.AddMinutes(-25)},
                new Move{Id = "Id2", Title = "Title2", ApplicationUserId = "UserId2", GameId = "GameId1", CreatedOn = DateTime.UtcNow.AddMinutes(-20)},
                new Move{Id = "Id3", Title = "Title3", ApplicationUserId = "UserId3", GameId = "GameId2", CreatedOn = DateTime.UtcNow.AddMinutes(-5)},
                new Move{Id = "Id4", Title = "Title4", ApplicationUserId = "UserId1", GameId = "GameId1", CreatedOn = DateTime.UtcNow.AddMinutes(-18)},
            };

            await db.Moves.AddRangeAsync(testingMoves);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.movesService.GetGameAllMovesViewModelByGameIdAsync("GameId1");

            //Assert
            Assert.Equal(expected[0], actual[0].Title);
            Assert.Equal(expected[1], actual[1].Title);
            Assert.Equal(expected[2], actual[2].Title);
        }
    }
}
