using System;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

namespace Game
{
	public class ConfigMap<T> where T:ConfigBaseTemp
	{
		private string _name;
		private T[] list;
		private Dictionary<int,T> _map;
		public ConfigMap (string path,bool build=false)
		{
			_name = path;
			if(build)
			{
				buildConfig (AppConst.ConfigPath+path);
			}
		}

		private void buildConfig(string path)
		{
//			Debug.Log ("build json: "+_name);
			string str = (AppMain.Inst.ResMgr.Load(path) as UnityEngine.TextAsset).text;
			_map = new Dictionary<int, T> ();
			list = JsonMapper.ToObject<T[]> (str);
			foreach (T t in list) {
				_map.Add (t.id, t);
			}
		}

		public T Get(int key)
		{
			checkBuilded ();
			if(_map.ContainsKey(key)==true)
			{
				return _map[key];
			}
			Debug.LogError(_name+" key not found "+key);
			return null;
		}

		public int Count{
			get{
				checkBuilded ();
				return _map.Count;
			}
		}

		public Dictionary<int,T>.ValueCollection Values()
		{
			checkBuilded ();
			return _map.Values;
		}

		public Dictionary<int,T>.KeyCollection Keys()
		{
			checkBuilded ();
			return _map.Keys;
		}

		public bool ContainsKey(int id)
		{
			checkBuilded ();
			if (_map.ContainsKey (id)) {
				return true;
			}
			return false;
		}

		private void checkBuilded()
		{
			if (_map == null) {
				buildConfig (AppConst.ConfigPath+_name);
			}
		}


	}
}

