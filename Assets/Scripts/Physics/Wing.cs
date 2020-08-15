using System.Collections.Generic;
using UnityEngine;

namespace Sail.Physics
{
	public enum MediumType { Air, Water }

	[RequireComponent(typeof(Rigidbody))]
	public class Wing : MonoBehaviour
	{
		[SerializeField] private Transform m_FlowMarker;
		[SerializeField] private Transform[] m_ForcePoints;
		[SerializeField] private AnimationCurve m_LiftCurve;
		[SerializeField] private bool m_InvertCurve;
		[SerializeField] private MediumType m_Medium;
		[SerializeField] private float m_TotalArea;

		private Transform mTransform;
		private Rigidbody mRigidbody;

		private void Awake()
		{
			mTransform = transform;
			mRigidbody = GetComponent<Rigidbody>();
			if (m_ForcePoints.Length == 0) m_ForcePoints = new[] {mTransform};
		}

		private void FixedUpdate()
		{
			foreach (var p in m_ForcePoints)
			{
				var point = p.position;
				var outputForce = ApplyFlow(m_FlowMarker.forward * m_FlowMarker.localScale.x,
					mRigidbody.GetPointVelocity(point), PhysicsConstants.MediumDensityByType[m_Medium],
					m_TotalArea / m_ForcePoints.Length);
				mRigidbody.AddForceAtPosition(outputForce, point);

				Debug.DrawRay(point, outputForce, Color.blue);
				Debug.DrawRay(point, mRigidbody.velocity, Color.magenta);
			}
		}

		private Vector3 ApplyFlow(Vector3 flow, Vector3 velocity, float mediumDensity, float area)
		{
			var apparentFlow = flow - velocity;
			var apparentFlowNormalized = apparentFlow.normalized;
			var forward = mTransform.forward;
			var right = mTransform.right;

			var dragCoefficient = (1 - Mathf.Abs(Vector3.Dot(apparentFlowNormalized, forward))) * 2;
			var drag = mediumDensity * apparentFlow.sqrMagnitude * dragCoefficient * area
				* apparentFlowNormalized / 2;

			var angle = Vector3.SignedAngle(forward, apparentFlowNormalized, right);
			var sign = Mathf.Sign(angle);
			if (m_InvertCurve) angle *= -1;
			if (angle > 90)
			{
				angle = (angle - 180) * -1;
				sign *= -1;
			}
			else if (angle < -90)
			{
				angle = (angle + 180) * -1;
				sign *= -1;
			}

			var liftCoefficient = m_LiftCurve.Evaluate(angle);
			var lift = mediumDensity * apparentFlow.sqrMagnitude * liftCoefficient * area * sign
				* Vector3.Cross(-apparentFlowNormalized, right) / 2;


			Debug.DrawRay(mTransform.position, flow, Color.cyan);
			// Debug.DrawRay(mTransform.position, drag, Color.red);
			// Debug.DrawRay(mTransform.position, lift, Color.green);
			// Debug.DrawRay(mTransform.position, forward * 100f, Color.red);
			// Debug.DrawRay(mTransform.position, apparentWindNormalized * 100f, Color.green);
			// Debug.DrawRay(mTransform.position, right * 100f, Color.blue);

			return lift + drag;
		}
	}
}
