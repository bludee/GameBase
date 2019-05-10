/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using System.Collections.Generic;
using System;
using UnityEngine;
using XLua;
using System.Linq;
using System.Reflection;
using FairyGUI;

//配置的详细介绍请看Doc下《XLua的配置.doc》
public static class CustomGenConfig
{



	private static string[] luaCallCsharpNameSpace={
		"LitJson",
		"game.core",
		"game.res"
	};


	//	[Hotfix]
	//	public static List<Type> by_property
	//	{
	//		get
	//		{
	//			List<Type> resultTypes = new List<Type> ();
	//			Type[] types = Assembly.Load ("Assembly-CSharp").GetTypes ();
	//			int len = types.Length;
	//			for (int i = 0; i < len; i++) {
	//				if (string.IsNullOrEmpty (types [i].Namespace)) {
	//				}
	//				if (CheckNameSpace (types [i].Namespace,hotFixNameSpace) == true) {
	//					resultTypes.Add (types[i]);
	//				}
	//			}
	//			return resultTypes;
	//		}
	//	}

	[LuaCallCSharp]
	public static List<Type> luaCallByProperty
	{
		get
		{
			List<Type> resultTypes = new List<Type> ();
			Type[] types = Assembly.Load ("Assembly-CSharp").GetTypes ();
			int len = types.Length;
			for (int i = 0; i < len; i++) {
				if (CheckNameSpace (types [i].Namespace,luaCallCsharpNameSpace) == true) {
					resultTypes.Add (types[i]);
				}
			}
			return resultTypes;
		}
	}
	private static bool CheckNameSpace(string ns,string[] nsarr)
	{
		foreach(string key in nsarr)
		{
			if(key.Equals(ns))
			{
				return true;
			}
		}
		return false;
	}

	//lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
	[LuaCallCSharp]
	public static List<Type> LuaCallCSharp = new List<Type>() {
		typeof(System.Object),
		typeof(UnityEngine.Object),
		typeof(Vector2),
		typeof(Vector3),
		typeof(Vector4),
		typeof(Quaternion),
		typeof(Color),
		typeof(Ray),
		typeof(Bounds),
		typeof(Ray2D),
		typeof(Time),
		typeof(GameObject),
		typeof(Component),
		typeof(Behaviour),
		typeof(Transform),
		typeof(Resources),
		typeof(TextAsset),
		typeof(Keyframe),
		typeof(AnimationCurve),
		typeof(AnimationClip),
		typeof(MonoBehaviour),
		typeof(ParticleSystem),
		typeof(SkinnedMeshRenderer),
		typeof(Renderer),
		typeof(WWW),
		typeof(System.Collections.Generic.List<int>),
		typeof(Action<string>),
		typeof(UnityEngine.Debug),
		typeof(Action),

		(typeof(EventContext)),  
		(typeof(EventDispatcher)),  
		(typeof(EventListener)),  
		(typeof(InputEvent)),  
		(typeof(DisplayObject)),  
		(typeof(Container)),  
		(typeof(Stage)),  
		(typeof(Controller)),  
		(typeof(GObject)),  
		(typeof(GGraph)),  
		(typeof(GGroup)),  
		(typeof(GImage)),  
		(typeof(GLoader)),  
		(typeof(GMovieClip)),  
		(typeof(TextFormat)),  
		(typeof(GTextField)),  
		(typeof(GRichTextField)),  
		(typeof(GTextInput)),  
		(typeof(GComponent)),  
		(typeof(GList)),  
		(typeof(GRoot)),  
		(typeof(GLabel)),  
		(typeof(GButton)),  
		(typeof(GComboBox)),  
		(typeof(GProgressBar)),  
		(typeof(GSlider)),  
		(typeof(PopupMenu)),  
		(typeof(ScrollPane)),  
		(typeof(Transition)),  
		(typeof(UIPackage)),  
		(typeof(Window)),  
		(typeof(GObjectPool)),  
		(typeof(Relations)),  
		(typeof(RelationType)),  
	};

	//C#静态调用Lua的配置（包括事件的原型），仅可以配delegate，interface
	[CSharpCallLua]
	public static List<Type> CSharpCallLua = new List<Type>() {
		typeof(Action),
		typeof(Func<double, double, double>),
		typeof(Action<string>),
		typeof(Action<double>),
		typeof(UnityEngine.Events.UnityAction),
		typeof(System.Collections.IEnumerator),

		(typeof(EventCallback1)),
		(typeof(EventContext)),  
		(typeof(EventDispatcher)),  
		(typeof(EventListener)),  
		(typeof(InputEvent)),  
		(typeof(DisplayObject)),  
		(typeof(Container)),  
		(typeof(Stage)),  
		(typeof(Controller)),  
		(typeof(GObject)),  
		(typeof(GGraph)),  
		(typeof(GGroup)),  
		(typeof(GImage)),  
		(typeof(GLoader)),  
		(typeof(GMovieClip)),  
		(typeof(TextFormat)),  
		(typeof(GTextField)),  
		(typeof(GRichTextField)),  
		(typeof(GTextInput)),  
		(typeof(GComponent)),  
		(typeof(GList)),  
		(typeof(GRoot)),  
		(typeof(GLabel)),  
		(typeof(GButton)),  
		(typeof(GComboBox)),  
		(typeof(GProgressBar)),  
		(typeof(GSlider)),  
		(typeof(PopupMenu)),  
		(typeof(ScrollPane)),  
		(typeof(Transition)),  
		(typeof(UIPackage)),  
		(typeof(Window)),  
		(typeof(GObjectPool)),  
		(typeof(Relations)),  
		(typeof(RelationType)),  

	};

	//黑名单
	[BlackList]
	public static List<List<string>> BlackList = new List<List<string>>()  {
		new List<string>(){"UnityEngine.WWW", "movie"},
		new List<string>(){"UnityEngine.Texture2D", "alphaIsTransparency"},
		new List<string>(){"UnityEngine.Security", "GetChainOfTrustValue"},
		new List<string>(){"UnityEngine.CanvasRenderer", "onRequestRebuild"},
		new List<string>(){"UnityEngine.Light", "areaSize"},
		new List<string>(){"UnityEngine.AnimatorOverrideController", "PerformOverrideClipListCleanup"},
		#if !UNITY_WEBPLAYER
		new List<string>(){"UnityEngine.Application", "ExternalEval"},
		#endif
		new List<string>(){"UnityEngine.GameObject", "networkView"}, //4.6.2 not support
		new List<string>(){"UnityEngine.Component", "networkView"},  //4.6.2 not support
		new List<string>(){"System.IO.FileInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
		new List<string>(){"System.IO.FileInfo", "SetAccessControl", "System.Security.AccessControl.FileSecurity"},
		new List<string>(){"System.IO.DirectoryInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
		new List<string>(){"System.IO.DirectoryInfo", "SetAccessControl", "System.Security.AccessControl.DirectorySecurity"},
		new List<string>(){"System.IO.DirectoryInfo", "CreateSubdirectory", "System.String", "System.Security.AccessControl.DirectorySecurity"},
		new List<string>(){"System.IO.DirectoryInfo", "Create", "System.Security.AccessControl.DirectorySecurity"},
		new List<string>(){"UnityEngine.MonoBehaviour", "runInEditMode"},
	};
}
