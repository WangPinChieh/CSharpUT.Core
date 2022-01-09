using Lib;
using NSubstitute;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _profile = Substitute.For<IProfile>();
            _token = Substitute.For<IToken>();
            _target = new AuthenticationService(_profile, _token);
        }

        private IProfile _profile;
        private IToken _token;
        private AuthenticationService _target;

        [Test()]
        public void is_valid()
        {
            GivenPassword("joey", "91");
            GivenToken("000000");
            ShouldBeValid("joey", "91000000");
        }

        private void ShouldBeValid(string account, string password)
        {
            var actual = _target.IsValid(account, password);

            Assert.IsTrue(actual);
        }

        private void GivenToken(string token)
        {
            _token.GetRandom("").ReturnsForAnyArgs(token);
        }

        private void GivenPassword(string account, string password)
        {
            _profile.GetPassword(account).Returns(password);
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