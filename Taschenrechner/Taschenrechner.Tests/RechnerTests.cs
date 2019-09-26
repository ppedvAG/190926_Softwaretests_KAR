using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class RechnerTests
    {
        [TestMethod]
        public void Add_2_and_3_returns_5()
        {
            // Arrange: Vorbereitung
            Rechner r = new Rechner();

            // Act: den zu testenden Code ausführen
            var result = r.Add(2, 3);

            // Assert: Ergebnis interpretieren
            Assert.AreEqual(8, result);
        }
    }
}
