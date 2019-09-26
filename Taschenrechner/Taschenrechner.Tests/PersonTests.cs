using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class PersonTests
    {
        // testm +TAB+TAB
        [TestMethod]
        public void Equals_with_null_returns_false()
        {
            // Entsprechenden Unit-Tests für Person 

            // Vorbereitung
            Person p = new Person();
            p.Vorname = "Max";
            p.Nachname = "Müller";
            p.Alter = 33;
            p.Kontostand = 6000;

            Assert.IsFalse(p.Equals(null)); // Erwartetes ergebnis: false
        }
        [TestMethod]
        public void Equals_with_wrong_datatypes_returns_false()
        {
            // Entsprechenden Unit-Tests für Person 

            // Vorbereitung
            Person p = new Person();
            p.Vorname = "Max";
            p.Nachname = "Müller";
            p.Alter = 33;
            p.Kontostand = 6000;

            int x = 0;

            Assert.IsFalse(p.Equals(x)); // Erwartetes ergebnis: false
        }
        [TestMethod]
        public void Equals_with_ref_not_equ_returns_false()
        {
            // Entsprechenden Unit-Tests für Person 

            // Vorbereitung
            Person p = new Person();
            p.Vorname = "Max";
            p.Nachname = "Müller";
            p.Alter = 33;
            p.Kontostand = 6000;

            Person p2 = p;

            Assert.IsTrue(p.Equals(p2)); // Erwartetes ergebnis: true
        }
        [TestMethod]
        public void Equals_with_same_values_returns_true()
        {
            // Entsprechenden Unit-Tests für Person 

            // Vorbereitung
            Person p = new Person();
            p.Vorname = "Max";
            p.Nachname = "Müller";
            p.Alter = 33;
            p.Kontostand = 6000;

            Person p2 = new Person();
            p2.Vorname = "Max";
            p2.Nachname = "Müller";
            p2.Alter = 33;
            p2.Kontostand = 6000;

            Assert.IsTrue(p.Equals(p2)); // Erwartetes ergebnis: true
        }
        [TestMethod]
        public void Equals_with_different_values_returns_false()
        {
            // Entsprechenden Unit-Tests für Person 

            // Vorbereitung
            Person p = new Person();
            p.Vorname = "Max";
            p.Nachname = "Müller";
            p.Alter = 33;
            p.Kontostand = 6000;

            Person p2 = new Person();
            p2.Vorname = "Anna";
            p2.Nachname = "Nass";
            p2.Alter = 33;
            p2.Kontostand = 6000;

            Assert.IsFalse(p.Equals(p2)); // Erwartetes ergebnis: false
        }
    }
}
