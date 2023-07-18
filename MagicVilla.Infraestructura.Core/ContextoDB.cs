using MagicVilla.Dominio.Entidades;
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

        #region Tables
        public virtual DbSet<Persona> Personas { get; set; }

        #endregion

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
                            MySqlServerVersion serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
                            optionsBuilder.UseMySql(connectionString, serverVersion);
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
            string assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MagicVilla.Infraestructura.Data.dll");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.LoadFrom(assemblyPath));
        }
    }
}