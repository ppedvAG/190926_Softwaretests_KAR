using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pose;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrüneBank.Tests
{
    [TestClass]
    public class OpeningHoursTests
    {
        [TestMethod]
        [DataRow(2019, 9, 2, 10, 29, false)]    // Montag 10:29 -> zu
        [DataRow(2019, 9, 2, 10, 30, true)]     //          10:30 -> offen
        [DataRow(2019, 9, 2, 19, 00, false)] //  19:00 -> zu
        [DataRow(2019, 9, 2, 18, 59, true)] //  18:59 -> offen
        [DataRow(2019, 9, 2, 12, 00, true)] //  12:00 -> offen

        [DataRow(2019, 9, 3, 10, 29, false)] // Dienstag 10:29 -> zu
        [DataRow(2019, 9, 3, 10, 30, true)] //  10:30 -> offen
        [DataRow(2019, 9, 3, 19, 00, false)] //  19:00 -> zu
        [DataRow(2019, 9, 3, 18, 59, true)] //  18:59 -> offen
        [DataRow(2019, 9, 3, 12, 00, true)] //  12:00 -> offen

        [DataRow(2019, 9, 4, 10, 29, false)] // Mittwoch 10:29 -> zu
        [DataRow(2019, 9, 4, 10, 30, true)] //  10:30 -> offen
        [DataRow(2019, 9, 4, 19, 00, false)] //  19:00 -> zu
        [DataRow(2019, 9, 4, 18, 59, true)] //  18:59 -> offen
        [DataRow(2019, 9, 4, 12, 00, true)] //  12:00 -> offen

        [DataRow(2019, 9, 5, 10, 29, false)] // Donnerstag 10:29 -> zu
        [DataRow(2019, 9, 5, 10, 30, true)] //  10:30 -> offen
        [DataRow(2019, 9, 5, 19, 00, false)] //  19:00 -> zu
        [DataRow(2019, 9, 5, 18, 59, true)] //  18:59 -> offen
        [DataRow(2019, 9, 5, 12, 00, true)] //  12:00 -> offen

        [DataRow(2019, 9, 6, 10, 29, false)] // Freitag 10:29 -> zu
        [DataRow(2019, 9, 6, 10, 30, true)] //  10:30 -> offen
        [DataRow(2019, 9, 6, 19, 00, false)] //  19:00 -> zu
        [DataRow(2019, 9, 6, 18, 59, true)] //  18:59 -> offen
        [DataRow(2019, 9, 6, 12, 00, true)] //  12:00 -> offen

        [DataRow(2019, 9, 7, 10, 29, false)] // Samstag 10:29 -> zu
        [DataRow(2019, 9, 7, 13, 29, true)] //  10:30 -> offen
        [DataRow(2019, 9, 7, 14, 00, false)] //  14:00 -> zu
        [DataRow(2019, 9, 7, 13, 59, true)] //  13:59 -> offen

        [DataRow(2019, 9, 8, 10, 29, false)] // Sonnstag 10:29 -> zu
        [DataRow(2019, 9, 8, 13, 29, false)] //  10:30 -> zu
        [DataRow(2019, 9, 8, 14, 00, false)] //  14:00 -> zu
        [DataRow(2019, 9, 8, 13, 59, false)] //  13:59 -> zu

        // .. Alle DataRows für die ganze Woche (Mo-So) hier reinschreiben ;)
        public void OpeningHours_isOpen(int year, int month, int day, int hour, int minute, bool expectedResult)
        {
            var testDay = new DateTime(year, month, day, hour, minute, 00);
            // testlogik:

            OpeningHours opening = new OpeningHours();

            Assert.IsTrue(opening.IsOpen(testDay) == expectedResult);
            // oder:
            // Assert.AreEqual(expectedResult, opening.IsOpen(testDay));
        }



        [TestMethod]
        public void OpeningHours_IsNowOpen()
        {
            var oh = new OpeningHours();

            Assert.IsTrue(oh.IsNowOpen()); // Problem: Funktioniert vlt Fr und Sa aber Sonntag nicht mehr

            // Microsoft.Fakes, FakesFramework (teil von VisualStudio Enterprise)
        }

        [TestMethod]
        public void OpeningHours_IsNowOpen_Fakes()
        {
            // Microsoft.Fakes, FakesFramework (teil von VisualStudio Enterprise)
            var oh = new OpeningHours();

            // FakesFramework erstellt eine komplette Isolationsschicht für das .NET Framework
            // Wenn jetzt jemand DateTime.Now haben will, können wir ein vordefiniertes Ergebnis zurückliefier

            // Shim -> Microsoft-Name für "Mock"
            using (ShimsContext.Create())
            {
                // Nur hier drinnen gilt unsere Fake-Konfiguration
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(1984, 1, 1, 14, 52, 40);

                var uhrzeitFake = DateTime.Now; // Fake

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(1984, 1, 1, 14, 52, 40);

                Assert.IsFalse(oh.IsNowOpen()); // Sonntag ;)

                // Abhängigkeiten:
                System.IO.Fakes.ShimFile.ExistsString = filename => true;

                Assert.IsTrue(File.Exists("7:\\demo//$()()||||<<y.exe"));

                // Roboterarm im Büro

            }
            var uhrzeitOriginal = DateTime.Now; // Original


            Assert.IsTrue(oh.IsNowOpen());

            // Ideal für folgende Situationen:
            // Sensor sagt: zu heiß/zu kalt / es brennt
            // Keine echte Datenbankverbindung
            // REST-Service liefert immer den selben JSON-String 
            // Datenbankergebnisse faken -> sehr schnell
        }


        // https://github.com/tonerdo/pose
        // -> Über NuGet installieren
        [TestMethod]
        public void OpeningHours_IsNowOpen_Pose()
        {
            Shim dateShim = Shim.Replace(() => DateTime.Now)
                                .With(() => new DateTime(1848, 3, 22, 12, 22, 50));

            DateTime datum = DateTime.Now; // Original

            PoseContext.Isolate(() =>
            {

                datum = DateTime.Now; // Fake

            }, dateShim);

        }
    }
}
