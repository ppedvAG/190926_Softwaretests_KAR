using ppedv.Personeverwaltung.Domain;
using ppedv.Personeverwaltung.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.Logic
{
    public class Core
    {
        public Core(IDevice device)
        {
            this.device = device;
        }
        private readonly IDevice device;

        // Irgendeine Logik, die mit IDevice arbeitet
        public IEnumerable<Person> RecruitPersonsForDepartment(int amount)
        {
            List<Person> newPersons = new List<Person>();
            for (int i = 0; i < amount; i++)
            {
                newPersons.Add(device.RecruitPerson()); // z.B. 5 mal die Maschiene ansteuern
            }
            return newPersons;
        }
    }
}
