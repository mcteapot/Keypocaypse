using UnityEngine;
using System.Collections;
using kissUI;

public class TakeWebplayerScreenshot : MonoBehaviour
{
	private string _data = string.Empty;
	public kissCamera kissCAM;
	public Texture2D bg;
	
	void OnGUI()
	{
		if( GUI.Button( new Rect(Screen.width*0.5f-32,32,64,32), "Save" ) )
			StartCoroutine( ScreeAndSave() );
			//Application.CaptureScreenshot("Screenshot.png");
	}
	
	IEnumerator ScreeAndSave()
	{
		yield return new WaitForEndOfFrame();
		//var newTexture = ScreenShoot( kissCAM.cam, bg.width, bg.height );
		Texture2D newTexture = ScreenShot2();
		//LerpTexture( bg, ref newTexture );
		_data = System.Convert.ToBase64String( newTexture.EncodeToPNG() );
		//Application.ExternalEval( "document.location.href='data:image/octet-stream;base64," + _data + "'" );
		Application.ExternalEval( "document.location.href='data:image/octet-stream;base64," + _data + "'" );
	}
	
	private static Texture2D ScreenShoot( Camera srcCamera, int width, int height )
	{
		var renderTexture = new RenderTexture( width, height, 0 );
		var targetTexture = new Texture2D( width, height, TextureFormat.RGB24, false );
		srcCamera.targetTexture = renderTexture;
		srcCamera.Render();
		RenderTexture.active = renderTexture;
		targetTexture.ReadPixels( new Rect(0, 0, width, height), 0, 0 );
		targetTexture.Apply();
		srcCamera.targetTexture = null;
		RenderTexture.active = null;
		srcCamera.ResetAspect();
		return targetTexture;
	}
	
	private static Texture2D ScreenShot2()
	{
		Texture2D tex = new Texture2D( Screen.width, Screen.height );
		tex.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
		tex.Apply();
		return tex;
	}
	
	private static void LerpTexture( Texture2D alphaTexture, ref Texture2D texture )
	{
		var bgColors = alphaTexture.GetPixels();
		var tarCols = texture.GetPixels();
		for( var i = 0; i < tarCols.Length; i++ )
			tarCols[i] = bgColors[i].a > 0.99f ? bgColors[i] : Color.Lerp( tarCols[i], bgColors[i], bgColors[i].a );
		texture.SetPixels( tarCols );
		texture.Apply();
	}
}