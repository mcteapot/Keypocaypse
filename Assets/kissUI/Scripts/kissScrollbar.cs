using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using kissUI;

[ExecuteInEditMode]
public class kissScrollbar : MonoBehaviour
{
	#region 0. Enums
	
	public enum OrientLR
	{
		LeftToRight,
		RightToLeft
	}
	
	public enum OrientBT
	{
		BottomToTop,
		TopToBottom
	}
	
	public enum ScrollOrient
	{
		Vertical,
		Horizontal
	}
	
	#endregion



	#region 1. Variables
	
	public kissRaycast uiRaycast = null;
	public kissObject Content;
	//public kissObject DragBounds = null;
	public kissImage ScrollThumb = null;
	public kissImage imgGutterTopOrRight;
	public kissImage imgGutterBottomOrLeft;
	public bool isDraggable = true;

	public Rect DraggableArea = new Rect();
	//TODO: maybe turn these 2 into Properties, and raise OnValueChanged from them
	public float XOffsetPercent = 0f;
	public float YOffsetPercent = 0f;

	public ScrollOrient scrollOrientation = ScrollOrient.Vertical;
	
	public OrientLR orientLR;
	public OrientBT orientBT;
	public bool onParentResize_ApplyExistingOffsetPercents = true;

	//------

	Vector3		PosOffset = new Vector3();
	int			clippingHeight = 0;
	int			nClientHeight = 0;
	int			heightDiff = 0;
	int			clippingWidth = 0;
	int			nClientWidth = 0;
	int			widthDiff = 0;
	float		onePercent = 0f;
	HitInfo		hi = null;
	int			mouseDown_X = 0;
	int			mouseDown_Y = 0;
	int			mouseDown_OffsetX = 0;
	int			mouseDown_OffsetY = 0;
	
	#endregion



	#region 2. Delegates

	//TODO:

	public delegate void del_OnValueChanged( kissScrollbar sb, float XOffset_Percent, float YOffset_Percent );
	public static del_OnValueChanged OnValueChanged = null;

	public delegate void del_Hori_OnValueChanged( kissScrollbar sb, float XOffset_Percent );
	public static del_Hori_OnValueChanged Hori_OnValueChanged = null;

	public delegate void del_Verti_OnValueChanged( kissScrollbar sb, float YOffset_Percent );
	public static del_Verti_OnValueChanged Verti_OnValueChanged = null;

	#endregion



	#region 3. Unity Events
	
	void Start ()
	{
		if( uiRaycast == null )
		{
			Transform root_tran = kissUtility.Find_kissUI_Root( transform );
			uiRaycast = root_tran.GetComponent< kissRaycast >();
		}

		if( ScrollThumb == null )
			return;

		//hi = uiRaycast.GetHitInfo( ScrollThumb.Tran );
	}
	
	void OnEnable()
	{
		if( ScrollThumb == null )
			return;

		if( ScrollThumb.Node == null || ScrollThumb.Node.Parent == null )
			return;

		kissObject drag_boounds_comp = ScrollThumb.Node.Parent.comp as kissObject;

		if( drag_boounds_comp != null )
		{
			drag_boounds_comp.OnSizeChanged += Parent_onSizeChanged;
			drag_boounds_comp.OnMarginsChanged += Parent_onSizeChanged;
			drag_boounds_comp.OnPaddingChanged += Parent_onSizeChanged;
		}

		cr_Content_UpdatePosOffsets_Started = false;
		cr_ResizeGutters_Started = false;
	}

	void OnDisable()
	{
		if( ScrollThumb == null )
			return;

		if( ScrollThumb.Node == null || ScrollThumb.Node.Parent == null )
			return;

		kissObject drag_boounds_comp = ScrollThumb.Node.Parent.comp as kissObject;

		if( drag_boounds_comp != null )
		{
			drag_boounds_comp.OnSizeChanged -= Parent_onSizeChanged;
			drag_boounds_comp.OnMarginsChanged -= Parent_onSizeChanged;
			drag_boounds_comp.OnPaddingChanged -= Parent_onSizeChanged;
		}
	}

