using System;
using Lib;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class HolidayTest
    {
        private readonly FakeHoliday _holiday = new FakeHoliday();

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

        private void GivenToday(DateTime date)
        {
            _holiday.Today = date;
        }
        private void ShouldReturn(string expected)
        {
            Assert.AreEqual(expected, _holiday.SayHello());
        }
    }

    internal class FakeHoliday : Holiday
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