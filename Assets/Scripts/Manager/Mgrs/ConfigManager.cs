using System;
using UnityEngine;
namespace Game
{
	public class ConfigManager:MonoBehaviour
	{
		public ConfigMap<LangTemp> LangConfig;



		void Awake()
		{
			Init ();
		}

		void Init()
		{
			InitConfigs ();
		}
		public void InitConfigs()
		{
			LangConfig = new ConfigMap<LangTemp> ("CN");
		}


	}
}

