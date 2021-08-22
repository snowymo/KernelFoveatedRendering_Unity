using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveCtrl : MonoBehaviour {

	public RenderTexture rt;
	public string path;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			saveUtil.saveRT (rt, path);
		}
	}
}
