using NUnit.Framework;
using CafeApp;
using System.Windows;

namespace CafeAppTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void AuthenticationUser_WithCorrectInfo_ReturnsTrue()
        {
            string workerName = "Майкл Тейлор";
            int workerTypeID = 2;

            int result = LoginPage.AuthenticateUser(workerName, workerTypeID);

            int expected = 0;

            Assert.Equals(result, expected);

        }
        [Test]
        public void AuthenticationUser_WithFalseInfo_ReturnsFalse()
        {
            string workerName = "Daniel Redcliff";
            int workerTypeID = 1;

            int result = LoginPage.AuthenticateUser(workerName, workerTypeID);

            int expected = 0;

            Assert.AreEqual(result, expected);
        }
    }
}