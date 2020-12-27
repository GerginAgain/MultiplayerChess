namespace Chess.Services.Interfaces
{
    using System.Threading.Tasks;
    using Chess.Data.Models;

    public interface IPicturesService
    {
        Task CreatePictureAsync(string name, string link);

        Task<Picture> GetPictureByLinkAsync(string pictureLink); 
    }
}
