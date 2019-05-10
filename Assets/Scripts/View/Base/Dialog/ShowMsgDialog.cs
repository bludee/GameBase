using System;
using FairyGUI;
namespace Game
{
	public delegate void MsgConfirm(object obj);
	public class ShowMsgDialog:GComponent
	{
		GTextField msgText;
		GButton yesBtn;
		GButton noBtn;
		MsgConfirm yesCb;
		Action noCb;

		GTextField titleText;
		GButton closeBtn;

//		GGraph maskGraph;


		private object confirmObj;
		public override void ConstructFromXML (FairyGUI.Utils.XML xml)
		{
			base.ConstructFromXML (xml);
			msgText = this.GetChild ("msgText").asTextField;
			yesBtn = this.GetChild ("yes").asButton;
			noBtn = this.GetChild ("no").asButton;
			closeBtn = this.GetChild ("backBtn").asButton;
			closeBtn.onClick.Add (onClickNo);
			titleText = this.GetChild ("title").asTextField;

			yesBtn.onClick.Add (onClickYes);
			noBtn.onClick.Add (onClickNo);

		}

		private void onClickYes()
		{
			if (yesCb != null) {
				yesCb (confirmObj);
			}
			DialogHide ();
		}

		private void onClickNo()
		{
			if (noCb != null) {
				noCb ();
			}
			DialogHide ();
		}

		public void SetData(string msg,MsgConfirm yescb,object conobj,Action nocb)
		{
			msgText.text = msg;
			confirmObj = conobj;
			yesCb = yescb;
			noCb = nocb;
			this.Center ();
			GRoot.inst.AddChild (this);
			UIUtil.ShowDialogAnim (this);
		}

		public void DialogHide()
		{
			UIUtil.HideDialogAnim (this,hideAnimOver);
		}

		private void hideAnimOver()
		{
			GRoot.inst.RemoveChild (this);
			this.Dispose ();
		}


		public static void CreateMsgDialog(string msg,MsgConfirm ycb,object conobj,Action ncb)
		{
			(UIPackage.CreateObject ("Base", "ShowMsgDialog").asCom as ShowMsgDialog).SetData (msg,ycb,conobj,ncb);
		}


		/// <summary>
		/// 提示信息框,没有回调操作
		/// </summary>
		/// <param name="msg">Message.</param>
		public static void CreateTipDialog(string msg)
		{
			CreateMsgDialog (msg,null,null,null);
		}

		/// <summary>
		/// 金币不足通用提示框
		/// </summary>
		public static void CreateGoldMsgDialog()
		{
			string msg = AppMain.Inst.ConfigMgr.LangConfig.Get (1).word;
			CreateMsgDialog (msg,null,null,null);
		}
	}
}

