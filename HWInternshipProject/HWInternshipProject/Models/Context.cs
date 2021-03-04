using System.IO;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;
using PCLAppConfig;

namespace HWInternshipProject.Models
{
    public class Context : DbContext
    {

        private static string DbName = "db.sqlite";
        public DbSet<User> users { get; set; }
        public DbSet<Profile> profiles { get; set; }

        public Context()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = "";
            try
            {
                dbPath = Path.Combine(FileSystem.AppDataDirectory, ConfigurationManager.AppSettings.Get("Database_name"));
            }
            catch (Xamarin.Essentials.NotImplementedInReferenceAssemblyException)
            {
                dbPath = ConfigurationManager.AppSettings.Get("Database_name");
            }

            optionsBuilder.UseSqlite($"Filename={dbPath}");

        }
    }

}