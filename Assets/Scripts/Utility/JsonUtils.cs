using System;
using UnityEngine;

namespace Game
{
	public class JsonUtils
	{
		public JsonUtils ()
		{
		}

		public static T Decode<T>(string json)
		{
			return (T)JsonUtility.FromJson<T> (json);
		}

		public static string Encode(object obj)
		{
			return JsonUtility.ToJson (obj);
		}



	}
}

