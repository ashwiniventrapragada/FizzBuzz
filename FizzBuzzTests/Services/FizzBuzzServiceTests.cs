using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzz.Interfaces;
using FizzBuzz.Services;
using NSubstitute;
using Xunit;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;

namespace FizzBuzzTests.Services
{
    public class FizzBuzzServiceTests
    {
        public readonly IFizzBuzzService FizzBuzzService;
        public FizzBuzzServiceTests()
        {
            FizzBuzzService = Substitute.For<FizzBuzzService>();
        }

        [Fact]
        public void Run_When_InputIsnull_Then_Exception()
        {
            //Act
            Func<IEnumerable<string>> result = () => FizzBuzzService.Run(null);

            //Assert
            result.Should().Throw<Exception>();
        }

        [Fact]
        public void Run_When_InputIsEmpty_Then_Exception()
        {
            //Act
            var result = FizzBuzzService.Run(new[] { "" });

            //Assert
            result.First().Should().Be("Invalid Item");
        }

        [Fact]
        public void Run_When_InputIsValid_Then_ReturnResult()
        {
            //Arrange
            var input = new[] { "1", "3", "5", "", "15", "A", "23" };

            //Act
            var result = FizzBuzzService.Run(input);

            //Assert
            result.ToArray()[0].Should().Be("Divided 1 by 3");
            result.ToArray()[1].Should().Be("Divided 1 by 5");
            result.ToArray()[2].Should().Be("Fizz");
            result.ToArray()[3].Should().Be("Buzz");
            result.ToArray()[4].Should().Be("Invalid Item");
            result.ToArray()[5].Should().Be("FizzBuzz");
            result.ToArray()[6].Should().Be("Invalid Item");
            result.ToArray()[7].Should().Be("Divided 23 by 3");
            result.ToArray()[8].Should().Be("Divided 23 by 5");
        }
    }
}
