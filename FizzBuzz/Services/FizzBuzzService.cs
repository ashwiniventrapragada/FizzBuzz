using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Interfaces;

namespace FizzBuzz.Services
{
    public class FizzBuzzService: IFizzBuzzService
    {
        public IEnumerable<string> Run(IEnumerable<string> input)
        {
            if (input == null || !input.Any())
            {
                throw new Exception("input cannot be null or empty");
            }

            var result = new List<string>();
            foreach (var item in input)
            {
                
                if (int.TryParse(item, out var value))
                {
                    var isDivisibleBy3 = IsDivisible(value, 3);
                    var isDivisibleBy5 = IsDivisible(value, 5);

                    if (isDivisibleBy3 && isDivisibleBy5)
                    {
                        result.Add("FizzBuzz");
                    }
                    else if (isDivisibleBy3)
                    {
                        result.Add("Fizz");
                    }
                    else if (isDivisibleBy5)
                    {
                        result.Add("Buzz");
                    }
                    else
                    {
                        result.Add($"Divided {item} by 3");
                        result.Add($"Divided {item} by 5");
                    }
                }
                else
                {
                    result.Add("Invalid Item");
                }
            }

            return result;
        }

        // We can move this to an extension function in the future
        private static bool IsDivisible(int input, int by)
        {
            return input % @by == 0;
        }
    }
}
