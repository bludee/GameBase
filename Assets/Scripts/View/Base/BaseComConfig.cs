using System;
using FairyGUI;
namespace Game
{
	public class BaseComConfig
	{
		public BaseComConfig ()
		{
		}

		public static void Init()
		{
			//加载通用包 还有绑定通用组件等
			AppMain.Inst.ResMgr.AddUIPackage("Base");
			UIObjectFactory.SetPackageItemExtension (UIPackage.GetItemURL("Base","ShowMsgDialog"),typeof(ShowMsgDialog));
			UIObjectFactory.SetPackageItemExtension (UIPackage.GetItemURL("Base","ShowTipDialog"),typeof(ShowTipDialog));




		}


	}
}

