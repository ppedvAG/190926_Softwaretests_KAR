using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Robotech.Hardware.Tests
{
    [TestClass]
    public class XingRecruiter3000Tests
    {
        [TestMethod]
        public void RecruitPerson_can_recruit_Person()
        {
            XingRecruiter3000 maschine = new XingRecruiter3000();
            var result = maschine.RecruitPerson();

            result.Should().NotBeNull();
        }
    }
}
