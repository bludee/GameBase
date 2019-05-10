using System;
using UnityEngine;
namespace Game
{
	public class SinCurve:MonoBehaviour
	{
		public float cycle=5f;//重复几个周期
		public float scaleX=0.02f;//标准x轴位移缩放系数
		public float scaleY=30f;//标准y轴位移缩放系数
		private float curx=0f;//当前x值

		public float xDiff=0.1f;//递进值

		public float scydiff=10f;//波动方向的递进值

		private bool updateFlag = false;


		public int waveRot = 0;//0  x方向波动  1 Y方向波动

		float waveNum=5f; //波动的初始值


		int flip=50;


		Action callback;

		void Start()
		{
//			SetData ();
		}

		public void SetCallback(Action cb)
		{
			callback = cb;
		}

		public void SetData(float cy,float sx,float sy,float tx,int f)
		{
			cycle = cy * 2;
			scaleX = sx;
			scaleY = sy;
			xDiff = tx;
			flip = f;
			curx = 0f;
			if (waveRot == 0) {
				waveNum = this.transform.position.x;
			} else {
				waveNum = this.transform.position.y;
			}
			updateFlag = true;
		}

		public void SetData()
		{
			cycle*=3;//3为圆周率  为了计算效率取3
			curx = 0f;
			if (waveRot == 0) {
				waveNum = this.transform.position.x;
			} else {
				waveNum = this.transform.position.y;
			}

			updateFlag = true;
		}


		void Update()
		{
			if (updateFlag == true) {
				Result ();
			}
		}

		void Result()
		{
			if (curx > cycle) {
				//运动结束
				updateFlag=false;
				if (callback != null) {
					callback ();
				}
				Destroy(this.gameObject);
				return;
			}

			curx += xDiff;
			scaleY += scydiff;

			//float x = curx * scaleX;
			float x = 8f;
			float y = x * (float)Math.Sin (curx) * scaleY * flip;


			if (waveRot == 0) {
				this.transform.position = new Vector3 (waveNum + y, this.transform.position.y + x, this.transform.position.z);
			} else {
				this.transform.position = new Vector3 (this.transform.position.x + x,waveNum + y, this.transform.position.z);
			}


		}


	}
}

