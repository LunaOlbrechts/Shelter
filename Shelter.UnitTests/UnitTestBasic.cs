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
            _controller = new ShelterAPIController(_mockedLogger.Object, _mockedDataAccess.Object, _mockedContext.Object);
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
        // Testing on id not found
        [Test]
        public void Test_IdNotFound()
        {
            _mockedDataAccess.Setup(x => x.GetShelterById(13)).Returns(default(Shelter.Shared.Shelters));
            var result = _controller.GetShelter(13);
            Assert.IsInstanceOf(typeof(NotFoundResult), result);
        }
    }
}