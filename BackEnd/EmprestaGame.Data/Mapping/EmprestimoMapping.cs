using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.Data.Mapping
{
    public class EmprestimoMapping : EntityTypeConfiguration<Emprestimo>
    {
        public EmprestimoMapping()
        {
            this.ToTable("Emprestimo");
            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);


            this.Property(x => x.idJogo)
                  .HasColumnName("idJogo")
                  .IsRequired();

            this.Property(x => x.idUsuario)
                 .HasColumnName("idUsuario")
                 .IsRequired();

            this.Property(x => x.Status)
              .HasColumnName("Status");

            this.Ignore(x => x.Usuario);
            this.Ignore(x => x.Jogo);




        }


    }
}
