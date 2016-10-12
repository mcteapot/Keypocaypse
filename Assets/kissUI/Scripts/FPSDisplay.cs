using UnityEngine;
using System.Collections;

public class FPSDisplay : MonoBehaviour
{
	public int desiredFrameRate = 60;
	public Color textColor = Color.white;

	int origTargetFrameRate = 0;
	float deltaTime = 0.0f;
	GUIStyle style = null;
	Rect rect = new Rect();

	void Awake()
	{
		origTargetFrameRate = Application.targetFrameRate;
		Application.targetFrameRate = 60;
	}

	void OnEnable()
	{
		origTargetFrameRate = Application.targetFrameRate;
		Application.targetFrameRate = desiredFrameRate;
	}

	void OnDisable()
	{
		Application.targetFrameRate = origTargetFrameRate;
	}

	void Update()
	{
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}

	void OnGUI()
	{
		if( style == null )
		{
			int w = Screen.width, h = Screen.height;
			rect = new Rect(10, 0, w, h * 2 / 100);
			
			style = new GUIStyle();
			style.alignment = TextAnchor.UpperLeft;
			style.fontSize = 12; //h * 2 / 100;
			style.normal.textColor = textColor;
		}

		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);		// SWidth: " + kissRaycast.GVWidth + " SHeight: " + kissRaycast.GVHeight

		GUI.Label(rect, text, style);
	}
}