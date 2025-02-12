using RomanNumerals.Domain.Services;

namespace RomanNumerals.Domain.Entities
{
	public class RomanNumeral
	{
		public string Value { get; }

		public RomanNumeral(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("Value cannot be null or empty", nameof(value));

			Value = value;
		}

		public int ToDecimal() => RomanConverter.RomanToDecimal(Value);
	}
}