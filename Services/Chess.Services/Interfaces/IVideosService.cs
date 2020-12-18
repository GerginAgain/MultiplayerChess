using Chess.Services.Paging;
using Chess.Web.ViewModels.InputModels.Videos;
using Chess.Web.ViewModels.ViewModels.Videos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Services.Interfaces
{
    public interface IVideosService
    {
        Task CreateVideoAsync(AddVideoInputModel model);

        Task<LatestThreeAddedVideosViewModel> GetLatestThreeVideosAsync();

        Task<PaginatedList<VideoAllViewModel>> GetAllVideosViewModelsAsync(int pageNumber, int pageSize);

        Task<PaginatedList<FavouriteVideoViewModel>> GetFavouriteVideoViewModelsAsync(int pageNumber, int pageSize);
    }
}
