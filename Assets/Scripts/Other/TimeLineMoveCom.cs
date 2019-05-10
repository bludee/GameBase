
using System;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

namespace Game
{
	/// <summary>
	/// 贝塞尔曲线运动,优化变量  调整时间设置,目标点设置,运动完成callback 旋转设置
	/// </summary>


	public class TimeLineMoveCom:MonoBehaviour
	{
		public Vector3 start;
		public Vector3 end;
		public Vector3 center;
		public float t = 0;

		Action callBack=null;

		public bool flag=false;


		public bool flip=false;




		private int markStatus=0; // |     0  | 1 |   2 |

		public float startTime=0f;
		public float continueTime=0f;

		/// <summary>
		/// 暂停时已经持续的时间
		/// </summary>
		private float pauseTime=0f;
		public bool SelfUpdate=true;


		private int changeType = 0;



		public void SetCurveParams(Vector3 s,Vector3 c,Vector3 e,float stime,float td,Action cb,bool f=false)
		{
			t = 0;
			start = s;
			center = c;
			end = e;
			continueTime = td;
			startTime = stime;
			callBack = cb;
			flip=f;
			flag = true;
			markStatus=0; 
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





		public bool CanClick{
			get{ 
				if (markStatus == 1) {
					return true;
				}
				return false;

			}
		}


		public Vector3 GetCheckTPos(float sett)
		{
			Vector3 result= (1 -sett) * (1 - sett) * start + 2 * sett * (1- sett) * center + sett * sett * end;
			return result;
		}


		public void Stop()
		{
			flag = false;
			t = 0;
			markStatus = 0;
		}

		public void Pause()
		{
			flag = false;
			pauseTime = Time.time - startTime;
		}

		public void Resume()
		{
			startTime = Time.time - pauseTime;
			flag = true;
		}

	}
}

