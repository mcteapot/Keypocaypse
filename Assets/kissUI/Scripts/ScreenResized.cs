using UnityEngine;
using System.Collections;

public class ScreenResized : MonoBehaviour
{
	ResizeMouseDragBounds rmdb;
	
	// Use this for initialization
	void Start ()
	{
		rmdb = new ResizeMouseDragBounds();
		rmdb.Init();

		rmdb.cam = gameObject.GetComponent< kissCamera >();
		rmdb.ray = gameObject.GetComponent< kissRaycast >();
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if( rmdb != null )
//			rmdb.Update();
	}
}


/// <summary>
/// Should use temporarily until Unity3d-team fix the bug
/// http://issuetracker.unity3d.com/issues/input-when-resizing-window-input-dot-mouseposition-will-be-clamped-by-the-original-window-size
/// </summary>
class ResizeMouseDragBounds
{
	public kissCamera cam;
	public kissRaycast ray;

	private int prevWidth;
	private int prevHeight;
	private bool isInited = false;
	
	
	public void Init()
	{
		prevWidth  = Screen.width;
		prevHeight = Screen.height;
		
		isInited = true;
	}
	
	public void Update()
	{
		if( !isInited )
			Init();
		
		if( Screen.width != prevWidth || Screen.height != prevHeight )
			SetResolution();
	}
	
	private void SetResolution()
	{
		prevWidth  = Screen.width;
		prevHeight = Screen.height;
		
		Screen.SetResolution( Screen.width, Screen.height, Screen.fullScreen );

		if( cam != null )
			cam.Refresh();

		if( ray != null )
		{
			// Soft Update
			kissRaycast.GVWidthLast = -1;
			kissRaycast.GVHeightLast = -1;
		}
	}
}

