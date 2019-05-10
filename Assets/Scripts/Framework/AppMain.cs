using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Game;

namespace Game
{
	public class AppMain{
		private static AppMain _instance;

		static GameObject m_GameManager;
		GameObject AppGameManager{
			get{ 
				if (m_GameManager == null) {
					m_GameManager = GameObject.Find ("GameManager");
				}
				return m_GameManager;
			}
		}


		public static AppMain Inst
		{
			get{ 
				if (_instance == null) {
					_instance = new AppMain ();
				}
				return _instance;
			}
		}


		static Dictionary<string,object> m_Managers = new Dictionary<string, object> ();

		/// <summary>
		/// 添加管理器
		/// </summary>
		/// <returns>The manager.</returns>
		/// <param name="typeName">Type name.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public T AddManager<T>(string typeName) where T:Component
		{
			object result = null;
			m_Managers.TryGetValue (typeName, out result);
			if (result != null) {
				return (T)result;
			}
			Component c = AppGameManager.AddComponent<T> ();
			m_Managers.Add (typeName, c);
			return default(T);
		}


		/// <summary>
		/// 获取管理器
		/// </summary>
		/// <returns>The manager.</returns>
		/// <param name="typeName">Type name.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public T GetManager<T>(string typeName) where T:class
		{
			if (!m_Managers.ContainsKey (typeName)) {
				return default(T);
			}
			object manager = null;
			m_Managers.TryGetValue (typeName, out manager);
			return (T)manager;
		}


		/// <summary>
		/// 移除一个管理器
		/// </summary>
		/// <param name="typeName">Type name.</param>
		public void RemoveManager(string typeName)
		{
			if (!m_Managers.ContainsKey (typeName)) {
				return;
			}
			object manager = null;
			m_Managers.TryGetValue (typeName, out manager);
			Type type = manager.GetType ();
			if (type.IsSubclassOf (typeof(MonoBehaviour))) {
				GameObject.Destroy ((Component)manager);
			}
			m_Managers.Remove (typeName);
		}


		public void StartUp ()
		{
			Inst.AddManager<SaveManager> (ManagerName.Save);
			Inst.AddManager<ObjectPoolManager> (ManagerName.Pool);
			//		Instance.AddManager<NetworkManager> (ManagerName.NetWork);
			Inst.AddManager<ThreadManager> (ManagerName.Thread);
			Inst.AddManager<SoundManager> (ManagerName.Sound);
			Inst.AddManager<TimerManager> (ManagerName.Timer);
			Inst.AddManager<ResourcesManager> (ManagerName.Resource);
			Inst.AddManager<ModelManager> (ManagerName.Model);
			Inst.AddManager<ViewManager> (ManagerName.View);
			Inst.AddManager<ConfigManager> (ManagerName.Config);
			Inst.AddManager<GameManager> (ManagerName.Game);
			Inst.AddManager<NativeShareScript> (ManagerName.Share);
		}


		public NetworkManager NetworkMgr{
			get{ 
				return Inst.GetManager<NetworkManager> (ManagerName.NetWork);
			}
		}

		public ThreadManager ThreadMgr{
			get{ 
				return Inst.GetManager<ThreadManager> (ManagerName.Thread);
			}
		}

		public SoundManager SoundMgr{
			get{ 
				return Inst.GetManager<SoundManager> (ManagerName.Sound);
			}
		}

		public TimerManager TimerMgr{
			get{ 
				return Inst.GetManager<TimerManager> (ManagerName.Timer);
			}
		}

		public ResourcesManager ResMgr{
			get{ 
				return Inst.GetManager<ResourcesManager> (ManagerName.Resource);
			}
		}

		public ModelManager ModelMgr{
			get{ 
				return Inst.GetManager<ModelManager> (ManagerName.Model);
			}
		}

		public ViewManager ViewMgr{
			get{ 
				return Inst.GetManager<ViewManager> (ManagerName.View);
			}
		}

		public GameManager GameMgr{
			get{ 
				return Inst.GetManager<GameManager> (ManagerName.Game);
			}
		}

		public SaveManager SaveMgr{
			get{ 
				return Inst.GetManager<SaveManager> (ManagerName.Save);
			}
		}

		public ConfigManager ConfigMgr{
			get{ 
				return Inst.GetManager<ConfigManager> (ManagerName.Config);
			}
		}

		public ObjectPoolManager PoolMgr{
			get{ 
				return Inst.GetManager<ObjectPoolManager> (ManagerName.Pool);
			}
		}

		public NativeShareScript ShareTool{
			get{ 
				return Inst.GetManager<NativeShareScript> (ManagerName.Share);
			}
		}



	}

}