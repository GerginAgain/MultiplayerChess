using Chess.Data;
using Chess.Data.Models;
using Chess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Services
{
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
