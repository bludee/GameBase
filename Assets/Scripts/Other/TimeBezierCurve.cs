using System;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

namespace Game
{
	/// <summary>
	/// 贝塞尔曲线运动,优化变量  调整时间设置,目标点设置,运动完成callback 旋转设置
	/// </summary>


	public class TimeBezierCurve:MonoBehaviour
	{
		public Vector3 start;
		public Vector3 end;
		public Vector3 center;
		public float t = 0;

		Action callBack=null;

		bool roFlag=true;
		public bool flag=false;
		public bool flip=false;
		public float startTime=0f;
		public float continueTime=0f;

		public float rotationS = 0f;
		public float rotationE = 0f;

		/// <summary>
		/// 暂停时已经持续的时间
		/// </summary>
		public bool SelfUpdate=true;



		void Start()
		{
		}

		public void SetRotationRange(float s,float e)
		{
			rotationS = s;
			rotationE = e;
		}
		public void SetCurveParams(Vector3 s,Vector3 c,Vector3 e,float stime,float td,Action cb,bool f=false,bool ro=true)
		{
			t = 0;
			start = s;
			center = c;
			end = e;
			continueTime = td;
			startTime = stime;
			callBack = cb;
			flip=f;
			roFlag = ro;
			flag = true;
			this.transform.position = start;
		}


		float diff=0f;
		public void UpdateTime()
		{
			diff = Time.time - startTime;
			if (diff == 0f) {
				return;
			}
			t=diff/continueTime;
//			t = Mathf.Round( t* 100)/100f;
			Result (start, end, t);
			if (roFlag == true) {
				Rotation ();
			}
		}

		void Update()
		{
			if (flag == true&&SelfUpdate==true) {
				UpdateTime ();
			}
		}

		public void Result(Vector3 startPos, Vector3 endPos, float t)
		{
			if (t >= 1)
			{
				t = 1;
				if (callBack != null) {
					callBack ();
					callBack = null;
				}
				flag = false;
				return;
			}
			Vector3 target=(1 -t) * (1 - t) * startPos + 2 * t * (1- t) * center + t * t * endPos;
			this.transform.position = Vector3.Lerp (this.transform.position,target,1f);
		}




		public void Rotation()
		{
			float yr = 0f;
			Vector3 r = new Vector3 (0,0,yr);
		
			yr = rotationS + (rotationE - rotationS) * t / 1;
			if (flip == true) {
				r.z = -yr;
			} else {
				r.z = yr;
			}
			transform.eulerAngles = r;
		}

		public void Stop()
		{
			flag = false;
			t = 0;
		}
	}
}

