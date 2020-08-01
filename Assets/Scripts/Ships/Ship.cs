using UnityEngine;

namespace Sail.Ships
{
	public class Ship
	{
		public Quaternion Orientation { get; set; }
		public Sail Sail { get; }
		public Hull Hull { get; }

		public Ship()
		{
			Orientation = Quaternion.identity;
			Sail = new Sail();
			Sail.MastOrientation = Orientation;

			Hull = new Hull();
		}
	}
}