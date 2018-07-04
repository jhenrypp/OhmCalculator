using Moq;
using OhmCalculator.ApplicationCore.Values;
using OhmCalculator.ApplicationCore.Exceptions;
using OhmCalculator.ApplicationCore.interfaces;
using OhmCalculator.ApplicationCore.Services;
using OhmCalculator.UnitTests.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OhmCalculator.UnitTests.ApplicationCore.Services
{
    public class FourResistorTest
    {
        public FourResistorTest()
        {

        }
        [Fact]
        public void TestValidColor()
        {
            //Arrage
            var m = new Mock<IBandColors>();
            var stubColorList = new StubBandList();
            m.Setup(x => x.GetAllBandColors()).Returns(stubColorList.GetAllBandColors());
            var fourBandResistor = new OhmValueCalculator(m.Object);

            //Act
            fourBandResistor.CalculateOhmValue("brown", "red", "red", "yellow");
            //Assert
            m.Verify(x => x.GetAllBandColors(), Times.AtLeastOnce);
        }

        [Fact]
        
        public void TestInvalidColor()
        {
            //Arrage
            var m = new Mock<IBandColors>();
            var stubColorList = new StubBandList();
            m.Setup(x => x.GetAllBandColors()).Returns(stubColorList.GetAllBandColors());
            var fourBandResistor = new OhmValueCalculator(m.Object);
            var expected = $"Invalid color for band";

            //Act
            Exception ex = Assert.Throws<ColorNotFoundException>(() => fourBandResistor.CalculateOhmValue("darkbrown", "red", "red", "yellow"));

            //Assert
            Assert.Contains(expected, ex.Message);
        }

        [Fact]
        public void TestCalculateResistance()
        {
            //Arrage
            var m = new Mock<IBandColors>();
            var stubColorList = new StubBandList();
            m.Setup(x => x.GetAllBandColors()).Returns(stubColorList.GetAllBandColors());
            var fourBandResistor = new OhmValueCalculator(m.Object);
            var expected = 1200;

            //Act
             
            var result = fourBandResistor.CalculateOhmValue("brown", "red", "red", "yellow");

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
