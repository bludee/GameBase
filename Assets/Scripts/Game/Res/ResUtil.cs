using System;
using Spine.Unity;
using UnityEngine;
using Spine;
namespace Game
{
	/// <summary>
	/// 资源工具类  所有的需要根据逻辑设置路径的资源都要通过本类来获取,方便修改目录结构
	/// </summary>
	public class ResUtil
	{
		public ResUtil ()
		{
		}


		public static UnityEngine.Object LoadModel()
		{
			return AppMain.Inst.ResMgr.Load("Prefabs/model");
		}

		public static SkeletonDataAsset GetAnimationDataAsset(String path)
		{
			SkeletonDataAsset asset = (SkeletonDataAsset)AppMain.Inst.ResMgr.Load ("Model/test/"+path+"_SkeletonData");
			return asset;
		}



		public static AudioClip GetClipByName(string name)
		{
			AudioClip clip = AppMain.Inst.ResMgr.Load ("Sound/"+name) as AudioClip;
			return clip;
		}


		static Vector2 np = Vector2.one * 0.5f;
		public static Sprite CreateSprite(string path,float w=128,float h=128)
		{
			Rect nrect = new Rect (0,0,w,h);
			Sprite sp = Sprite.Create (AppMain.Inst.ResMgr.Load (path) as Texture2D, nrect, np, 1,0,SpriteMeshType.Tight);
			return sp;
		}

		/// <summary>
		/// 获取npc模型的路径
		/// </summary>
		/// <returns>The npc model path.</returns>
		/// <param name="path">Path.</param>
		public static string GetNpcModelPath(string path)
		{
			return "Npc/"+path;
		}


	}
}

