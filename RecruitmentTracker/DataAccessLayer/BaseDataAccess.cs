using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecruitmentTracker.Data;
using System.IO;

namespace RecruitmentTracker.DataAccessLayer
{
    public class BaseDataAccess
    {
        public DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
        public IConfiguration Configuration = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json").Build();

        public BaseDataAccess()
        {
            builder.UseSqlServer(Configuration["ConnectionStrings:MyDatabaseConnection"]);
        }
    }
}
