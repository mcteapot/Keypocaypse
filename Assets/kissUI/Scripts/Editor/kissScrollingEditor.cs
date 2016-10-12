using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using kissUI;

[CustomEditor( typeof( kissScrolling ) )]
public class kissScrollingEditor : Editor
{
	#region 1. Variables

	kissScrolling scrl = null;

	SectionPanel section_Setup;
	Texture2D section_Setup_icon = null;
	Color section_Setup_clr;
	Color section_Setup_clr_Dark;

	SectionPanel section_Increasing;
	Texture2D section_Increasing_icon = null;
	Color section_Increasing_clr;
	Color section_Increasing_clr_Dark;

	SectionPanel section_Decreasing;
	Texture2D section_Decreasing_icon = null;
	Color section_Decreasing_clr;
	Color section_Decreasing_clr_Dark;

	SectionPanel section_Scrolling;
	Texture2D section_Scrolling_icon = null;
	Color section_Scrolling_clr;
	Color section_Scrolling_clr_Dark;

	List< bool > inc_exp = null;
	List< bool > dec_exp = null;

	GUIStyle style_Add = null;
	GUIStyle style_AddLabel = null;
	GUIStyle style_Remove = null;
	GUIStyle style_MoveUp = null;
	GUIStyle style_MoveDown = null;
	GUIStyle style_Helpbox = null;

	#endregion



	#region 2. Unity Events

	void OnEnable()
	{
		scrl = target as kissScrolling;

		section_Setup = new SectionPanel( "Setup_Info" );				// doesnt matter what you pass in, as long as its a Unique Key
		section_Setup_icon = null; 										//EditorGUIUtility.FindTexture( "PreMatCube" ) as Texture2D;
		section_Setup_clr = new Color( .90f, .86f, .90f, .8f );
		section_Setup_clr_Dark = new Color( 60/255f, 80/255f, 80/255f, .9f );

		section_Increasing = new SectionPanel( "Increasing_Images" );				// doesnt matter what you pass in, as long as its a Unique Key
		section_Increasing_icon = null; 										//EditorGUIUtility.FindTexture( "PreMatCube" ) as Texture2D;
		section_Increasing_clr = new Color( .90f, .86f, .90f, .8f );
		section_Increasing_clr_Dark = new Color( 60/255f, 80/255f, 80/255f, .9f );

		section_Decreasing = new SectionPanel( "Decreasing_Images" );				// doesnt matter what you pass in, as long as its a Unique Key
		section_Decreasing_icon = null; 										//EditorGUIUtility.FindTexture( "PreMatCube" ) as Texture2D;
		section_Decreasing_clr = new Color( .90f, .86f, .90f, .8f );
		section_Decreasing_clr_Dark = new Color( 60/255f, 80/255f, 80/255f, .9f );

		section_Scrolling = new SectionPanel( "Scrolling_Info" );		// doesnt matter what you pass in, as long as its a Unique Key
		section_Scrolling_icon = null;									//EditorGUIUtility.FindTexture( "PreMatCube" ) as Texture2D;
		section_Scrolling_clr = new Color( .90f, .86f, .90f, .8f );
		section_Scrolling_clr_Dark = new Color( 60/255f, 80/255f, 80/255f, .9f );
		
		style_Add = new GUIStyle();
		style_Add.normal.background = AssetDatabase.LoadAssetAtPath( "Assets/kissUI/Editor/Textures/Round_Plus.png", typeof(Texture2D) ) as Texture2D;
		style_Add.active.background = AssetDatabase.LoadAssetAtPath( "Assets/kissUI/Editor/Textures/Round_Plus_Press.png", typeof(Texture2D) ) as Texture2D;
		
		style_Remove = new GUIStyle();
		style_Remove.normal.background = AssetDatabase.LoadAssetAtPath( "Assets/kissUI/Editor/Textures/Round_Minus.png", typeof(Texture2D) ) as Texture2D;
		style_Remove.active.background = AssetDatabase.LoadAssetAtPath( "Assets/kissUI/Editor/Textures/Round_Minus_Press.png", typeof(Texture2D) ) as Texture2D;
		style_Remove.margin.top = 3;
		
		style_MoveUp = new GUIStyle();
		style_MoveUp.normal.background = AssetDatabase.LoadAssetAtPath( "Assets/kissUI/Editor/Textures/Round_Up.png", typeof(Texture2D) ) as Texture2D;
		style_MoveUp.active.background = AssetDatabase.LoadAssetAtPath( "Assets/kissUI/Editor/Textures/Round_Up_Press.png", typeof(Texture2D) ) as Texture2D;
		style_MoveUp.margin.top = 3;
		
		style_MoveDown = new GUIStyle();
		style_MoveDown.normal.background = AssetDatabase.LoadAssetAtPath( "Assets/kissUI/Editor/Textures/Round_Down.png", typeof(Texture2D) ) as Texture2D;
		style_MoveDown.active.background = AssetDatabase.LoadAssetAtPath( "Assets/kissUI/Editor/Textures/Round_Down_Press.png", typeof(Texture2D) ) as Texture2D;
		style_MoveDown.margin.top = 3;

		inc_exp = new List< bool >();

		for( int i = 0; i < inc_exp.Count; i++ )
			inc_exp.Add( false );

		dec_exp = new List< bool >();

		for( int i = 0; i < inc_exp.Count; i++ )
			inc_exp.Add( false );
	}
	
