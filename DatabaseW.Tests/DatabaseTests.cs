using DatabaseW.DataViewModel.Typ_nieruchomosci;
using DatabaseW.Models;
using DatabaseW.Views.APIs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Property_rental.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DatabaseWTests
{
    [TestClass]
    public class DatabaseTests
    {
        //[TestMethod]
        //public void DistanceAndDurationTest()
        //{
        //    string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=AleksandraFredry2%20Gliwice%20Slaskie%20Polska&destinations=ul.Zwyci%C4%99stwa49%20CreditAgricoleBankPolskaS.A.%2044-100Gliwice%20Poland&mode=driving&sensor=false&language=en-EN&units=imperial&key=AIzaSyDxAC7sQJdA9a9LUIjmqf13oEY-whT8CEI&fbclid=IwAR1LV9L_5cB6e_4UmO6Go-Y5kkpl6VivhJVbsBCrpwREquLrbCt_DThcAvg";
        //    vmDistance pom;
        //    pom = PageAPIDetail.DistanceAndDuration(url);
        //    NUnit.Framework.Assert.GreaterOrEqual(pom.distance, 0, "Error! Distance is less than 0!");
        //}

        [TestMethod]
        public void CreateTyp_Nieruchomosci()
        {
            var mockSet = new Mock<DbSet<Typ_nieruchomosci>>();

            var mockContext = new Mock<Context>();
            mockContext.Setup(p => p.Typ_Nieruchomoscis).Returns(mockSet.Object);

            var service = new Typ_nieruchomosciDataService(mockContext.Object);
            service.Save(new Typ_nieruchomosci { Opis = "garaż" });

            mockSet.Verify(p => p.Add(It.IsAny<Typ_nieruchomosci>()), Times.Once());
            mockContext.Verify(p => p.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void GetAllTyp_NieruchomosciQuery()
        {
            var data = new List<Typ_nieruchomosci>
            {
                new Typ_nieruchomosci { Opis = "garaż" },
                new Typ_nieruchomosci { Opis = "magazyn" },
                new Typ_nieruchomosci { Opis = "sala gimnastyczna" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Typ_nieruchomosci>>();
            mockSet.As<IQueryable<Typ_nieruchomosci>>().Setup(p => p.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Typ_nieruchomosci>>().Setup(p => p.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Typ_nieruchomosci>>().Setup(p => p.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Typ_nieruchomosci>>().Setup(p => p.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<Context>();
            mockContext.Setup(p => p.Typ_Nieruchomoscis).Returns(mockSet.Object);

            var service = new Typ_nieruchomosciDataService(mockContext.Object);
            service.LoadData();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3, service.DataList.Count);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("garaż", service.DataList[0].Opis);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("magazyn", service.DataList[1].Opis);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("sala gimnastyczna", service.DataList[2].Opis);
        }
    }
}
