using F1Stats.Data.Models;
using F1Stats.Repository;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Moq;
using NuGet.Frameworks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace F1Stats.Logic.Test
{
    [TestFixture]
    public class LogicTest
    {
        Mock<ICsapatRepository> csapatRepo;
        Mock<IVersenyzoRepository> versenyzoRepo;
        Mock<IEredmenyRepository> eredmenyRepo;
        Mock<IVersenyhetvegeRepository> vhRepo;

        [SetUp]
        public void Setup()
        {
            csapatRepo = new Mock<ICsapatRepository>();
            versenyzoRepo = new Mock<IVersenyzoRepository>();
            eredmenyRepo = new Mock<IEredmenyRepository>();
            vhRepo = new Mock<IVersenyhetvegeRepository>();
            List<Versenyzo> versenyzok = new List<Versenyzo>()
            {
                new Versenyzo() { nev = "Hamilton", csapat_nev = "Mercedes" , eletkor = 25, idenybeli_pont = 0, rajtszam = 1, ossz_pont = 26},
                new Versenyzo() { nev = "Bottas", csapat_nev = "Mercedes" , eletkor = 28, idenybeli_pont = 0, rajtszam = 2, ossz_pont = 12},
                new Versenyzo() { nev = "Leklerk", csapat_nev = "Ferrari" , eletkor = 23, idenybeli_pont = 0, rajtszam = 3, ossz_pont = 55},
                new Versenyzo() { nev = "Latifi", csapat_nev = "Williams" , eletkor = 24, idenybeli_pont = 0, rajtszam = 4, ossz_pont = 1},
            };
            List<Csapat> csapatok = new List<Csapat>()
            {
                new Csapat() { csapat_nev = "Mercedes", gyozelmek = 20, motor = "Mercedes", versenyek_szama = 50},
                new Csapat() { csapat_nev = "Ferrari", gyozelmek = 1, motor = "Ferrari", versenyek_szama = 61},
                new Csapat() { csapat_nev = "Williams", gyozelmek = 0 , motor = "Mercedes" , versenyek_szama = 75},
            };
            List<Versenyhetvege> vhetvegek = new List<Versenyhetvege>()
            {
                new Versenyhetvege() { VERSENYHETVEGE_SZAMA = 1, hossz = 2500, idopont = DateTime.Now, kor = 64, nev = "Hungarian Grad Prix", helyszin = "Magyarorszag"}
            };
            List<Eredmeny> eredmenyek = new List<Eredmeny>()
            {
                new Eredmeny() { eredmenyId = 1, versenyhetvege_szam = 1, rajtszam = 1, helyezes = 1, pont = 25},
                new Eredmeny() { eredmenyId = 2, versenyhetvege_szam = 1, rajtszam = 3, helyezes = 2, pont = 15},
                new Eredmeny() { eredmenyId = 3, versenyhetvege_szam = 1, rajtszam = 4, helyezes = 3, pont = 13},
                new Eredmeny() { eredmenyId = 4, versenyhetvege_szam = 1, rajtszam = 2, helyezes = 4, pont = 10},
                new Eredmeny() { eredmenyId = 5, versenyhetvege_szam = 2, rajtszam = 2, helyezes = 1, pont = 25},
                new Eredmeny() { eredmenyId = 6, versenyhetvege_szam = 2, rajtszam = 3, helyezes = 2, pont = 15},
                new Eredmeny() { eredmenyId = 7, versenyhetvege_szam = 3, rajtszam = 1, helyezes = 1, pont = 25},
            };
            csapatRepo.Setup(repo => repo.GetAll()).Returns(csapatok.AsQueryable());
            versenyzoRepo.Setup(repo => repo.GetAll()).Returns(versenyzok.AsQueryable());
            csapatRepo.Setup(repo => repo.GetOne(It.IsAny<string>())).Returns(csapatok[2]);
            eredmenyRepo.Setup(repo => repo.GetAll()).Returns(eredmenyek.AsQueryable());
            eredmenyRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns(eredmenyek[1]);
            vhRepo.Setup(repo => repo.GetAll()).Returns(vhetvegek.AsQueryable());
        }

        [Test]
        public void TestDeleteVersenyzo()
        {
            VersenyzoLogic vlogic = new VersenyzoLogic(this.versenyzoRepo.Object);
            Assert.That(vlogic.GetAllVersenyzo().Count, Is.EqualTo(4));
            vlogic.DeleteVersenyzo(1);
            versenyzoRepo.Verify(repo => repo.Deleteversenyzo(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void TestAddVersenyhetvege()
        {
            VersenyhetvegeLogic vhLogic = new VersenyhetvegeLogic(this.vhRepo.Object);
            Assert.That(vhLogic.GetAllVersenyhetvege().Count, Is.EqualTo(1));
            Versenyhetvege newVh = new Versenyhetvege()
            {
                VERSENYHETVEGE_SZAMA = 2,
                helyszin = "Auszria",
                hossz = 2160,
                kor = 49,
                idopont = DateTime.Now,
                nev = "AU GP",
            };
            vhLogic.CreateVersenyhetvege(newVh);
            vhRepo.Verify(repo => repo.CreateVersenyHetvege(It.IsAny<Versenyhetvege>()), Times.Once);
            vhRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void TestUpdateCsapat()
        {
            CsapatLogic csLogic = new CsapatLogic(this.csapatRepo.Object);
            csLogic.UpdateGyozelmek("Williams", 1);
            csapatRepo.Verify(repo => repo.UpdateGyozelmek(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void TestReadEredmeny()
        {
            EredmenyLogic eLogic = new EredmenyLogic(this.eredmenyRepo.Object);
            var eredmeny = eLogic.GetOneEredmeny(1);
            Eredmeny epectedEredmeny = new Eredmeny() { eredmenyId = 2, versenyhetvege_szam = 1, rajtszam = 3, helyezes = 2, pont = 15 };
            Assert.That(Is.Equals(eredmeny,epectedEredmeny));
            eredmenyRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Once);
            eredmenyRepo.Verify(repo => repo.GetAll(), Times.Never);
        }

        [Test]
        public void TestTeamWithMostPointsWithCurrentDrivers()
        {
            string teamWithMostPointsWithCurrentDrivers = OsszetettLogic.TestGetTeamWithMostPoints(this.versenyzoRepo.Object, this.csapatRepo.Object);
            string expectedTeam = "Ferrari";
            Assert.That(teamWithMostPointsWithCurrentDrivers, Is.EqualTo(expectedTeam));
            this.versenyzoRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.csapatRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Test]
        public void TestResultPointsWithDriverNames()
        {
            List<ElertPont> expectedPoints = new List<ElertPont>()
            {
                new ElertPont() {DriverName = "Hamilton", Points = 50},
                new ElertPont() {DriverName = "Bottas", Points = 35},
                new ElertPont() {DriverName = "Leklerk", Points = 30},
                new ElertPont() {DriverName = "Latifi", Points = 13}
            };
            var results = OsszetettLogic.TestGetDriversPoints(this.eredmenyRepo.Object, this.versenyzoRepo.Object).AsQueryable();
            Assert.That(results, Is.EquivalentTo(expectedPoints));
            this.eredmenyRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.versenyzoRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.versenyzoRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void TestResultOfOneWeekendByEngine()
        {
            List<string> engineResult = new List<string>()
            {
                "Mercedes",
                "Ferrari",
                "Mercedes",
                "Mercedes"
            };
            var result = OsszetettLogic.TestGetResultWithEngineNames(1, this.eredmenyRepo.Object, this.csapatRepo.Object, this.versenyzoRepo.Object);
            Assert.That(result, Is.EquivalentTo(engineResult));
            this.eredmenyRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.versenyzoRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.versenyzoRepo.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
