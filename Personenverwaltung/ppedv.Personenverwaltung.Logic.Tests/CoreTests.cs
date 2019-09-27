using System;
using System.Collections.Generic;
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


        [TestMethod]
        public void GetAllPeople_returns_exactly_5_Persons()
        {
            var mockRepo = new Mock<IRepository>();
            // Konfig: "Es sind 5 in der "DB" "
            mockRepo.Setup(x => x.GetAll<Person>())
                    .Returns(() => new List<Person>
                    {
                        new Person{Vorname="Tom1",Nachname="Ate"},
                        new Person{Vorname="Tom2",Nachname="Ate"},
                        new Person{Vorname="Tom3",Nachname="Ate"},
                        new Person{Vorname="Tom4",Nachname="Ate"},
                        new Person{Vorname="Tom5",Nachname="Ate"},
                    });
            Core core = new Core(null, mockRepo.Object); // null, weil hier kein IDevice benötigt wird

            var result = core.GetAllPeople(); // ich hab alle 5 aus der "DB" bekommen
            result.Should().HaveCount(5);
        }


        [TestMethod]
        public void GetPersonWithHighestBalance_returns_correct_Person()
        {
            var mockRepo = new Mock<IRepository>();
            Person correctResult = new Person { Vorname = "Tom3", Nachname = "Ate", Kontostand = 1_000_00 };
            // Konfig: "Es sind 5 in der "DB" "
            mockRepo.Setup(x => x.GetAll<Person>())
                    .Returns(() => new List<Person>
                    {
                        new Person{Vorname="Tom1",Nachname="Ate",Kontostand=100},
                        new Person{Vorname="Tom2",Nachname="Ate",Kontostand=100},
                        correctResult,
                        new Person{Vorname="Tom4",Nachname="Ate",Kontostand=100},
                        new Person{Vorname="Tom5",Nachname="Ate",Kontostand=100},
                    });
            Core core = new Core(null, mockRepo.Object); // null, weil hier kein IDevice benötigt wird

            var result = core.GetPersonWithHighestBalance();

            // https://fluentassertions.com/objectgraphs/
            result.Should().BeEquivalentTo(correctResult);
        }

        [TestMethod]
        public void RecruitPersonsAndSaveInDB_calls_HW_and_saves_in_DB()
        {
            var hwmock = new Mock<IDevice>();
            var dbmock = new Mock<IRepository>();

            Core core = new Core(hwmock.Object, dbmock.Object);
            core.RecruitPersonsAndSaveInDB(5);

            hwmock.Verify(x => x.RecruitPerson(), Times.Exactly(5));
            dbmock.Verify(x => x.Save(), Times.AtLeast(1));
        }

        [TestMethod]
        public void RecruitPersonsAndSaveInDB_with_invalid_argument_throws_ArgumentException()
        {
            var hwmock = new Mock<IDevice>();
            var dbmock = new Mock<IRepository>();

            Core core = new Core(hwmock.Object, dbmock.Object);

            core.Invoking(x => x.RecruitPersonsAndSaveInDB(-5))
                .Should()
                .ThrowExactly<ArgumentException>();

            hwmock.Verify(x => x.RecruitPerson(), Times.Never);
            dbmock.Verify(x => x.Save(), Times.Never);
        }
    }
}
