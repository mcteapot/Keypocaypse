using UnityEngine;
using System.Collections;
using kissUI;

public class DragSelectionArea : MonoBehaviour
{
	public kissRaycast	uiRaycast;
	public kissObject	selectionRect;
	public bool			isVisible = false;
	
	private HitInfo		hi = null;
	private int			mouseDown_OffsetX = 0;
	private int			mouseDown_OffsetY = 0;
	private int			mouseDown_X = 0;
	private int			mouseDown_Y = 0;
	private int			mouseDown_W = 0;
	private int			mouseDown_H = 0;

	void Start() {} //...

	public void onMouseDown()
	{
		if( uiRaycast == null )
		{
			Transform root_tran = kissUtility.Find_kissUI_Root( transform );
			uiRaycast = root_tran.GetComponent< kissRaycast >();
		}

		if( uiRaycast == null )
			return;

		hi = uiRaycast.GetHitInfo( gameObject.transform );
		
		if( hi == null )
			hi = uiRaycast.hitInfo;

		if( hi.level != 0 )
			return;

		//Debug.Log( "DSA  hi.level: " + hi.level );

		mouseDown_X = (int) hi.MousePos.x;
		mouseDown_Y = (int) hi.MousePos.y;

		mouseDown_W = selectionRect.Width;
		mouseDown_H = selectionRect.Height;

		float diff_X = selectionRect.transform.position.x - uiRaycast.transform.position.x;
		int new_OffsetX = mouseDown_X - (int) diff_X;
		
		float diff_Y = selectionRect.transform.position.y - uiRaycast.transform.position.y;
		int new_OffsetY = mouseDown_Y - (int) diff_Y - mouseDown_H/2;
		
		float new_OffsetZ = selectionRect.PosOffset.z;
		
		selectionRect.PosOffset = new Vector3( new_OffsetX, new_OffsetY, new_OffsetZ );

		mouseDown_OffsetX = (int) selectionRect.PosOffset.x;
		mouseDown_OffsetY = (int) selectionRect.PosOffset.y;

		kissUtility.ReCalculate_SizePosition( selectionRect.Node );
		
		ShowSelectionArea();
	}
	
//	public void onMouseDrag()
//	{
//		float diffW = hi.MousePosLast.x - hi.MousePos.x;
//		
//		float diffX = 0;
//		float newOffX = selectionRect.PosOffset.x;
//		
//		if( diffW <= 0 )
//		{
//			newOffX = mouseDown_OffsetX;
//			selectionRect.Width = (int) mouseDown_W - (int) diffW;
//		}
//		else
//		{
//			diffX = (hi.MousePosLast.x - mouseDown_OffsetX) - hi.MousePos.x;
//			newOffX = (hi.MouseDown_OffsetX - diffX);
//			
//			selectionRect.Width = (int) mouseDown_W + (int) diffW;
//		}
//		
//		float diffH = hi.MousePosLast.y - hi.MousePos.y;
//		
//		float diffY = 0;
//		float newOffY = selectionRect.PosOffset.y;
//		
//		if( diffH <= 0 )
//		{
//			newOffY = mouseDown_OffsetY;
//			selectionRect.Height = (int) mouseDown_H - (int) diffH;
//		}
//		else
//		{
//			diffY = (hi.MousePosLast.y - mouseDown_OffsetY) - hi.MousePos.y;
//			newOffY = (hi.MouseDown_OffsetY - diffY);
//			
//			selectionRect.Height = (int) mouseDown_H + (int) diffH;
//		}
//		
//		float newOffZ = selectionRect.PosOffset.z;
//		
//		//if( diffW > 0 || diffH > 0 )
//			selectionRect.PosOffset = new Vector3( newOffX, newOffY, newOffZ );
//		
//		kissUtility.ReCalculate_SizePosition( selectionRect.transform, selectionRect.Node );
//	}

	public void onMouseDrag()
	{
		if( hi.level != 0 )
			return;

		int diff_W = mouseDown_X - (int) hi.MousePos.x;
		
		//int newOffX = (int) selectionRect.PosOffset.x;
		int newOffX = mouseDown_OffsetX;
		
		if( diff_W <= 0 )
		{
			newOffX = mouseDown_OffsetX;
			selectionRect.Width = mouseDown_W - diff_W;
		}
		else
		{
			//int diff_X = (mouseDown_X - mouseDown_OffsetX) - (int) hi.MousePos.x;
			int diff_X = mouseDown_X - (int) hi.MousePos.x;
			newOffX = (mouseDown_OffsetX - diff_X);

			selectionRect.Width = mouseDown_W + diff_W;
		}
		
		int diff_H = mouseDown_Y - (int) hi.MousePos.y;
		
		//int newOffY = (int) selectionRect.PosOffset.y;
		int newOffY = mouseDown_OffsetY;
		
		if( diff_H <= 0 )
		{
			newOffY = mouseDown_OffsetY;
			selectionRect.Height = mouseDown_H - diff_H;
		}
		else
		{
			//int diff_Y = (mouseDown_Y - mouseDown_OffsetY) - (int) hi.MousePos.y;
			int diff_Y = mouseDown_Y - (int) hi.MousePos.y;
			//newOffY = (mouseDown_OffsetY - diff_Y);
			newOffY = (mouseDown_OffsetY - diff_Y + mouseDown_H/2);
			
			//selectionRect.Height = mouseDown_H + diff_H;
			selectionRect.Height = mouseDown_H/2 + diff_H;
		}
		
		float newOffZ = selectionRect.PosOffset.z;
		
		//if( diffW > 0 || diffH > 0 )
		selectionRect.PosOffset = new Vector3( newOffX, newOffY, newOffZ );
		
		kissUtility.ReCalculate_SizePosition( selectionRect.Node );
	}
	
	public void onMouseUp()
	{
		if( hi.level != 0 )
			return;
		
		HideSelectionArea();
		
		selectionRect.Width = 0;
		selectionRect.Height = 0;
		
		selectionRect.PosOffset = new Vector3( 0f, 0f, selectionRect.PosOffset.z );
		
		kissUtility.ReCalculate_SizePosition( selectionRect.Node );
	}
	
	public void ShowSelectionArea()
	{
		if( selectionRect.ObjectType == kissObjectType.Image )
		{
			(selectionRect as kissImage).IsVisible = true;
		}
		else if( selectionRect.ObjectType == kissObjectType.Group || selectionRect.ObjectType == kissObjectType.Layout )
		{
			selectionRect.HideChildren = false;
			kissUtility.Children_SetHiddenBy( selectionRect.transform, selectionRect.transform, selectionRect.HideChildren );
		}

		//kissUtility.ReCalculate_Children( selectionRect.transform );
		kissUtility.ReCalculate_SizePosition( selectionRect.Node );
		
		isVisible = true;
	}
	
	public void HideSelectionArea()
	{
		if( selectionRect.ObjectType == kissObjectType.Image )
		{
			(selectionRect as kissImage).IsVisible = false;
		}
		else if( selectionRect.ObjectType == kissObjectType.Group || selectionRect.ObjectType == kissObjectType.Layout )
		{
			selectionRect.HideChildren = true;
			kissUtility.Children_SetHiddenBy( selectionRect.transform, selectionRect.transform, selectionRect.HideChildren );
		}

		//kissUtility.ReCalculate_Children( selectionRect.transform );
		kissUtility.ReCalculate_SizePosition( selectionRect.Node );
		
		isVisible = false;
	}
	
}
