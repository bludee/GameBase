using System;

namespace Game
{
	/// <summary>
	/// 用户基础设置类
	/// </summary>
	public class UserConfig
	{
		private static int sound=1;
		private static int soundEft=1;
		public UserConfig ()
		{
		}



		public static int Sound{
			get{
				return sound;
			}
			set{ 
				if (sound == value) {
					return;
				}
				sound = value;
				if (sound == 0) {
					AppMain.Inst.SoundMgr.BgVol = 0f;
				} else {
					AppMain.Inst.SoundMgr.BgVol = 1f;
				}
				AppMain.Inst.SaveMgr.SetInt ("sound",sound);
			}
		}

		public static int SoundEft{
			get{
				return soundEft;
			}
			set{ 
				if (soundEft == value) {
					return;
				}
				soundEft = value;
				if (soundEft == 0) {
					AppMain.Inst.SoundMgr.EffectVol = 0f;
				} else {
					AppMain.Inst.SoundMgr.EffectVol = 1f;
				}
				AppMain.Inst.SaveMgr.SetInt ("soundeft",soundEft);
			}
		}

		public static void Create()
		{
			AppMain.Inst.SaveMgr.SetInt ("sound",1);
			AppMain.Inst.SaveMgr.SetInt ("soundeft",1);
		}


		public static void Load()
		{
			SoundEft = AppMain.Inst.SaveMgr.GetInt ("soundeft");
			Sound = AppMain.Inst.SaveMgr.GetInt ("sound");
		}
	}
}

