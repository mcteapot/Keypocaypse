using UnityEngine;
using System.Collections;
using kissUI;

public class ShowHideLayout : MonoBehaviour
{
	public kissLayout myLayout;	
	public bool isVisible = false;
	public BringLayoutToFront BL2F;
	
	public void ToggleVisibility()
	{
		if( myLayout == null )
		{
			Debug.LogWarning( this.name + " - ShowHideLayout:  MyLayout not provided! Aborting!" );
			return;
		}
		
		if( isVisible )
			HideLayout();
		else
			ShowLayout();
	}
	
	public void ToggleVisibility2()
	{
		if( myLayout == null )
		{
			Debug.LogWarning( this.name + " - ShowHideLayout:  MyLayout not provided! Aborting!" );
			return;
		}
		
		if( isVisible )
			HideLayout2();
		else
			ShowLayout();
	}
	
	public void ShowLayout()
	{
		myLayout.HideChildren = false;
		kissUtility.Children_SetHiddenBy( myLayout.transform, myLayout.transform, myLayout.HideChildren );
		
		//kissUtility.ReCalculate_Children( myLayout.transform );
		kissUtility.ReCalculate_SizePosition( myLayout.Node );
		
		isVisible = true;
	}
	
	public void HideLayout()
	{
		if( BL2F != null )
		{
			bool isInFrontNow = BL2F.IsLayoutInFrontNow( myLayout.transform );
			if( isInFrontNow == false )
				return;
		}
		
		myLayout.HideChildren = true;
		kissUtility.Children_SetHiddenBy( myLayout.transform, myLayout.transform, myLayout.HideChildren );
		
		//kissUtility.ReCalculate_Children( myLayout.transform );
		kissUtility.ReCalculate_SizePosition( myLayout.Node );
		
		isVisible = false;
		
		if( BL2F != null )
		{
			int idx = BL2F.GetLayoutIndex( myLayout.transform );
			int bringToFront = 0;
			if( idx == 0 )
				bringToFront = 1;
			else if( idx == 1 )
				bringToFront = 0;
			
			BL2F.bringToFront( bringToFront );
		}
	}
	
	private void HideLayout2()
	{
		myLayout.HideChildren = true;
		kissUtility.Children_SetHiddenBy( myLayout.transform, myLayout.transform, myLayout.HideChildren );
		
		//kissUtility.ReCalculate_Children( myLayout.transform );
		kissUtility.ReCalculate_SizePosition( myLayout.Node );
		
		isVisible = false;
	}
}




