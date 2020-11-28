using System;
using System.Threading.Tasks;

namespace Chess.Data.Seeding
{
    public interface ISeeder
    {
        public interface ISeeder
        {
            Task SeedAsync(ChessDbContext dbContext, IServiceProvider serviceProvider);
        }
    }
}
