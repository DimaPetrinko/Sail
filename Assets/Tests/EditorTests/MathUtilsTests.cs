using NUnit.Framework;
using Sail.Utils;

namespace Sail.Tests.EditorTests
{
	public class MathUtilsTests
	{
		[Test]
		public void Clamp_ValueLowerThanFrom_EqualsLower()
		{
			var value = -5f;

			var result = MathUtils.Clamp(value, -2f, 1f);

			Assert.AreEqual(-2f, result);
		}

		[Test]
		public void Clamp_ValueGreaterThanTo_EqualsTo()
		{
			var value = 6f;

			var result = MathUtils.Clamp(value, -2f, 1f);

			Assert.AreEqual(1f, result);
		}

		[Test]
		public void Clamp_ValueBetweenToAndFrom_EqualsValue()
		{
			var value = -0.5f;

			var result = MathUtils.Clamp(value, -2f, 1f);

			Assert.AreEqual(value, result);
		}

		[Test]
		public void Max_AGreaterThanB_ReturnsA()
		{
			var a = 12f;
			var b = 3f;

			var result = MathUtils.Max(a, b);

			Assert.AreEqual(a, result);
		}

		[Test]
		public void Max_ALessThanB_ReturnsB()
		{
			var a = 5;
			var b = 9;

			var result = MathUtils.Max(a, b);

			Assert.AreEqual(b, result);
		}

		[Test]
		public void Max_AEqualsB_ReturnsA()
		{
			var a = 5d;
			var b = 5d;

			var result = MathUtils.Max(a, b);

			Assert.AreEqual(a, result);
		}
	}
}