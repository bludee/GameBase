using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
