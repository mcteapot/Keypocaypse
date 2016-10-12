using UnityEngine;
using System.Collections;
using kissUI;

[ExecuteInEditMode]
public class kissDragToMove : MonoBehaviour
{
	public kissRaycast		uiRaycast;
	public kissObject		objectToMove;
	// ---
	private HitInfo			hi = null;
	private int				mouseDown_OffsetX = 0;
	private int				mouseDown_OffsetY = 0;
	private int				mouseDown_X = 0;
	private int				mouseDown_Y = 0;
	private kissImage		imgSelf;


	void Start()
	{
		if( uiRaycast == null )
		{
			Transform root_tran = kissUtility.Find_kissUI_Root( transform );
			uiRaycast = root_tran.GetComponent< kissRaycast >();
		}

		imgSelf = gameObject.GetComponent< kissImage >();
	}


	[ kissInputEntryCall( title = "mouse down handler", type = InputHandlerType.MouseDown, index = 0 ) ]	//, button = kissButton.Right, modifier = kissModifier.Alt | kissModifier.Shift, ...
	public void onMouseDown()
	{
		if( uiRaycast == null )
		{
			Debug.LogWarning( "uiRaycast not set for '" + this.name + "'.  Aborting!", this );
			return;
		}
		
		if( objectToMove == null )
		{
			Debug.LogWarning( "objectToMove not set for '" + this.name + "'.  Aborting!", this );
			return;
		}

		if( imgSelf == null )
			imgSelf = gameObject.GetComponent< kissImage >();

		hi = uiRaycast.GetHitInfo( imgSelf.Tran );
		
		if( hi == null )
			hi = uiRaycast.hitInfo;

		//Debug.Log( "hi.level: " + hi.level );

		mouseDown_X = (int) hi.MousePos.x;
		mouseDown_Y = (int) hi.MousePos.y;

		mouseDown_OffsetX = (int) objectToMove.PosOffset.x;
		mouseDown_OffsetY = (int) objectToMove.PosOffset.y;
	}


	[ kissInputEntryCall( title = "mouse drag handler", type = InputHandlerType.MouseDrag, index = 0 ) ]
	public void onMouseDrag()
	{
		if( uiRaycast == null )
			return;
		
		if( objectToMove == null )
			return;
		
		int diff_X = mouseDown_X - (int) hi.MousePos.x;
		int diff_Y = mouseDown_Y - (int) hi.MousePos.y;
		
		int new_OffsetX = mouseDown_OffsetX - diff_X;
		int new_OffsetY = mouseDown_OffsetY - diff_Y;
		float new_OffsetZ = objectToMove.PosOffset.z;
		
		objectToMove.PosOffset = new Vector3( new_OffsetX, new_OffsetY, new_OffsetZ );
	}


}



