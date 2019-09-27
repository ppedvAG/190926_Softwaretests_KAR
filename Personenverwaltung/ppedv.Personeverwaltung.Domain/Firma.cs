using System.Collections.Generic;

namespace ppedv.Personeverwaltung.Domain
{
    public class Firma : Entity
    {
        public string Name { get; set; }
        public virtual HashSet<Abteilung> Abteilungen { get; set; } = new HashSet<Abteilung>();
    }

}
