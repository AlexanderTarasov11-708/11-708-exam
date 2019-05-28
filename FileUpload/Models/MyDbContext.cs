using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUpload.Models;

namespace FileUpload
{
    public class MyDbContext:DbContext
    {
        public DbSet<MyFile> Files { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
