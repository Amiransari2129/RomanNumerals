using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals.Domain.Services
{
	public static class RomanConverter
	{
		private static readonly Dictionary<char, int> RomanToDecimalMap = new Dictionary<char, int>
		{
			{'I', 1},
			{'V', 5},
			{'X', 10},
			{'L', 50},
			{'C', 100},
			{'D', 500},
			{'M', 1000}
		};

		private static readonly List<(int value, string numeral)> DecimalToRomanMap = new List<(int, string)>
		{
			(1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
			(100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
			(10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
		};

		public static int RomanToDecimal(string roman)
		{
			string romanUpper = roman.ToUpper().Trim();

			int decimalValue = 0;
			for (int i = 0; i < romanUpper.Length; i++)
			{
				if (i + 1 < romanUpper.Length && RomanToDecimalMap[romanUpper[i]] < RomanToDecimalMap[romanUpper[i + 1]])
				{
					decimalValue -= RomanToDecimalMap[romanUpper[i]];
				}
				else
				{
					decimalValue += RomanToDecimalMap[romanUpper[i]];
				}
			}
			return decimalValue;
		}

		public static string DecimalToRoman(int number)
		{
			if (number > 3000 || number <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(number), "Value cannot be greater than 3000 or less than 0");
			}

			StringBuilder roman = new StringBuilder();
			foreach (var (value, numeral) in DecimalToRomanMap)
			{
				while (number >= value)
				{
					roman.Append(numeral);
					number -= value;
				}
				if (number == 0)
				{
					break;
				}
			}
			return roman.ToString();
		}
	}
}