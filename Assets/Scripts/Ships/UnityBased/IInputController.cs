using System;

namespace Sail.Ships.UnityBased
{
	public interface IInputController : IDisposable
	{
		InputAxisDelegate RudderDelegate { get; }
		InputAxisDelegate SailAngleDelegate { get; }
		InputAxisDelegate SailLevelDelegate { get; }
		Input2DAxisDelegate CameraDelegate { get; }
		void OnEnable();
		void OnDisable();
		void Update();
	}
}