	//	void Update () {}

	#endregion



	#region 4. kiss Events
	
	public void Parent_onSizeChanged()
	{
		Update_DraggableArea();

		if( onParentResize_ApplyExistingOffsetPercents )
			SetOffset_usingPercents();

		Content_UpdatePosOffsets();
		
		ResizeGutters();
	}

	public void onMouseDown()
	{
		//Debug.Log( "onMouseDown()" );

		hi = uiRaycast.GetHitInfo( ScrollThumb.Tran );
		
		if( hi == null )
			hi = uiRaycast.hitInfo;
		
		mouseDown_X = (int) hi.MousePos.x;
		mouseDown_Y = (int) hi.MousePos.y;

		mouseDown_OffsetX = (int) ScrollThumb.PosOffset.x;
		mouseDown_OffsetY = (int) ScrollThumb.PosOffset.y;
	}

	public void onMouseDrag()
	{
		Dragging_UpdateOffsets();
		
		Content_UpdatePosOffsets();
		
		ResizeGutters();
	}

	#endregion



	#region Other

	public void Dragging_UpdateOffsets()
	{
		if( uiRaycast == null )
			return;

		if( ScrollThumb == null )
			return;

		if( isDraggable == false )
			return;

		float diffX = mouseDown_X - hi.MousePos.x;
		float diffY = mouseDown_Y - hi.MousePos.y;

		float newY = Mathf.Clamp( mouseDown_OffsetY - diffY, DraggableArea.y, DraggableArea.height );
		float newX = Mathf.Clamp( mouseDown_OffsetX - diffX, DraggableArea.x, DraggableArea.width );

		float newZ = ScrollThumb.PosOffset.z;
		
		ScrollThumb.PosOffset = new Vector3( newX, newY, newZ );

		Thumb_CalculatePercents();
		
	}

	public void Refresh_PosOffsets()
	{
		if( ScrollThumb == null )
			return;
		
		if( isDraggable == false )
			return;
		
		float newY = Mathf.Clamp( ScrollThumb.PosOffset.y, DraggableArea.y, DraggableArea.height );
		float newX = Mathf.Clamp( ScrollThumb.PosOffset.x, DraggableArea.x, DraggableArea.width );
		float newZ = ScrollThumb.PosOffset.z;
		
		ScrollThumb.PosOffset = new Vector3( newX, newY, newZ );

		Thumb_CalculatePercents();
		
	}

	public void Content_UpdatePosOffsets()
	{
		if( Content == null )
			return;

		if( cr_Content_UpdatePosOffsets_Started == false )
			StartCoroutine( CR_Content_UpdatePosOffsets() );
	}

	private bool cr_Content_UpdatePosOffsets_Started = false;

	private IEnumerator CR_Content_UpdatePosOffsets()
	{
		cr_Content_UpdatePosOffsets_Started = true;
		yield return null;


		kissObject parent_comp = Content.Node.Parent.comp as kissObject;

		if( scrollOrientation == ScrollOrient.Vertical )
		{
			if( parent_comp != null )
				clippingHeight = parent_comp.Height;
			
			nClientHeight = Content.Height + Content.Margin.top + Content.Margin.bottom;
			heightDiff = nClientHeight - clippingHeight;
			onePercent = 100f / heightDiff;

			PosOffset.x = Content.PosOffset.x;
			PosOffset.y = Mathf.Round( YOffsetPercent / onePercent );
			PosOffset.z = Content.PosOffset.z;
		}
		else
		{
			if( parent_comp != null )
				clippingWidth = parent_comp.Width;
			
			nClientWidth = Content.Width + Content.Margin.right + Content.Margin.left;
			widthDiff = nClientWidth - clippingWidth;
			onePercent = 100f / widthDiff;

			PosOffset.x = Mathf.Round( XOffsetPercent / onePercent );
			PosOffset.y = Content.PosOffset.y;
			PosOffset.z = Content.PosOffset.z;			
		}
		
		Content.PosOffset = PosOffset; //new Vector3( newXOffset, newYOffset, newZOffset );
		// kissImage's Update() will check if PosOffset changes, and change its position automagically.
		// PosOffset Works with Unitys Animation Editor too.. I think it still does! :P
		

		cr_Content_UpdatePosOffsets_Started = false;
	}

