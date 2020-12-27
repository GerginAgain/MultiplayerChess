namespace Chess.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        public interface ISeeder
        {
            Task SeedAsync(ChessDbContext dbContext, IServiceProvider serviceProvider);
        }
    }
}
