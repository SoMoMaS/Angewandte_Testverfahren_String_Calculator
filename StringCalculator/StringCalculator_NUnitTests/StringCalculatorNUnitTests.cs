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
    }
}
