using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.Data.Mapping
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapping()
        {
            this.ToTable("Usuario");
            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();

            this.Property(x => x.Login)
                .HasColumnName("Login")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(x => x.Senha)
                  .HasColumnName("Senha")
                  .HasMaxLength(250)
                  .IsRequired();

            this.Property(x => x.Status)
              .HasColumnName("Status");


            this.Ignore(x => x.ListaJogos);

            this.Ignore(x => x.ListaEmprestimo);


        }



    }
}
