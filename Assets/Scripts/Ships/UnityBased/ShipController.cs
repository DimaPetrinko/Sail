using System;
using System.Linq;
using UnityEngine;

namespace Sail.Ships.UnityBased
{
	[Serializable]
	public struct Range
	{
		public float from;
		public float to;

		public float Span => to - from;
	}

	[Serializable]
	public class Rudder
	{
		[SerializeField] private Transform m_Pivot;
		[SerializeField] private Range m_AngleRange;
		[SerializeField] private float m_Speed = 0.8f;
		[SerializeField] private float m_CoolOffSpeed = 0.1f;

		private float mPreviousRotationState;

		public float RotationState { get; private set; }

		public void Start()
		{
			ApplyAngle(0);
		}

		public void Rotate(float value)
		{
			float delta;
			if (Mathf.Approximately(value, 0f)) delta = -RotationState * m_CoolOffSpeed;
			else delta = value * m_Speed;

			var newRotationState = Mathf.Clamp(RotationState += delta * Time.deltaTime, -1, 1);

			if (Mathf.Approximately(mPreviousRotationState, newRotationState) && value == 0) return;
			RotationState = newRotationState;
			mPreviousRotationState = RotationState;

			ApplyAngle(RotationState);
		}

		private void ApplyAngle(float rotationState)
		{
			Debug.LogWarning(rotationState);

			var actualAngle = -Mathf.Lerp(m_AngleRange.@from, m_AngleRange.to, (rotationState + 1) / 2);
			m_Pivot.localRotation = Quaternion.Euler(Vector3.up * actualAngle);
		}
	}

	[Serializable]
	public class Sail
	{
		[SerializeField] private Transform m_Pivot;
		[SerializeField] private Range m_AngleRange;
		[SerializeField] private Range m_ScaleRange;
		[SerializeField] private float m_ForceMultiplier = 2f;
		[SerializeField] private float m_AngleSpeed = 0.8f;
		[SerializeField] private float m_LevelSpeed = 0.4f;

		private float mRotationState;
		private float mLevel;
		private float mPreviousRotationState;
		private float mPreviousLevel;

		private Vector3 mForceDirection;
		private float mForceMagnitude;

		public Vector3 Force => mForceDirection * mForceMagnitude;

		public void Start()
		{
			ApplyAngle(0);
			ApplyLevel(0);
		}

		public void SetAngle(float value)
		{
			var newRotationState = Mathf.Clamp(mRotationState += value * m_AngleSpeed * Time.deltaTime, -1, 1);

			if (Mathf.Approximately(mPreviousRotationState, newRotationState) && value == 0) return;
			mRotationState = newRotationState;
			mPreviousRotationState = mRotationState;

			ApplyAngle(mRotationState);
		}

		private void ApplyAngle(float rotationState)
		{
			Debug.Log(rotationState);

			var actualAngle = -Mathf.Lerp(m_AngleRange.@from, m_AngleRange.to, (rotationState + 1) / 2);
			m_Pivot.localRotation = Quaternion.Euler(Vector3.up * actualAngle);

			mForceDirection = m_Pivot.forward;
		}

		public void SetLevel(float value)
		{
			var newLevel = Mathf.Clamp01(mLevel += value * m_LevelSpeed * Time.deltaTime);

			if (Mathf.Approximately(mPreviousLevel, newLevel) && value == 0) return;
			mLevel = newLevel;
			mPreviousLevel = mLevel;

			ApplyLevel(mLevel);
		}

		private void ApplyLevel(float level)
		{
			Debug.Log(level);
			var actualScale = Mathf.Lerp(m_ScaleRange.@from, m_ScaleRange.to, level);
			m_Pivot.localScale = new Vector3(1, actualScale, 1);

			mForceMagnitude = level * m_ForceMultiplier;
		}
	}

	[RequireComponent(typeof(CharacterController))]
	public class ShipController : MonoBehaviour
	{
		[SerializeField] private CharacterController m_Controller;
		[SerializeField] private Transform m_CameraPivot;
		[SerializeField] private Rudder m_Rudder;
		[SerializeField] private Sail[] m_Sails;

		private IInputController mInputController;

		private void Awake()
		{
			m_Controller = GetComponent<CharacterController>();
			mInputController = new BoatInputController(m_Rudder.Rotate,
				SetAllSailsAngle, SetAllSailsLevel, OnCameraActionPerformed);
		}

		private void Start()
		{
			m_Rudder.Start();
			for (var i = 0; i < m_Sails.Length; i++) m_Sails[i].Start();
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
			Move();
		}

		private void OnDestroy()
		{
			mInputController.Dispose();
		}

		private void Move()
		{
			var totalForce = m_Sails.Select(s => s.Force).Aggregate((a, b) => a + b);
			var forward = transform.forward;
			var movementDirection = forward * Vector3.Dot(totalForce, forward);
			Debug.DrawRay(transform.position + Vector3.up, movementDirection, Color.green);
			Debug.DrawRay(transform.position + Vector3.up, totalForce, Color.red);
			Debug.DrawRay(transform.position + Vector3.up, forward, Color.blue);
			m_Controller.Move(movementDirection * Time.deltaTime);
		}

		private void SetAllSailsAngle(float angle)
		{
			for (var i = 0; i < m_Sails.Length; i++) m_Sails[i].SetAngle(angle);
		}

		private void SetAllSailsLevel(float level)
		{
			for (var i = 0; i < m_Sails.Length; i++) m_Sails[i].SetLevel(level);
		}

		private void OnCameraActionPerformed(Vector2 value)
		{
			// Debug.Log($"Camera action performed. Value is {value}");
		}
	}
}