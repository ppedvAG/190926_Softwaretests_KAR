using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.Tests.NUnit
{
    [TestFixture]
    public class RechnerTestsNUnit
    {
        [Test]
        public void Add_2_and_3_returns_5()
        {
            // Arrange: Vorbereitung
            Rechner r = new Rechner();

            // Act: den zu testenden Code ausführen
            var result = r.Add(2, 3);

            // Assert: Ergebnis interpretieren
            Assert.AreEqual(5, result);
        }

        // Normalfall (Gültige Eingabe -> Gültige Ausgabe)
        // Fehlerfall (Ungültige Eingabe -> Fehler/Ausgabe)
        // Null-Fall
        // Extremfall

        [Test]
        public void Add_Int32Max_and_1_throws_OverflowException()
        {
            // Arrange: Vorbereitung
            Rechner r = new Rechner();

            Assert.Throws<OverflowException>(() =>
            {
                r.Add(Int32.MaxValue, 1);
            });

        }

        [Test]
        public void Add_Int32Min_and_N1_throws_OverflowException()
        {
            // Arrange: Vorbereitung
            Rechner r = new Rechner();

            Assert.Throws<OverflowException>(() =>
            {
                r.Add(Int32.MinValue, -1);
            });
        }


        // Mehrere Testfälle
        [Test]
        [TestCase(3, 5, 8)]
        [TestCase(5, 3, 8)]
        [TestCase(5, -3, 2)]
        [TestCase(-5, -3, -8)]
        [TestCase(0, 0, 0)]
        [TestCase(5, 0, 5)]
        public void Add_returns_expectedResult(int z1, int z2, int expectedResult)
        {
            Rechner r = new Rechner();

            var result = r.Add(z1, z2);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
