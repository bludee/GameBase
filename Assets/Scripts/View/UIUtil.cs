using System;
using FairyGUI;
using DG.Tweening;
namespace Game
{
	public class UIUtil
	{
		public UIUtil ()
		{
		}

		public static void ShowDialogAnim(GComponent view)
		{
			float time = 0.25f;
			view.alpha = 0f;
			Tweener tw = DOTween.To(() => 0f,
				val =>
				{
					view.alpha = val;
				}, 1f,time);
			float y = view.y;
			Tweener tw2 = DOTween.To(() => y-120f,
				val =>
				{
					view.y = val;
				}, y,time);
			tw2.SetEase (Ease.OutElastic);
			tw.SetUpdate (true);
			tw2.SetUpdate (true);
		}

		public static void HideDialogAnim(GComponent view,TweenCallback cb=null)
		{
			Tweener tw = DOTween.To(() => 1f,
				val =>
				{
					view.alpha = val;
				}, 0f,0.25f);
			if (cb != null) {
				tw.OnComplete (cb);
			}
		}
	}
}

