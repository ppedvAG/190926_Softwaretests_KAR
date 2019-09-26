using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }

        public override bool Equals(object obj)
        {

            // Wenn der Datentyp richtig ist:

            //--------> Wenn nicht: sind die Werte gleich? -> True
            //----------> Wenn nicht: false

            // Seit C# 7.0:
            // if(obj is Person == false) -> False

            // Wenn der Parameter null ist -> False
            if (obj == null)
                return false;

            // Wenn der Datentyp falsch ist -> false
            if (obj.GetType() != typeof(Person))
                return false;

            // -----> Sind die Referenzen gleich ? 
            if (this != obj)
            {
                // Referenzen ungleich ---> Werte gleich?
                if (this.Vorname != ((Person)obj).Vorname ||
                        this.Alter != ((Person)obj).Alter ||
                        this.Nachname != ((Person)obj).Nachname ||
                        this.Kontostand != ((Person)obj).Kontostand)
                    return false;

            }

            return true;
        }
    }
}
