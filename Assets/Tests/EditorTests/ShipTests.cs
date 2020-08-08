using NUnit.Framework;
using Sail.Ships;
using UnityEngine;

/*
 * Naming convention for tests is What_Action_ExpectedResult
*/

namespace Sail.Tests.EditorTests
{
	public class ShipTests
	{
		private static Ship CreateShip() { return new Ship(); }

		[Test]
		public void NewShip_Created_InitializedCorrectly()
		{
			var ship = CreateShip();

			Assert.IsNotNull(ship);
			Assert.IsNotNull(ship.Sail);
			Assert.IsNotNull(ship.Hull);
			Assert.AreEqual(Quaternion.identity, ship.Orientation);
		}

		private class SailTests
		{
			private Ships.Sail mSail;

			[SetUp]
			public void SetUpSail()
			{
				mSail = new Ships.Sail();
			}

			[Test]
			public void SailLevel_SetToLessThanZero_EqualsZero()
			{
				mSail.Level = -1f;

				Assert.GreaterOrEqual(mSail.Level, 0f);
			}

			[Test]
			public void SailLevel_SetToMoreThanOne_EqualsOne()
			{
				mSail.Level = 2f;

				Assert.GreaterOrEqual(mSail.Level, 1f);
			}

			[Test]
			public void FullyOpenSail_WithInlineWindDirection_OutputsFullForce()
			{
				var wind = new Vector3(3, 0, 1);
				var yWindAngle = Vector3.Angle(Vector3.forward, new Vector3(wind.x, 0, wind.z));

				mSail.Level = 1f;
				mSail.Angle = yWindAngle;
				mSail.Blow(wind);

				Assert.AreEqual(wind.magnitude, mSail.OutputForce.magnitude);
			}

			[Test]
			public void FullyOpenSail_WithPerpendicularWindDirection_OutputsNoForce()
			{
				var wind = new Vector3(3, 0, 1);
				var yWindAngle = Vector3.Angle(Vector3.forward, new Vector3(wind.x, 0, wind.z));

				mSail.Level = 1f;
				mSail.Angle = yWindAngle + 90;
				mSail.Blow(wind);

				Assert.AreEqual(0f, mSail.OutputForce.magnitude, 0.0001f);
			}

			[Test]
			public void FullyOpenSail_WithSlightlyDownwardsInlineWindDirection_OutputsLessThanFullForce()
			{
				var wind = new Vector3(3, 1, 1);
				var yWindAngle = Vector3.Angle(Vector3.forward, new Vector3(wind.x, 0, wind.z));

				mSail.Level = 1f;
				mSail.Angle = yWindAngle;
				mSail.Blow(wind);

				Assert.Less(mSail.OutputForce.magnitude, wind.magnitude);
				Assert.Greater(mSail.OutputForce.magnitude, 0f);
			}

			[Test]
			public void HalfOpenSail_WithInlineWindDirection_OutputsHalfForce()
			{
				var wind = new Vector3(3, 0, 1);
				var yWindAngle = Vector3.Angle(Vector3.forward, new Vector3(wind.x, 0, wind.z));

				mSail.Level = 0.5f;
				mSail.Angle = yWindAngle;
				mSail.Blow(wind);

				Assert.AreEqual(wind.magnitude / 2f, mSail.OutputForce.magnitude, 0.0001f);
			}

			[Test]
			public void HalfOpenSail_WithPerpendicularWindDirection_OutputsNoForce()
			{
				var wind = new Vector3(3, 0, 1);
				var yWindAngle = Vector3.Angle(Vector3.forward, new Vector3(wind.x, 0, wind.z));

				mSail.Level = 0.5f;
				mSail.Angle = yWindAngle + 90;
				mSail.Blow(wind);

				Assert.AreEqual(0f, mSail.OutputForce.magnitude, 0.0001f);
			}

			[Test]
			public void HalfOpenSail_WithSlightlyDownwardsInlineWindDirection_OutputsLessThanHalfForce()
			{
				var wind = new Vector3(3, 1, 1);
				var yWindAngle = Vector3.Angle(Vector3.forward, new Vector3(wind.x, 0, wind.z));

				mSail.Level = 0.5f;
				mSail.Angle = yWindAngle;
				mSail.Blow(wind);

				Assert.Less(mSail.OutputForce.magnitude, wind.magnitude / 2f);
				Assert.Greater(mSail.OutputForce.magnitude, 0f);
			}

			[Test]
			public void FullyOpenSail_WithAngledMastOrientationAndInlineWindDirection_OutputsLessThanFullForce()
			{
				var wind = new Vector3(0, 0, 1);
				var yWindAngle = Vector3.Angle(Vector3.forward, new Vector3(wind.x, 0, wind.z));

				mSail.Level = 1f;
				mSail.Angle = yWindAngle;
				mSail.MastOrientation = Quaternion.AngleAxis(10, Vector3.right);
				mSail.Blow(wind);

				Assert.Less(mSail.OutputForce.magnitude, wind.magnitude);
				Assert.Greater(mSail.OutputForce.magnitude, 0f);
			}

			[Test]
			public void FullyOpenSail_WithAngledMastOrientationAndEquallyAngledWindDirection_OutputsFullForce()
			{
				var wind = Quaternion.AngleAxis(10, Vector3.right) * new Vector3(3, 0, 1);
				var yWindAngle = Vector3.Angle(Vector3.forward, new Vector3(wind.x, 0, wind.z));

				mSail.Level = 1f;
				mSail.Angle = yWindAngle;
				mSail.MastOrientation = Quaternion.AngleAxis(10, Vector3.right);
				mSail.Blow(wind);

				Assert.AreEqual(wind.magnitude, mSail.OutputForce.magnitude, 0.0001f);
			}
		}

		private class HullTests
		{
			private Hull mHull;

			[SetUp]
			public void SetUpHull()
			{
				mHull = new Hull();
			}

			[Test]
			public void Hull_WithForceInOtherDirection_ResultsInInlineOutputVector()
			{
				mHull.Orientation = Quaternion.LookRotation(new Vector3(2, 0, 2), Vector3.up);
				mHull.ApplyMastForce(new Vector3(3, 0, 1));

				var expectedForceDirection = (mHull.Orientation * Vector3.forward).normalized;

				Assert.AreEqual(expectedForceDirection, mHull.MovementDirection.normalized);
			}

			[Test]
			public void Rudder_SetToLessThanNegativeOne_EqualsNegativeOne()
			{
				mHull.Rudder = -4f;

				Assert.AreEqual(-1f, mHull.Rudder);
			}

			[Test]
			public void Rudder_SetToMoreThanOne_EqualsOne()
			{
				mHull.Rudder = 5f;

				Assert.AreEqual(1f, mHull.Rudder);
			}

			[Test]
			public void Rudder_SetToBetweenNegativeOneAndOne_EqualsValue()
			{
				mHull.Rudder = 0.2f;

				Assert.AreEqual(0.2f, mHull.Rudder);
			}

			[Test]
			public void DeltaRotation_WithRudderAtMaxRightAndNonZeroSpeed_LooksToTheRight()
			{
				mHull.Rudder = 1f;
				mHull.Speed = 1f;

				var resultEuler = mHull.RotationDelta.eulerAngles;
				Assert.Less(resultEuler.y, 0f);
			}
		}
	}
}