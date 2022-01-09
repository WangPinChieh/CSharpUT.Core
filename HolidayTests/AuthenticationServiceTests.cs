using Lib;
using NSubstitute;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        [Test()]
        public void is_valid()
        {
            var profile = Substitute.For<IProfile>();
            profile.GetPassword("joey").Returns("91");
            var token = Substitute.For<IToken>();
            token.GetRandom("").ReturnsForAnyArgs("000000");
            var target = new AuthenticationService(profile, token);

            var actual = target.IsValid("joey", "91000000");

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