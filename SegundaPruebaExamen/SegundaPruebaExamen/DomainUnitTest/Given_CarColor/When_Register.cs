using Domain.RepositoryContracts;
using Domain.ServiceImplementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace DomainUnitTest
{
    [TestClass]
    public class When_Register
    {
        private MockFactory _mockFactory;
        private Mock<ICarColorRepository> _mockCarColorRepository;
        

        [TestInitialize]
        public void TestInitialize()
        {
            _mockFactory = new MockFactory();
            _mockCarColorRepository = _mockFactory.CreateMock<ICarColorRepository>();   
            
        }

        [Fact]
        public void TestMethod1()
        {
            //ARRANGE
            _mockCarColorRepository.Expects.One.Method(X => X.Insert(null)).WihtAnyArguments().WillReturn("TodoOK");
            bool IsOk = true;
            //ACT
            try
            {
                var sut = CreateSut();
                sut.Register("XXX");
            }
            catch (Exception ex)
            {
                IsOk = false;
            }
            //ASSERT
            Assert.IsTrue(IsOk);

        }

         private CarColorService CreateSut()
        {
            return new CarColorService(_mockCarColorRepository.MockObject);
        } 
    }
}
