using Sail.Utils;
using UnityEngine;

namespace Sail.Ships
{
	public class Sail
	{
		private Vector3 mNormal;
		private Quaternion mMastOrientation;
		private float mLevel;
		private float mAngle;

		public float Level
		{
			get => mLevel;
			set => mLevel = MathUtils.Clamp(value, 0f, 1f);
		}

		public float Angle
		{
			get => mAngle;
			set
			{
				mAngle = value;
				UpdateNormal();
			}
		}
		public Quaternion MastOrientation
		{
			get => mMastOrientation;
			set
			{
				mMastOrientation = value;
				UpdateNormal();
			}
		}

		public Vector3 OutputForce { get; private set; }

		public Sail()
		{
			Level = 0f;
			Angle = 0f;
			MastOrientation = Quaternion.identity;
		}

		public void Blow(Vector3 wind)
		{
			OutputForce = mNormal * Vector3.Dot(wind, mNormal) * Level;
		}

		private void UpdateNormal()
		{
			mNormal = (MastOrientation * Quaternion.AngleAxis(mAngle, Vector3.up) * Vector3.forward).normalized;
		}
	}
}