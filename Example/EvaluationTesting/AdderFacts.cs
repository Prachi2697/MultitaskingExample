using System;
using EvaluationTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultitaskingDemo;
using Shouldly;

namespace EvaluationTesting
{
    [TestClass]
    public class AdderFacts
    {
        [TestMethod]
        public void AdderMethod_Increases_ProcessCount()
        {
            //Arrange
            var sut = new Adder();

            //Act
            sut.AdderMethod();

            //Assert
            sut.processCount.ShouldBe(2);
        }

        [TestMethod]
        public void AdderMethod_Increases_ProcessCount1()
        {
            //Arrange
            var sut = new Adder();

            //Act
            sut.AdderMethod();
            sut.AdderMethod();

            //Assert
            sut.processCount.ShouldBe(3);
        }
       
    }
}
