using CompuTicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuTicker.Business
{
    public class CalculatorAggregate : ICalculatorAggregate
    {
        public async Task<double> Calculate(EquationModel equationModel)
        {
            if (equationModel == null)
                return default(double);

            switch (equationModel.Operation)
            {
                case "+":
                    return await Task.Run (() => Add(equationModel.Param1, equationModel.Param2)).ConfigureAwait(false);
                case "-":
                    return await Task.Run (() => Subtract(equationModel.Param1, equationModel.Param2)).ConfigureAwait(false);
                case "*":
                    return await Task.Run(() => Multiply(equationModel.Param1, equationModel.Param2)).ConfigureAwait(false);
                case "/":
                    if (equationModel.Param2 == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    return await Task.Run(() => Divide(equationModel.Param1, equationModel.Param2)).ConfigureAwait(false);
                default:
                    throw new ArgumentException($"Operation {equationModel.Operation} is not supported.");
            }
        }

        private double Add(double a, double b) => a + b;
        private double Subtract(double a, double b) => a - b;
        private double Multiply(double a, double b) => a * b;
        private double Divide(double a, double b) => a / b;
    }
}
