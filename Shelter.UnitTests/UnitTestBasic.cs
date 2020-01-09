using NUnit.Framework;
using Mvc.Controllers;
using Moq;
using Mvc;
using Shelter.Shared;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Shelter.UnitTests
{
    public class Tests
    {
        private Mock<IShelterDataAccess> _mockedDataAccess;
        private Mock<ILogger<ShelterAPIController>> _mockedLogger;
        private Mock<ShelterContext> _mockedContext;
        private ShelterAPIController _controller;
        [SetUp]
        public void Setup()
        {
            _mockedDataAccess = new Mock<IShelterDataAccess>(MockBehavior.Strict);
            _mockedLogger = new Mock<ILogger<ShelterAPIController>>(MockBehavior.Strict);
            _mockedContext = new Mock<ShelterContext>(MockBehavior.Strict);
            _controller = new ShelterAPIController(_mockedLogger.Object, _mockedDataAccess.Object);
        }
        [TearDown]
        public void TearDown()
        {
            _mockedDataAccess.VerifyAll();
            _mockedLogger.VerifyAll();
        }
        // These tests can be run using dotnet test
        // Testing on empty fields 
        [Test]
        public void Test_Empty()
        {
            var newAnimal = new Shelter.Shared.Animal()
            {
                Name = "Bob",
                Race = "Yorkshire",
                KidFriendly = true
            };
            Assert.IsNotEmpty(newAnimal.Name);
            Assert.IsNotEmpty(newAnimal.Race);
        }
        // Testing on valid characters
        [Test]
        public void Test_ValidCharacters()
        {

        }
        // Testing on unique id's 
        [Test]
        public void Test_UniqueId()
        {

        }
        // Testing on getting all shelters
        [Test]
        public void Test_GetAllShelters()
        {
            var shelters = new List<Shelter.Shared.Shelters>();
            _mockedDataAccess.Setup(x => x.GetAllShelters()).Returns(shelters);
            // uncomment the next line, run the test, read the exception message.
            // mockedDataAccess.Setup(x => x.GetAllSheltersFull()).Returns(shelters);
            var result = _controller.GetAllShelters();
            // uncomment this obviously wrong line, see what happens
            // Assert.IsInstanceOf(typeof(NotFoundResult), result);
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
            Assert.AreEqual(((OkObjectResult)result).Value, shelters);
        }
        // Testing on adding new shelter
        [Test]
        public void Test_AddShelter()
        {
            var shelter = new Shelter.Shared.Shelters()
            {
                Name = "Abc"
            };
            _mockedDataAccess.Setup(x => x.GetShelterById(12)).Returns(shelter);
            var result = _controller.GetShelter(12);
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
            Assert.AreEqual(((OkObjectResult)result).Value, shelter);
        }
        // Testing on id not found
        [Test]
        public void Test_IdNotFound()
        {
            _mockedDataAccess.Setup(x => x.GetShelterById(19)).Returns(default(Shelter.Shared.Shelters));
            var result = _controller.GetShelter(19);
            Assert.IsInstanceOf(typeof(NotFoundResult), result);
        }
    }
}