using FluentAssertions;

namespace NumberRanges.Tests;

public class NumberRangesTest
{
	[Theory]
	[InlineData(1, true)]
	[InlineData(2, true)]
	[InlineData(3, true)]
	[InlineData(4, true)]
	[InlineData(5, true)]
	[InlineData(6, true)]
	[InlineData(7, false)]
	[InlineData(8, true)]
	[InlineData(9, true)]
	[InlineData(10, true)]
	[InlineData(11, false)]
	[InlineData(12, false)]
	[InlineData(13, false)]
	[InlineData(14, false)]
	[InlineData(15, true)]
	[InlineData(16, false)]
	[InlineData(17, false)]
	[InlineData(18, false)]
	[InlineData(19, true)]
	[InlineData(20, true)]
	[InlineData(21, true)]
	[InlineData(22, true)]
	[InlineData(23, true)]
	[InlineData(24, false)]
	[InlineData(25, true)]
	[InlineData(26, true)]
	[InlineData(27, true)]
	[InlineData(28, true)]
	[InlineData(29, true)]
	[InlineData(30, true)]
	public void Test_Scenario1(int number, bool expected)
	{
		var range = new NumberRange("-6,8-10,15,19-23,25-");

		range.Contains(number).Should().Be(expected);
	}

	[Theory]
	[InlineData(1, true)]
	[InlineData(2, true)]
	[InlineData(3, true)]
	[InlineData(4, true)]
	[InlineData(5, true)]
	[InlineData(6, true)]
	[InlineData(7, false)]
	[InlineData(8, true)]
	[InlineData(9, true)]
	[InlineData(10, true)]
	[InlineData(11, false)]
	[InlineData(12, false)]
	[InlineData(13, false)]
	[InlineData(14, false)]
	[InlineData(15, true)]
	[InlineData(16, false)]
	[InlineData(17, false)]
	[InlineData(18, false)]
	[InlineData(19, true)]
	[InlineData(20, true)]
	[InlineData(21, true)]
	[InlineData(22, true)]
	[InlineData(23, true)]
	[InlineData(24, false)]
	[InlineData(25, true)]
	[InlineData(26, true)]
	[InlineData(27, true)]
	[InlineData(28, true)]
	[InlineData(29, true)]
	[InlineData(30, true)]
	public void Test_Scenario2(int number, bool expected)
	{
		var range = NumberRange.Create()
			.AddLowerThanOrEqual(6)
			.AddRange(8, 10)
			.Add(15)
			.AddRange(19, 23)
			.AddGreaterThanOrEqual(25);

		range.Contains(number).Should().Be(expected);
	}

	[Theory]
	[InlineData(1, true)]
	[InlineData(2, true)]
	[InlineData(3, true)]
	[InlineData(4, true)]
	[InlineData(5, true)]
	[InlineData(6, true)]
	[InlineData(7, false)]
	[InlineData(8, true)]
	[InlineData(9, true)]
	[InlineData(10, true)]
	[InlineData(11, false)]
	[InlineData(12, false)]
	[InlineData(13, false)]
	[InlineData(14, false)]
	[InlineData(15, true)]
	[InlineData(16, false)]
	[InlineData(17, false)]
	[InlineData(18, false)]
	[InlineData(19, true)]
	[InlineData(20, true)]
	[InlineData(21, true)]
	[InlineData(22, true)]
	[InlineData(23, true)]
	[InlineData(24, false)]
	[InlineData(25, true)]
	[InlineData(26, true)]
	[InlineData(27, true)]
	[InlineData(28, true)]
	[InlineData(29, true)]
	[InlineData(30, true)]
	public void Test_Scenario3(int number, bool expected)
	{
		var range = NumberRange.Create()
			.Add("-6")
			.Add("8-10")
			.Add("15")
			.Add("19-23")
			.Add("25-");

		range.Contains(number).Should().Be(expected);
	}

	[Theory]
	[InlineData(1, true)]
	[InlineData(2, true)]
	[InlineData(3, true)]
	[InlineData(4, true)]
	[InlineData(5, true)]
	[InlineData(6, true)]
	[InlineData(7, false)]
	[InlineData(8, true)]
	[InlineData(9, true)]
	[InlineData(10, true)]
	[InlineData(11, false)]
	[InlineData(12, false)]
	[InlineData(13, false)]
	[InlineData(14, false)]
	[InlineData(15, true)]
	[InlineData(16, false)]
	[InlineData(17, false)]
	[InlineData(18, false)]
	[InlineData(19, true)]
	[InlineData(20, true)]
	[InlineData(21, true)]
	[InlineData(22, true)]
	[InlineData(23, true)]
	[InlineData(24, false)]
	[InlineData(25, true)]
	[InlineData(26, true)]
	[InlineData(27, true)]
	[InlineData(28, true)]
	[InlineData(29, true)]
	[InlineData(30, true)]
	public void Test_Scenario4(int number, bool expected)
	{
		var range = NumberRange.Create("-6", "8-10", "15", "19-23", "25-");
		range.Contains(number).Should().Be(expected);
	}

