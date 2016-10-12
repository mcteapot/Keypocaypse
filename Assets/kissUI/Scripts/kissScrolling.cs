using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using kissUI;

[ExecuteInEditMode]
public class kissScrolling : MonoBehaviour
{
	#region 0. Enums
	
	public enum DirectionHori
	{
		LeftToRight,
		RightToLeft
	}
	
	public enum DirectionVerti
	{
		BottomToTop,
		TopToBottom
	}
	
	public enum ScrollOrientation
	{
		Vertical,
		Horizontal,
		Both
	}
	
	#endregion



	#region 1. Delegates
	
	//TODO:
	
	public delegate void del_Values_OnChanged( kissScrolling scrl, float XOffset_Percent, float YOffset_Percent );
	public static del_Values_OnChanged Values_OnChanged = null;
	
	public delegate void del_ValueHori_OnChanged( kissScrolling scrl, float XOffset_Percent );
	public static del_ValueHori_OnChanged ValueHori_OnChanged = null;
	
	public delegate void del_ValueVerti_OnChanged( kissScrolling scrl, float YOffset_Percent );
	public static del_ValueVerti_OnChanged ValueVerti_OnChanged = null;
	
	#endregion


	
	#region 2. Variables

	public kissRaycast uiRaycast = null;

	public kissImage Thumb = null;
	public bool isThumbDraggable = true;

	public kissObject DragBounds = null;

	public kissText HoriLabel;
	public kissText VertiLabel;

	public kissImage GutterBegin;
	public kissImage GutterEnd;

	public Rect DraggableArea = new Rect();

	public ScrollOrientation scrollingOrient = ScrollOrientation.Vertical;
	
	public DirectionHori horizontalDir;
	public DirectionVerti verticalDir;

	[SerializeField] private float _HorizontalValue_Percent = 0f;
	public float HorizontalValue_Percent
	{
		get {
			return _HorizontalValue_Percent;
		}
		set {
			bool isDiff = _HorizontalValue_Percent != value;
			if( isDiff )
			{
				_HorizontalValue_Percent = value;

				if( HoriLabel != null )
				{
					HoriLabel.Text = _HorizontalValue_Percent + "%";
					HoriLabel.Refresh();
				}

				if( ValueHori_OnChanged != null )
					ValueHori_OnChanged( this, _HorizontalValue_Percent );
			}
		}
	}
	
	[SerializeField] private float _VerticalValue_Percent = 0f;
	public float VerticalValue_Percent
	{
		get {
			return _VerticalValue_Percent;
		}
		set {
			bool isDiff = _VerticalValue_Percent != value;
			if( isDiff )
			{
				_VerticalValue_Percent = value;

				if( VertiLabel != null )
				{
					VertiLabel.Text = _VerticalValue_Percent + "%";
					VertiLabel.Refresh();
				}

				if( ValueVerti_OnChanged != null )
					ValueVerti_OnChanged( this, _VerticalValue_Percent );
			}
		}
	}

	public bool onParentResize_ApplyExistingOffsetPercents = true;

	public kissObject ContentView;

	public List< kissImage > listDecreaseImgs = new List< kissImage >();
	public List< kissImage > listIncreaseImgs = new List< kissImage >();

	//------

	Vector3		PosOffset = new Vector3();
	int			clippingHeight = 0;
	int			nClientHeight = 0;
	int			heightDiff = 0;
	int			clippingWidth = 0;
	int			nClientWidth = 0;
	int			widthDiff = 0;
	float		onePercent = 0f;
	int			mouseDown_X = 0;
	int			mouseDown_Y = 0;
	int			mouseDown_OffsetX = 0;
	int			mouseDown_OffsetY = 0;
	HitInfo		hi = null;

	#endregion


	
	#region 3. Unity Events
	
	void Start ()
	{
		ObjectRefs_Check();
	}

	void OnEnable()
	{
		Init();
	}

	void OnDisable()
	{
		DeInit();
	}

