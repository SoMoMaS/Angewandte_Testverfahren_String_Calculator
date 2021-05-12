using NUnit.Framework;
using StringCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator_NUnitTests
{
    class StringCalculatorNUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_String_Is_Empty_Should_Return_Zero()
        {
            Assert.AreEqual(StringCalculator.StringCalculator.Add(""), 0);
        }

        [Test]
        public void Given_String_Contains_A_Number_Should_Return_The_Given_Number()
        {
            Assert.AreEqual(StringCalculator.StringCalculator.Add("1"), 1);
            Assert.AreEqual(StringCalculator.StringCalculator.Add("2"), 2);
        }

        [Test]
        public void Given_String_Contains_2_Number_Seperated_By_Comma_Should_Return_The_Sum_Of_The_Numbers()
        {
            Assert.AreEqual(StringCalculator.StringCalculator.Add("5,10"), 15);
            Assert.AreEqual(StringCalculator.StringCalculator.Add("20,69"), 89);
            Assert.AreEqual(StringCalculator.StringCalculator.Add("19,10000"), 10019);
        }

        [Test]
        public void Given_String_Contains_Invalid_Characters_Should_Return_Zero()
        {
            Assert.AreEqual(StringCalculator.StringCalculator.Add("asd"), 15);
        }
    }
}
