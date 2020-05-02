using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class screenshots : MonoBehaviour {

	// Use this for initialization
	public int width = Screen.width;
	public int height = Screen.height;
	public Texture2D ScreenShotImage;

//	var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
//	// Read screen contents into the texture
//	tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
//	tex.Apply();
//	byte[] screenshot = tex.EncodeToPNG();
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	if(Input.GetKeyDown(KeyCode.A))
		{
			if(ScreenShotImage)
			{
				Destroy(ScreenShotImage);
			}

			StartCoroutine(TakeScreenshot());
//			var width = Screen.width;
//			var height = Screen.height;
//			var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
//			// Read screen contents into the texture
//			tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
//			tex.Apply();
//			byte[] screenshot = tex.EncodeToPNG();
		}
	}

	private IEnumerator TakeScreenshot() 
	{
		yield return new WaitForEndOfFrame();

		width = Screen.width;
		height = Screen.height;
		ScreenShotImage = new Texture2D(width, height, TextureFormat.RGB24, false);
		// Read screen contents into the texture
		ScreenShotImage.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		ScreenShotImage.Apply();
		byte[] screenshot = ScreenShotImage.EncodeToPNG();
	}
}
