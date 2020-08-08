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
			Hull = new Hull();
			Hull.Orientation = Quaternion.identity;

			Orientation = Hull.Orientation;

			Sail = new Sail();
			Sail.MastOrientation = Orientation;

		}
	}
}