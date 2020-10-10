using Microsoft.EntityFrameworkCore;
using NmAdminBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NmAdminBackEnd.Data
{
    // Database context.
    public class ArticleDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=article.db");
    }
}
