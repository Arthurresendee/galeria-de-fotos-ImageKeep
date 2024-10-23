
using ImageKeep.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImageKeep.Data.Mapping
{
    public class FotoMapping : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                // .UseIdentityColumn()
                ;

            builder.Property(e => e.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(e => e.CaminhoFoto)
                .HasColumnName("CaminhoFoto")
                .HasColumnType("TEXT")
                .IsRequired();


            builder.Property(e => e.DataUpload)
                .HasColumnName("DataUpload")
                .HasColumnType("DateTime")
                .IsRequired();

                builder.HasIndex(e => e.DataUpload, "IX_Endereco_DataUpload");
        }

    }
}