	[Theory]
	[InlineData(1, true)]
	[InlineData(2, true)]
	[InlineData(3, true)]
	[InlineData(4, true)]
	[InlineData(5, true)]
	[InlineData(6, true)]
	[InlineData(7, false)]
	[InlineData(8, true)]
	[InlineData(9, true)]
	[InlineData(10, true)]
	[InlineData(11, false)]
	[InlineData(12, false)]
	[InlineData(13, false)]
	[InlineData(14, false)]
	[InlineData(15, true)]
	[InlineData(16, false)]
	[InlineData(17, false)]
	[InlineData(18, false)]
	[InlineData(19, true)]
	[InlineData(20, true)]
	[InlineData(21, true)]
	[InlineData(22, true)]
	[InlineData(23, true)]
	[InlineData(24, false)]
	[InlineData(25, true)]
	[InlineData(26, true)]
	[InlineData(27, true)]
	[InlineData(28, true)]
	[InlineData(29, true)]
	[InlineData(30, true)]
	public void Test_Scenario5(int number, bool expected)
	{
		var range = new NumberRange("-6", "8-10", "15", "19-23", "25-");
		range.Contains(number).Should().Be(expected);
	}

	[Theory]
	[InlineData("6,8-10,15,19-23,25", 25)]
	[InlineData("6,8-10,15,19-23,25-", null)]
	[InlineData("-6,8-10,15,19-23,25", 25)]
	[InlineData("-6,8-10,15,19-23,25-", null)]
	public void Test_HighValue(string s, int? expected)
	{
		var range = new NumberRange(s);

		range.HighValue.Should().Be(expected);
	}

	[Theory]
	[InlineData("6,8-10,15,19-23,25", 6)]
	[InlineData("6,8-10,15,19-23,25-", 6)]
	[InlineData("-6,8-10,15,19-23,25", null)]
	[InlineData("-6,8-10,15,19-23,25-", null)]
	public void Test_LowValue(string s, int? expected)
	{
		var range = new NumberRange(s);

		range.LowValue.Should().Be(expected);
	}

	[Theory]
	[InlineData("6,8-10,15,19-23,25", "6,8-10,15,19-23,25")]
	[InlineData("-6,8-10,15,19-23,25-", "-6,8-10,15,19-23,25-")]
	[InlineData("19-23,8-10,15,-6,25-", "-6,8-10,15,19-23,25-")]
	public void Test_ToString(string s, string expected)
	{
		var range = new NumberRange(s);

		range.ToString().Should().Be(expected);
	}

	[Theory]
	[InlineData("-30,8-20,15,19-23,7,25-", "-")]
	[InlineData("6,8-20,15,19-23,7,25", "6-23,25")]
	[InlineData("-6,8-14,15,19-23,25-", "-6,8-15,19-23,25-")]
	[InlineData("3,4,5,6,7-9,11,12,13-15,17,18,19-", "3-9,11-15,17-")]
	public void Test_Optimize(string s, string expected)
	{
		var range = new NumberRange(s);
		range.Optimize();

		range.ToString().Should().Be(expected);
	}

	[Theory]
	[InlineData("-6,7,25-", "-6", "7", "25-")]
	[InlineData("6,8-20,15,19-23,7,25", "6", "8-20", "15", "19-23", "7", "25")]
	public void Test_Parse(string s, params string[] expected)
	{
		var range = NumberRange.Parse(s);

		range.Select(r => r.ToString()).Should().BeEquivalentTo(expected);
	}

	[Theory]
	[InlineData("-,20", "-")]			 // a = all
	[InlineData("20,-", "-")]			 // b = all

