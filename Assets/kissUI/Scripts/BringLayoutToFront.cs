using UnityEngine;
using System;
using System.Collections;
using kissUI;

public class BringLayoutToFront : MonoBehaviour
{
	public kissRaycast uiRaycast;
	public kissLayout[] myLayouts;
	public kissImage[] myTaskbarAppBtn;
	public int InFrontPresently;

	void Start () {}
	//void Update () {}
	
	public void bringToFront( int layoutIndex )
	{
		if( layoutIndex >= myLayouts.Length )
			return;
		
		if( myLayouts[ layoutIndex ] == null )
			return;
		
		if( myLayouts[ layoutIndex ].HideChildren == true )
			return;
		
		//Debug.Log( "InFrontPresently  Name: " + myLayouts[ InFrontPresently ].name );
		//bool isLayoutInFront = IsLayoutInFrontNow( myLayouts[ InFrontPresently ].transform );
		
		bool isLayoutInFrontNow = InFrontPresently == layoutIndex;
		
//		if( isLayoutInFrontNow )
//		{
//			if( myLayouts[ InFrontPresently ].HideChildren == true )
//				isLayoutInFrontNow = false;
//		}
		
		if( isLayoutInFrontNow == false )
		{
			kissLayout front_lo = myLayouts[ layoutIndex ];
			kissLayout back_lo = myLayouts[ InFrontPresently ];
			
			front_lo.PosOffset = new Vector3( front_lo.PosOffset.x, front_lo.PosOffset.y, -30 );
			back_lo.PosOffset = new  Vector3( back_lo.PosOffset.x, back_lo.PosOffset.y, 0 );
			
			kissLayout.ReCalculate_Position( front_lo );
			kissLayout.ReCalculate_Position( back_lo );
			
			if( uiRaycast != null && myTaskbarAppBtn[ layoutIndex ] != null )
				uiRaycast.ChangeFocusToImage( myTaskbarAppBtn[ layoutIndex ] );
			
			InFrontPresently = layoutIndex;
			//Debug.Log( "InFrontPresently  Changed to Name: " + myLayouts[ InFrontPresently ].name );
		}
	}
	
	public void bringToFront( GameObject objLayout )
	{
		Debug.Log( "Layout Object: " + objLayout );
		//InFrontPresently = layoutIndex;
	}
	
	public bool IsLayoutInFrontNow( Transform layout_tran )
	{
		bool isInFront = false;
		
		for( int i = 0; i < myLayouts.Length; i++ )
		{
			if( myLayouts[ i ].transform == layout_tran )
			{
				if( i == InFrontPresently )
					isInFront = true;
				
				break;
			}
		}
		
		return isInFront;
	}
	
	public int GetLayoutIndex( Transform layout_tran )
	{
		int index = -1;
		
		for( int i = 0; i < myLayouts.Length; i++ )
		{
			if( myLayouts[ i ].transform == layout_tran )
			{
				if( i == InFrontPresently )
					index = i;
				
				break;
			}
		}
		
		return index;
	}
	
}
