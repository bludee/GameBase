using System;
using FairyGUI;
namespace Game
{
	public class ShowRewardDialog:GComponent
	{
		Controller iconCon;
		GRichTextField tipText;
		Transition trans;
		GTextField moneyText;
		public override void ConstructFromXML (FairyGUI.Utils.XML xml)
		{
			base.ConstructFromXML (xml);
			iconCon = this.GetController ("c1");
			tipText = this.GetChild ("tipText").asRichTextField;
			trans = this.GetTransition ("t0");
			moneyText=this.GetChild("n11").asTextField;
		}

		/// <summary>
		/// 只有文本
		/// </summary>
		/// <param name="msg">Message.</param>
		public void SetText(string msg)
		{
			tipText.text = msg;
		}

		public void Play(string msg)
		{
			iconCon.selectedIndex = 0;
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

		public void PlayMoney(int num)
		{
			iconCon.selectedIndex = 1;
			moneyText.text = num.ToString ();
			GRoot.inst.AddChild (this);
			this.Center ();
			trans.Play (overPlay);
		}


		public static void CreateRewardDialog(string msg)
		{
			(UIPackage.CreateObject ("Base", "ShowRewardDialog").asCom as ShowRewardDialog).Play (msg);
		}

		public static void CreateRewardDialog(string msg,int money)
		{
//			string imgurl ="<img src='"+ UIPackage.GetItemURL ("Base","Gold")+"'/>";//金币的url
//			<img src=''/>>
			//替换就行
//			msg=msg.Replace("$",imgurl+"x"+money.ToString());
			(UIPackage.CreateObject ("Base", "ShowRewardDialog").asCom as ShowRewardDialog).PlayMoney (money);
		}
	}
}

