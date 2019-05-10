using System;
using System.Collections.Generic;
namespace Game
{
	[Serializable]
	public class UserInfo
	{

		private string uuid="";//用户id
		private string channel="debug";//渠道
		private int archive=0;//0 不存档   1存档

		private PlayerInfo player;

		public bool isNew=true;

		public UserInfo ()
		{
		}


		public UserInfo CreateNewUser()
		{
			UserInfo info = new UserInfo ();
			info.uuid = "User"+Util.GetUniqueId ();
			info.player = new PlayerInfo ().CreateNewPlayer ();
			return info;
		}


		public PlayerInfo Player
		{
			get{ 
				return player;
			}
		}

		public byte[] SaveByte()
		{
			byte[] save = Util.ObjectToBytes (this);
			return save;

		}
	}
}

