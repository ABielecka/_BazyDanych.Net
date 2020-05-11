using NUnit.Framework;
using DatabaseW.Views.APIs;
using NUnit.Util;

namespace DatabaseWTests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void DistanceAndDurationTest_isPositive()
        {
            string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=AleksandraFredry2%20Gliwice%20Slaskie%20Polska&destinations=ul.Zwyci%C4%99stwa49%20CreditAgricoleBankPolskaS.A.%2044-100Gliwice%20Poland&mode=driving&sensor=false&language=en-EN&units=imperial&key=AIzaSyDxAC7sQJdA9a9LUIjmqf13oEY-whT8CEI&fbclid=IwAR1LV9L_5cB6e_4UmO6Go-Y5kkpl6VivhJVbsBCrpwREquLrbCt_DThcAvg";
            vmDistance pom;
            pom = PageAPIDetail.DistanceAndDuration(url);
            int expectedDistance = 499;
            string expectedDuration = "1 min";
            Assert.AreEqual(pom.distance, expectedDistance, "Error! Distance is less than 0!");
            Assert.AreEqual(pom.durtion, expectedDuration, "Error! Duration is less than 0!");
        }
        
        [Test]
        public void DistanceAndDurationTest_isZero()
        {
            string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=AleksandraFredry2%20Gliwice%20Slaskie%20Polska&destinations=AleksandraFredry2%20Gliwice%20Slaskie%20Polska&mode=driving&sensor=false&language=en-EN&units=imperial&key=AIzaSyDxAC7sQJdA9a9LUIjmqf13oEY-whT8CEI&fbclid=IwAR1LV9L_5cB6e_4UmO6Go-Y5kkpl6VivhJVbsBCrpwREquLrbCt_DThcAvg";
            vmDistance pom;
            pom = PageAPIDetail.DistanceAndDuration(url);
            int expectedDistance = 1;
            string expectedDuration = "1 min";
            Assert.AreEqual(pom.distance, expectedDistance, "Error! Distance cannot be 0!");
            Assert.AreEqual(pom.durtion, expectedDuration, "Error! Duration cannot be 0!");
        }

        [Test]
        public void TrimAddressTest_test1()
        {
            string inputString = "Aleksandra Fredry 20, Gliwice Slaskie, Polska";
            string expectedString = "AleksandraFredry20+GliwiceSlaskie+Polska";
            string output = PageAPIDetail.TrimAddress(inputString);
            Assert.AreEqual( expectedString, output,"Not equal!");
        }

        [Test]
        public void TrimAddressTest_test2()
        {
            string inputString = "Aleksandra      Fredry ,,,,,,,,20, Gliwice  , , , , ,Slaskie,          Polska";
            string expectedString = "AleksandraFredry20+Gliwice+Slaskie+Polska";
            string output = PageAPIDetail.TrimAddress(inputString);
            Assert.AreEqual(expectedString, output, "Not equal!");
        }

        [Test]
        public void TrimAddressTest_test3()
        {
            string inputString = "Aleksandra      Fredry ,,,,,,,,20, GliwiceSlaskie,          Polska";
            string expectedString = "AleksandraFredry20+GliwiceSlaskie+Polska";
            string output = PageAPIDetail.TrimAddress(inputString);
            Assert.AreEqual(expectedString, output, "Not equal!");
        }

        [Test]
        public void TrimAddressTest_test4()
        {
            string inputString = "Aleksandra,Fredry ,,,,,,,,20, Gliwice  , , , , ,Slaskie,          Polska";
            string expectedString = "Aleksandra+Fredry20+Gliwice+Slaskie+Polska";
            string output = PageAPIDetail.TrimAddress(inputString);
            Assert.AreEqual(expectedString, output, "Not equal!");
        }

        [Test]
        public void TrimAddressTest_test5()
        {
            string inputString = "Aleksandra      Fredry ,,,,,,,,20, Gliwice +++++++++++Slaskie,          Polska";
            string expectedString = "AleksandraFredry20+Gliwice+Slaskie+Polska";
            string output = PageAPIDetail.TrimAddress(inputString);
            Assert.AreEqual(expectedString, output, "Not equal!");
        }
    }
}
