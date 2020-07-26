using System;
using Sail.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sail.Boat
{
	public delegate void InputActionDelegate(InputAction.CallbackContext context);
	public delegate void InputAxisDelegate(float value);
	public delegate void Input2DAxisDelegate(Vector2 value);

	public class BoatInputController : IDisposable
	{
		private readonly GameControls mGameControls;

		private readonly InputAxisDelegate mRudderDelegate;
		private readonly InputAxisDelegate mSailAngleDelegate;
		private readonly InputAxisDelegate mSailLevelDelegate;
		private readonly Input2DAxisDelegate mCameraDelegate;

		public BoatInputController(InputAxisDelegate rudderDelegate, InputAxisDelegate sailAngleDelegate,
			InputAxisDelegate sailLevelDelegate, Input2DAxisDelegate cameraDelegate)
		{
			mGameControls = new GameControls();

			mRudderDelegate = rudderDelegate;
			mSailAngleDelegate = sailAngleDelegate;
			mSailLevelDelegate = sailLevelDelegate;
			mCameraDelegate = cameraDelegate;

			if (mGameControls != null)
			{
				mGameControls.Boat.Camera.performed += OnCameraActionPerformed;
			}
		}

		public void OnEnable()
		{
			mGameControls.Enable();
		}

		public void OnDisable()
		{
			mGameControls.Disable();
		}

		public void Update()
		{
			mRudderDelegate(mGameControls.Boat.Rudder.ReadValue<float>());
			mSailAngleDelegate(mGameControls.Boat.SailAngle.ReadValue<float>());
			mSailLevelDelegate(mGameControls.Boat.SailLevel.ReadValue<float>());
		}

		public void Dispose()
		{
			mGameControls?.Dispose();
		}

		private void OnCameraActionPerformed(InputAction.CallbackContext context)
		{
			mCameraDelegate?.Invoke(context.ReadValue<Vector2>());
		}
	}
}