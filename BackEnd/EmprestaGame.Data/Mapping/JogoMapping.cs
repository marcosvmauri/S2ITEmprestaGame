using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.Data.Mapping
{
    public class JogoMapping : EntityTypeConfiguration<Jogo>
    {
        public JogoMapping()
        {
            this.ToTable("Jogo");
            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(250)
                .IsRequired();

            this.Property(x => x.Console)
                .HasColumnName("Console")
                .HasMaxLength(250)
                .IsRequired();

            this.Property(x => x.Status)
               .HasColumnName("Status");

            this.Property(x => x.idUsuario)
                .HasColumnName("idUsuario");

            this.Ignore(x => x.Usuario);

            this.Ignore(x => x.ListaEmprestimo);

            //HasMany(x => x.ListaEmprestimo)
            //.WithRequired(x => x.Jogo);
            //.Map(x => x.MapKey("Jogo_Id"));

        }
    }
}
