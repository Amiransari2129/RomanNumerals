using System;
using Xunit;
using RomanNumerals.Domain.Services;

namespace RomanNumerals.Tests
{
	public class RomanConverterTests
	{
		[Theory]
		[InlineData("I", 1)]
		[InlineData("IV", 4)]
		[InlineData("VI", 6)]
		[InlineData("IX", 9)]
		[InlineData("XII", 12)]
		[InlineData("XXVII", 27)]
		[InlineData("XLIV", 44)]
		[InlineData("XC", 90)]
		[InlineData("CM", 900)]
		[InlineData("MCMXCIX", 1999)]
		[InlineData("MMCDXLIV", 2444)]
		[InlineData("MMM", 3000)]
		public void RomanToDecimal_ShouldReturnCorrectValue(string roman, int expected)
		{
			int result = RomanConverter.RomanToDecimal(roman);
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData(1, "I")]
		[InlineData(4, "IV")]
		[InlineData(6, "VI")]
		[InlineData(9, "IX")]
		[InlineData(12, "XII")]
		[InlineData(27, "XXVII")]
		[InlineData(44, "XLIV")]
		[InlineData(90, "XC")]
		[InlineData(900, "CM")]
		[InlineData(1999, "MCMXCIX")]
		[InlineData(2444, "MMCDXLIV")]
		[InlineData(3000, "MMM")]
		public void DecimalToRoman_ShouldReturnCorrectValue(int number, string expected)
		{
			string result = RomanConverter.DecimalToRoman(number);
			Assert.Equal(expected, result);
		}

		[Fact]
		public void DecimalToRoman_NumberTooLarge_ShouldThrowException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => RomanConverter.DecimalToRoman(3001));
		}
		[Fact]
		public void DecimalToRoman_NumberTooSmall_ShouldThrowException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => RomanConverter.DecimalToRoman(0));
		}
	}
}