	public void Update_DraggableArea()
	{
		if( ScrollThumb == null )
			return;

		kissObject drag_boounds_comp = ScrollThumb.Node.Parent.comp as kissObject;

		if( drag_boounds_comp == null )
			return;

		int parentW = 0;
		int parentH = 0;
		int X = 0;
		int Y = 0;
		
		switch( drag_boounds_comp.ObjectType ){
		case kissObjectType.Camera:
			kissCamera cam = drag_boounds_comp as kissCamera;
			parentW = cam.Width;
			parentW -= cam.Padding.left + cam.Padding.right;
			parentH = cam.Height;
			parentH -= cam.Padding.bottom + cam.Padding.top;
			break;
			
		case kissObjectType.Group:
			kissGroup grp = drag_boounds_comp as kissGroup;
			parentW = grp.Width;
			parentW -= grp.Padding.left + grp.Padding.right;
			parentH = grp.Height;
			parentH -= grp.Padding.bottom + grp.Padding.top;
			break;
			
		case kissObjectType.Layout:
			kissLayout lo = drag_boounds_comp as kissLayout;
			parentW = lo.Width;
			parentW -= lo.Padding.left + lo.Padding.right;
			parentH = lo.Height;
			parentH -= lo.Padding.bottom + lo.Padding.top;
			break;
			
		case kissObjectType.Image:
			kissImage img = drag_boounds_comp as kissImage;
			parentW = img.Width;
			parentW -= img.Padding.left + img.Padding.right;
			X = img.Padding.left;
			
			parentH = img.Height;
			parentH -= img.Padding.bottom + img.Padding.top;
			Y = img.Padding.bottom;
			break;
			
		default:
			parentW = 120;
			parentH = 120;
			break;
		}
		
		int W = parentW;
		int H = parentH;
		
		W -= ScrollThumb.Width;
		W =  Mathf.Max( W, 0 );
		
		H -= ScrollThumb.Height;
		H =  Mathf.Max( H, 0 );
		
		X = Mathf.Max( X , 0 );
		Y = Mathf.Max( Y , 0 );

		DraggableArea.width = (float) W;
		DraggableArea.height = (float) H;
		DraggableArea.x = (float) X;
		DraggableArea.y = (float) Y;

	}
	
	public void Thumb_CalculatePercents()
	{
		if( ScrollThumb == null )
			return;
		
		if( isDraggable == false )
			return;


		float onePercentX = 100 / (DraggableArea.width + (DraggableArea.width<=0?1:0));		//revise this
		float onePercentY = 100 / (DraggableArea.height + (DraggableArea.height<=0?1:0));	// ~//~
		
		if( orientLR == OrientLR.LeftToRight )
			XOffsetPercent = Mathf.Round( ScrollThumb.PosOffset.x * onePercentX );								//XOffsetPercent = Mathf.Round( ScrollThumb.XOffset * onePercentX );
		else if( orientLR == OrientLR.RightToLeft )
			XOffsetPercent = Mathf.Round( (DraggableArea.width - ScrollThumb.PosOffset.x) * onePercentX );		//XOffsetPercent = Mathf.Round( (DraggableArea.width - ScrollThumb.XOffset) * onePercentX );
		
		if( orientBT == OrientBT.BottomToTop )
			YOffsetPercent = Mathf.Round( ScrollThumb.PosOffset.y * onePercentY );								//YOffsetPercent = Mathf.Round( ScrollThumb.YOffset * onePercentY );
		else if( orientBT == OrientBT.TopToBottom )
			YOffsetPercent = Mathf.Round( (DraggableArea.height - ScrollThumb.PosOffset.y) * onePercentY );	//YOffsetPercent = Mathf.Round( (DraggableArea.height - ScrollThumb.YOffset) * onePercentY );
	}
	
