using System;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
	[Serializable]
	public class PlayerInfo
	{
		private string playerName;



		private int money;//当前钱





		public PlayerInfo ()
		{
			init ();
		}

		private void init()
		{
		}

		public void AddMoney(int num)
		{
			Money+=num;
		}
		public int Money{
			get{ 
				return money;
			}
			set
			{ 
				money = value;
				GEventCenter<string>.Inst.DispatchEvent (EventNames.UpdateMoney, null);
			}
		}

		public string PlayerName{
			get{ 
				return playerName;
			}
			set{ 
				playerName = value;
			}
		}

		public PlayerInfo CreateNewPlayer()
		{
			money = 100000;
			return this;
		}




		public void SaveJson()
		{
			string save=JsonUtils.Encode (this);
			AppMain.Inst.SaveMgr.SetString ("save",save);
		}

		public byte[] SaveByte()
		{
			byte[] save = Util.ObjectToBytes (this);
			return save;
		}
	}
}

