using AutoFixture;
using ppedv.Personeverwaltung.Domain;
using ppedv.Personeverwaltung.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotech.Hardware
{
    public class XingRecruiter3000 : IDevice
    {
        private Fixture fix = new Fixture();
        public Person RecruitPerson()
        {
            Console.Beep();
            return fix.Create<Person>();
        }
    }
}
