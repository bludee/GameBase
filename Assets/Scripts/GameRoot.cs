using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
namespace Game{


	/// <summary>
	/// 游戏的总入口  负责游戏流程的控制
	/// 
	/// 
	/// 
	/// 
	/// 1.初始化相关管理器
	/// 2.加载UI
	/// 	3.检查更新
	/// 	4.更新
	/// 	5.重置游戏
	/// 	6.进入游戏
	/// </summary>
	public class GameRoot : MonoBehaviour {


		// Use this for initialization
		void Awake () {
			AppMain.Inst.StartUp ();
			ThirdInit ();
			initGameConfig ();
			initUiConfig ();
		}
		void Start()
		{
			GameStart ();
		}

		private void initGameConfig()
		{
			Application.targetFrameRate = AppConst.GameFrameRate;
		}

		private void initUiConfig()
		{
			//绑定自定义Gloader扩展
			UIObjectFactory.SetLoaderExtension (typeof(GameLoader));
			//初始化dotween设置
			//设置自动销毁
			//DG.Tweening.DOTween. = true;

			#if UNITY_ANDROID
			UIConfig.defaultFont = "Droid Sans,Droid Sans Fallback,SimHei,LTHYSZK,Microsoft YaHei";
			#endif
			#if UNITY_IPHONE
			UIConfig.defaultFont = "Heiti SC,PingFang SC";
			#endif
			#if UNITY_EDITOR
			UIConfig.defaultFont = "Microsoft YaHei";
			#endif

//			GRoot.inst.SetContentScaleFactor ((int)GRoot.inst.width, (int)GRoot.inst.height, UIContentScaler.ScreenMatchMode.MatchWidthOrHeight);

//			UIConfig.buttonSound = new NAudioClip(AppMain.Inst.SoundMgr.GetClipById (39));
			//通用包加载和组件绑定
			BaseComConfig.Init ();
		}

		private void ThirdInit()
		{
//			TakingDataRoot.Inst.Init ();
		}


		private void GameStart()
		{
			GameConst.Init();
			GlobalData.LoaderUser ();
//			UserConfig.Load ();
			AppMain.Inst.ViewMgr.GetView<StartPanel> (ViewName.StartPanel).Show ();
		}


		/// <summary>
		/// 退出执行
		/// </summary>
		void OnApplicationQuit()
		{
//			AppMain.Inst.SaveMgr.SaveUser ();
//			Debug.Log ("onApplicationQuit "+Time.time);
		}

		/// <summary>
		/// 失去或者获得焦点时
		/// </summary>
		void OnApplicationFocus(bool isFocus)
		{
//			AppMain.Inst.SaveMgr.SaveUser ();
		}


		/// <summary>
		/// 程序暂停时  false 是回到游戏 true是切出游戏
		/// </summary>
		void OnApplicationPause(bool isPause)
		{
			Debug.Log (isPause);
		}
	}
}