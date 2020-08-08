using Sail.Utils;
using UnityEngine;

namespace Sail.Ships
{
	public class Hull
	{
		private float mRudder;
		public float Rudder
		{
			get => mRudder;
			set => mRudder = MathUtils.Clamp(value, -1f, 1f);
		}

		public float Speed
		{
			get => mSpeed;
			set => mSpeed = MathUtils.Max(0f, value);
		}

		public Vector3 MovementDirection { get; private set; }

		public Quaternion RotationDelta { get; private set; }

		public Quaternion Orientation { get; set; }

		private readonly AnimationCurve mRotationOverSpeedCurve = new AnimationCurve(
			new Keyframe(0, 0),
			new Keyframe(4, 1),
			new Keyframe(20, 0.1f));
		private float mSpeed;

		private void UpdateRotationDelta()
		{
			var rotationRate = mRotationOverSpeedCurve.Evaluate(Speed);
			// RotationDelta = ;
		}

		public void ApplyMastForce(Vector3 force)
		{
			
		}
	}
}