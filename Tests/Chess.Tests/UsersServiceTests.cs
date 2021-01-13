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
        private static IMapper _mapper;

        public UsersServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public async Task GetAllUserViewModelsAsync_WithValidDAta_ShouldReturnCorrectCount()
        {
            //Arrange
            var expected = 3;

            var moqHttpContext = new Mock<IHttpContextAccessor>();
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);
            //var moqMapper = new Mock<IMapper>();

            var moqGameService = new Mock<IGamesService>();

            var option = new DbContextOptionsBuilder<ChessDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var context = new ChessDbContext(option);

            //var context = InitializeContext.CreateContextForInMemory();
            this.usersService = new UsersService(context, moqHttpContext.Object, userManager.Object, _mapper, moqGameService.Object);

            var testingUsers = new List<ApplicationUser>
            {
                new ApplicationUser{Id = "Id1", UserName = "Seller1", IsDeleted = false,EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-25)},
                new ApplicationUser{Id = "Id2", UserName = "Seller2", IsDeleted = false, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-20)},
                new ApplicationUser{Id = "Id3", UserName = "Seller3", IsDeleted = false, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-5)},
                new ApplicationUser{Id = "Id4", UserName = "Seller4", IsDeleted = true, EmailConfirmed = true, CreatedOn = DateTime.UtcNow.AddDays(-18)},
            };

            await context.ApplicationUsers.AddRangeAsync(testingUsers);
            await context.SaveChangesAsync();

            //Act
            var actual = await this.usersService.GetAllUserViewModelsAsync(1, 10);
            ;
            //Assert
            Assert.Equal(expected, actual.Count());
        }
    }
}
