using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
        public void OpeningHours_isOpen(int year, int month, int day, int hour, int minute,bool expectedResult)
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
        }
    }
}
