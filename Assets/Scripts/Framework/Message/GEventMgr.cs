using System;
using System.Collections.Generic;
namespace Game
{
	public class GEventMgr
	{

		private Dictionary<string,GEventCallBack> dic;
		public GEventMgr ()
		{
		}

		public void Add(string key,GEventCallBack cb)
		{
			if (dic == null) {
				dic = new Dictionary<string, GEventCallBack> ();
			}
			dic.Add (key,cb);
			GEventCenter<string>.Inst.AddEventListener (key,cb);
		}


		public void Dispose()
		{
			if (dic == null || dic.Count == 0) {
				return;
			}
			foreach (var key in dic.Keys) {
				GEventCenter<string>.Inst.RemoveEventListener (key,dic[key]);
			}
			dic.Clear ();
			dic = null;
		}
	}
}

