using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using System.IO;
namespace Game{
	public class ResourcesManager:MonoBehaviour
	{
		private Dictionary<string,int> uiPkgMap;

		public UnityEngine.Object Load(string path,int loadType=0)
		{
			return Resources.Load<UnityEngine.Object> (path);
		}

		public Sprite LoadSprite(string path)
		{
			return Resources.Load<Sprite> (path);		
		}

		/// <summary>
		/// 加载UI资源
		/// </summary>
		/// <param name="path">Path.</param>
		public void AddUIPackage(string path)
		{
			if (uiPkgMap == null) {
				uiPkgMap = new Dictionary<string, int> ();
			}
			if (uiPkgMap.ContainsKey (path) == false) {
				uiPkgMap.Add (path, 1);
				FairyGUI.UIPackage.AddPackage ("GameUI/"+path);
			} else {
				uiPkgMap [path] = uiPkgMap [path] + 1;
			}

		}


		/// <summary>
		/// 卸载UI资源
		/// </summary>
		/// <param name="path">Path.</param>
		public void RemoveUIPackage(string path)
		{
			if (uiPkgMap != null && uiPkgMap.ContainsKey (path)) {
				uiPkgMap [path] = uiPkgMap [path] - 1;
				if (uiPkgMap [path] <= 0) {
					uiPkgMap.Remove (path);
					FairyGUI.UIPackage.RemovePackage (path);					
				}
			}
		}



		public byte[] LoadLuaFile(string path)
		{
			string myStr="";
			using(FileStream fsRead=new FileStream(@"../GuajiGame/Assets/Resources/LuaScripts/"+path+".lua",FileMode.Open))
			{
				int fslen=(int)fsRead.Length;
				byte[] result=new byte[fslen];
				int r=fsRead.Read(result,0,fslen);
				myStr=System.Text.Encoding.UTF8.GetString(result);
			}
			return System.Text.Encoding.UTF8.GetBytes(myStr);
		}


	}
}
