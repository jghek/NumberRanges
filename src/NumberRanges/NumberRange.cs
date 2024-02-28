using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberRanges
{
	/// <summary>
	/// Represents a range of numbers.
	/// </summary>
	public interface IRange
	{
		/// <summary>
		/// Returns true if the range contains the number.
		/// </summary>
		/// <param name="number">The number</param>
		/// <returns></returns>
		bool Contains(int number);
		
		/// <summary>
		/// The lowest value in the range. If the range is unbounded at the low end, this will be null.
		/// </summary>
		int? LowValue { get; }

		/// <summary>
		/// The highest value in the range. If the range is unbounded at the high end, this will be null.
		/// </summary>
		int? HighValue { get; }
	}

	/// <summary>
	/// A range that represents a range of numbers. Annotated like this: 5-8
	/// </summary>
	internal class LowHighNumberRange : IRange
	{
		private readonly int _low;
		private readonly int _high;

		public LowHighNumberRange(int low, int high)
		{
			_low = low;
			_high = high;
		}

		public int? LowValue => _low;
		public int? HighValue => _high;

		public bool Contains(int number) => 
			number >= _low && number <= _high;

		public override string ToString() =>
			_low == _high ? _low.ToString() : $"{_low}-{_high}";

		public override bool Equals(object obj) =>
			obj != null && GetType() == obj.GetType() && _low == ((LowHighNumberRange)obj)._low && _high == ((LowHighNumberRange)obj)._high;

		override public int GetHashCode() => 
			_low.GetHashCode() ^ _high.GetHashCode();
	}

	/// <summary>
	/// A range that represents all numbers less than or equal to a value. Annotated like this: -5
	/// </summary>
	internal class LowNumberRange : IRange
	{
		private readonly int _value;

		public int? LowValue => null;
		public int? HighValue => _value;

		public LowNumberRange(int value)
		{
			_value = value;
		}

		public bool Contains(int number) => 
			number <= _value;

		public override string ToString() =>
			$"-{_value}";

		public override bool Equals(object obj) =>
			obj != null && GetType() == obj.GetType() && _value == ((LowNumberRange)obj)._value;

		override public int GetHashCode() => 
			_value.GetHashCode();
	}

	/// <summary>
	/// A range that represents all numbers greater than or equal to a value. Annotated like this: 5-
	/// </summary>
	internal class HighNumberRange : IRange
	{
		private readonly int _value;
		public int? HighValue => null;
		public int? LowValue => _value;

		public HighNumberRange(int value)
		{
			_value = value;
		}

		public bool Contains(int number) => 
			number >= _value;

		public override string ToString() =>
			$"{_value}-";

		public override bool Equals(object obj) =>
			obj != null && GetType() == obj.GetType() && _value == ((HighNumberRange)obj)._value;

		override public int GetHashCode() => 
			_value.GetHashCode();
	}

	/// <summary>
	/// A range that represents a single number. Annotated like this: 5
	/// </summary>
	internal class SingleNumberRange : IRange
	{
		private readonly int _value;
		public int? LowValue => _value;
		public int? HighValue => _value;

		public SingleNumberRange(int value)
		{
			_value = value;
		}

		public bool Contains(int number) => 
			_value == number;

		public override string ToString() =>
			_value.ToString();

		public override bool Equals(object obj) =>
			obj != null && GetType() == obj.GetType() && _value == ((SingleNumberRange)obj)._value;

		override public int GetHashCode() => 
			_value.GetHashCode();
	}

	/// <summary>
	/// A range that represents all numbers. Annotated like this: -
	/// </summary>
	internal class AllNumberRange : IRange
	{
		public int? LowValue => null;
		public int? HighValue => null;

		public bool Contains(int number) => 
			true;

		public override string ToString() =>
			"-";

		public override bool Equals(object obj) =>
			obj != null && GetType() == obj.GetType();

		override public int GetHashCode() => 
			0;
	}	

	/// <summary>
	/// A range that represents a collection of ranges. Annotated like this: 5,8-10,15,19-23,25-
	/// </summary>
	public class NumberRange : IRange
	{
		/// <summary>
		/// Create a new NumberRange. The range is empty.
		/// The Create method is a factory method that can be used to create a new instance of NumberRange. It exaclty the same as using the constructor, but this allow for a more fluent syntax.
		/// </summary>
		/// <returns>An instance of NumberRange.</returns>
		public static NumberRange Create() => new NumberRange();

		/// <summary>
		/// Create a new NumberRange. The range is a comma separated list of ranges. Each range can be a single number, a range of numbers, or a range of numbers with an open end.
		/// The Create method is a factory method that can be used to create a new instance of NumberRange. It exaclty the same as using the constructor, but this allow for a more fluent syntax.		/// </summary>
		/// <param name="range">A range as text, that will be parsed.</param>
		/// <returns>An instance of NumberRange.</returns>
		public static NumberRange Create(string range) => new NumberRange(range);

		/// <summary>
		/// Create a new NumberRange. The range is a list of ranges. Each range can be a single number, a range of numbers, or a range of numbers with an open end.
		/// The Create method is a factory method that can be used to create a new instance of NumberRange. It exaclty the same as using the constructor, but this allow for a more fluent syntax.		/// </summary>
		/// <param name="ranges"></param>
		/// <returns>An instance of NumberRange.</returns>
		public static NumberRange Create(params string[] ranges) => new NumberRange(ranges);

		private List<IRange> _range = new List<IRange>();

		/// <summary>
		/// The lowest value in the range. If the range is unbounded at the low end, this will be null.
		/// </summary>
		public int? LowValue => _range.Exists(r => !r.LowValue.HasValue) ? null : _range.Min(r => r.LowValue);
		
		/// <summary>
		/// The highest value in the range. If the range is unbounded at the high end, this will be null.
		/// </summary>
		public int? HighValue => _range.Exists(r => !r.HighValue.HasValue) ? null : _range.Max(r => r.HighValue);

		/// <summary>
		/// Create a new NumberRange. The range is empty.
		/// </summary>
		public NumberRange() 
		{ }

		/// <summary>
		/// Create a new NumberRange. The range is a comma separated list of ranges. Each range can be a single number, a range of numbers, or a range of numbers with an open end.
		/// </summary>
		/// <param name="range"></param>
		public NumberRange(string range) =>
			_range.AddRange(Parse(range));

		/// <summary>
		/// Create a new NumberRange. The range is a list of ranges. Each range can be a single number, a range of numbers, or a range of numbers with an open end.
		/// </summary>
		/// <param name="ranges"></param>
		public NumberRange(params string[] ranges)
		{
			foreach (var range in ranges)
				_range.AddRange(Parse(range));
		}

		/// <summary>
		/// Add a single number to the range.
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public NumberRange Add(int number)
		{
			_range.Add(new SingleNumberRange(number));
			return this;
		}

		/// <summary>
		/// Add a range of numbers to the range.
		/// </summary>	
		public NumberRange Add(string range)
		{
			_range.AddRange(Parse(range));
			return this;
		}

		/// <summary>
		/// Add a range that is open ended at the high end.
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public NumberRange AddGreaterThanOrEqual(int number)
		{
			_range.Add(new HighNumberRange(number));
			return this;
		}

		/// <summary>
		/// Add a range that is open ended at the low end.
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public NumberRange AddLowerThanOrEqual(int number)
		{
			_range.Add(new LowNumberRange(number));
			return this;
		}

		/// <summary>
		/// Add a range of numbers to the range with a low and high value.
		/// </summary>
		/// <param name="low"></param>
		/// <param name="high"></param>
		/// <returns></returns>
		public NumberRange AddRange(int low, int high)
		{
			_range.Add(new LowHighNumberRange(low, high));
			return this;
		}

		/// <summary>
		/// Check if the range contains a number.
		/// </summary>
		/// <param name="number"></param>
		/// <returns>True if the number is in de the range. False if not.</returns>
		public bool Contains(int number) =>
			_range.Exists(r => r.Contains(number));

		public static IEnumerable<IRange> Parse(string s) =>
			s.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(r => r.Trim()).Select<string, IRange>(r =>
			{
				if (r.Contains("-"))
				{
					var parts = r.Split('-');
					
					if (parts[0] == "" && parts[1] == "")
						return new AllNumberRange();

					if (parts[0] == "")
						return new LowNumberRange(int.Parse(parts[1]));
					
					if (parts[1] == "")
						return new HighNumberRange(int.Parse(parts[0]));
				
					return new LowHighNumberRange(int.Parse(parts[0]), int.Parse(parts[1]));
				}

				return new SingleNumberRange(int.Parse(r));
			});

		public override string ToString() => 
			string.Join(",", _range
				.OrderBy(r => r.LowValue ?? 0)
				.Select(r => r.ToString()));

		public override bool Equals(object obj) =>
			obj != null && GetType() == obj.GetType() && _range.SequenceEqual(((NumberRange)obj)._range);

		override public int GetHashCode() =>
			_range.Aggregate(0, (acc, r) => acc ^ r.GetHashCode());

		/// <summary>
		/// Optimize the range. This will join overlapping ranges and remove empty ranges.
		/// </summary>
		public void Optimize()
		{
			bool done = false;

			while (!done)
			{
				done = true;

				foreach (var c in combinations(_range, 2))
				{
					if (TryJoin(c.First(), c.Last(), out var joined))
					{
						_range.Remove(c.First());
						_range.Remove(c.Last());
						_range.Add(joined);
						done = false;
						break;
					}
				}
			}

			_range.Sort((a, b) => (a.LowValue ?? 0).CompareTo(b.LowValue ?? 0));
		}

		private static IEnumerable<IEnumerable<T>> combinations<T>(IEnumerable<T> c, int k) =>
			k == 0 ? new[] { new T[0] } :
				c.SelectMany((e, i) =>
					combinations(c.Skip(i + 1), k - 1).Select(c => (new[] { e }).Concat(c)));		

		/// <summary>
		/// Try to Join two ranges. If the ranges can be joined, the joined range is returned.
		/// </summary>
		/// <param name="a">Range 1</param>
		/// <param name="b">Range 2</param>
		/// <param name="joined">The combined range. Value is null when ranges could not be joined.</param>
		/// <returns>True if succesful, False is not.</returns>
		public static bool TryJoin(IRange a, IRange b, out IRange joined)
		{
			joined = null;

			if (a is AllNumberRange)
				joined = a;
			else if (b is AllNumberRange)
				joined = b;
			else if (a is HighNumberRange)
			{
				if (b is HighNumberRange)
					joined = hh(a, b);
				else if (b is LowNumberRange)
					joined = hl(a, b);
				else if (b is LowHighNumberRange)
					joined = hrs(a, b);
				else if (b is SingleNumberRange)
					joined = hrs(a, b);
			}
			else if (a is LowNumberRange)
			{
				if (b is HighNumberRange)
					joined = hl(b, a);
				else if (b is LowNumberRange)
					joined = ll(a, b);
				else if (b is LowHighNumberRange)
					joined = lrs(a, b);
				else if (b is SingleNumberRange)
					joined = lrs(a, b);
			}
			else if (a is LowHighNumberRange)
			{
				if (b is HighNumberRange)
					joined = hrs(b, a);
				else if (b is LowNumberRange)
					joined = lrs(b, a);
				else if (b is LowHighNumberRange)
					joined = rr(a, b);
				else if (b is SingleNumberRange)
					joined = rs(a, b);
			}
			else if (a is SingleNumberRange)
			{
				if (b is HighNumberRange)
					joined = hrs(b, a);
				else if (b is LowNumberRange)
					joined = lrs(b, a);
				else if (b is LowHighNumberRange)
					joined = rs(b, a);
				else if (b is SingleNumberRange)
					joined = ss(a, b);
			}

			return joined != null;

			IRange hh(IRange a, IRange b) => new HighNumberRange(Math.Min(a.LowValue.Value, b.LowValue.Value));

			IRange hl(IRange a, IRange b) => a.LowValue.Value <= b.HighValue.Value ? new AllNumberRange() : null;

			IRange hrs(IRange a, IRange b) => b.HighValue.Value + 1 >= a.LowValue.Value ? new HighNumberRange(Math.Min(a.LowValue.Value, b.LowValue.Value)) : null;

			IRange ll(IRange a, IRange b) => new LowNumberRange(Math.Max(a.HighValue.Value, b.HighValue.Value));

			IRange lrs(IRange a, IRange b) => b.LowValue.Value - 1 <= a.HighValue.Value ? new LowNumberRange(Math.Max(a.HighValue.Value, b.HighValue.Value)) : null;

			IRange rr(IRange a, IRange b)
			{
				if ((a.HighValue.Value + 1 >= b.LowValue.Value && a.HighValue.Value - 1 <= b.HighValue.Value)
				 || (b.HighValue.Value + 1 >= a.LowValue.Value && b.HighValue.Value - 1 <= a.HighValue.Value))
					return new LowHighNumberRange(Math.Min(a.LowValue.Value, b.LowValue.Value), Math.Max(a.HighValue.Value, b.HighValue.Value));

				return null;
			}

			IRange rs(IRange a, IRange b)
			{
				if (a.HighValue.Value + 1 >= b.LowValue.Value && a.LowValue.Value - 1 <= b.LowValue.Value)
					return new LowHighNumberRange(Math.Min(a.LowValue.Value, b.LowValue.Value), Math.Max(a.HighValue.Value, b.LowValue.Value));

				return null;
			}

			IRange ss(IRange a, IRange b)
			{
				if (a.LowValue.Value == b.LowValue.Value)
					return new SingleNumberRange(a.LowValue.Value);
				else if (Math.Abs(a.LowValue.Value - b.LowValue.Value) == 1)
					return new LowHighNumberRange(Math.Min(a.LowValue.Value, b.LowValue.Value), Math.Max(a.LowValue.Value, b.LowValue.Value));

				return null;
			}
		}
	}
}
