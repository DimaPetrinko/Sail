using System;

namespace Sail.Utils
{
	public static class MathUtils
	{
		public static T Clamp<T>(T value, T from, T to) where T : IComparable, IComparable<T>
		{
			if (value.CompareTo(from) < 0) value = from;
			else if (value.CompareTo(to) > 0) value = to;
			return value;
		}

		public static T Max<T>(T a, T b) where T : IComparable, IComparable<T>
		{
			return b.CompareTo(a) > 0 ? b : a;
		}
	}
}