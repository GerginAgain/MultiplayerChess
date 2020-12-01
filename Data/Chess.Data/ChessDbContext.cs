using System;
using System.Collections.Generic;
using System.Text;
using Chess.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chess.Data
{
    public class ChessDbContext : IdentityDbContext<ApplicationUser>
    {
        public ChessDbContext(DbContextOptions<ChessDbContext> options)
            :base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Game> Games { get; set; }
    }
}
