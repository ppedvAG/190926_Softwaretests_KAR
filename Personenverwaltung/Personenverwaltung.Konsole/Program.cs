using ppedv.Personenverwaltung.Data.EF;
using ppedv.Personenverwaltung.Logic;
using ppedv.Personeverwaltung.Domain.Interfaces;
using Robotech.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IDevice hardware = new XingRecruiter3000();
            IRepository datenbank = new EFRepository(new EFContext());
            Core core = new Core(hardware,datenbank);

            // Testdaten generiere
            core.RecruitPersonsAndSaveInDB(100);

            // Reichste Person:
            var rich = core.GetPersonWithHighestBalance();
            Console.WriteLine("Die reichste Person ist:");
            Console.WriteLine(rich.Vorname);
            Console.WriteLine(rich.Nachname);
            Console.WriteLine(rich.Alter);
            Console.WriteLine(rich.Kontostand);
            Console.WriteLine("---");

            // Alle Daten ausgeben:
            foreach (var item in core.GetAllPeople())
            {
                Console.WriteLine($"Vorname: {item.Vorname} Nachname:{item.Nachname}");
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
