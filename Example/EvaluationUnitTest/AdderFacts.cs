using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultitaskingDemo;
using Shouldly;

namespace EvaluationUnitTest
{
    [TestClass]
    public class MethodTestClass
    {
        [TestMethod]
        public void Test_Adder()
        {
            // Arrange
            var sut = new Adder();

            // Act
            sut.AdderMethod();

            // Assert
            sut.processCount.ShouldBe(1);
        }

        [TestMethod]
        public void Test_Adder1()
        {
            // Arrange
            var sut = new Adder();

            // Act
            sut.AdderMethod();
            sut.AdderMethod();

            // Assert
            sut.processCount.ShouldBe(2);
        }
    }
}
