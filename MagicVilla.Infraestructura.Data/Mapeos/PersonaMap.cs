using MagicVilla.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagicVilla.Infraestructura.Data.Mapeos
{
    internal class PersonaMap
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Nombre)
                .HasMaxLength(100)
                .HasColumnName("Nombre");
            
            builder.Property(t => t.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("Apellidos");

            builder.Property(t => t.Sexo)
                .HasMaxLength(100)
                .HasColumnName("Sexo");
            
            builder.ToTable("personas");
        }
    }
}
