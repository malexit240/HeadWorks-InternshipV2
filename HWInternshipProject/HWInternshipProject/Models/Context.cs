using System.IO;
using Xamarin.Essentials;
using Microsoft.EntityFrameworkCore;
using PCLAppConfig;


namespace HWInternshipProject.Models
{
    public class Context : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Profile> profiles { get; set; }

        public Context()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath;
            try
            {
                dbPath = Path.Combine(FileSystem.AppDataDirectory, ConfigurationManager.AppSettings.Get("Database_name"));
            }
            catch (Xamarin.Essentials.NotImplementedInReferenceAssemblyException)
            {
                dbPath = "db.sqlite";
            }

            optionsBuilder.UseSqlite($"Filename={dbPath}");

        }
    }

}