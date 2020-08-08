using Sail.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sail.Ships.UnityBased
{
	public delegate void InputActionDelegate(InputAction.CallbackContext context);
	public delegate void InputAxisDelegate(float value);
	public delegate void Input2DAxisDelegate(Vector2 value);

	public class BoatInputController : IInputController
	{
		private readonly GameControls mGameControls;

		public InputAxisDelegate RudderDelegate { get; }
		public InputAxisDelegate SailAngleDelegate { get; }
		public InputAxisDelegate SailLevelDelegate { get; }
		public Input2DAxisDelegate CameraDelegate { get; }

		public BoatInputController(InputAxisDelegate rudderDelegate, InputAxisDelegate sailAngleDelegate,
			InputAxisDelegate sailLevelDelegate, Input2DAxisDelegate cameraDelegate)
		{
			mGameControls = new GameControls();

			RudderDelegate = rudderDelegate;
			SailAngleDelegate = sailAngleDelegate;
			SailLevelDelegate = sailLevelDelegate;
			CameraDelegate = cameraDelegate;

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
			RudderDelegate(mGameControls.Boat.Rudder.ReadValue<float>());
			SailAngleDelegate(mGameControls.Boat.SailAngle.ReadValue<float>());
			SailLevelDelegate(mGameControls.Boat.SailLevel.ReadValue<float>());
		}

		public void Dispose()
		{
			mGameControls?.Dispose();
		}

		private void OnCameraActionPerformed(InputAction.CallbackContext context)
		{
			CameraDelegate?.Invoke(context.ReadValue<Vector2>());
		}
	}
}