using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Interfaces
{
    public interface IFizzBuzzService
    {
        IEnumerable<string> Run(IEnumerable<string> input);
    }
}
