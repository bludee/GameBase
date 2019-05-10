using System;
using DG.Tweening;
using UnityEngine;
namespace Game
{
	public class TweenUtil
	{


		public static void TweenTwoMoneyPos(GameObject go)
		{
			
		}


		public static void Move(GameObject go,Vector3 targetPos,float time,TweenCallback callback)
		{
			Tweener tw = go.transform.DOMove (targetPos,time);
			tw.SetEase (Ease.Linear);
			tw.OnComplete (callback);
		}


		public static void TweenPath(GameObject go,Vector3[] paths,float time,TweenCallback cb)
		{
			Tweener tw2 = go.transform.DOLocalPath (paths,time,PathType.CatmullRom,PathMode.TopDown2D,1);
			tw2.SetEase (Ease.OutSine);
			tw2.OnComplete (cb);
		}

		public static void TweenJump(GameObject go,Vector3 end,float power,int num,float time,Vector3 ro,TweenCallback cb)
		{
			Sequence tw = go.transform.DOLocalJump (end,800,1,time);
			tw.OnComplete (cb);
			go.transform.DOBlendableLocalRotateBy (ro,time);
		}

		public static void TweenBaitJump(GameObject go,Vector3 end,float power,int num,float time,TweenCallback cb)
		{
			Sequence tw = go.transform.DOLocalJump (end,power,1,time);
			tw.OnComplete (cb);
		}


		/// <summary>
		/// 根据起点 终点 t值时位置 计算中心点
		/// </summary>
		/// <returns>The beizer parameter.</returns>
		/// <param name="svec">Svec.</param>
		/// <param name="tvec">Tvec.</param>
		/// <param name="evec">Evec.</param>
		/// <param name="t">T.</param>
		public static Vector3 CalcBeizerParam(Vector3 svec,Vector3 tvec,Vector3 evec,float t)
		{
			Vector3 cv = Vector3.zero;
			cv=(tvec - ((1 - t) * (1 - t) * svec + t * t * evec) )/ (2 * t * (1 - t));
			return cv;
		}


		/// <summary>
		/// 过定点,计算中心点 贝塞尔曲线
		/// </summary>
		/// <returns>The center.</returns>
		/// <param name="sv">Sv.</param>
		/// <param name="tv">Tv.</param>
		/// <param name="ev">Ev.</param>
		/// <param name="t">T.</param>
		public static Vector3 CalcCenter(Vector3 sv,Vector3 tv,Vector3 ev,float t)
		{
			return 8 / 3 * tv - sv / 6 - 3 / 2 * ev;
		}

	}
}

