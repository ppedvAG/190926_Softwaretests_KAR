using ppedv.Personeverwaltung.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.Data.EF
{
   // Konfiguration für das EF
    public class EFContext : DbContext
    {
        // Für TN-PCs:
        // @"Server=.;Database=Personenverwaltung_Produktiv;Trusted_Connection=true"

        // Für Trainer-PC (Michi):
        // @"Server=(localdb)\MSSQLLocalDB;Database=Personenverwaltung_Produktiv;Trusted_Connection=true;AttachDbFilename=C:\temp\Personenverwaltung.mdf"
        public EFContext() : this(@"Server=(localdb)\MSSQLLocalDB;Database=Personenverwaltung_Produktiv;Trusted_Connection=true;AttachDbFilename=C:\temp\Personenverwaltung.mdf") { }
        public EFContext(string connectionString) : base(connectionString){}

        public DbSet<Person> Person { get; set; }
        public DbSet<Abteilung> Abteilung { get; set; }
        public DbSet<Firma> Firma { get; set; }


        // Erweiterte Konfiguration:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
