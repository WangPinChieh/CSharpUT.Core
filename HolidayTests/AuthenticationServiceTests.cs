using Lib;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        [Test()]
        public void is_valid()
        {
            var profile = new MockProfile();
            var token = new MockToken();
            var target = new AuthenticationService(profile, token);

            var actual = target.IsValid("joey", "91000000");

            //always failed
            Assert.IsTrue(actual);
        }
    }

    public class MockToken : IToken
    {
        public string GetRandom(string account)
        {
            return "000000";
        }
    }

    public class MockProfile : IProfile
    {
        public string GetPassword(string account)
        {
            if (account == "joey")
            {
                return "91";
            }

            return "";
        }
    }
}