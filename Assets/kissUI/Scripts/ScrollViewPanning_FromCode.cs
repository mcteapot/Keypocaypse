using UnityEngine;
using System.Collections;
using kissUI;

[ExecuteInEditMode]
public class ScrollViewPanning_FromCode : MonoBehaviour
{
	#region 1. Variables

	public kissRaycast		uiRaycast;
	public kissScrolling	ScrollbarVert;
	public kissScrolling	ScrollbarHori;
	public kissObject		ScrollingContent;
	public Texture			UseMouseCursor;
	// --
	private int				mouseDown_X = 0;
	private int				mouseDown_Y = 0;
	private int				mouseDown_OffsetX = 0;
	private int				mouseDown_OffsetY = 0;
	private kissImage		this_img;
	private HitInfo			hi = null;

	#endregion


	#region 2. Unity Events

	void OnEnable()
	{
		this_img = GetComponent< kissImage >();
		
		if( this_img != null )
		{
			this_img.OnMouseDown += onMouseDown;
			this_img.OnMouseDrag += onMouseDrag;
			this_img.OnMouseUp += onMouseUp;
		}
		
	}

	void OnDisable()
	{
		if( this_img != null )
		{
			this_img.OnMouseDown -= onMouseDown;
			this_img.OnMouseDrag -= onMouseDrag;
			this_img.OnMouseUp -= onMouseUp;
		}
	}

	#endregion


	#region 3. kissUI Events

	public void onMouseDown( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		//Debug.Log( "ScrollViewPanning_FromCode.onMouseDown()", img );

		if( uiRaycast == null )
		{
			Transform root_tran = kissUtility.Find_kissUI_Root( transform );
			uiRaycast = root_tran.GetComponent< kissRaycast >();
		}

		if( uiRaycast == null )
			return;

		if( ScrollingContent == null )
			return;

		hi = uiRaycast.GetHitInfo( this_img.Tran );
		
		if( hi == null )
			hi = uiRaycast.hitInfo;

		mouseDown_X = (int) hi.MousePos.x;
		mouseDown_Y = (int) hi.MousePos.y;

		mouseDown_OffsetX = (int) ScrollingContent.PosOffset.x;
		mouseDown_OffsetY = (int) ScrollingContent.PosOffset.y;

		if( UseMouseCursor != null && Btn == kissMouseButton.Middle )
		{
			img.stateCursors[ (int) kissState.Pressed ] = UseMouseCursor;
			img.stateCursorHotspots[ (int) kissState.Pressed ] = new Vector2( 16, 16 );
		}
	}

	public void onMouseDrag( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		//Debug.Log( "ScrollViewPanning_FromCode.onMouseDrag()", img );

		if( uiRaycast == null )
			return;

		if( ScrollingContent == null )
			return;

		if( Btn != kissMouseButton.Middle )
			return;

		kissObject parent_ko = ScrollingContent.Node.Parent.obj as kissObject;

		int diff_X = mouseDown_X - (int) hi.MousePos.x;
		int diff_Y = mouseDown_Y - (int) hi.MousePos.y;
		
		int new_OffsetX = mouseDown_OffsetX - diff_X;
		int new_OffsetY = mouseDown_OffsetY - diff_Y;
		float new_OffsetZ = ScrollingContent.PosOffset.z;

		if( parent_ko != null )
		{
			if( ScrollbarHori != null )
			{
				int ContentWidth = ScrollingContent.Width + ScrollingContent.Margin.right + ScrollingContent.Margin.left;
				int widthDiff = ContentWidth - parent_ko.Width;
				new_OffsetX = Mathf.Clamp( new_OffsetX, 0, widthDiff );

				float onePercentX = 100f / widthDiff;
				float percentX = new_OffsetX * onePercentX;
				//Debug.Log( "percentX: " + percentX );
				
				ScrollbarHori.SetHoriPercent( percentX );
			}

			if( ScrollbarVert != null )
			{
				int ContentHeight = ScrollingContent.Height + ScrollingContent.Margin.top + ScrollingContent.Margin.bottom;
				int heightDiff = ContentHeight - parent_ko.Height;
				new_OffsetY = Mathf.Clamp( new_OffsetY, 0, heightDiff );

				float onePercentY = 100f / heightDiff;
				float percentY = new_OffsetY * onePercentY;
				//Debug.Log( "percentY: " + percentY );

				ScrollbarVert.SetVertPercent( percentY );
			}
		}
		
		ScrollingContent.PosOffset = new Vector3( new_OffsetX, new_OffsetY, new_OffsetZ );
	}

	public void onMouseUp( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos, bool isOver )
	{
		//Debug.Log( "ScrollViewPanning_FromCode.onMouseUp()", img );

		if( UseMouseCursor != null && Btn == kissMouseButton.Middle )
		{
			img.stateCursors[ (int) kissState.Pressed ] = null;
			img.stateCursorHotspots[ (int) kissState.Pressed ] = new Vector2( 0, 0 );
			img.Refresh();
		}
	}

	#endregion


	// Other
	
}
