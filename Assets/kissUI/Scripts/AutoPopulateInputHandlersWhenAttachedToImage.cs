using UnityEngine;
using System.Collections;
using kissUI;

public class AutoPopulateInputHandlersWhenAttachedToImage : MonoBehaviour
{
	public kissRaycast		uiRaycast;
	public kissLayout		LayoutToMove;
	// for: -- Mouse Up --
	[ kissInputEntryGet(	title = "get Test field",    index = 0, type = InputHandlerType.MouseUp ) ]
	[ kissInputEntryModify( title = "modify Test field", index = 1, type = InputHandlerType.MouseUp, entry = 0, modification = Modification.Multiply, entry2Value = "1" ) ]
	[ kissInputEntrySet(	title = "set Test field",    index = 2, type = InputHandlerType.MouseUp, entry = 1 ) ]
	public int TestField = 0;

	//---
	private HitInfo			hi = null;
	private int				mouseDown_OffsetX = 0;
	private int				mouseDown_OffsetY = 0;
	private int				mouseDown_X = 0;
	private int				mouseDown_Y = 0;

	void Start()
	{
		if( uiRaycast == null )
		{
			Transform tran_Root = kissUtility.Find_kissUI_Root( transform );
			uiRaycast = tran_Root.GetComponent< kissRaycast >();
		}
	}

	// for: -- Mouse Down --
//	[ kissInputEntryCall(	type = InputHandlerType.MouseDown, button = kissButton.Middle, modifier = kissModifier.Alt | kissModifier.Shift, index = 0, title = "mouse down handler 0") ]
	public void onMouseDown()
	{
		if( uiRaycast == null )
		{
			Debug.LogWarning( "uiRaycast not set for '" + this.name + "'.  Abort!" );
			return;
		}
		
		if( LayoutToMove == null )
		{
			Debug.LogWarning( "LayoutToMove not set for '" + this.name + "'.  Abort!" );
			return;
		}

		hi = uiRaycast.GetHitInfo( gameObject.transform );
		
		if( hi == null )
			hi = uiRaycast.hitInfo;
		
		mouseDown_X = (int) hi.MousePos.x;
		mouseDown_Y = (int) hi.MousePos.y;

		mouseDown_OffsetX = (int) LayoutToMove.PosOffset.x;
		mouseDown_OffsetY = (int) LayoutToMove.PosOffset.y;
		
	}

	// for: -- Mouse Drag --
//	[ kissInputEntryCall(	type = InputHandlerType.MouseDrag, index = 1, title = "mouse drag handler 1" ) ]
	public void onMouseDrag()
	{
		if( uiRaycast == null )
			return;
		
		if( LayoutToMove == null )
			return;

//		float diffX = (hi.MousePosLast.x - mouseDown_OffsetX) - hi.MousePos.x;
//		float diffY = (hi.MousePosLast.y - mouseDown_OffsetY) - hi.MousePos.y;
//		
//		float newOffX = (hi.MouseDown_OffsetX - diffX);
//		float newOffY = (hi.MouseDown_OffsetY - diffY);
//		float newOffZ = LayoutToMove.PosOffset.z;

		int diff_X = mouseDown_X - (int) hi.MousePos.x;
		int diff_Y = mouseDown_Y - (int) hi.MousePos.y;
		
		int new_OffsetX = mouseDown_OffsetX - diff_X;
		int new_OffsetY = mouseDown_OffsetY - diff_Y;
		float new_OffsetZ = LayoutToMove.PosOffset.z;

		LayoutToMove.PosOffset = new Vector3( new_OffsetX, new_OffsetY, new_OffsetZ );
		
	}

	// for: -- Mouse Drag --
//	[ kissInputEntryCall(	type = InputHandlerType.MouseDrag, index = 2, title = "mouse drag handler 2" ) ]
	public void modify_Handler1_Entry(){}

	// for: -- Mouse Drag --
//	[ kissInputEntryCall(	type = InputHandlerType.MouseDrag, index = 3, title = "mouse drag handler 3" ), kissInputFuncParam( index = 0, value = "one" ), kissInputFuncParam( index = 1, useEntry = 0 ) ]
	public void testOne( string testing1, string testing2 )
	{
		Debug.Log( testing1 + ", " + testing2 );
	}

	// for: -- Mouse Drag --
//	[ kissInputEntryCall(	type = InputHandlerType.MouseDrag, index = 4, title = "mouse drag handler 4" ) ]
	public void tada()
	{
		
	}
	
}
