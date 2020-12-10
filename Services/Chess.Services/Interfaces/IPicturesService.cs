using Chess.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Services.Interfaces
{
    public interface IPicturesService
    {
        Task CreatePictureAsync(string name, string link);

        Task<Picture> GetPictureByLinkAsync(string pictureLink); 
    }
}
