using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 挂在摄像机上的脚本,根据实际屏幕大小计算摄像机size
/// </summary>
public class CameraSet : MonoBehaviour {

	void Start () {
		Resolution[] res = Screen.resolutions;
		float w = (float)Screen.width;
		float h = (float)Screen.height;
		float bili = h / w;
		float designBili = 1080f / 1920f;
		float size=600f * bili / designBili;
		Debug.Log ("screen size : "+size);
		Camera.main.orthographicSize = size;
	}
	
}