	[InlineData("20-,20-", "20-")]       // a = H | b = H, duplicate joinable
	[InlineData("20-,-25", "-")]         // a = H | b = L, joinable
	[InlineData("25-,-20", null)]        // a = H | b = L, not joinable
	[InlineData("20-,25-", "20-")]       // a = H | b = H, joinable, a wins
	[InlineData("25-,20-", "20-")]       // a = H | b = H, joinable, b wins
	[InlineData("25-,20-30", "20-")]     // a = H | b = R, overlap joinable
	[InlineData("25-,30-40", "25-")]     // a = H | b = R, inclusion joinable
	[InlineData("25-,23-24", "23-")]     // a = L | b = R, adjacent joinable
	[InlineData("25-,10-20", null)]      // a = H | b = R, not joinable
	[InlineData("25-,24", "24-")]        // a = H | b = S, adjacent joinable
	[InlineData("25-,26", "25-")]        // a = H | b = S, inclusion joinable
	[InlineData("25-,20", null)]         // a = H | b = S, not joinable

	[InlineData("-25,-25", "-25")]       // a = L | b = L, duplicate joinable
	[InlineData("-25,20-", "-")]         // a = L | b = H, joinable
	[InlineData("-20,25-", null)]        // a = L | b = H, not joinable
	[InlineData("-20,-25", "-25")]       // a = L | b = L, joinable, a wins
	[InlineData("-25,-20", "-25")]       // a = L | b = L, joinable, b wins
	[InlineData("-25,20-30", "-30")]     // a = L | b = R, overlap joinable
	[InlineData("-25,10-20", "-25")]     // a = L | b = R, inclusion joinable
	[InlineData("-25,26-27", "-27")]     // a = L | b = R, adjacent joinable
	[InlineData("-25,30-40", null)]      // a = L | b = R, not joinable
	[InlineData("-25,26", "-26")]        // a = L | b = S, adjacent joinable
	[InlineData("-25,24", "-25")]        // a = L | b = S, inclusion joinable
	[InlineData("-25,30", null)]         // a = L | b = S, not joinable

	[InlineData("10-25,10-25", "10-25")] // a = R | b = R, duplicate joinable
	[InlineData("10-25,20-", "10-")]     // a = R | b = H, overlap joinable
	[InlineData("30-40,25-", "25-")]     // a = R | b = H, inclusion joinable
	[InlineData("20-24,25-", "20-")]     // a = R | b = H, adjacent joinable
	[InlineData("10-20,25-", null)]      // a = R | b = H, not joinable
	[InlineData("10-25,-20", "-25")]     // a = R | b = L, overlap joinable
	[InlineData("10-20,-25", "-25")]     // a = R | b = L, inclusion joinable
	[InlineData("26-27,-25", "-27")]     // a = R | b = L, adjacent joinable
	[InlineData("40-50,-25", null)]      // a = R | b = L, not joinable
	[InlineData("10-30,20-40", "10-40")] // a = R | b = R, overlap joinable
	[InlineData("15-45,20-30", "15-45")] // a = R | b = R, inclusion joinable
	[InlineData("12-20,21-32", "12-32")] // a = R | b = R, adjacent joinable
	[InlineData("10-20,30-40", null)]    // a = R | b = R, not joinable
	[InlineData("15-45,30", "15-45")]    // a = R | b = S, inclusion joinable
	[InlineData("12-20,21", "12-21")]    // a = R | b = S, adjacent joinable
	[InlineData("10-20,30", null)]       // a = R | b = S, not joinable
								  
	[InlineData("24,25-", "24-")]        // a = S | b = H, adjacent joinable
	[InlineData("26,25-", "25-")]        // a = S | b = H, inclusion joinable
	[InlineData("20,25-", null)]         // a = S | b = H, not joinable
	[InlineData("26,-25", "-26")]        // a = S | b = L, adjacent joinable
	[InlineData("24,-25", "-25")]        // a = S | b = L, inclusion joinable
	[InlineData("30,-25", null)]         // a = S | b = L, not joinable
	[InlineData("15,10-20", "10-20")]    // a = S | b = R, inclusion joinable
	[InlineData("19,20-25", "19-25")]    // a = S | b = R, adjacent joinable
	[InlineData("10,30-40", null)]       // a = S | b = R, not joinable
	[InlineData("15,15", "15")]	         // a = S | b = S, inclusion joinable
	[InlineData("10,11", "10-11")]       // a = S | b = S, adjacent joinable
	[InlineData("10,12", null)]          // a = S | b = S, not joinable
	public void Test_TryJoin(string s, string? expected)
	{
		var range = NumberRange.Parse(s).ToList();

		range.Should().HaveCount(2);

		NumberRange.TryJoin(range[0], range[1], out var joined).Should().Be(expected is not null);
		joined?.ToString().Should().Be(expected);	
	}
}