	void OnDisable()
	{
		// dont realy need this... just OCD! ;)

//		scrl = null;
//
//		section_Scrolling = null;
//		section_Scrolling_icon = null;
	}

	public override void OnInspectorGUI()
	{
		GUISkin origSkin = GUI.skin;
		GUI.skin = EditorGUIUtility.GetBuiltinSkin( kissEditorPrefs.isProSkin ? EditorSkin.Scene : EditorSkin.Inspector );
		


		GUIStyles_Check();
		
		kissGUI.BeginView( false );
		
		GUILayout.Space( 4 );

		DrawSection_Setup();
		DrawSection_Increasing_Images();
		DrawSection_Decreasing_Images();
		DrawSection_Scrolling();
		
		GUILayout.Space( 4 );
		
		kissGUI.EndView( false );



		GUI.skin = origSkin;

//		if( GUI.changed )
//			EditorUtility.SetDirty( scrl );
	}

	#endregion



	#region Other

	void GUIStyles_Check()
	{
		if( style_Helpbox != null )
			return;
		
		// these need to be created during the GUI render cycle, which this does.
		// maybe it needs to do .CalcSize() or sumtin'?! :{
		// I just know, I'm not a big fan of having to do it during a GUI cycle. :P
		
		style_Helpbox = new GUIStyle( "helpbox" );
		style_Helpbox.padding.top = 1;
		style_Helpbox.padding.bottom = 1;
		style_Helpbox.padding.right = 1;
		style_Helpbox.padding.left = 1;
		
		style_AddLabel = new GUIStyle( "label" );
		style_AddLabel.margin.top = 0;
		style_AddLabel.margin.bottom = 0;
		style_AddLabel.margin.right = 0;
		style_AddLabel.margin.left = 0;
		style_AddLabel.padding.top = 0;
		style_AddLabel.padding.bottom = 0;
	}

	void DrawSection_Setup()
	{
		if( section_Setup == null )
			return;

		string tabbed_info = "";
		Color section_clr = kissEditorPrefs.isProSkin ? section_Setup_clr_Dark : section_Setup_clr;

		kissGUI.BeginSection( "Setup Details", tabbed_info, section_clr, section_Setup, section_Setup_icon );
		
		if( section_Setup.isVisible )
		{
			bool origEnabled = GUI.enabled;

			bool isHori = scrl.scrollingOrient == kissScrolling.ScrollOrientation.Horizontal;
			bool isVerti = scrl.scrollingOrient == kissScrolling.ScrollOrientation.Vertical;
			bool isBoth = scrl.scrollingOrient == kissScrolling.ScrollOrientation.Both;

			scrl.scrollingOrient = (kissScrolling.ScrollOrientation) EditorGUILayout.EnumPopup( "Orientation", scrl.scrollingOrient, "minipopup" );

			if( isHori || isBoth )
				scrl.horizontalDir = (kissScrolling.DirectionHori) EditorGUILayout.EnumPopup( "Hori Direction", scrl.horizontalDir, "minipopup" );

			if( isVerti || isBoth )
				scrl.verticalDir = (kissScrolling.DirectionVerti) EditorGUILayout.EnumPopup( "Verti Direction", scrl.verticalDir, "minipopup" );


			kissGUI.Separator( "Required", section_clr );


			scrl.uiRaycast = EditorGUILayout.ObjectField( "Raycast Events", scrl.uiRaycast, typeof( kissObject ), true ) as kissRaycast;
			scrl.Thumb = EditorGUILayout.ObjectField( "Thumb Image", scrl.Thumb, typeof( kissImage ), true ) as kissImage;
			scrl.DragBounds = EditorGUILayout.ObjectField( "Drag Bounds", scrl.DragBounds, typeof( kissObject ), true ) as kissObject;

			GUI.enabled = scrl.DragBounds == null;
			scrl.DraggableArea = EditorGUILayout.RectField( "Drag Area", scrl.DraggableArea );
			GUI.enabled = origEnabled;


			kissGUI.Separator( "Optional", section_clr );


			scrl.GutterBegin = EditorGUILayout.ObjectField( "Gutter Begin", scrl.GutterBegin, typeof( kissImage ), true ) as kissImage;
			scrl.GutterEnd = EditorGUILayout.ObjectField( "Gutter End", scrl.GutterEnd, typeof( kissImage ), true ) as kissImage;

			if( isHori || isBoth )
				scrl.HoriLabel = EditorGUILayout.ObjectField( "Hori Label", scrl.HoriLabel, typeof( kissText ), true ) as kissText;

			if( isVerti || isBoth )
				scrl.VertiLabel = EditorGUILayout.ObjectField( "Verti Label", scrl.VertiLabel, typeof( kissText ), true ) as kissText;

			scrl.ContentView = EditorGUILayout.ObjectField( "Scroll Content", scrl.ContentView, typeof( kissObject ), true ) as kissObject;


			GUI.enabled = origEnabled;
		}
		
		kissGUI.EndSection( section_Setup );
	}

