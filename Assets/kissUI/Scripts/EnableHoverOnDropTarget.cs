using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using kissUI;

[ExecuteInEditMode]
public class EnableHoverOnDropTarget : MonoBehaviour
{
	public kissRaycast			uiRaycast;
	public List< kissImage >	dropTarget;
	// --
	private kissImage			imgSelf;
	private HitInfo				hi = null;



	#region Unity Events

	void Start()		//added so Inspector shows Enable/Disable checkbox.
	{
		if( uiRaycast == null )
		{
			Transform root_tran = kissUtility.Find_kissUI_Root( transform );
			uiRaycast = root_tran.GetComponent< kissRaycast >();
		}
		
		imgSelf = gameObject.GetComponent< kissImage >();
	}

	#endregion 



	#region kissUI Events

	public void onMouseDown()
	{
		if( imgSelf == null )
			imgSelf = gameObject.GetComponent< kissImage >();

		//Debug.Log( "EnableHoverOnDropTarget.onMouseDown()", imgSelf );

		if( uiRaycast == null )
		{
			Transform root_tran = kissUtility.Find_kissUI_Root( transform );
			uiRaycast = root_tran.GetComponent< kissRaycast >();
		}

		if( uiRaycast == null )
		{
			Debug.LogWarning( "uiRaycast not set for '" + this.name + "'.  Aborting!", this );
			return;
		}

		hi = uiRaycast.GetHitInfo( imgSelf.Tran );
		
		if( hi == null )
			hi = uiRaycast.hitInfo;

		for( int i = 0; i < imgSelf.ClippedBy.Count; i++ )
		{
			if( imgSelf.ClippedBy[ i ].tran.name == "Content" )
				imgSelf.ClippedBy[ i ].enabled = false;
		}

		imgSelf.PosOffset = new Vector3( imgSelf.PosOffset.x, imgSelf.PosOffset.y, -10 );


		int missing_DropTargets = 0;

		for( int i = 0; i < dropTarget.Count; i++ )
		{
			kissImage img = dropTarget[ i ];

			if( img == null )
			{
				missing_DropTargets++;
				continue;
			}

			kissImageData hoverData = img.StateData[ (int) kissState.Hover ];

			if( hoverData != null )
				hoverData.isStateEnabled = true;
		}

		if( missing_DropTargets > 0 )
			Debug.LogWarning( "Warning:  Some Drop Targets seem to be missing! Can you update them?  (left click this Debug entry to ping the Drag Source that needs updating!)", imgSelf );
	}


	public void onMouseUp()
	{
		//Debug.Log( "EnableHoverOnDropTarget.onMouseUp()" );

        imgSelf.PosOffset = new Vector3( 0f, 0f, -0.1f );

		for( int i = 0; i < dropTarget.Count; i++ )
		{
			kissImage img = dropTarget[ i ];

			if( img == null )
				continue;

			kissImageData hoverData = img.StateData[ (int) kissState.Hover ];

			if( hoverData != null )
			{
				hoverData.isStateEnabled = false;
				img.ActiveState = kissState.Normal;
				img.Update_State();
			}
		}
	}

	#endregion



	#region Other

	///other code here

	#endregion
	
}
