using Microsoft.AspNetCore.Mvc;
using RomanNumerals.Domain.Services;

namespace RomanNumerals.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RomanNumeralsController : ControllerBase
	{
		[HttpGet("to-decimal/{roman}")]
		public IActionResult ToDecimal(string roman)
		{
			try
			{
				var result = RomanConverter.RomanToDecimal(roman);
				return Ok(result);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("to-roman/{number}")]
		public IActionResult ToRoman(int number)
		{
			try
			{
				var result = RomanConverter.DecimalToRoman(number);
				return Ok(result);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}