	#endregion



	#region 3. Unity Event Helpers

	void ObjectRefs_Check()
	{
		if( uiRaycast == null )
		{
			Transform root_tran = kissUtility.Find_kissUI_Root( transform );
			uiRaycast = root_tran.GetComponent< kissRaycast >();
		}
		
		if( DragBounds == null && Thumb != null && Thumb.Node.Parent != null )
			DragBounds = Thumb.Node.Parent.obj;

		// ....
	}

	void Init()
	{
		ObjectRefs_Check();
		
		if( Thumb != null )
		{
			Thumb.OnMouseDown += Thumb_onMouseDown;
			Thumb.OnMouseDrag += Thumb_onMouseDrag;
		}

		if( DragBounds != null )
		{
			DragBounds.OnSizeChanged += Parent_onSizeChanged;
			DragBounds.OnMarginsChanged += Parent_onSizeChanged;
			DragBounds.OnPaddingChanged += Parent_onSizeChanged;
		}

//		if( GutterBegin != null )
//		{
//			GutterBegin.OnMouseDown += ValuePercent_Decrease_onMouseDown;
//			GutterBegin.OnMouseHeld += ValuePercent_Decrease_onMouseHeld;
//		}
//
//		if( GutterEnd != null )
//		{
//			GutterEnd.OnMouseDown += ValuePercent_Increase_onMouseDown;
//			GutterEnd.OnMouseHeld += ValuePercent_Increase_onMouseHeld;
//		}

		for( int i = 0; i < listIncreaseImgs.Count; i++ )
			AddIncreasingInputHandlersTo( listIncreaseImgs[ i ] );

		for( int i = 0; i < listDecreaseImgs.Count; i++ )
			AddDecreasingInputHandlersTo( listDecreaseImgs[ i ] );

		cr_ContentView_UpdatePosOffsets_Started = false;
		cr_ResizeGutters_Started = false;
	}

	void DeInit()
	{
		if( Thumb != null )
		{		
			Thumb.OnMouseDown -= Thumb_onMouseDown;
			Thumb.OnMouseDrag -= Thumb_onMouseDrag;
		}

		if( DragBounds != null )
		{
			DragBounds.OnSizeChanged -= Parent_onSizeChanged;
			DragBounds.OnMarginsChanged -= Parent_onSizeChanged;
			DragBounds.OnPaddingChanged -= Parent_onSizeChanged;
		}

//		if( GutterBegin != null )
//		{
//			GutterBegin.OnMouseDown -= ValuePercent_Decrease_onMouseDown;
//			GutterBegin.OnMouseHeld -= ValuePercent_Decrease_onMouseHeld;
//		}
//
//		if( GutterEnd != null )
//		{
//			GutterEnd.OnMouseDown -= ValuePercent_Increase_onMouseDown;
//			GutterEnd.OnMouseHeld -= ValuePercent_Increase_onMouseHeld;
//		}

		for( int i = 0; i < listIncreaseImgs.Count; i++ )
			RemoveIncreasingInputHandlersFrom( listIncreaseImgs[ i ] );
		
		for( int i = 0; i < listDecreaseImgs.Count; i++ )
			RemoveDecreasingInputHandlersFrom( listDecreaseImgs[ i ] );
	}

	public void AddIncreasingInputHandlersTo( kissImage img )
	{
		if( img == null )
			return;

		//Debug.Log( "AddIncreasingInputHandlersTo( " + img.name + " )" );

		img.OnMouseDown += ValuePercent_Increase_onMouseDown;
		img.OnMouseHeld += ValuePercent_Increase_onMouseHeld;
	}
	
	public void RemoveIncreasingInputHandlersFrom( kissImage img )
	{
		if( img == null )
			return;

		//Debug.Log( "RemoveIncreasingInputHandlersFrom( " + img.name + " )" );

		img.OnMouseDown -= ValuePercent_Increase_onMouseDown;
		img.OnMouseHeld -= ValuePercent_Increase_onMouseHeld;
	}

