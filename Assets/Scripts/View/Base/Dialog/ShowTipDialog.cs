using System;
using FairyGUI;
namespace Game
{
	public class ShowTipDialog:GComponent
	{
		Transition trans;
		GTextField tipText;
		public override void ConstructFromXML (FairyGUI.Utils.XML xml)
		{
			base.ConstructFromXML (xml);
			trans = this.GetTransition ("t0");
			tipText = this.GetChild ("tipText").asTextField;
		}

		public void SetText(string msg)
		{
			tipText.text = msg;
		}

		public void Play(string msg)
		{
			tipText.text = msg;
			GRoot.inst.AddChild (this);
			this.Center ();
			trans.Play (overPlay);
		}

		public void overPlay()
		{
			GRoot.inst.RemoveChild (this);
			this.Dispose ();
		}


		public static void CreateTipDialog(string msg)
		{
			(UIPackage.CreateObject ("Base", "ShowTipDialog").asCom as ShowTipDialog).Play (msg);
		}
	}
}

