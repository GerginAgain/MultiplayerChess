﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Services.Interfaces
{
    public interface IGamesService
    {
        Task<int> GetCountOfAllGamesAsync();
    }
}