	public void AddDecreasingInputHandlersTo( kissImage img )
	{
		if( img == null )
			return;

		//Debug.Log( "AddDecreasingInputHandlersTo( " + img.name + " )" );
		
		img.OnMouseDown += ValuePercent_Decrease_onMouseDown;
		img.OnMouseHeld += ValuePercent_Decrease_onMouseHeld;
	}
	
	public void RemoveDecreasingInputHandlersFrom( kissImage img )
	{
		if( img == null )
			return;

		//Debug.Log( "RemoveDecreasingInputHandlersFrom( " + img.name + " )" );
		
		img.OnMouseDown -= ValuePercent_Decrease_onMouseDown;
		img.OnMouseHeld -= ValuePercent_Decrease_onMouseHeld;
	}

	#endregion
	
	
	
	#region 4. kissUI Events
	
	public void Parent_onSizeChanged()
	{
		Update_DraggableArea();
		
		if( onParentResize_ApplyExistingOffsetPercents )
			Thumb_UpdateOffsets_FromValuePercents();
		
		ContentView_UpdatePosOffsets();
		
		ResizeGutters();
	}

	public void Thumb_onMouseDown( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		//Debug.Log( "onMouseDown()" );

		if( Btn != kissMouseButton.Left )
			return;

		hi = uiRaycast.GetHitInfo( Thumb.Tran );
		
		if( hi == null )
			hi = uiRaycast.hitInfo;

		mouseDown_X = (int) hi.MousePos.x;
		mouseDown_Y = (int) hi.MousePos.y;
		
		mouseDown_OffsetX = (int) Thumb.PosOffset.x;
		mouseDown_OffsetY = (int) Thumb.PosOffset.y;
	}
	
	public void Thumb_onMouseDrag( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		Dragging_UpdateOffsets();
		
		ContentView_UpdatePosOffsets();
		
		ResizeGutters();
	}

	public void ValuePercent_Decrease_onMouseDown( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		//Debug.Log( "onMouseDown()" );
		
		if( Btn != kissMouseButton.Left )
			return;

		if( scrollingOrient == ScrollOrientation.Horizontal )
			HoriPercent_Decrease( 2 );
		else if( scrollingOrient == ScrollOrientation.Vertical )
			VertPercent_Decrease( 2 );
		else
		{
			HoriPercent_Decrease( 2 );
			VertPercent_Decrease( 2 );
		}
	}

	public void ValuePercent_Decrease_onMouseHeld( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		//Debug.Log( "onMouseHeld()" );
		
		if( Btn != kissMouseButton.Left )
			return;

		if( scrollingOrient == ScrollOrientation.Horizontal )
			HoriPercent_Decrease( 1 );
		else if( scrollingOrient == ScrollOrientation.Vertical )
			VertPercent_Decrease( 1 );
		else
		{
			HoriPercent_Decrease( 1 );
			VertPercent_Decrease( 1 );
		}
	}

	public void ValuePercent_Increase_onMouseDown( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		//Debug.Log( "onMouseDown()" );
		
		if( Btn != kissMouseButton.Left )
			return;

		if( scrollingOrient == ScrollOrientation.Horizontal )
			HoriPercent_Increase( 2 );
		else if( scrollingOrient == ScrollOrientation.Vertical )
			VertPercent_Increase( 2 );
		else
		{
			HoriPercent_Increase( 2 );
			VertPercent_Increase( 2 );
		}
	}
	
	public void ValuePercent_Increase_onMouseHeld( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		//Debug.Log( "onMouseHeld()" );
		
		if( Btn != kissMouseButton.Left )
			return;

		if( scrollingOrient == ScrollOrientation.Horizontal )
			HoriPercent_Increase( 1 );
		else if( scrollingOrient == ScrollOrientation.Vertical )
			VertPercent_Increase( 1 );
		else
		{
			HoriPercent_Increase( 1 );
			VertPercent_Increase( 1 );
		}
	}

