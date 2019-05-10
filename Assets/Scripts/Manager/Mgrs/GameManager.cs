using System;
using FairyGUI;
using XLua;
using UnityEngine;
namespace Game
{


	/// <summary>
	/// 
	/// </summary>
	public class GameManager:MonoBehaviour
	{
		void Awake()
		{
			Init ();
		}

		void Init()
		{
		}


		/// <summary>
		/// xlua 相关设置
		/// </summary>
//		private static LuaEnv luaGameEnv=null;
//		public static LuaEnv LuaGameEnv{
//			get{ 
//				if (luaGameEnv == null) {
//					luaGameEnv = new LuaEnv ();
//					luaGameEnv.AddLoader((ref string filename)=>{
//						TextAsset text=ResMgr.Inst.Load("LuaScripts/"+filename+".lua") as TextAsset;
//						return text.bytes;
//					}
//					);
//				}
//				return luaGameEnv;
//			}
//		}
	}
}

