using System;
using UnityEngine;
using Spine;
using Spine.Unity;
namespace Game
{
	public class ModelManager:MonoBehaviour
	{
		private const string SpineUIPrefabPath = "Prefab/SpineUI";


		void Awake()
		{
			Init ();
		}

		void Init()
		{
			//			InitConfigs ();
		}



		public GameObject CreateModel(string prefab)
		{
			GameObject model = (GameObject)Instantiate (AppMain.Inst.ResMgr.Load (prefab));
			return model;
		}

		/// <summary>
		/// 根据预制体和动画资源路径创建一个spine动画
		/// </summary>
		/// <returns>The model.</returns>
		/// <param name="prefab">Prefab.</param>
		/// <param name="assetPath">Asset path.</param>
		/// <param name="init">If set to <c>true</c> init.</param>
		private GameObject createSpineModel(string prefab,string assetPath,bool init)
		{
			GameObject model = (GameObject)Instantiate (AppMain.Inst.ResMgr.Load (prefab));
			SkeletonAnimation ani = model.GetComponent<SkeletonAnimation> ();
			if (!string.IsNullOrEmpty (assetPath)) {
				ani.skeletonDataAsset = GetSkeletonAsset (assetPath);
			}
			if (init==true) {
				ani.Initialize (true);
			}
			return model;	
		}

		public void ChangeSpineAsset(SkeletonAnimation ani,string assetPath,bool init=true)
		{
			ani.skeletonDataAsset = GetSkeletonAsset ("Model/Fish/"+assetPath);
			if (init == true) {
				ani.Initialize (true);
			}
		}



		public SkeletonDataAsset GetSkeletonAsset(string path)
		{
			SkeletonDataAsset asset = (SkeletonDataAsset)AppMain.Inst.ResMgr.Load (path+"_SkeletonData");
			return asset;
		}


		public GameObject CreateSpineModelForUI(string path,bool init=true)
		{	
			GameObject model = createSpineModel (SpineUIPrefabPath,path,init);
			return model;
			
		}
	}
}