	#endregion
	
	
	
	#region Other
	
	public void Dragging_UpdateOffsets()
	{
		if( Thumb == null )
			return;
		
		if( isThumbDraggable == false )
			return;

		float diffX = mouseDown_X - hi.MousePos.x;
		float diffY = mouseDown_Y - hi.MousePos.y;

		float newX = Mathf.Clamp( mouseDown_OffsetX - diffX, DraggableArea.x, DraggableArea.width );
		float newY = Mathf.Clamp( mouseDown_OffsetY - diffY, DraggableArea.y, DraggableArea.height );

		float newZ = Thumb.PosOffset.z;
		
		Thumb.PosOffset = new Vector3( newX, newY, newZ );
		
		Thumb_CalculatePercents();
		
	}
	
	public void Refresh_PosOffsets()
	{
		if( Thumb == null )
			return;
		
		if( isThumbDraggable == false )
			return;
		
		float newY = Mathf.Clamp( Thumb.PosOffset.y, DraggableArea.y, DraggableArea.height );
		float newX = Mathf.Clamp( Thumb.PosOffset.x, DraggableArea.x, DraggableArea.width );
		float newZ = Thumb.PosOffset.z;
		
		Thumb.PosOffset = new Vector3( newX, newY, newZ );
		
		Thumb_CalculatePercents();
		
	}
	
	public void ContentView_UpdatePosOffsets()
	{
		if( ContentView == null )
			return;
		
		if( cr_ContentView_UpdatePosOffsets_Started == false )
			StartCoroutine( CR_ContentView_UpdatePosOffsets() );
	}
	
	private bool cr_ContentView_UpdatePosOffsets_Started = false;
	
	private IEnumerator CR_ContentView_UpdatePosOffsets()
	{
		cr_ContentView_UpdatePosOffsets_Started = true;
		yield return null;

		if( ContentView.Node.Parent == null )
			yield break;	//return;
		
		kissObject parent_ko = ContentView.Node.Parent.obj;
		
		if( scrollingOrient == ScrollOrientation.Vertical )
		{
			if( parent_ko != null )
				clippingHeight = parent_ko.Height;
			
			nClientHeight = ContentView.Height + ContentView.Margin.top + ContentView.Margin.bottom;
			heightDiff = nClientHeight - clippingHeight;
			onePercent = 100f / heightDiff;
			
			PosOffset.x = ContentView.PosOffset.x;
			PosOffset.y = Mathf.Round( VerticalValue_Percent / onePercent );
			PosOffset.z = ContentView.PosOffset.z;
		}
		else if( scrollingOrient == ScrollOrientation.Horizontal )
		{
			if( parent_ko != null )
				clippingWidth = parent_ko.Width;
			
			nClientWidth = ContentView.Width + ContentView.Margin.right + ContentView.Margin.left;
			widthDiff = nClientWidth - clippingWidth;
			onePercent = 100f / widthDiff;
			
			PosOffset.x = Mathf.Round( HorizontalValue_Percent / onePercent );
			PosOffset.y = ContentView.PosOffset.y;
			PosOffset.z = ContentView.PosOffset.z;			
		}
		else if( scrollingOrient == ScrollOrientation.Both )
		{
			if( parent_ko != null )
			{
				clippingWidth = parent_ko.Width;
				clippingHeight = parent_ko.Height;
			}

			nClientWidth = ContentView.Width + ContentView.Margin.right + ContentView.Margin.left;
			widthDiff = nClientWidth - clippingWidth;
			onePercent = 100f / widthDiff;
			PosOffset.x = Mathf.Round( HorizontalValue_Percent / onePercent );

			nClientHeight = ContentView.Height + ContentView.Margin.top + ContentView.Margin.bottom;
			heightDiff = nClientHeight - clippingHeight;
			onePercent = 100f / heightDiff;
			PosOffset.y = Mathf.Round( VerticalValue_Percent / onePercent );

			PosOffset.z = ContentView.PosOffset.z;
		}
		
		ContentView.PosOffset = PosOffset;

		cr_ContentView_UpdatePosOffsets_Started = false;
	}
	
