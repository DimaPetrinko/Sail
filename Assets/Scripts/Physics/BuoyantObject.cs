using System;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace Sail.Physics
{
	public class BuoyantObject : MonoBehaviour
	{
		[SerializeField] private Transform m_WaterMarker;
		[SerializeField] private Transform[] m_ForcePoints;
		[SerializeField] private MediumType m_Medium;
		[SerializeField] private float m_Density;

		private Transform mTransform;
		private Rigidbody mRigidbody;
		private float mVolume;

		private void Awake()
		{
			mTransform = transform;
			mRigidbody = GetComponent<Rigidbody>();
			if (m_ForcePoints.Length == 0) m_ForcePoints = new[] {mTransform};
			mVolume = mRigidbody.mass / m_Density;
		}

		private void OnValidate()
		{
			if (mRigidbody != null)
			{
				mVolume = mRigidbody.mass / m_Density;
				Debug.Log(mVolume);
			}
		}

		private void FixedUpdate()
		{
			foreach (var p in m_ForcePoints)
			{
				var point = p.position;
				var submerged = m_WaterMarker.position.y - point.y > 0;
				var outputForce = ApplyBuoyancy(submerged, mVolume / m_ForcePoints.Length,
					PhysicsConstants.MediumDensityByType[m_Medium]);
				var forcePerPoint = outputForce + PhysicsConstants.Gravity * mRigidbody.mass / m_ForcePoints.Length;
				mRigidbody.AddForceAtPosition(forcePerPoint, point);

				Debug.DrawRay(point, forcePerPoint, Color.red);
			}
		}

		private Vector3 ApplyBuoyancy(bool submerged, float volume, float mediumDensity)
		{
			if (!submerged) return Vector3.zero;
			return mediumDensity * volume * -PhysicsConstants.Gravity;
		}
	}
}