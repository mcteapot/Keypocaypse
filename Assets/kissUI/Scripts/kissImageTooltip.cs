using UnityEngine;
using System.Collections;

namespace kissUI
{
	//TODO:  move to Examples/Scripts source for all
	[ExecuteInEditMode]
	public class kissImageTooltip : MonoBehaviour
	{
		public kissImage imgTooltip;
		public kissRaycast raycastCam;
		float nMouseEnter_Time;
		public float PopupShownAfter = 1f;
		public bool PopupShown;
		public bool isMouseOverStill = false;
		Vector2 v2MousePos = new Vector2();
	//	static bool cancelShowngTooltip = false;
		kissImage imgParent;
		
		void Update ()
		{
			if( isMouseOverStill )
			{
				float diff1 = Time.realtimeSinceStartup - nMouseEnter_Time;
				if( PopupShown == false && diff1 > PopupShownAfter )
				{
					PopupShown = true;
					kissImage.ShowHideRegions( imgTooltip, true );
					
					//kissUtility.ShowHideChildren_Recursive( imgTooltip.Tran, true );
					
					if( imgParent == null )
						imgParent = this.GetComponent< kissImage >();
					
					//kissUtility.SetHiddenBy( imgTooltip.Tran, imgParent.Tran, false );
					kissUtility.HiddenBy_SetEnabled( imgTooltip.Tran, imgParent.Tran, false, true );
					
					//kissUtility.ReCalculate_SizePosition( imgTooltip.Tran );
				}
			}
		}
		
		
		public void onMouseEnter()
		{
			isMouseOverStill = true;
			nMouseEnter_Time = Time.realtimeSinceStartup;
			
	//		cancelShowngTooltip = false;
	//		StartCoroutine( ShowTooltipAfterDelay( 2f ) );
		}
		
		public void onMouseLeave()
		{
	//		cancelShowngTooltip = true;
			
			isMouseOverStill = false;
			PopupShown = false;
			kissImage.ShowHideRegions( imgTooltip, false );
			
			//kissUtility.ShowHideChildren_Recursive( imgTooltip.Tran, false );
			
			if( imgParent == null )
				imgParent = this.GetComponent< kissImage >();
			
			//kissUtility.SetHiddenBy( imgTooltip.Tran, imgParent.Tran, true );
			kissUtility.HiddenBy_SetEnabled( imgTooltip.Tran, imgParent.Tran, true, true );
			
			//kissUtility.ReCalculate_SizePosition( imgTooltip.Tran );
		}
		
		public void onMouseDown()
		{
	//		cancelShowngTooltip = true;
			
			isMouseOverStill = false;
			PopupShown = false;
			kissImage.ShowHideRegions( imgTooltip, false );
			
			//kissUtility.ShowHideChildren_Recursive( imgTooltip.Tran, false );
			
			if( imgParent == null )
				imgParent = this.GetComponent< kissImage >();
			
			//kissUtility.SetHiddenBy( imgTooltip.Tran, imgParent.Tran, true );
			kissUtility.HiddenBy_SetEnabled( imgTooltip.Tran, imgParent.Tran, true, true );
			
			//kissUtility.ReCalculate_SizePosition( imgTooltip.Tran );
		}
		
		public void onMouseUp()
		{
			float fStart = Time.realtimeSinceStartup;
			kissObject found_obj = this.transform.GetComponent< kissObject >();
			kissNode found_cComp = found_obj == null ? null : found_obj.Node.Parent;
			float fEnd = Time.realtimeSinceStartup;
			if( found_cComp != null )
				Debug.Log( "FOUND Parent: " + found_cComp.comp.name + " in " + (fEnd - fStart).ToString() + " seconds" );
		}
		
		public void onMouseMoved()
		{
			//Debug.Log( "onMouseMoved" );
			
			v2MousePos = raycastCam.GetMouseRelativePos( imgTooltip );
			 
			imgTooltip.PosOffset = new Vector3( v2MousePos.x + 10, v2MousePos.y - imgTooltip.Height - 19, imgTooltip.PosOffset.z );
			
		}
		
	//	public static IEnumerator WaitForRealSeconds( float delay )
	//	{
	//		float start = Time.realtimeSinceStartup;
	//		while( Time.realtimeSinceStartup < start + delay && cancelShowngTooltip == false )
	//		{
	//			yield return null;
	//		}
	//	}
	//	
	//	private IEnumerator ShowTooltipAfterDelay( float delay )
	//	{
	//		Debug.Log( "Delay for >>>>>>" );
	//		
	//		yield return StartCoroutine( WaitForRealSeconds( delay ) );
	//		
	//		if( cancelShowngTooltip == false )
	//			Debug.Log( "Execute Here <<<<<<" );
	//	}
		
	}
}