	void DrawSection_Increasing_Images()
	{
		if( section_Increasing == null )
			return;

		string tabbed_info = "";
		Color section_clr = kissEditorPrefs.isProSkin ? section_Increasing_clr_Dark : section_Increasing_clr;
		
		kissGUI.BeginSection( "Value Increasing Images", tabbed_info, section_clr, section_Increasing, section_Increasing_icon );
		
		if( section_Increasing.isVisible )
		{
			bool origEnabled = GUI.enabled;
			

			
			for( int i = 0; i < scrl.listIncreaseImgs.Count; i++ )
				DrawIncreaseImage( ref scrl.listIncreaseImgs, ref inc_exp, i );
			
			EditorGUILayout.BeginHorizontal();
			
			GUILayout.FlexibleSpace();
			
			EditorGUILayout.BeginHorizontal( style_Helpbox );
			GUILayout.Label( "Add", style_AddLabel, GUILayout.ExpandWidth( false ), GUILayout.ExpandHeight( false ) );
			if( GUILayout.Button( "", style_Add, GUILayout.Width( 13 ), GUILayout.Height(13) ) )
			{
				scrl.listIncreaseImgs.Add( null );
				inc_exp.Add( false );
			}
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.EndHorizontal();

			
			
			GUI.enabled = origEnabled;
		}
		
		kissGUI.EndSection( section_Increasing );
	}

	void DrawSection_Decreasing_Images()
	{
		if( section_Decreasing == null )
			return;

		string tabbed_info = "";
		Color section_clr = kissEditorPrefs.isProSkin ? section_Decreasing_clr_Dark : section_Decreasing_clr;
		
		kissGUI.BeginSection( "Value Decreasing Images", tabbed_info, section_clr, section_Decreasing, section_Decreasing_icon );
		
		if( section_Decreasing.isVisible )
		{
			bool origEnabled = GUI.enabled;



			for( int i = 0; i < scrl.listDecreaseImgs.Count; i++ )
				DrawDecreaseImage( ref scrl.listDecreaseImgs, ref dec_exp, i );
			
			EditorGUILayout.BeginHorizontal();
			
			GUILayout.FlexibleSpace();
			
			EditorGUILayout.BeginHorizontal( style_Helpbox );
			GUILayout.Label( "Add", style_AddLabel, GUILayout.ExpandWidth( false ), GUILayout.ExpandHeight( false ) );
			if( GUILayout.Button( "", style_Add, GUILayout.Width( 13 ), GUILayout.Height(13) ) )
			{
				scrl.listDecreaseImgs.Add( null );
				dec_exp.Add( false );
			}
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.EndHorizontal();
			
			
			
			GUI.enabled = origEnabled;
		}
		
		kissGUI.EndSection( section_Decreasing );
	}

