using UnityEngine;
using System.Collections;

public class androidScreenResize : MonoBehaviour
{
	public int desiredWidth = 320;
	public int desiredHeight = 569;
	
//	public int aspectWidth;
//	public int aspectHeight;
//	
//	private float aspectRatio;

	private DeviceOrientation lastOrientation = DeviceOrientation.Unknown;
	
	// Use this for initialization
	void Start ()
	{
//		if( Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight )
//			aspectRatio = Screen.width / Screen.height;
//		else if( Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown )
//			aspectRatio = Screen.height / Screen.width;
		
		SetDeviceResolution();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if( lastOrientation != Input.deviceOrientation )
			SetDeviceResolution();
	}
	
	void SetDeviceResolution()
	{
//		if( Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight )
//		{
//			aspectHeight = desiredWidth;
//			aspectWidth = Mathf.RoundToInt( aspectHeight * aspectRatio );
//		}
//		else if( Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown )
//		{
//			aspectWidth = desiredWidth;
//			aspectHeight = Mathf.RoundToInt( aspectWidth * aspectRatio );
//		}
//		
//		if( Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight )
//			Screen.SetResolution( aspectHeight, aspectWidth, Screen.fullScreen );
//		else if( Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown )
//			Screen.SetResolution( aspectWidth, aspectHeight, Screen.fullScreen );
		
		if( Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight )
			Screen.SetResolution( desiredHeight, desiredWidth, Screen.fullScreen );
		else if( Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown )
			Screen.SetResolution( desiredWidth, desiredHeight, Screen.fullScreen );
	}
	
}







