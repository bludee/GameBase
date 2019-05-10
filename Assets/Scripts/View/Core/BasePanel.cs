using System;
using FairyGUI;
using UnityEngine;
namespace Game
{
	/// <summary>
	/// 所有UI的基类 
	/// </summary>
	public class BasePanel:Window
	{
		private string panelName;

		protected string pkgName;
		protected string objName;

		/// <summary>
		/// 是否已经创建UI并添加到Stage上
		/// </summary>
		private bool isInited=false;

		public bool IsInited {
			get {
				return isInited;
			}
		}

		public BasePanel ()
		{
		}

		/// <summary>
		/// Gets or sets the name of the panel.
		/// </summary>
		/// <value>The name of the panel.</value>
		public string PanelName {
			get {
				return panelName;
			}
			set{ 
				panelName = value;
			}
		}

		/// <summary>
		/// 初始化时调用
		/// </summary>
		protected override void OnInit ()
		{
			isInited = true;
			this.contentPane.MakeFullScreen ();
		}
		/// <summary>
		/// 隐藏时调用
		/// </summary>
		protected override void OnHide ()
		{
			base.OnHide ();
		}

		/// <summary>
		/// 显示前调用
		/// </summary>
		protected override void OnShown ()
		{
			if (isInited == false) {
				CreateUI ();
				OnInit ();
			}
			base.OnShown ();
		}
		/// <summary>
		/// Raises the update event.
		/// </summary>
		protected override void OnUpdate ()
		{
			base.OnUpdate ();
		}

		/// <summary>
		/// 释放资源
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="game.ui.core.BasePanel"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="game.ui.core.BasePanel"/> in an unusable state. After calling
		/// <see cref="Dispose"/>, you must release all references to the <see cref="game.ui.core.BasePanel"/> so the garbage
		/// collector can reclaim the memory that the <see cref="game.ui.core.BasePanel"/> was occupying.</remarks>
		public override void Dispose ()
		{
			isInited = false;
			base.Dispose ();
			AppMain.Inst.ViewMgr.RemoveView (this.panelName);
		}

		/// <summary>
		/// 关闭并释放资源
		/// </summary>
		public void Distroy()
		{
			Hide ();
			Dispose ();
			AppMain.Inst.ResMgr.RemoveUIPackage (this.pkgName);
		}

		protected override void DoShowAnimation ()
		{
			base.DoShowAnimation ();
		}

		protected override void DoHideAnimation ()
		{
			base.DoHideAnimation ();
		}
		
		protected virtual void setItemExtension()
		{
			
		}

		/// <summary>
		/// 创建UI并添加到舞台
		/// </summary>
		public void CreateUI()
		{
			if (String.IsNullOrEmpty (pkgName) || String.IsNullOrEmpty (objName)) {
				Debug.LogError (panelName + " pkgName or objName is null");
				return;
			}
			AppMain.Inst.ResMgr.AddUIPackage (pkgName);
			this.setItemExtension();
			this.contentPane = UIPackage.CreateObject (pkgName, objName).asCom;
//			this.contentPane.MakeFullScreen ();
			this.Init ();
//			this.Center (true);
		}

	}
}

