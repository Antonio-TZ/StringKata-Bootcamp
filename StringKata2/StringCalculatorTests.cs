using NUnit.Framework;
using System;

namespace StringKata2 {
    [TestFixture]
    public class StringCalculatorTests {

        private StringCalculator calculator;

        [OneTimeSetUp]
        public void Initialise() {
            calculator = new StringCalculator();
        }

        [Test]
        public void return_0_when_passed_empty_string() {
            int result = calculator.add("");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void return_number_passed() {
            int result = calculator.add("1");
            Assert.AreEqual(1, result);
        }

        [Test]
        public void return_sum_of_two_numbers() {
            int result = calculator.add("1,2");
            Assert.AreEqual(3, result);
        }

        [Test]
        [TestCase("1,2,3", ExpectedResult = 6)]
        [TestCase("1,2,3,4", ExpectedResult = 10)]
        [TestCase("1,2,3,4,5", ExpectedResult = 15)]
        public int return_sume_of_multiple_numbers(string numbers) {
            return calculator.add(numbers);
        }

        [Test]
        public void return_sum_when_newline_character_is_delimiter() {
            int result = calculator.add("1\n2,3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void return_sum_when_passed_custom_delimiters() {
            int result = calculator.add("//;\n1\n2;3,4");
            Assert.AreEqual(10, result);
        }

        [Test]
        public void return_sum_when_passed_custom_delimiters_of_any_length() {
            int result = calculator.add("//[***]\n1\n2***3,4***5");
            Assert.AreEqual(15, result);
        }

        [Test]
        public void return_sum_when_passed_multiple_custom_delimiters_of_any_length() {
            int result = calculator.add("//[***][;]\n1\n2;3,4***5");
            Assert.AreEqual(15, result);
        }

        [Test]
        public void throw_exceptions_when_passed_negative_numbers() {
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.add("//;\n1\n2;3,4,-5"));
        }

        [Test]
        public void ignore_numbers_larger_than_1000() {
            int result = calculator.add("//;\n1\n2;3,4,1001");
            Assert.AreNotEqual(1011, result);
        }
    }
}
