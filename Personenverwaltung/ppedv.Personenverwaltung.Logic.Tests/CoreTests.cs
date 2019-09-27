using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Personeverwaltung.Domain;
using ppedv.Personeverwaltung.Domain.Interfaces;

namespace ppedv.Personenverwaltung.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        //[TestMethod]
        //public void RecruitPersonsForDepartment_can_recruit_5_persons()
        //{
        //    Core core = new Core(null); // Core ist ohne hardware ja nicht erstellbar

        //    var result = core.RecruitPersonsForDepartment(5);

        //    result.Should().HaveCount(5);
        //}

        [TestMethod]
        public void RecruitPersonsForDepartment_can_recruit_5_persons_with_MOQ()
        {
            var deviceMock = new Mock<IDevice>(); // Mach mir ein Fake basierend auf IDevice
            //deviceMock.Setup(x => x.RecruitPerson())
            //          .Returns(() => new Person { Vorname = "Mock", Nachname = "Person", Alter = 0, Kontostand = 0 });

            deviceMock.SetupSequence(x => x.RecruitPerson())
                      .Returns(() => new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100 })
                      .Returns(() => new Person { Vorname = "Anna", Nachname = "Nass", Alter = 20, Kontostand = 20 })
                      .Returns(() => new Person { Vorname = "Peter", Nachname = "Silie", Alter = 30, Kontostand = 33330 })
                      .Returns(() => new Person { Vorname = "Franz", Nachname = "Ose", Alter = 40, Kontostand = -44440 })
                      .Returns(() => new Person { Vorname = "Martha", Nachname = "Pfahl", Alter = 50, Kontostand = 55550 });


            Core core = new Core(deviceMock.Object); //.Object -> die echte Instanz dahinter

            var result = core.RecruitPersonsForDepartment(5);

             result.Should().HaveCount(5);
            // Echte Mock-Feature:
            deviceMock.Verify(x => x.RecruitPerson(), Times.Exactly(5));
        }

        [TestMethod]
        public void RecruitPersonsForDepartment_with_invalid_amount_throws_ArgumentException()
        {
            var deviceMock = new Mock<IDevice>(); // Mach mir ein Fake basierend auf IDevice

            Core core = new Core(deviceMock.Object); //.Object -> die echte Instanz dahinter

            //Assert.ThrowsException<ArgumentException>(() =>
            //{
            //    var result = core.RecruitPersonsForDepartment(-5);
            //});

            core.Invoking(x => x.RecruitPersonsForDepartment(-5))
                .Should().ThrowExactly<ArgumentException>();

            // Echte Mock-Feature:
            deviceMock.Verify(x => x.RecruitPerson(), Times.Never);
        }
    }
}
