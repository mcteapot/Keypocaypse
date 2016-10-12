using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using kissUI;

[ExecuteInEditMode]
public class AllImages_onMouseWheel : MonoBehaviour
{
	public kissImage[] images2;
	
	void OnEnable()
	{
		images2 = gameObject.GetComponentsInChildren< kissImage >();
		
		for( int i = 0; i < images2.Length; i++ )
		{
			if( images2[ i ] == null )
				continue;

			images2[ i ].OnMouseWheel += OnMouseWheel;
		}
	}
	
	void OnDisable()
	{
		for( int i = 0; i < images2.Length; i++ )
		{
			if( images2[ i ] == null )
				continue;

			images2[ i ].OnMouseWheel -= OnMouseWheel;
		}
	}
	
	// Update is called once per frame
	//void Update () {}
	
	
	void OnMouseWheel( kissImage img, int deltaX, int deltaY, kissModifier keyMod )
	{
		Debug.Log( "OnMouseWheel:  " + img.name );
	}
}
