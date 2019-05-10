using System;
using UnityEngine;
using System.Collections.Generic;
using DG;
namespace Game
{
	/// <summary>
	/// 贝塞尔曲线运动,优化变量  调整时间设置,目标点设置,运动完成callback 旋转设置
	/// </summary>


	public class BezierCurve:MonoBehaviour
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

		public float normalDiff = 0f;



		private int markStatus=0; // |     0  | 1 |   2 |
		private float markMax=0.8f;
		private float markMin=0.7f;

		void Start()
		{
		}

		public void SetGoldParams(Vector3 s,Vector3 c,Vector3 e,float td,Action cb)
		{
			t = 0;
			start = s;
			center = c;
			end = e;
			timeDiff = td;
			callBack = cb;
			roFlag = false;
			flag = true;
		}
		public void SetFishParams(Vector3 s,Vector3 c,Vector3 e,float td,Action cb,bool f=false)
		{
			t = 0;
			start = s;
			center = c;
			end = e;
			timeDiff = td;
			normalDiff = td;
			callBack = cb;
			flip=f;
			roFlag = true;
			flag = true;
		}

		public void SetParams(Vector3 s,Vector3 c,Vector3 e,float td,Action cb,bool rf=true)
		{
			t = 0;
			start = s;
			center = c;
			end = e;
			timeDiff = td;
			callBack = cb;
			roFlag = rf;
			flag = true;
		}
		void Update()
		{
			if (flag == true) {
				t += timeDiff;
				Result (start, end, t);
				if (roFlag == true) {
					ro ();
				}
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
			this.transform.position= (1 -t) * (1 - t) * startPos + 2 * t * (1- t) * center + t * t * endPos;
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
			Vector3 r = new Vector3 (0,0,yr);
			if (t <= 0.5) {
				yr = 180f * (0.5f - t);
			} else {
				yr = 180f * (0.5f - t);
			}
			if (flip == true) {
				r.z = -yr;
			} else {
				r.z = yr;
			}
			transform.eulerAngles = r;
		}


		public void Normal()
		{
			timeDiff = normalDiff;
		}




		public void CheckMarkFlag()
		{
			if (t >= markMax && markStatus == 1) {
				//do some
				markStatus=2;
				return;
			}

			if (t >= markMin &&markStatus == 0) {
				markStatus = 1;
				return;
			}
		}


		public bool CanClick{
			get{ 
				if (markStatus == 1) {
					return true;
				}
				return false;
				
			}
		}
	}
}

