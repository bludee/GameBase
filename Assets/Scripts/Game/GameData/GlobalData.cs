using System;

namespace Game
{
	public class GlobalData
	{
		public static UserInfo User;
		public static PlayerInfo Player;
		public GlobalData ()
		{
		}



		public static void CreateUser()
		{
			User = new UserInfo ().CreateNewUser ();
			Player = User.Player;
			UserConfig.Create ();
		}



		public static void LoaderUser()
		{
			byte[] bytes=AppMain.Inst.SaveMgr.LoadUser ();
			if (bytes.Length == 0) {
				CreateUser ();
				return;
			}
			User= Util.BytesToObject (bytes) as UserInfo;
			User.isNew = false;
			Player = User.Player;
		}
	}
}

