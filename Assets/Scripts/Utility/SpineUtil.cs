using System;
using Spine;
using UnityEngine;
using Spine.Unity;
namespace Game
{
	public class SpineUtil
	{


		public static void PlayAction(SkeletonAnimation anim,string name,bool loop=true,float sc=1f,int trackid=0)
		{
			if (anim != null && anim.state != null) {
				if (anim.timeScale != sc) {
					anim.timeScale = sc;
				}
				anim.state.SetAnimation (0, name, loop);
			}else
			{
//				Debug.Log ("PlayAction  anim is null" );
			}
		}


		public static TrackEntry RevertPlayAction(SkeletonAnimation anim,string name,bool loop=true,float sc=1f)
		{
			if (anim != null && anim.state != null) {
				TrackEntry t= anim.state.SetAnimation (0,name,loop);
				float time = anim.Skeleton.Data.FindAnimation (name).Duration;
				anim.Update (time);
				if (anim.timeScale != sc) {
					anim.timeScale = sc;
				}
				return t;
			}
			return null;
		}



		public static void AddAction(SkeletonAnimation anim,string name,bool loop=true,float dealy=0f,float sc=1f)
		{
			TrackEntry entry=anim.state.AddAnimation (0,name,loop,dealy);
		}



		public static void ChangeDataAsset(SkeletonAnimation anim,string path)
		{
			anim.skeletonDataAsset = AppMain.Inst.ModelMgr.GetSkeletonAsset (path);
		}


		/// <summary>
		/// 获取骨骼的世界坐标
		/// </summary>
		/// <returns>The bone world vec.</returns>
		/// <param name="anim">Animation.</param>
		/// <param name="boneName">Bone name.</param>
		public static Vector3 GetBoneWorldVec(SkeletonAnimation anim,string boneName)
		{
			Bone bone = anim.skeleton.FindBone (boneName);
			Vector3 vec = new Vector3 (bone.worldX-750f,bone.WorldY-250f,-65);
			return vec;
		}




		public static AtlasRegion CreateRegion(Texture2D tex)
		{
			Spine.AtlasRegion region = new AtlasRegion ();
			region.width = tex.width;
			region.height = tex.height;
			region.originalWidth = tex.width;
			region.originalHeight = tex.height;
			region.rotate = false;
			region.page = new AtlasPage ();
			region.page.name = tex.name;
			region.page.width = tex.width;
			region.page.height = tex.height;
			region.page.uWrap = TextureWrap.ClampToEdge;
			region.page.vWrap = TextureWrap.ClampToEdge;
			return region;
		}


		public static Material CreateRegionAttackmentByTexture(Slot slot,Texture2D tex)
		{	
			Debug.Log ("准备替换图片");
			if (slot == null || tex == null) {
				return null;
			}
			RegionAttachment attackment = slot.Attachment as RegionAttachment;
			if (attackment == null) {
				return null;
			}
			Debug.Log ("替换图片");
			attackment.RendererObject = CreateRegion (tex);
			attackment.SetUVs (0f,1f,1f,0f,false);
			Material mat = new Material (Shader.Find("Sprites/Default"));
			mat.mainTexture = tex;
			(attackment.RendererObject as AtlasRegion).page.rendererObject = mat;
//			UpdateOffsetByTexture2D (attackment,tex);
			slot.Attachment = attackment;
			return mat;
		}


		public static Material CreateMeshAttackmentByTexture(Slot slot,Texture2D tex)
		{
			if (slot == null || tex == null) {
				return null;
			}
			MeshAttachment oldAtt = slot.Attachment as MeshAttachment;
			if (oldAtt == null) {
				return null;
			}
			MeshAttachment att = new MeshAttachment (oldAtt.Name);
			att.RendererObject = CreateRegion (tex);
			att.Path = oldAtt.Path;

			att.Bones = oldAtt.Bones;
			att.Edges = oldAtt.Edges;
			att.Triangles = oldAtt.triangles;
			att.Vertices = oldAtt.Vertices;
			att.WorldVerticesLength = oldAtt.WorldVerticesLength;
			att.HullLength = oldAtt.HullLength;
			att.RegionRotate = false;



			att.RegionU = 0f;
			att.RegionV = 1f;
			att.RegionU2 = 1f;
			att.RegionV2 = 0f;

			att.RegionUVs = oldAtt.RegionUVs;
			att.UpdateUVs ();

			Material mat = new Material (Shader.Find("Sprites/Default"));
			mat.mainTexture = tex;
			(att.RendererObject as Spine.AtlasRegion).page.rendererObject = mat;
			slot.Attachment = att;

			//不根据图片大小更换的话 重新计算 
//			att.UpdateOffsetByTexture2D (att,tex);


			return mat;
		}


		private static void UpdateOffsetByTexture2D(RegionAttachment att,Texture2D tex)
		{
			float width = tex.width;
			float height = tex.height;
			float scaleX = att.scaleX;
			float scaleY = att.scaleY;
			float regionScaleX = width / att.regionOriginalWidth * scaleX;
			float regionScaleY = height / att.regionOriginalHeight * scaleY;
			float localX = -width / 2 * scaleX + att.regionOffsetX * regionScaleX;
			float localY = -height / 2 * scaleY + att.regionOffsetY * regionScaleY;
			float localX2 = localX + att.regionWidth * regionScaleX;
			float localY2 = localY + att.regionHeight * regionScaleY;
			float rotation = att.rotation;
			float cos = MathUtils.CosDeg(rotation);
			float sin = MathUtils.SinDeg(rotation);
			float x = att.x;
			float y = att.y;
			float localXCos = localX * cos + x;
			float localXSin = localX * sin;
			float localYCos = localY * cos + y;
			float localYSin = localY * sin;
			float localX2Cos = localX2 * cos + x;
			float localX2Sin = localX2 * sin;
			float localY2Cos = localY2 * cos + y;
			float localY2Sin = localY2 * sin;
			float[] offset = att.offset;
			offset[RegionAttachment.BLX] = localXCos - localYSin;
			offset[RegionAttachment.BLY] = localYCos + localXSin;
			offset[RegionAttachment.ULX] = localXCos - localY2Sin;
			offset[RegionAttachment.ULY] = localY2Cos + localXSin;
			offset[RegionAttachment.URX] = localX2Cos - localY2Sin;
			offset[RegionAttachment.URY] = localY2Cos + localX2Sin;
			offset[RegionAttachment.BRX] = localX2Cos - localYSin;
			offset[RegionAttachment.BRY] = localYCos + localX2Sin;
		}



	}
}

