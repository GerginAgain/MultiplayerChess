namespace Chess.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
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

    public class MessagesServiceTests
    {
        private IMessagesService messagesService;
        private static IMapper mapper;

        public MessagesServiceTests()
        {
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                MessagesServiceTests.mapper = mapper;
            }          
        }

        [Fact]
        public async Task AddMessageToDbAsync_WithValidData_ShouldAddMessageToDbCorrectly()
        {
            //Arrange
            var expectedMessage = new Message
            {
                Id = "MessageId",
                Content = "MessageContent",
                ApplicationUserId = "UserId",
                GameId = "GameId",
            };

            var moqUsersService = new Mock<IUsersService>();
            moqUsersService.Setup(x => x.GetCurrentUserAsync()).ReturnsAsync(new ApplicationUser { Id = "UserId" });

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.messagesService = new MessagesService(db, mapper, moqUsersService.Object);

            //Act
            await this.messagesService.AddMessageToDbAsync("MessageContent", "GameId");
            var resultMessage = await db.Messages.FirstOrDefaultAsync(x => x.Content == "MessageContent" && x.GameId == "GameId");

            //Assert
            Assert.Equal(expectedMessage.Content, resultMessage.Content);
            Assert.Equal(expectedMessage.GameId, resultMessage.GameId);
            Assert.Equal(expectedMessage.ApplicationUserId, resultMessage.ApplicationUserId);
        }

        [Fact]
        public async Task GetGameAllMessagesViewModelByGameIdAsync_WithValidDAta_ShouldReturnCorrectCount()
        {
            //Arrange
            var expected = 3;

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.messagesService = new MessagesService(db, mapper, moqUsersService.Object);

            var testingMessages = new List<Message>
        {
            new Message{Id = "Id1", Content = "Content1", ApplicationUserId = "UserId1", GameId = "GameId1", CreatedOn = DateTime.UtcNow.AddMinutes(-25)},
            new Message{Id = "Id2", Content = "Content2", ApplicationUserId = "UserId2", GameId = "GameId1", CreatedOn = DateTime.UtcNow.AddMinutes(-20)},
            new Message{Id = "Id3", Content = "Content3", ApplicationUserId = "UserId3", GameId = "GameId2", CreatedOn = DateTime.UtcNow.AddMinutes(-5)},
            new Message{Id = "Id4", Content = "Content4", ApplicationUserId = "UserId4", GameId = "GameId1", CreatedOn = DateTime.UtcNow.AddMinutes(-18)},
        };

            await db.Messages.AddRangeAsync(testingMessages);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.messagesService.GetGameAllMessagesViewModelByGameIdAsync("GameId1");

            //Assert
            Assert.Equal(expected, actual.Count());
        }

        [Fact]
        public async Task GetGameAllMessagesViewModelByGameIdAsync_WithValidDAta_ShouldReturnCorrectOrder()
        {
            //Arrange
            var expected = new List<string> { "Content1", "Content2", "Content4" };

            var moqUsersService = new Mock<IUsersService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.messagesService = new MessagesService(db, mapper, moqUsersService.Object);

            var testingMessages = new List<Message>
        {
            new Message{Id = "Id1", Content = "Content1", ApplicationUserId = "UserId1", GameId = "GameId1", CreatedOn = DateTime.UtcNow.AddMinutes(-25)},
            new Message{Id = "Id2", Content = "Content2", ApplicationUserId = "UserId2", GameId = "GameId1", CreatedOn = DateTime.UtcNow.AddMinutes(-20)},
            new Message{Id = "Id3", Content = "Content3", ApplicationUserId = "UserId3", GameId = "GameId2", CreatedOn = DateTime.UtcNow.AddMinutes(-5)},
            new Message{Id = "Id4", Content = "Content4", ApplicationUserId = "UserId1", GameId = "GameId1", CreatedOn = DateTime.UtcNow.AddMinutes(-18)},
        };

            await db.Messages.AddRangeAsync(testingMessages);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.messagesService.GetGameAllMessagesViewModelByGameIdAsync("GameId1");

            //Assert
            Assert.Equal(expected[0], actual[0].Content);
            Assert.Equal(expected[1], actual[1].Content);
            Assert.Equal(expected[2], actual[2].Content);
        }
    }
}
