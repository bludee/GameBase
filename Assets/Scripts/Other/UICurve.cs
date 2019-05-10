using System;
using UnityEngine;
using System.Collections.Generic;
using DG;
using FairyGUI;
namespace Game
{
	/// <summary>
	/// 贝塞尔曲线运动,优化变量  调整时间设置,目标点设置,运动完成callback 旋转设置
	/// </summary>


	public class UICurve
	{
		public Vector3 start;
		public Vector3 end;
		public Vector3 center;
		public float t = 0;

		Action callBack=null;

		bool roFlag=true;
		public bool flag=false;

		public float timeDiff=0.01f;

		public bool flip=false;

		GObject owner;

		Vector3 posCache=Vector3.zero;

		public void SetParams(GObject own,Vector3 s,Vector3 c,Vector3 e,float td,Action cb,bool rf=true)
		{
			owner = own;
			t = 0;
			start = s;
			center = c;
			end = e;
			timeDiff = td;
			callBack = cb;
			roFlag = rf;
			flag = true;
		}
		public void Update()
		{
			if (flag == true) {
				t += timeDiff;
				Result (start, end, t);
			}
		}

		public void Result(Vector3 startPos, Vector3 endPos, float t)
		{
			if (t > 1)
			{
				t = 1;
				if (callBack != null) {
					callBack ();
					callBack = null;
				}
				flag = false;
				return;
			}
			posCache= (1 -t) * (1 - t) * startPos + 2 * t * (1- t) * center + t * t * endPos;
			owner.SetXY (posCache.x,posCache.y);
			if (roFlag == true) {
				ro ();
			}
		}

		public float TimeDiff{
			get{ 
				return timeDiff;
			}
			set
			{ 
				timeDiff = value;
			}
		}

		public void ro()
		{
			float yr = 0f;
//			Vector3 r = new Vector3 (0,0,yr);
//			if (t <= 0.5) {
//				yr = 180f * (0.5f - t);
//			} else {
//				yr = 180f * (0.5f - t);
//			}
//			if (flip == true) {
//				r.z = yr;
//			} else {
//				r.z = -yr;
//			}

			yr = 180 * t;
			owner.rotation = yr;
		}

	}
}

