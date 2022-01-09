using System;
using Lib;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class HolidayTest
    {
        private FakeHoliday _holiday;

        [SetUp]
        public void SetUp()
        {
            _holiday = new FakeHoliday();
        }

        [Test]
        public void today_is_not_xmas()
        {
            GivenToday(new DateTime(2022, 1, 9));
            ShouldReturn("Today is not Xmas");
        }


        [Test]
        public void today_is_xmas()
        {
            GivenToday(new DateTime(2022, 12, 25));
            ShouldReturn("Merry Xmas");
        }

        private void ShouldReturn(string expected)
        {
            Assert.AreEqual(expected, _holiday.SayHello());
        }

        private void GivenToday(DateTime today)
        {
            _holiday.GivenToday(today);
        }
    }

    public class FakeHoliday : Holiday
    {
        private DateTime _today;

        public void GivenToday(DateTime today)
        {
            _today = today;
        }

        protected override DateTime GetToday()
        {
            return _today;
        }
    }
}