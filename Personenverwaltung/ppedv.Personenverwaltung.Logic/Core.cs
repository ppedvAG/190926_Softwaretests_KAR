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
        public Core(IDevice device, IRepository repository)
        {
            this.device = device;
            this.repository = repository;
        }
        private readonly IDevice device;
        private readonly IRepository repository;

        // Irgendeine Logik, die mit IDevice arbeitet
        public IEnumerable<Person> RecruitPersonsForDepartment(int amount)
        {
            if (amount < 0)
                throw new ArgumentException();

            List<Person> newPersons = new List<Person>();
            for (int i = 0; i < amount; i++)
            {
                newPersons.Add(device.RecruitPerson()); // z.B. 5 mal die Maschiene ansteuern
            }
            return newPersons;
        }

        // Logik, die auf die DB zugreift:

        public IEnumerable<Person> GetAllPeople()
        {
            return repository.GetAll<Person>();
        }
        public Person GetPersonWithHighestBalance()
        {
            return GetAllPeople().OrderByDescending(x => x.Kontostand)
                                 .First();
        }


        // Logik, die auf die HW UND die DB zugreift
        public void RecruitPersonsAndSaveInDB(int amount)
        {
            var people = RecruitPersonsForDepartment(amount); // Maschine
            foreach (var person in people)
            {
                repository.Add<Person>(person); // DB
            }
            repository.Save(); // DB
        }
    }
}
