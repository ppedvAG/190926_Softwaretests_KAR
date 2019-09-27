 using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Personeverwaltung.Domain;

namespace ppedv.Personenverwaltung.Data.EF.Tests
{
    [TestClass]
    public class EFContextTests
    {
        const string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Personenverwaltung_Test;Trusted_Connection=true;AttachDbFilename=C:\temp\Personenverwaltung.mdf";

        [TestMethod]
        public void EFContext_can_create_EFContext()
        {
            EFContext context = new EFContext(connectionString);
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void EFContext_can_create_Database()
        {
            EFContext context = new EFContext(connectionString);

            // Ursprungszustand wiederherstellen:
            if (context.Database.Exists())
                context.Database.Delete();

            Assert.IsFalse(context.Database.Exists());
            context.Database.Create();
            Assert.IsTrue(context.Database.Exists());
        }

        // Testen, ob alle Datentypen: Create,Read,Update,Delete -> CRUD-Tests

        [TestMethod]
        public void EFContext_can_CRUD_Person()
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 };
            string newVorname = "Peter";

            // Create
            using(EFContext context = new EFContext(connectionString))
            {
                context.Person.Add(p1); // SQL-Insert
                context.SaveChanges();
            }

            // Check Create
            using (EFContext context = new EFContext(connectionString))
            {
                Person loadedPerson = context.Person.Find(p1.ID);
                // Check: Read
                Assert.IsTrue(loadedPerson.Vorname == p1.Vorname); // ToDo: Richtig: ObjectGraph

                // Update
                loadedPerson.Vorname = newVorname; //EF: Changetracker
                context.SaveChanges();
            }

            // Check Update
            using (EFContext context = new EFContext(connectionString))
            {
                Person loadedPerson = context.Person.Find(p1.ID);
                // Check: Read
                Assert.IsTrue(loadedPerson.Vorname == newVorname); // ToDo: Richtig: ObjectGraph

                // Delete
                context.Person.Remove(loadedPerson);
                context.SaveChanges();
            }


            // Check Delete
            using (EFContext context = new EFContext(connectionString))
            {
                Person loadedPerson = context.Person.Find(p1.ID);
                Assert.IsNull(loadedPerson);
            }
        }
    }
}
