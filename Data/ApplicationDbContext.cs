using ASPSampleRazor.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASPSampleRazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudentModel> Students { get; set; }
    }
}
