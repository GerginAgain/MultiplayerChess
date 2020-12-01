using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Chess.Services.Interfaces
{
    public interface IUsersService
    {
        Task<int> GetCountOfAllUsersAsync();
    }
}
