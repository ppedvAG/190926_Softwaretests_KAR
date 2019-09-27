using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personeverwaltung.Domain
{

    public class Abteilung : Entity
    {
        public string Name { get; set; }
        public virtual Person Abteilungsleiter { get; set; }
        public virtual HashSet<Person> Mitarbeiter { get; set; } = new HashSet<Person>();
    }

}
