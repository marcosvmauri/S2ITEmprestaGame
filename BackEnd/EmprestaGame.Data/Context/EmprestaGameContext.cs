using EmprestaGame.Data.Mapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EmprestaGame.Data.Context
{
    public class EmprestaGameContext : DbContext
    {
        public EmprestaGameContext()
            : base("EmprestaGameContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(250));

            modelBuilder.Properties()
               .Where(p => p.Name == "Id")
               .Configure(p => p.IsKey());

            //Adicionar configurações das entidades.
            modelBuilder.Configurations.Add(new UsuarioMapping());
            modelBuilder.Configurations.Add(new JogoMapping());
            modelBuilder.Configurations.Add(new TokenMapping());
            modelBuilder.Configurations.Add(new EmprestimoMapping());


            //Buildar contexto.
            modelBuilder.Build(this.Database.Connection).Compile();
        }
    }
}
