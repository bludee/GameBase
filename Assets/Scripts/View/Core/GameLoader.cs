using System;
using FairyGUI;
using UnityEngine;
namespace Game
{
	public class GameLoader:GLoader
	{
		protected override void LoadExternal()
		{
			Texture2D tex;
			UnityEngine.Object con = AppMain.Inst.ResMgr.Load (this.url);
			if (con is Sprite) {
				tex = (con as Sprite).texture as Texture2D;
			} else {
				tex = con as Texture2D;
			}

			if (tex != null) {
				base.onExternalLoadSuccess (new NTexture (tex));
			} else {
				base.onExternalLoadFailed ();
			}

		}

		protected override void FreeExternal (NTexture texture)
		{
			base.FreeExternal (texture);
		}

		void OnLoadSuccess(NTexture tex)
		{
			if (string.IsNullOrEmpty (this.url)) {
				return;
			}
			base.onExternalLoadSuccess (tex);
		}

		void OnLoadFail(string err)
		{
			Debug.Log ("GLoader: load "+this.url+"  error");
			this.onExternalLoadFailed ();
		}
	}
}

