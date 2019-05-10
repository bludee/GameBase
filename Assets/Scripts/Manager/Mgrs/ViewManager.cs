using System;
using FairyGUI;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class ViewManager:MonoBehaviour
	{
		/// <summary>
		/// 单例的面板
		/// </summary>
		private Dictionary<string,object> viewDic=new Dictionary<string, object>();
		/// <summary>
		/// 每次创建都返回新面板
		/// </summary>
		private Dictionary<string,object> dialogDic = new Dictionary<string, object> ();



		/// <summary>
		/// 创建一个View,如果已经初始化则直接返回
		/// </summary>
		/// <returns>The view.</returns>
		/// <param name="viewName">View name.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public T GetView<T>(string viewName) where T:new()
		{
			object view;
			viewDic.TryGetValue (viewName, out view);
			if (view != null) {
				return (T)view;
			}
			view = new T ();
			viewDic.Add (viewName,view);
			return (T)view;
		}

		public void RemoveView(string viewName)
		{
			if (viewDic.ContainsKey (viewName)) {
				viewDic [viewName] = null;
				viewDic.Remove (viewName);
			}
		}


		/// <summary>
		/// 检查View是否已经初始化
		/// </summary>
		/// <returns><c>true</c>, if view created was checked, <c>false</c> otherwise.</returns>
		/// <param name="viewName">View name.</param>
		public bool CheckViewCreated(string viewName)
		{
			object panel;
			viewDic.TryGetValue (viewName, out panel);
			return panel != null;
		}


		/// <summary>
		/// 测试T 能不能强转为BasePanel ,方便以后处理通用逻辑
		/// </summary>
		/// <param name="view">View.</param>
		private void DoSome(BasePanel view)
		{
			view.ToString ();
		}


		///还需要添加非单例的窗口 如提示框等窗口
		public T CreateDialog<T>(string dialogName) where T:new()
		{
			object dialog= new T ();
			dialogDic.Add (dialogName,dialog);
			return (T)dialog;
		}



		public void HideMainScene()
		{
		}

	}
}

