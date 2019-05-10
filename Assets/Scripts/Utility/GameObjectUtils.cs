using System;
using UnityEngine;
namespace Game
{
	public class GameObjectUtils
	{
		public GameObjectUtils ()
		{
		}


		public static void ResetZ(Transform trans)
		{
			float z = trans.position.y/1000f;
			trans.position = new Vector3 (trans.position.x,trans.position.y,z);
		}
	}
}

