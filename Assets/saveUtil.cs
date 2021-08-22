using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public static class saveUtil{

	public static void saveRT(RenderTexture destination, string pngOutPath)
	{
		var tex = new Texture2D(destination.width, destination.height);
		tex.ReadPixels(new Rect(0, 0, destination.width, destination.height), 0, 0);
		tex.Apply();

		File.WriteAllBytes(Application.dataPath + "/" + pngOutPath + ".png", tex.EncodeToPNG());
		Debug.Log(Application.dataPath + "/" + pngOutPath + ".png");
	}

	[MenuItem("Assets/Save RenderTexture to file")]
    public static void SaveRTToFile()
    {
        RenderTexture rt = Selection.activeObject as RenderTexture;

        RenderTexture.active = rt;
        Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        RenderTexture.active = null;

        byte[] bytes;
        bytes = tex.EncodeToPNG();
        
        string path = AssetDatabase.GetAssetPath(rt) + ".png";
		System.IO.File.WriteAllBytes(path + ".png", bytes);
        //AssetDatabase.ImportAsset(path);
		Debug.Log("Saved to " + path + ".png");
    }
}
