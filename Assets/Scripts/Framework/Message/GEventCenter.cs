using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	/// <summary>
	/// 定义事件分发委托
	/// </summary>
	public delegate void GEventCallBack(GEvent data);

	/// <summary>
	///通知中心
	/// </summary>
	public class GEventCenter<T>
	{

		/// <summary>
		/// 通知中心单例
		/// </summary>
		private static GEventCenter<T> _inst=null;
		public static GEventCenter<T> Inst
		{
			get{
				if ( _inst== null) {
					_inst= new GEventCenter<T> ();
				}
				return _inst;
			}
		}
		/// <summary>
		/// 存储事件的字典
		/// </summary>
		private Dictionary<T,GEventCallBack> eventListeners
		= new Dictionary<T, GEventCallBack>();

		private Dictionary<T,int> eventNumDic = new Dictionary<T, int> ();


		/// <summary>
		/// 注册事件
		/// </summary>
		/// <param name="eventKey">事件Key</param>
		/// <param name="eventListener">事件监听器</param>
		public void AddEventListener(T eventKey,GEventCallBack eventListener)
		{
			if (!eventListeners.ContainsKey (eventKey)) {
				eventListeners.Add (eventKey, new GEventCallBack(eventListener));
			} else {//GEventCallBack gcb = 
				eventListeners [eventKey]+= eventListener;
//				gcb += eventListener;
			}
			if (!eventNumDic.ContainsKey (eventKey)) {
				eventNumDic.Add (eventKey, 1);
			} else {
				eventNumDic [eventKey] +=1 ;
			}
		}

		/// <summary>
		/// 移除事件
		/// </summary>
		/// <param name="eventKey">事件Key</param>
		public void RemoveEventListener(T eventKey,GEventCallBack eventListener)
		{
			if(!eventListeners.ContainsKey(eventKey))
				return;
			eventListeners [eventKey] -= eventListener;
			eventNumDic [eventKey] -= 1;
			if (eventNumDic [eventKey] == 0) {
				eventListeners [eventKey] = null;
				eventListeners.Remove (eventKey);
			}
		}

		/// <summary>
		/// 分发事件
		/// </summary>
		/// <param name="eventKey">事件Key</param>
		/// <param name="notific">通知</param>
		public void DispatchEvent(T eventKey,GEvent notific)
		{
			if (!eventListeners.ContainsKey(eventKey))
				return;
			eventListeners[eventKey](notific);
		}

		/// <summary>
		/// 分发事件
		/// </summary>
		/// <param name="eventKey">事件Key</param>
		/// <param name="sender">发送者</param>
		/// <param name="param">通知内容</param>
		public void DispatchEvent(T eventKey, GameObject sender, object param)
		{
			if(!eventListeners.ContainsKey(eventKey))
				return;
			eventListeners[eventKey](new GEvent(sender,param));
		}

		/// <summary>
		/// 分发事件
		/// </summary>
		/// <param name="eventKey">事件Key</param>
		/// <param name="param">通知内容</param>
		public void DispatchEvent(T eventKey,object param)
		{
			if(!eventListeners.ContainsKey(eventKey))
				return;
			eventListeners[eventKey](new GEvent(param));
		}

		/// <summary>
		/// 是否存在指定事件的监听器
		/// </summary>
		public Boolean HasEventListener(T eventKey)
		{
			return eventListeners.ContainsKey(eventKey);
		}
	}
}