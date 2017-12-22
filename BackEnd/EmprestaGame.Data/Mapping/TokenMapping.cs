using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestaGame.Data.Mapping
{
    public class TokenMapping : EntityTypeConfiguration<Token>
    {
        public TokenMapping()
        {
            this.ToTable("Token");
            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(x => x.Login)
                .HasColumnName("Login")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(x => x.Chave)
                .HasColumnName("Chave")
                .HasMaxLength(250)
                .IsRequired();
            
            this.Property(x => x.Validade)
                  .HasColumnName("Validade")
                  .IsRequired();

            this.Property(x => x.IP)
                  .HasColumnName("IP")
                  .HasMaxLength(250)
                  .IsRequired();

            this.Ignore(x => x.Status);
        }
    }
}
