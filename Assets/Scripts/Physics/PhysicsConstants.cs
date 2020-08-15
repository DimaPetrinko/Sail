using System.Collections.Generic;
using UnityEngine;

namespace Sail.Physics
{
	public static class PhysicsConstants
	{
		public static readonly Vector3 Gravity = new Vector3(0, -9.81f, 0);

		public static readonly Dictionary<MediumType, float> MediumDensityByType = new Dictionary<MediumType, float>
		{
			{MediumType.Air, 0.001225f}, {MediumType.Water, 0.997f}
		};
	}
}