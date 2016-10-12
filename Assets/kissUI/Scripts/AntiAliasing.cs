using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
[RequireComponent( typeof( Camera ) )]
public class AntiAliasing : MonoBehaviour {

	public int Anti_Aliasing = 0;	//0 = NONE, 2 = 2x, 4 = 4x, 6 = 6x
	int origAA = 0;
	
	// Use this for initialization
	void Start () {
//		origAA = QualitySettings.antiAliasing;
//		QualitySettings.antiAliasing = Anti_Aliasing;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnEnable()
	{
		// register the callback when enabling object
//		Camera.onPreRender += MyPreRender;
//		Camera.onPostRender += MyPostRender;
	}
	
	void OnDisable()
	{
		// remove the callback when disabling object
//		Camera.onPreRender -= MyPreRender;
//		Camera.onPostRender -= MyPostRender;
	}
	
	void MyPreRender( Camera cam )
	{
		origAA = QualitySettings.antiAliasing;
		if( origAA != Anti_Aliasing )
			QualitySettings.antiAliasing = Anti_Aliasing;
		
		//Debug.Log( "QualitySettings.antiAliasing origAA:  " + origAA );
	}
	
	void MyPostRender( Camera cam )
	{
		if( origAA != Anti_Aliasing )
			QualitySettings.antiAliasing = origAA;
		
		//Debug.Log( "QualitySettings.antiAliasing After:  " + QualitySettings.antiAliasing );
	}	
}