	void DrawSection_Scrolling()
	{
		if( section_Scrolling == null )
			return;

		string tabbed_info = "";
		Color section_clr = kissEditorPrefs.isProSkin ? section_Scrolling_clr_Dark : section_Scrolling_clr;

		kissGUI.BeginSection( "Scrolling Info", tabbed_info, section_clr, section_Scrolling, section_Scrolling_icon );

		if( section_Scrolling.isVisible )
		{
			bool origEnabled = GUI.enabled;


			bool isHori = scrl.scrollingOrient == kissScrolling.ScrollOrientation.Horizontal;
			bool isVerti = scrl.scrollingOrient == kissScrolling.ScrollOrientation.Vertical;
			bool isBoth = scrl.scrollingOrient == kissScrolling.ScrollOrientation.Both;


			//kissGUI.Separator( "Values in %", section_clr );


			if( isHori || isBoth )
				scrl.HorizontalValue_Percent = EditorGUILayout.FloatField( "Horizontal Value %", scrl.HorizontalValue_Percent );

			if( isVerti || isBoth )
				scrl.VerticalValue_Percent = EditorGUILayout.FloatField( "Vertical Value %", scrl.VerticalValue_Percent );


			GUI.enabled = origEnabled;
		}

		kissGUI.EndSection( section_Scrolling );
	}

	void DrawIncreaseImage( ref List< kissImage > list, ref List< bool > exp, int i )
	{
		bool origEnabled = GUI.enabled;

		kissImage img = list[ i ];
		int removeAt = -1;
		int moveUp = -1;
		int moveDown = -1;
		
		EditorGUILayout.BeginHorizontal();
		
		if( exp.Count != list.Count )
		{
			exp = new List< bool >();
			for( int j = 0; j < list.Count; j++ )
				exp.Add( false );
		}
		
		GUILayout.Label( i + ")" );
		
		exp[ i ] = GUILayout.Toggle( exp[ i ], "", (GUIStyle) "foldout", GUILayout.ExpandWidth( false ) );
		EditorGUI.BeginChangeCheck();
		kissImage old_img = img;
		img = EditorGUILayout.ObjectField( img, typeof( kissImage ), true ) as kissImage;
		if( EditorGUI.EndChangeCheck() && img != old_img )
		{
			if( old_img != null )
				scrl.RemoveIncreasingInputHandlersFrom( old_img );

			if( img != null )
				scrl.AddIncreasingInputHandlersTo( img );
		}

		if( i == 0 ) GUI.enabled = false;
		if( GUILayout.Button( "", style_MoveUp, GUILayout.Width( 12 ), GUILayout.Height( 12 ) ) )
			moveUp = i;
		if( i == 0 ) GUI.enabled = origEnabled && true;
		
		if( i == list.Count-1 ) GUI.enabled = false;
		if( GUILayout.Button( "", style_MoveDown, GUILayout.Width( 12 ), GUILayout.Height( 12 ) ) )
			moveDown = i;
		if( i == list.Count-1 ) GUI.enabled = origEnabled && true;
		
		if( GUILayout.Button( "", style_Remove, GUILayout.Width( 13 ), GUILayout.Height( 13 ) ) )
			removeAt = i;
		
		EditorGUILayout.EndHorizontal();
		
		if( exp[ i ] )
		{
			EditorGUILayout.BeginHorizontal();
			
			GUILayout.Space( 11 );
			
			EditorGUILayout.BeginVertical( (GUIStyle)"helpbox" );
			
			GUILayout.Space( 3 );
			
			GUILayout.Label( "ToDo: add additional options?" );
			
			GUILayout.Space( 3 );
			
			EditorGUILayout.EndVertical();
			
			EditorGUILayout.EndHorizontal();
			
			GUILayout.Space( 1 );
		}

		list[ i ] = img;

		if( moveUp > 0 && moveDown < list.Count - 1 )
		{
			kissImage imgTemp = list[ moveUp ];
			list.RemoveAt( moveUp );
			bool isExpanded = exp[ moveUp ];
			exp.RemoveAt( moveUp );
			
			list.Insert( moveUp - 1, imgTemp );
			exp.Insert( moveUp - 1, isExpanded );
		}
		
		if( moveDown >= 0 && moveDown < list.Count - 1 )
		{
			kissImage imgTemp = list[ moveDown ];
			list.RemoveAt( moveDown );
			bool isExpanded = exp[ moveDown ];
			exp.RemoveAt( moveDown );
			
			list.Insert( moveDown + 1, imgTemp );
			exp.Insert( moveDown + 1, isExpanded );
		}
		
		if( removeAt >= 0 )
		{
			kissImage imgRemove = list[ removeAt ];
			if( imgRemove != null )
				scrl.RemoveIncreasingInputHandlersFrom( imgRemove );

			list.RemoveAt( removeAt );
			exp.RemoveAt( removeAt );
		}

		GUI.enabled = origEnabled;
	}

