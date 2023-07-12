using MagicVilla.Infraestructura.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace MagicVilla.Infraestructura.Core
{
    public class ContextoDB : DbContext, IContextoDB
    {
        private readonly IConfiguration _configuration;

        public ContextoDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ContextoDB(DbContextOptions<ContextoDB> options)
           : base(options)
        {
        }

        public DbContext Instance => this;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetSection("Config:ConnectionString").Value;
                string provider = _configuration.GetSection("Config:ProviderDB").Value;

                switch (provider)
                {
                    case "mysql":
                        {
                            optionsBuilder.UseMySql(ServerVersion.AutoDetect(connectionString));
                            break;
                        }
                    default:
                        {
                            throw new Exception("Base de datos configurada incorrectamente, revise el parámetro ProviderDB");
                        }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}