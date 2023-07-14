using MagicVilla.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Infraestructura.Data.Mapeos
{
    internal class PersonaMap
    {
        public new void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID")
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
