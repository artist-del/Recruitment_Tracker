using Microsoft.EntityFrameworkCore;
using RecruitmentTracker.Models;

namespace RecruitmentTracker.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicantInfo> ApplicantInfo { get; set; }
    }
}
