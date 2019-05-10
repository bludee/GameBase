using System;
using FairyGUI;
using UnityEngine;
namespace Game
{
	public class StartPanel:BasePanel
	{
		public StartPanel ()
		{
			//用来在ViewMgr中获取和检测是否已经创建的Key,添加新UI时按格式添加即可
			this.PanelName = ViewName.StartPanel;
			//fgui包名
			this.pkgName = "Start";
			//fgui对象名
			this.objName = "StartPanel";
			//加载并创建UI
			this.CreateUI ();
		}

		/// <summary>
		/// 初始化方法,只有在被创建时调用,一般在这里获取item,添加事件等
		/// </summary>
		protected override void OnInit ()
		{
			base.OnInit ();
			this.onClick.Add (startGame);
		}


		/// <summary>
		/// 每次显示时调用
		/// </summary>
		protected override void OnShown ()
		{
			base.OnShown ();
		}


		/// <summary>
		/// 关闭时调用
		/// </summary>
		protected override void OnHide ()
		{
			base.OnHide ();
		}

		/// <summary>
		/// 关闭并释放资源
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="Game.StartPanel"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="Game.StartPanel"/> in an unusable state. After calling
		/// <see cref="Dispose"/>, you must release all references to the <see cref="Game.StartPanel"/> so the garbage
		/// collector can reclaim the memory that the <see cref="Game.StartPanel"/> was occupying.</remarks>
		public override void Dispose ()
		{
			base.Dispose ();
		}

		/// <summary>
		/// fgui绑定
		/// </summary>
		protected override void setItemExtension ()
		{
			base.setItemExtension ();
//			UIObjectFactory.SetPackageItemExtension (UIPackage.GetItemURL("Base","ShowTipDialog"),typeof(ShowTipDialog));
		}


		private void startGame()
		{
			Debug.Log ("to do");
//			Dispose ();
		}
	}
}

