namespace Chess.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Chess.Data;
    using Chess.Data.Models;
    using Chess.Services.Interfaces;

    public class PicturesService : IPicturesService
    {
        private readonly ChessDbContext db;

        public PicturesService(ChessDbContext db)
        {
            this.db = db;
        }

        public async Task CreatePictureAsync(string name, string link)
        {
            var picture = new Picture
            {
                Name = name,
                Link = link,
            };

            await this.db.Pictures.AddAsync(picture);
            await this.db.SaveChangesAsync();
        }

        public async Task<Picture> GetPictureByLinkAsync(string pictureLink)
        {
            var picture = await this.db.Pictures.FirstOrDefaultAsync(x => x.Link == pictureLink);

            return picture;
        }
    }
}
