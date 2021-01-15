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

    public class UsersServiceTests
    {
        private IUsersService usersService;
        private static IMapper mapper;

        public UsersServiceTests()
        {
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                UsersServiceTests.mapper = mapper;
            }
        }

        [Fact]
        public async Task GetCountOfAllUsersAsync_WithoutAnyUsers_ShouldReturnZero()
        {
            //Arrange
            var expectedResult = 0;

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);
            var moqGameService = new Mock<IGamesService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.usersService = new UsersService(db, moqHttpContext.Object, userManager.Object, mapper, moqGameService.Object);

            //Act
            var actual = await this.usersService.GetCountOfAllUsersAsync();

            //Assert
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public async Task GetCountOfAllUsersAsync_WithValidData_ShouldReturnCorrectCount()
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

            this.usersService = new UsersService(db, moqHttpContext.Object, userManager.Object, mapper, moqGameService.Object);

            var testingUsers = new List<ApplicationUser>
            {
                new ApplicationUser{Id = "Id1", UserName = "Player1", IsDeleted = false,EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new ApplicationUser{Id = "Id2", UserName = "Player2", IsDeleted = false, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-20)},
                new ApplicationUser{Id = "Id3", UserName = "Player3", IsDeleted = false, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-5)},
                new ApplicationUser{Id = "Id4", UserName = "Player4", IsDeleted = true, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-5)},
                new ApplicationUser{Id = "Id5", UserName = "admin", IsDeleted = false, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-18)},
            };

            await db.ApplicationUsers.AddRangeAsync(testingUsers);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.usersService.GetCountOfAllUsersAsync();

            //Assert
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public async Task GetAllUserViewModelsAsync_WithValidDAta_ShouldReturnCorrectCount()
        {
            //Arrange
            var expected = 3;

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);
            var moqGameService = new Mock<IGamesService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.usersService = new UsersService(db, moqHttpContext.Object, userManager.Object, mapper, moqGameService.Object);

            var testingUsers = new List<ApplicationUser>
            {
                new ApplicationUser{Id = "Id1", UserName = "Player1", IsDeleted = false,EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new ApplicationUser{Id = "Id2", UserName = "Player2", IsDeleted = false, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-20)},
                new ApplicationUser{Id = "Id3", UserName = "Player3", IsDeleted = false, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-5)},
                new ApplicationUser{Id = "Id4", UserName = "Player4", IsDeleted = true, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-18)},
                new ApplicationUser{Id = "Id5", UserName = "admin", IsDeleted = false, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-18)},
            };

            await db.ApplicationUsers.AddRangeAsync(testingUsers);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.usersService.GetAllUserViewModelsAsync(1, 10);
            
            //Assert
            Assert.Equal(expected, actual.Count());
        }

        [Fact]
        public async Task GetAllUserViewModelsAsync_WithValidDAta_ShouldReturnCorrectOrder()
        {
            //Arrange
            var expected = new List<string> { "Id3", "Id2", "Id1" };

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);
            var moqGameService = new Mock<IGamesService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.usersService = new UsersService(db, moqHttpContext.Object, userManager.Object, mapper, moqGameService.Object);

            var testingUsers = new List<ApplicationUser>
            {
                new ApplicationUser{Id = "Id1", UserName = "Player1", IsDeleted = false,EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new ApplicationUser{Id = "Id2", UserName = "Player2", IsDeleted = false, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-20)},
                new ApplicationUser{Id = "Id3", UserName = "Player3", IsDeleted = false, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-5)},
            };

            await db.ApplicationUsers.AddRangeAsync(testingUsers);
            await db.SaveChangesAsync();

            //Act
            var actual = this.usersService.GetAllUserViewModelsAsync(1, 10).GetAwaiter().GetResult().ToList();

            //Assert
            Assert.Equal(expected[0], actual[0].Id);
            Assert.Equal(expected[1], actual[1].Id);
            Assert.Equal(expected[2], actual[2].Id);
        }

        [Fact]
        public async Task BlockUserByIdAsync_WithInvalidUserId_ShouldThrowAndArgumentException()
        {
            //Arrange
            var expectedErrorMessage = "User with the given id doesn't exist!";

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);
            var moqGameService = new Mock<IGamesService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.usersService = new UsersService(db, moqHttpContext.Object, userManager.Object, mapper, moqGameService.Object);

            //Act and act
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => this.usersService.BlockUserByIdAsync("UserId"));
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public async Task BlockUserByIdAsync_WithValidDAta_ShouldReturnTrue()
        {
            //Arrange
            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);
            var moqGameService = new Mock<IGamesService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var db = new ChessDbContext(option);

            this.usersService = new UsersService(db, moqHttpContext.Object, userManager.Object, mapper, moqGameService.Object);

            var testingUser = new ApplicationUser
            {
                Id = "UserId",
                UserName = "Player1",
                IsDeleted = false,
                EmailConfirmed = true,
                CreatedOn = DateTime.UtcNow.AddDays(-25),
            };

            await db.ApplicationUsers.AddAsync(testingUser);
            await db.SaveChangesAsync();

            //Act
            var actual = await this.usersService.BlockUserByIdAsync("UserId");

            //Assert
            Assert.True(actual);
            Assert.True(testingUser.IsDeleted);
        }
    }
}
