using NUnit.Framework;
using DatabaseW;
using DatabaseW.Views.APIs;

namespace DatabaseW.Tests
{
    public class DatabaseWTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DistanceAndDurationTest()
        {
            string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=AleksandraFredry2%20Gliwice%20Slaskie%20Polska&destinations=ul.Zwyci%C4%99stwa49%20CreditAgricoleBankPolskaS.A.%2044-100Gliwice%20Poland&mode=driving&sensor=false&language=en-EN&units=imperial&key=AIzaSyDxAC7sQJdA9a9LUIjmqf13oEY-whT8CEI&fbclid=IwAR1LV9L_5cB6e_4UmO6Go-Y5kkpl6VivhJVbsBCrpwREquLrbCt_DThcAvg";
            PageAPIDetail distMatrix = new PageAPIDetail("Aleksandra Fredry 20, Gliwice Śląskie, Polska");
            vmDistance pom;
            pom = distMatrix.DistanceAndDuration(url);
            Assert.GreaterOrEqual(pom.distance, 0, "Error! Distance is less than 0!");
        }

    }
}