	public void Update_DraggableArea()
	{
		if( Thumb == null )
			return;

		if( DragBounds == null )
			return;

		int dragW = 0;
		int dragH = 0;
		int X = 0;
		int Y = 0;
		
		switch( DragBounds.ObjectType ){
		case kissObjectType.Camera:
			kissCamera cam = DragBounds as kissCamera;
			dragW = cam.Width;
			dragW -= cam.Padding.left + cam.Padding.right;
			dragH = cam.Height;
			dragH -= cam.Padding.bottom + cam.Padding.top;
			break;
			
		case kissObjectType.Group:
			kissGroup grp = DragBounds as kissGroup;
			dragW = grp.Width;
			dragW -= grp.Padding.left + grp.Padding.right;
			dragH = grp.Height;
			dragH -= grp.Padding.bottom + grp.Padding.top;
			break;
			
		case kissObjectType.Layout:
			kissLayout lo = DragBounds as kissLayout;
			dragW = lo.Width;
			dragW -= lo.Padding.left + lo.Padding.right;
			dragH = lo.Height;
			dragH -= lo.Padding.bottom + lo.Padding.top;
			break;
			
		case kissObjectType.Image:
			kissImage img = DragBounds as kissImage;
			dragW = img.Width;
			dragW -= img.Padding.left + img.Padding.right;
			X = img.Padding.left;
			
			dragH = img.Height;
			dragH -= img.Padding.bottom + img.Padding.top;
			Y = img.Padding.bottom;
			break;
			
		default:
			dragW = 120;
			dragH = 120;
			break;
		}
		
		int W = dragW;
		int H = dragH;
		
		W -= Thumb.Width;
		W =  Mathf.Max( W, 0 );
		
		H -= Thumb.Height;
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
		if( Thumb == null )
			return;
		
		if( isThumbDraggable == false )
			return;
		
		
		float onePercentX = 100 / (DraggableArea.width + (DraggableArea.width<=0?1:0));		//revise this
		float onePercentY = 100 / (DraggableArea.height + (DraggableArea.height<=0?1:0));	// ~//~
		
		if( horizontalDir == DirectionHori.LeftToRight )
			HorizontalValue_Percent = Mathf.Round( Thumb.PosOffset.x * onePercentX );
		else if( horizontalDir == DirectionHori.RightToLeft )
			HorizontalValue_Percent = Mathf.Round( (DraggableArea.width - Thumb.PosOffset.x) * onePercentX );
		
		if( verticalDir == DirectionVerti.BottomToTop )
			VerticalValue_Percent = Mathf.Round( Thumb.PosOffset.y * onePercentY );
		else if( verticalDir == DirectionVerti.TopToBottom )
			VerticalValue_Percent = Mathf.Round( (DraggableArea.height - Thumb.PosOffset.y) * onePercentY );
	}
	
	public void Thumb_UpdateOffsets_FromValuePercents()
	{
		if( Thumb == null )
			return;
		
		float onePercentX = 100 / (DraggableArea.width + (DraggableArea.width==0?1:0));
		float onePercentY = 100 / (DraggableArea.height + (DraggableArea.height==0?1:0));
		
		float newX = 0;
		float newY = 0;
		float newZ = Thumb.PosOffset.z;
		
		if( horizontalDir == DirectionHori.LeftToRight )
			newX = Mathf.RoundToInt( HorizontalValue_Percent / onePercentX );
		else if( horizontalDir == DirectionHori.RightToLeft )
			newX = 0 - Mathf.RoundToInt( HorizontalValue_Percent / onePercentX ) + (int) DraggableArea.width;
		
		if( verticalDir == DirectionVerti.BottomToTop )
			newY = Mathf.RoundToInt( VerticalValue_Percent / onePercentY );
		else if( verticalDir == DirectionVerti.TopToBottom )
			newY = 0 - Mathf.RoundToInt( VerticalValue_Percent / onePercentY ) + (int) DraggableArea.height;
		
		newX = Mathf.Round( newX );
		newY = Mathf.Round( newY );
		
		Thumb.PosOffset = new Vector3( newX, newY, newZ );
		
	}
	
