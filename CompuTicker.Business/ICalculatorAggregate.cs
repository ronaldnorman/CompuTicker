using CompuTicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuTicker.Business
{
    public interface ICalculatorAggregate
    {
        Task<double> Calculate(EquationModel equationModel);
    }
}
