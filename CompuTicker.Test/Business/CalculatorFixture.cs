using System;
using System.Threading.Tasks;
using CompuTicker.Business;
using CompuTicker.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompuTicker.Test.Business
{
    [TestClass]
    public class CalculatorFixture
    {
        [DataTestMethod]
        [DataRow(1, 4, "+", 5)]
        [DataRow(8, 5, "-", 3)]
        [DataRow(3, 5, "*", 15)]
        [DataRow(9, 3, "/", 3)]
        public async Task Calculate_ShouldReturnCorrectResult_WhenUsingBasicOperations(double param1, double param2, string op, double expectedResult)
        {
            ICalculatorAggregate calculator = new CalculatorAggregate();
            var result = await calculator.Calculate(
                new EquationModel
                {
                    Param1 = param1,
                    Param2 = param2,
                    Operation = op
                });

            Assert.AreEqual<double>(expectedResult, result);
        }

        [TestMethod]
        public async Task Calculate_ShouldThrowDivideByZeroException_WhenDividingByZero()
        {
            ICalculatorAggregate calculator = new CalculatorAggregate();

            await Assert.ThrowsExceptionAsync<DivideByZeroException>(() => calculator.Calculate(
                 new EquationModel
                 {
                     Param1 = 5,
                     Param2 = 0,
                     Operation = "/"
                 }));
        }
    }
}
