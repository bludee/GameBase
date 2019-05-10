using System;
namespace Game
{
	public interface ISaveProvider
	{
		void SetString(string key,string value);
		void SetInt(string key,int value);
		void SetFloat(string key,float value);

		string GetString(string key);
		int GetInt(string key);
		float GetFloat(string key);

		void DeleteAll();
		void DeleteByKey(string key);
	}
}

