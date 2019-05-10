using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
namespace Game {
	public class SoundManager : MonoBehaviour {
		private AudioSource bgAudio;
		private AudioSource effectAudio;
        private Hashtable sounds = new Hashtable();

		private Vector3 normalPos = Vector3.zero;




		private float bgVol = 1f;
		private float effectVol=1f;

		public float BgVol{
			get{ 
				return bgVol;
			}
			set{ 
				bgVol = value;
				AppMain.Inst.SaveMgr.SaveSoundBg ( value);
				if (bgAudio != null) {
					bgAudio.volume = bgVol;
				}
			}
		}


		public float cacheBgVol{
			set{ 
				bgAudio.volume = value;
			}
		}

		public void FadeToMute()
		{
			bgAudio.DOFade (0,1f);
		}

		public float EffectVol{
			get{ 
				return effectVol;
			}
			set{ 
				effectVol = value;
				AppMain.Inst.SaveMgr.SaveSoundEffect ( value);
			}
		}


        void Awake() {
			bgAudio = this.gameObject.AddComponent<AudioSource>();
			effectAudio = this.gameObject.AddComponent<AudioSource> ();
			bgAudio.playOnAwake = false;
        }

		void Start()
		{
			float bv= AppMain.Inst.SaveMgr.LoadSoundBg ();
			float ev = AppMain.Inst.SaveMgr.LoadSoundEffect ();
			if (bv == -1f) {
				bv = 1f;
			}
			if (ev == -1f) {
				ev = 1f;
			}

			BgVol = bv;
			EffectVol = ev;

		}

        /// <summary>
        /// 添加一个声音
        /// </summary>
        void Add(string key, AudioClip value) {
            if (sounds[key] != null || value == null) return;
            sounds.Add(key, value);
        }
		public AudioClip GetClipById(int id)
		{
//			if (AppMain.Inst.ConfigMgr.MusicConfig.ContainsKey (id) == false) {
//				return null;
//			}
//			MusicTemp temp = AppMain.Inst.ConfigMgr.MusicConfig.Get (id);
//			return Get (temp.name);
			return null;
		}
        /// <summary>
        /// 获取一个声音
        /// </summary>
		AudioClip Get(string key) {
			if (sounds [key] == null) 
			{
				LoadAudioClip (key);
			}
            return sounds[key] as AudioClip;
        }

        /// <summary>
        /// 载入一个音频
        /// </summary>
        public AudioClip LoadAudioClip(string path) {
			AudioClip ac = null;
            if (ac == null) {
				ac = AppMain.Inst.ResMgr.Load ("Sound/"+path) as AudioClip;
				if (ac == null) {
					Debug.LogError ("sound not found: "+path);
				}
                Add(path, ac);
            }
            return ac;
        }

        /// <summary>
        /// 是否播放背景音乐，默认是1：播放
        /// </summary>
        /// <returns></returns>
        public bool CanPlayBackSound() {
            string key = AppConst.AppPrefix + "BackSound";
            int i = PlayerPrefs.GetInt(key, 1);
//			return false;
            return i == 1;
        }

        /// <summary>
        /// 播放背景音乐
        /// </summary>
        /// <param name="canPlay"></param>
		public void PlayBacksound(string name, bool canPlay,bool loop=true,float volsc=1f,bool replay=false) {
			if (bgAudio.clip != null&&replay==false) {
				if (name.IndexOf(bgAudio.clip.name) > -1&&bgAudio.isPlaying==true) {
					if (!canPlay) {
						bgAudio.Stop ();
						bgAudio.clip = null;
						Util.ClearMemory ();
					} 
                    return;
                }
            }
            if (canPlay) {
				bgAudio.loop = loop;
				bgAudio.clip = Get(name);
				bgAudio.volume = bgVol*volsc;
				bgAudio.time = 0f;
                bgAudio.Play();
            } else {
                bgAudio.Stop();
                bgAudio.clip = null;
                Util.ClearMemory();
            }
        }

        /// <summary>
        /// 是否播放音效,默认是1：播放
        /// </summary>
        /// <returns></returns>
        public bool CanPlaySoundEffect() {
            string key = AppConst.AppPrefix + "SoundEffect";
            int i = PlayerPrefs.GetInt(key, 1);
            return i == 1;
        }

        /// <summary>
        /// 播放音频剪辑
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="position"></param>
		public void PlayEffect(AudioClip clip,float volsc) {
			if (clip == null) {
				return;
			}
            if (!CanPlaySoundEffect()) return;
			AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position,effectVol*volsc); 
        }


		public void PlayEffectById(int id)
		{
//			if (AppMain.Inst.ConfigMgr.MusicConfig.ContainsKey (id) == false) {
//				return;
//			}
//			MusicTemp temp = AppMain.Inst.ConfigMgr.MusicConfig.Get (id);
//			float volsc = temp.volumePower / 100f;
//			PlayEffect(Get (temp.name),volsc);
		}


		public void PlayBackGroundById(int id,bool loop=true,bool rePlay=false)
		{
//			MusicTemp temp = AppMain.Inst.ConfigMgr.MusicConfig.Get (id);
//			float volsc = temp.volumePower / 100f;
//			PlayBacksound (temp.name,CanPlayBackSound(),loop,volsc,rePlay);
		}

		public void StopBackGround()
		{
			if (bgAudio.clip != null) {
				bgAudio.Stop ();
				bgAudio.clip = null;
				Util.ClearMemory();
			}
		}


		public void PauseBackGroud()
		{
			if (bgAudio.clip != null) {
				bgAudio.Pause ();
			}
		}

		public void ResumeBackGroud()
		{
			if (bgAudio.clip != null) {
				bgAudio.UnPause ();
			}
		}


		public void LoadBgmSound(int id)
		{
			
		}

		public void LoadQteSound(int id)
		{
//			MusicTemp temp = AppMain.Inst.ConfigMgr.MusicConfig.Get (id);
//			LoadAudioClip (temp.name);
		}

		public void PlayQteSound(int id)
		{
			if (id == 0) {
				return;
			}
			PlayEffectById(id);
		}




		public void SetBgPlayTime(float time)
		{
			bgAudio.time = time;
		}

		public float GetBGPlayTime()
		{
			if (bgAudio.isPlaying == false) {
				return 0f;
			}
			return bgAudio.time;
		}

		public AudioSource BGAudio{
			get{
				return bgAudio;
			}
		}



    }
}