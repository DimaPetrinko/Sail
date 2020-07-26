using System;
using UnityEngine;

namespace Sail.Boat
{
	[Serializable]
	public struct Range
	{
		public float from;
		public float to;

		public float Span => to - from;
	}

	public class BoatController : MonoBehaviour
	{
		[SerializeField] private Transform m_RotationPivot;
		[SerializeField] private Transform m_RudderPivot;
		[SerializeField] private Range m_RudderAngleRange; // extract rudder into a separate class and make it testable
		[SerializeField] private float m_RudderSpeed = 2f;
		[SerializeField] private float m_RudderCoolOffSpeed = 0.1f;
		[SerializeField] private float m_SailAngleSpeed = 2f;
		[SerializeField] private float m_SailLevelSpeed = 1f;

		private BoatInputController mInputController;
		private float mRudderAngle;
		private float mSailAngle;
		private float mSailLevel;

		private void Awake()
		{
			mInputController = new BoatInputController(OnRudderActionPerformed, OnSailAngleActionPerformed,
				OnSailLevelActionPerformed, OnCameraActionPerformed);
		}

		private void OnEnable()
		{
			mInputController.OnEnable();
		}

		private void OnDisable()
		{
			mInputController.OnDisable();
		}

		private void Update()
		{
			mInputController.Update();
		}

		private void OnDestroy()
		{
			mInputController.Dispose();
		}

		private void OnRudderActionPerformed(float value)
		{
			float delta;
			if (Mathf.Approximately(value, 0f)) delta = -mRudderAngle * m_RudderCoolOffSpeed;
			else delta = value * m_RudderSpeed;

			Debug.LogWarning(delta);

			mRudderAngle = Mathf.Clamp(mRudderAngle += delta * Time.deltaTime, -1, 1);
			var actualAngle = -Mathf.Lerp(m_RudderAngleRange.@from, m_RudderAngleRange.to, (mRudderAngle + 1) / 2);
			m_RudderPivot.localRotation = Quaternion.Euler(Vector3.up * actualAngle);
		}

		private void OnSailAngleActionPerformed(float value)
		{
			mSailAngle = Mathf.Clamp(mSailAngle += value * m_SailAngleSpeed * Time.deltaTime, -1, 1);
			Debug.Log($"Sail angle action performed. Value is {mSailAngle}");
		}

		private void OnSailLevelActionPerformed(float value)
		{
			mSailLevel = Mathf.Clamp01(mSailLevel += value * m_SailLevelSpeed * Time.deltaTime);
			Debug.Log($"Sail level action performed. Value is {mSailLevel}");
		}

		private void OnCameraActionPerformed(Vector2 value)
		{
			// Debug.Log($"Camera action performed. Value is {value}");
		}
	}
}