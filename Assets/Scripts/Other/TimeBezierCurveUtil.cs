using System;
using UnityEngine;

namespace Game
{
	public class TimeBezierCurveUtil
	{
		private static float tMax=0.4f;
		private static float tBei=2.5f;
		private static float distance=600f;
		public TimeBezierCurveUtil ()
		{
		}

		public static void ChangeCurve(int type,ref Vector3 target,float t)
		{
			switch (type) {
			case 0:
				return;
			case 1:
				FromTop (ref target,t);
				break;
			case 2:
				FromButtom (ref target,t);
				break;
			}
		}

		public static void FromTop(ref Vector3 target,float t)
		{
			float y = 0;
			if (t <= tMax) {
				y = distance * (1 - t * tBei)*(1 - t * tBei);
			}
			target.y += y;
		}

		public static void FromButtom(ref Vector3 target,float t)
		{
			float y = 0;
			if (t <= tMax) {
				y = distance * (1 - t * tBei)*(1 - t * tBei);
			}

			target.y -= y;
		}
	}
}

