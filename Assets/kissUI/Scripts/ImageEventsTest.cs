using UnityEngine;
using System.Collections;
using kissUI;

[ExecuteInEditMode]
public class ImageEventsTest : MonoBehaviour
{
	kissImage img;

	public kissText txt;
	
	// Use this for initialization
	//void Start(){}
	
	// Update is called once per frame
	//void Update(){}
	
	void OnEnable()
	{
		//Debug.Log( "ImageEventsTest:  OnEnable()" );
		
		if( img == null )
			img = gameObject.GetComponent< kissImage >();
		
		if( img != null )
			img.OnSizeChanged += onImageResized;
	}
	
	void OnDisable()
	{
		//Debug.Log( "ImageEventsTest:  OnDisable()" );
		
		if( img != null )
			img.OnSizeChanged -= onImageResized;
	}
	
	void onImageResized()
	{
		//Debug.Log( "ImageEventsTest:  onImageResized()" );
	}

	public void onMouseHeld()
	{
		//Debug.Log( "ImageEventsTest:  onMouseHeld()" );

		if( txt != null )
		{
			int txtVal = 0;
			bool isTxtVal = int.TryParse( txt.Text, out txtVal );
			
			if( isTxtVal )
				txtVal++;

			txt.Text = txtVal.ToString();
			txt.Refresh();
		}
	}

	public int FuncParams( int Arg1, int Arg2, string Arg3 )
	{
		Debug.Log( "FuncParams( " + Arg1 + ", " + Arg2 + ", " + Arg3 + " )" );

		return 0;
	}
}
