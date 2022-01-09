using System;

namespace Lib
{
    public class Holiday
    {
        public string SayHello()
        {
            if (GetToday().Month == 12 && GetToday().Day == 25)
            {
                return "Merry Xmas";
            }
            return "Today is not Xmas";
        }

        protected virtual DateTime GetToday()
        {
            return DateTime.Today;
        }
    }
}