	public void SetOffset_usingPercents()
	{
		if( ScrollThumb == null )
			return;
		
		float onePercentX = 100 / (DraggableArea.width + (DraggableArea.width==0?1:0));
		float onePercentY = 100 / (DraggableArea.height + (DraggableArea.height==0?1:0));
		
		float newX = 0;
		float newY = 0;
		float newZ = ScrollThumb.PosOffset.z;
		
		if( orientLR == OrientLR.LeftToRight )
			newX = Mathf.RoundToInt( XOffsetPercent / onePercentX );
		else if( orientLR == OrientLR.RightToLeft )
			newX = 0 - Mathf.RoundToInt( XOffsetPercent / onePercentX ) + (int) DraggableArea.width;

		if( orientBT == OrientBT.BottomToTop )
			newY = Mathf.RoundToInt( YOffsetPercent / onePercentY );
		else if( orientBT == OrientBT.TopToBottom )
			newY = 0 - Mathf.RoundToInt( YOffsetPercent / onePercentY ) + (int) DraggableArea.height;

		newX = Mathf.Round( newX );
		newY = Mathf.Round( newY );
		
		ScrollThumb.PosOffset = new Vector3( newX, newY, newZ );

	}

	public void ResizeGutters()
	{
		if( ScrollThumb == null )
			return;

		if( imgGutterBottomOrLeft == null )
			return;

		if( cr_ResizeGutters_Started == false )
			StartCoroutine( CR_ResizeGutters() );
	}

	private bool cr_ResizeGutters_Started = false;

	private IEnumerator CR_ResizeGutters()
	{
		cr_ResizeGutters_Started = true;
		yield return null;


		if( scrollOrientation == ScrollOrient.Vertical )
			imgGutterBottomOrLeft.Height = (int) ScrollThumb.PosOffset.y + Mathf.RoundToInt( ScrollThumb.Height / 2);
		else
			imgGutterBottomOrLeft.Width = (int) ScrollThumb.PosOffset.x + Mathf.RoundToInt( ScrollThumb.Width / 2);
		
		//kissUtility.ReCalculate_SizePosition( imgGutterBottomOrLeft.Tran.parent, null );
		imgGutterBottomOrLeft.Refresh();


		cr_ResizeGutters_Started = false;
	}

	public void SetVertPercent( float newVertPercent )
	{
		YOffsetPercent = Mathf.Clamp( newVertPercent, 0f, 100f );
		
		SetOffset_usingPercents();
		Content_UpdatePosOffsets();
		ResizeGutters();
	}

	public void SetHoriPercent( float newHoriPercent )
	{
		XOffsetPercent = Mathf.Clamp( newHoriPercent, 0f, 100f );
		
		SetOffset_usingPercents();
		Content_UpdatePosOffsets();
		ResizeGutters();
	}

	public void VertPercent_Increase( int amount )
	{
		YOffsetPercent += amount;
		YOffsetPercent = Mathf.Clamp( YOffsetPercent, 0f, 100f );

		SetOffset_usingPercents();
		Content_UpdatePosOffsets();
		ResizeGutters();
	}

	public void HoriPercent_Increase( int amount )
	{
		XOffsetPercent += amount;
		XOffsetPercent = Mathf.Clamp( XOffsetPercent, 0f, 100f );
		
		SetOffset_usingPercents();
		Content_UpdatePosOffsets();
		ResizeGutters();
	}

	public void VertPercent_Decrease( int amount )
	{
		YOffsetPercent -= amount;
		YOffsetPercent = Mathf.Clamp( YOffsetPercent, 0f, 100f );
		
		SetOffset_usingPercents();
		Content_UpdatePosOffsets();
		ResizeGutters();
	}

	public void HoriPercent_Decrease( int amount )
	{
		XOffsetPercent -= amount;
		XOffsetPercent = Mathf.Clamp( XOffsetPercent, 0f, 100f );

		SetOffset_usingPercents();
		Content_UpdatePosOffsets();
		ResizeGutters();
	}

	#endregion

}