	public void ResizeGutters()
	{
		if( Thumb == null )
			return;
		
		if( GutterBegin == null )
			return;
		
		if( cr_ResizeGutters_Started == false )
			StartCoroutine( CR_ResizeGutters() );
	}
	
	private bool cr_ResizeGutters_Started = false;
	
	private IEnumerator CR_ResizeGutters()
	{
		cr_ResizeGutters_Started = true;
		yield return null;
		
		
		if( scrollingOrient == ScrollOrientation.Vertical )
			GutterBegin.Height = (int) Thumb.PosOffset.y + Mathf.RoundToInt( Thumb.Height / 2);
		else if( scrollingOrient == ScrollOrientation.Horizontal )
			GutterBegin.Width = (int) Thumb.PosOffset.x + Mathf.RoundToInt( Thumb.Width / 2);
		else if( scrollingOrient == ScrollOrientation.Both )
		{
			GutterBegin.Height = (int) Thumb.PosOffset.y + Mathf.RoundToInt( Thumb.Height / 2);
			GutterBegin.Width = (int) Thumb.PosOffset.x + Mathf.RoundToInt( Thumb.Width / 2);
		}

		//kissUtility.ReCalculate_SizePosition( GutterBegin.Tran.parent, null );
		GutterBegin.Refresh();
		
		
		cr_ResizeGutters_Started = false;
	}
	
	public void SetVertPercent( float newVertPercent )
	{
		VerticalValue_Percent = Mathf.Clamp( newVertPercent, 0f, 100f );
		
		Thumb_UpdateOffsets_FromValuePercents();
		ContentView_UpdatePosOffsets();
		ResizeGutters();
	}
	
	public void SetHoriPercent( float newHoriPercent )
	{
		HorizontalValue_Percent = Mathf.Clamp( newHoriPercent, 0f, 100f );
		
		Thumb_UpdateOffsets_FromValuePercents();
		ContentView_UpdatePosOffsets();
		ResizeGutters();
	}
	
	public void VertPercent_Increase( int amount )
	{
		VerticalValue_Percent += amount;
		VerticalValue_Percent = Mathf.Clamp( VerticalValue_Percent, 0f, 100f );
		
		Thumb_UpdateOffsets_FromValuePercents();
		ContentView_UpdatePosOffsets();
		ResizeGutters();
	}
	
	public void HoriPercent_Increase( int amount )
	{
		HorizontalValue_Percent += amount;
		HorizontalValue_Percent = Mathf.Clamp( HorizontalValue_Percent, 0f, 100f );
		
		Thumb_UpdateOffsets_FromValuePercents();
		ContentView_UpdatePosOffsets();
		ResizeGutters();
	}
	
	public void VertPercent_Decrease( int amount )
	{
		VerticalValue_Percent -= amount;
		VerticalValue_Percent = Mathf.Clamp( VerticalValue_Percent, 0f, 100f );
		
		Thumb_UpdateOffsets_FromValuePercents();
		ContentView_UpdatePosOffsets();
		ResizeGutters();
	}
	
	public void HoriPercent_Decrease( int amount )
	{
		HorizontalValue_Percent -= amount;
		HorizontalValue_Percent = Mathf.Clamp( HorizontalValue_Percent, 0f, 100f );
		
		Thumb_UpdateOffsets_FromValuePercents();
		ContentView_UpdatePosOffsets();
		ResizeGutters();
	}
	
	#endregion

}
