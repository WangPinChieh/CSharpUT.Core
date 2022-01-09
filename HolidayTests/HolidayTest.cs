using System;
using Lib;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class HolidayTest
    {
        [Test]
        public void today_is_not_xmas()
        {
            var holiday = new FakeHoliday
            {
                Today = new DateTime(2022, 1, 9)
            };
            Assert.AreEqual("Today is not Xmas", holiday.SayHello());
        }


        [Test]
        public void today_is_xmas()
        {
            var holiday = new FakeHoliday
            {
                Today = new DateTime(2022, 12, 25)
            };
            Assert.AreEqual("Merry Xmas", holiday.SayHello());
        }

    }

    public class FakeHoliday : Holiday
    {
        private DateTime _today;

        public DateTime Today
        {
            set => _today = value;
        }
        protected override DateTime GetToday()
        {
            return _today;
        }
    }
}