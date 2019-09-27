using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robotech.Hardware;

namespace ppedv.Personenverwaltung.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void RecruitPersonsForDepartment_can_recruit_5_persons()
        {
            Core core = new Core(null); // Core ist ohne hardware ja nicht erstellbar

            var result = core.RecruitPersonsForDepartment(5);

            result.Should().HaveCount(5);
        }
    }
}
