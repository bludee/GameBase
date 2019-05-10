using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using FairyGUI;

namespace Game
{
	public class NativeShareScript : MonoBehaviour {
		//	public GameObject CanvasShareObj;

		private bool isProcessing = false;
		private bool isFocus = false;

		string weiboText="微博分享文本内容";
		string mmText="微信配有权分享文本内容";
		bool inited=false;

		private void init()
		{
//			weiboText = AppMain.Inst.ConfigMgr.CNConfig.Get (41).word;
//			mmText = AppMain.Inst.ConfigMgr.CNConfig.Get (43).word;
		}

		public void ShareBtnPress()
		{
			if (inited == false) {
				init ();
			}
			if (!isProcessing)
			{
				StartCoroutine(ShareByJar());
			}
		}



		public void ShareByCom(GComponent view)
		{
			if (inited == false) {
				init ();
			}
			if (!isProcessing)
			{
				StartCoroutine(ShareView(view));
			}
		}

		IEnumerator ShareView(GComponent view)
		{
			isProcessing = true;
			yield return new WaitForEndOfFrame();
			string filename = "screenshot.jpg";
			ScreenCapture.CaptureScreenshot(filename, 1);
			string destination = Path.Combine(Application.persistentDataPath, filename);
			Debug.Log ("unity path "+destination);
			yield return new WaitForSecondsRealtime(1f);

			if (!Application.isEditor)
			{
				AndroidJavaClass unityPlayer = new AndroidJavaClass("com.longma.hsy.ShareTool");
				string[] pkgs=new string[3];
				List<string> names=new List<string>();
				pkgs[0]="com.tencent.mm";
				names.Add("com.tencent.mm.ui.tools.ShareImgUI");
				names.Add("com.tencent.mm.ui.tools.ShareToTimeLineUI");

				pkgs[1]="com.tencent.mobileqq";
				names.Add("com.tencent.mobileqq.activity.JumpActivity");
				pkgs[2]="com.sina.weibo";
				names.Add("com.sina.weibo.composerinde.ComposerDispatchActivity");
				unityPlayer.CallStatic("ShareFun",filename,pkgs,names.ToArray(),"file://" + destination,weiboText,"选择分享应用");
//				(view as SharePanel).Dispose ();
				yield return new WaitForSecondsRealtime(1);
			}

			yield return new WaitUntil(() => isFocus);
			isProcessing = false;
		}

		IEnumerator ShareByJar()
		{
			isProcessing = true;
			yield return new WaitForEndOfFrame();
			ScreenCapture.CaptureScreenshot("screenshot.png", 2);
			string destination = Path.Combine(Application.persistentDataPath, "screenshot.png");//
			yield return new WaitForSecondsRealtime(0.3f);

			if (!Application.isEditor)
			{
				AndroidJavaClass unityPlayer = new AndroidJavaClass("com.longma.hsy.ShareTool");
				string[] pkgs=new string[3];
				List<string> names=new List<string>();
				pkgs[0]="com.tencent.mm";
				names.Add("com.tencent.mm.ui.tools.ShareImgUI");
				names.Add("com.tencent.mm.ui.tools.ShareToTimeLineUI");

				pkgs[1]="com.tencent.mobileqq";
				names.Add("com.tencent.mobileqq.activity.JumpActivity");
				pkgs[2]="com.sina.weibo";
				names.Add("com.sina.weibo.composerinde.ComposerDispatchActivity");
				unityPlayer.CallStatic("ShareFun",pkgs,names.ToArray(),"file://" + destination,weiboText,"选择分享应用");
				yield return new WaitForSecondsRealtime(1);
			}

			yield return new WaitUntil(() => isFocus);
			isProcessing = false;
		}

		IEnumerator ShareScreenshot()
		{
			isProcessing = true;
			yield return new WaitForEndOfFrame();
			ScreenCapture.CaptureScreenshot("screenshot.png", 2);
			string destination = Path.Combine(Application.persistentDataPath, "screenshot.png");//
			//先获取该图片 然后修改图片 在覆盖到本地   分享的时候使用uri
			Debug.Log("Unity path "+destination);
			yield return new WaitForSecondsRealtime(0.3f);

			if (!Application.isEditor)
			{
				AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
				AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
				intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));//设置行为


				//获取截图uri
				AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
				AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);


				//添加照片uri
				intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"),
					uriObject);

				//设置文字
				intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"),weiboText);

				//设置资源类型
				intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");


				AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
				AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser",
					intentObject, "选择渠道");
				currentActivity.Call("startActivity", chooser);

				yield return new WaitForSecondsRealtime(1);
			}

			yield return new WaitUntil(() => isFocus);
			//		CanvasShareObj.SetActive(false);
			isProcessing = false;
		}


		private void OnApplicationFocus(bool focus)
		{
			isFocus = focus;
		}
	}
}