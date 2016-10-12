using UnityEngine;
using System;
using System.Collections;
using kissUI;

public class LayoutToFrontWithDarkerBack : MonoBehaviour
{
	public kissLayout LayoutToFront;
	public kissImage  DarkerBack;
	public int desiredDebth;
	
	private int origDepth;
	private int origDepthImg;

	void Start () {}
	//void Update () {}
	
	public void BringToFront()
	{
		if( LayoutToFront == null )
			return;
		
//		if( cc == null )
//			cc = kissUtility.GetCachedComp( LayoutToFront.transform );
		
		origDepth = (int) LayoutToFront.PosOffset.z;
		LayoutToFront.PosOffset = new Vector3( LayoutToFront.PosOffset.x, LayoutToFront.PosOffset.y, (float) desiredDebth );
		
		kissUtility.ReCalculate_Children( LayoutToFront.Node.Parent );
		
		if( DarkerBack != null )
		{
			DarkerBack.Show();
			//kissImage.ReCalculate_Visibility( DarkerBack );
			//Debug.Log( "1) img.Parent:  " + DarkerBack.Parent.name );
			
			origDepthImg = (int) DarkerBack.PosOffset.z;
			DarkerBack.PosOffset = new Vector3( DarkerBack.PosOffset.x, DarkerBack.PosOffset.y, (float) desiredDebth + 1 );
			kissUtility.ReCalculate_Children( DarkerBack.Node.Parent );
		}
	}
	
	public void RestoreToOriginals()
	{
		if( LayoutToFront == null )
			return;
		
//		if( cc == null )
//			cc = kissUtility.GetCachedComp( LayoutToFront.transform );
		
		LayoutToFront.PosOffset = new Vector3( LayoutToFront.PosOffset.x, LayoutToFront.PosOffset.y, (float) origDepth );
		kissUtility.ReCalculate_Children( LayoutToFront.Node.Parent );
		
		if( DarkerBack != null )
		{
			DarkerBack.Hide();
			//kissImage.ReCalculate_Visibility( DarkerBack );
			
			DarkerBack.PosOffset = new Vector3( DarkerBack.PosOffset.x, DarkerBack.PosOffset.y, (float) origDepthImg );
			kissUtility.ReCalculate_Children( DarkerBack.Node.Parent );
			//Debug.Log( "2) img.Parent:  " + DarkerBack.Parent.name );
		}
	}
	
	public void onMouseHeld()
	{
		Debug.Log( "onMouseHeld", this );
	}
}
