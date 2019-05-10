using System;
using FairyGUI;
using UnityEngine;
namespace Game
{
	public class StartPanel:BasePanel
	{
		public StartPanel ()
		{
			this.PanelName = ViewName.StartPanel;
			this.pkgName = "Start";
			this.objName = "StartPanel";
			this.CreateUI ();
		}

		protected override void OnInit ()
		{
			base.OnInit ();
			this.onClick.Add (startGame);
		}


		private void startGame()
		{
			Debug.Log ("to do");
//			Dispose ();
		}
	}
}