	void DrawDecreaseImage( ref List< kissImage > list, ref List< bool > exp, int i )
	{
		bool origEnabled = GUI.enabled;
		
		kissImage img = list[ i ];
		int removeAt = -1;
		int moveUp = -1;
		int moveDown = -1;
		
		EditorGUILayout.BeginHorizontal();
		
		if( exp.Count != list.Count )
		{
			exp = new List< bool >();
			for( int j = 0; j < list.Count; j++ )
				exp.Add( false );
		}
		
		GUILayout.Label( i + ")" );
		
		exp[ i ] = GUILayout.Toggle( exp[ i ], "", (GUIStyle) "foldout", GUILayout.ExpandWidth( false ) );
		EditorGUI.BeginChangeCheck();
		kissImage old_img = img;
		img = EditorGUILayout.ObjectField( img, typeof( kissImage ), true ) as kissImage;
		if( EditorGUI.EndChangeCheck() && img != old_img )
		{
			if( old_img != null )
				scrl.RemoveDecreasingInputHandlersFrom( old_img );
			
			if( img != null )
				scrl.AddDecreasingInputHandlersTo( img );
		}
		
		if( i == 0 ) GUI.enabled = false;
		if( GUILayout.Button( "", style_MoveUp, GUILayout.Width( 12 ), GUILayout.Height( 12 ) ) )
			moveUp = i;
		if( i == 0 ) GUI.enabled = origEnabled && true;
		
		if( i == list.Count-1 ) GUI.enabled = false;
		if( GUILayout.Button( "", style_MoveDown, GUILayout.Width( 12 ), GUILayout.Height( 12 ) ) )
			moveDown = i;
		if( i == list.Count-1 ) GUI.enabled = origEnabled && true;
		
		if( GUILayout.Button( "", style_Remove, GUILayout.Width( 13 ), GUILayout.Height( 13 ) ) )
			removeAt = i;
		
		EditorGUILayout.EndHorizontal();
		
		if( exp[ i ] )
		{
			EditorGUILayout.BeginHorizontal();
			
			GUILayout.Space( 11 );
			
			EditorGUILayout.BeginVertical( (GUIStyle)"helpbox" );
			
			GUILayout.Space( 3 );
			
			GUILayout.Label( "ToDo: add additional options?" );
			
			GUILayout.Space( 3 );
			
			EditorGUILayout.EndVertical();
			
			EditorGUILayout.EndHorizontal();
			
			GUILayout.Space( 1 );
		}
		
		list[ i ] = img;
		
		if( moveUp > 0 && moveDown < list.Count - 1 )
		{
			kissImage imgTemp = list[ moveUp ];
			list.RemoveAt( moveUp );
			bool isExpanded = exp[ moveUp ];
			exp.RemoveAt( moveUp );
			
			list.Insert( moveUp - 1, imgTemp );
			exp.Insert( moveUp - 1, isExpanded );
		}
		
		if( moveDown >= 0 && moveDown < list.Count - 1 )
		{
			kissImage imgTemp = list[ moveDown ];
			list.RemoveAt( moveDown );
			bool isExpanded = exp[ moveDown ];
			exp.RemoveAt( moveDown );
			
			list.Insert( moveDown + 1, imgTemp );
			exp.Insert( moveDown + 1, isExpanded );
		}
		
		if( removeAt >= 0 )
		{
			kissImage imgRemove = list[ removeAt ];
			if( imgRemove != null )
				scrl.RemoveDecreasingInputHandlersFrom( imgRemove );
			
			list.RemoveAt( removeAt );
			exp.RemoveAt( removeAt );
		}
		
		GUI.enabled = origEnabled;
	}

//	void AddIncreasingInputHandlersTo( kissImage img )
//	{
//		//Debug.Log( "AddIncreasingInputHandlersTo( " + img.name + " )" );
//
//		kissScrolling.AddIncreasingInputHandlersTo( );
//	}
//
//	void RemoveIncreasingInputHandlersFrom( kissImage img )
//	{
//		Debug.Log( "RemoveIncreasingInputHandlersFrom( " + img.name + " )" );
//	}

	#endregion

}
