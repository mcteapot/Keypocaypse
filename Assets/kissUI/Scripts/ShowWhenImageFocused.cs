using UnityEngine;
using System.Collections;
using kissUI;

public class ShowWhenImageFocused : MonoBehaviour
{
	public kissImage imgFocused;
	
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	//void Update () {}
	
	
	public void onFocusReceived()
	{
		if( imgFocused == null )
			return;
		
		//Debug.Log( "onFocusReceived" );
		
		imgFocused.IsVisible = true;
		
		kissImage.ReCalculate_Visibility( imgFocused );
	}
	
	public void onFocusLost()
	{
		if( imgFocused == null )
			return;
		
		//Debug.Log( "onFocusLost" );
		
		imgFocused.IsVisible = false;
		
		kissImage.ReCalculate_Visibility( imgFocused );
	}
	
}
