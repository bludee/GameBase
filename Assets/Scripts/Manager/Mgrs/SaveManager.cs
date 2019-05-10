using System;
using UnityEngine;
namespace Game
{
	public class SaveManager:MonoBehaviour
	{
		private ISaveProvider saveProvider;
		void Awake()
		{
			saveProvider = new UnitySaveProvider ();
		}

		public void SetString(string key,string value)
		{
			saveProvider.SetString (key,value);
		}

		public void SetInt(string key,int value)
		{
			saveProvider.SetInt (key,value);
		}

		public void SetFloat(string key,float value)
		{
			saveProvider.SetFloat (key,value);
		}

		public string GetString(string key)
		{
			return saveProvider.GetString (key);
		}

		public int GetInt(string key)
		{
			return saveProvider.GetInt (key);
		}

		public float GetFloat(string key)
		{
			return saveProvider.GetFloat (key);
		}

		public void DeleteAll()
		{
			saveProvider.DeleteAll ();
		}

		public void DeleAllByKey(string key)
		{
			saveProvider.DeleteByKey (key);
		}


		public void SaveUser()
		{
			if (GlobalData.User == null) {
				return;
			}
			SaveData (GlobalData.User.SaveByte(),AppConst.UserSaveName);
		}
		public byte[] LoadUser()
		{
			return LoadData (AppConst.UserSaveName);
		}

		public void SaveAchieve()
		{
//			SaveData (AchieveMgr.Inst.achieveSave.SaveByte(),AppConst.AchieveSaveName);
		}

		public byte[] LoadAchieve()
		{
			return LoadData (AppConst.AchieveSaveName);
		}



		public void SaveData(byte[] data,string saveName,bool compress=true)
		{
			if (compress) {
				data = Util.CompressBytes (data);
			}
			//写到文件
			FileUtils.CreateOrUpdateFile(AppConst.SavePath,saveName,data,data.Length);
		}
		public byte[] LoadData(string name)
		{
			byte[] result=FileUtils.LoadFile2Bytes (AppConst.SavePath + "/" + name);
			result = Util.DecompressBytes (result);
			return result;
		}




		public void SaveSoundBg(float bg)
		{
			saveProvider.SetFloat ("sound_bgVol",bg);
		}

		public void SaveSoundEffect(float effect)
		{
			saveProvider.SetFloat ("sound_effectVol",effect);
		}

		public float LoadSoundBg()
		{
			return saveProvider.GetFloat ("sound_bgVol");
		}

		public float LoadSoundEffect()
		{
			return saveProvider.GetFloat ("sound_effectVol");
		}
	}
}

