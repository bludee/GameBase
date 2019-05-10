using System;
using UnityEngine;
namespace Game
{
	public class UnitySaveProvider:ISaveProvider
	{
		public UnitySaveProvider ()
		{
		}


		public void SetString (string key, string value)
		{
			PlayerPrefs.SetString (key,value);
		}

		public void SetInt (string key, int value)
		{
			PlayerPrefs.SetInt (key,value);
		}

		public void SetFloat (string key, float value)
		{
			PlayerPrefs.SetFloat (key,value);
		}

		public string GetString (string key)
		{
			if (PlayerPrefs.HasKey (key) == false) {
				return string.Empty;
			}
			return PlayerPrefs.GetString (key);
		}

		public int GetInt (string key)
		{
			if (PlayerPrefs.HasKey (key) == false) {
				return -1;
			}
			return PlayerPrefs.GetInt (key);
		}

		public float GetFloat (string key)
		{
			if (PlayerPrefs.HasKey (key) == false) {
				return -1f;
			}
			return PlayerPrefs.GetFloat (key);
		}

		public void DeleteAll()
		{
			PlayerPrefs.DeleteAll ();
		}

		public void DeleteByKey(string key)
		{
			PlayerPrefs.DeleteKey (key);
		}
	}
}

