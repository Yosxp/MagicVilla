using MagicVilla.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.Infraestructura.Data.Mapeos
{
    internal class EstudianteMap
    {
        public void Configure(EntityTypeBuilder<Estudiante> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Nombre)
                .HasMaxLength(45)
                .HasColumnName("Nombre");

            builder.Property(t => t.Apellidos)
                .HasMaxLength(45)
                .HasColumnName("Apellidos");

            builder.Property(t => t.Sexo)
                .HasMaxLength(45)
                .HasColumnName("Sexo");

            builder.Property(t => t.Grado)
               .HasMaxLength(45)
               .HasColumnName("Grado");

            builder.ToTable("estudiantes");
        }
    }
}
