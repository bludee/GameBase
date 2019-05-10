using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game{
	public class AppConst{

		/// <summary>
		/// 调试模式 用于内部测试
		/// </summary>
		public const bool DebugMode=false;


		/// <summary>
		/// 是否开启热更新
		/// </summary>
		public const bool UpdateModel=false;

		public const int TimerInterval = 1;

		/// <summary>
		///  游戏帧频
		/// </summary>
		public const int GameFrameRate=60;



		public const string AppName="Guaji";//应用名称

		public const string AssetDir = "StreamingAssets";//素材目录

		public const string AppPrefix=AppName+"_"; //应用程序前缀  设置本地设置key用

		public const string ResourcesServerUrl="http://localhost:80";//测试资源更新地址

		public static string UserId = string.Empty;//用户Id

		public static int SocketPort=0;//socket 端口

		public static string SocketAddress = string.Empty;//socket ip


		public static int SceneWidth=1920;
		public static int SceneHeight = 1080;

		/// <summary>
		/// json文件路径
		/// </summary>
		public const string ConfigPath = "Config/";


		/// <summary>
		/// 存档路径
		/// </summary>
		/// <value>The player save path.</value>
		public static string SavePath{
			get{ 
				return Util.AppDataPath () + "/Save";
			}
		}

		/// <summary>
		/// User存档文件名
		/// </summary>
		/// <value>The name of the player save.</value>
		public static string UserSaveName="user.s";

		public static string ShareSave="screenshot.png";

		/// <summary>
		/// 成就存档名称
		/// </summary>
		/// <value>The name of the player save.</value>
		public static string AchieveSaveName="achieve.s";

	}
}
