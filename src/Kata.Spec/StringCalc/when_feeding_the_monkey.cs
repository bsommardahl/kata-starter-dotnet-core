using System;
using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec.StringCalc
{
    public class when_adding_with_an_empty_string
    {
        static Calculator _systemUnderTest;

        Establish context = () =>
            _systemUnderTest = new Calculator();
        
        Because of = () =>
            _result = _systemUnderTest.Calculate("");

        It should_return_zero = () =>
            _result.Should().Be(0);

        static int _result;
    }
    
    public class when_passing_a_single_number
    {
        // Given the user input is one number when calculating the sum then it should return the same number. (example "3" should equal 3)
        static Calculator _systemUnderTest;

        Establish context = () =>
            _systemUnderTest = new Calculator();
        
        Because of = () =>
            _result = _systemUnderTest.Calculate("3");

        It should_return_int_three = () =>
            _result.Should().Be(3);

        static int _result;
    }
    
    public class when_summing_two_number
    {
        static Calculator _systemUnderTest;

        Establish context = () =>
            _systemUnderTest = new Calculator();
        
        Because of = () =>
            _result = _systemUnderTest.Calculate("1,3");

        It should_return_int_three = () =>
            _result.Should().Be(4);

        static int _result;
    }
}

// Given the user input is an unknown amount of numbers when calculating the sum then it should return the sum of all the numbers. (example "1,2,3" should equal 6)
// Given the user input is multiple numbers with new line and comma delimiters when calculating the sum then it should return the sum of all the numbers. (example "1\n2,3" should equal 6)
// Given the user input is multiple numbers with a custom single-character delimiter when calculating the sum then it should return the sum of all the numbers. (example “//;\n1;2” should return 3)
// Given the user input contains one negative number when calculating the sum then it should throw an exception "negatives not allowed: x" (where x is the negative number).
// Given the user input contains multiple negative numbers mixed with positive numbers when calculating the sum then it should throw an exception "negatives not allowed: x, y, z" (where x, y, z are only the negative numbers).
// Given the user input contains numbers larger than 1000 when calculating the sum it should only sum the numbers less than 1001. (example 2 + 1001 = 2)
// Given the user input is multiple numbers with a custom multi-character delimiter when calculating the sum then it should return the sum of all the numbers. (example: “//[]\n12***3” should return 6)
// Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[][%]\n12%3” should return 6)