using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using kissUI;

[CustomEditor( typeof( kissFocusGroup ) )]
public class kissFocusGroupEditor : Editor
{
	kissFocusGroup focus_grp = null;
	SectionPanel section_FocusGrp;
	Texture2D section_icon = null;
	Color section_clr = Color.white;
	List< bool > expand_info = null;

	GUIStyle style_Add = null;
	GUIStyle style_AddLabel = null;
	GUIStyle style_Remove = null;
	GUIStyle style_MoveUp = null;
	GUIStyle style_MoveDown = null;
	GUIStyle style_Helpbox = null;

	void OnEnable()
	{
		section_FocusGrp = new SectionPanel( "kissFocusGroup" );		// doesnt matter what you pass in, as long as its a Unique Key

		focus_grp = target as kissFocusGroup;
		section_icon = null; //EditorGUIUtility.FindTexture( "PreMatCube" ) as Texture2D;
		section_clr = new Color( .90f, .86f, .90f, .8f );

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

		expand_info = new List< bool >();

		for( int i = 0; i < focus_grp.FocusList.Count; i++ )
			expand_info.Add( false );
	}

	void OnDisable()
	{
		// dont realy need this... just OCD! ;)

//		focus_grp = null;
//		section_FocusGrp = null;
//		section_icon = null;
//		expand_info = null;
	}
	
	public override void OnInspectorGUI()
	{
		GUIStyles_Check();

		kissGUI.BeginView( false );

		GUILayout.Space( 4 );

		DrawSection_FocusGroup();

		GUILayout.Space( 4 );

		kissGUI.EndView( false );
	}

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

	void DrawSection_FocusGroup()
	{
		string tabbed_info = "Images: " + focus_grp.FocusList.Count;

		kissGUI.BeginSection( "Focusing", tabbed_info, section_clr, section_FocusGrp, section_icon );
		if( section_FocusGrp.isVisible )
		{
			bool origEnabled = GUI.enabled;

			EditorGUI.BeginChangeCheck();
			focus_grp.FocusedIndex = EditorGUILayout.IntField( "Focused Index", focus_grp.FocusedIndex  );
			if( EditorGUI.EndChangeCheck() )
			{
				//TODO:   set the focus to the new image(s)
			}

			focus_grp.AutoFocusing = GUILayout.Toggle( focus_grp.AutoFocusing, " Auto Focus (via Index)" );

			GUI.enabled = ! focus_grp.AutoFocusing;

			for( int i = 0; i < focus_grp.FocusList.Count; i++ )
				DrawFocusInfo( focus_grp.FocusList, i );

			EditorGUILayout.BeginHorizontal();

			GUILayout.FlexibleSpace();

			EditorGUILayout.BeginHorizontal( style_Helpbox );
			GUILayout.Label( "Add", style_AddLabel, GUILayout.ExpandWidth( false ), GUILayout.ExpandHeight( false ) );
			if( GUILayout.Button( "", style_Add, GUILayout.Width( 13 ), GUILayout.Height(13) ) )
			{
				focus_grp.FocusList.Add( new kissFocusInfo() );
				expand_info.Add( true );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.EndHorizontal();

			//kissGUI.Separator( "", section_clr );
			


			GUI.enabled = origEnabled;
		}
		kissGUI.EndSection( section_FocusGrp );
	}

	void DrawFocusInfo( List<kissFocusInfo> InfoList, int i )
	{
		bool origEnabled = GUI.enabled;
		kissFocusInfo info = InfoList[ i ];
		int removeAt = -1;
		int moveUp = -1;
		int moveDown = -1;

		EditorGUILayout.BeginHorizontal();

		if( expand_info.Count != InfoList.Count )
		{
			expand_info = new List< bool >();
			for( int j = 0; j < focus_grp.FocusList.Count; j++ )
				expand_info.Add( false );
		}

		GUILayout.Label( i + ")" );

		expand_info[ i ] = GUILayout.Toggle( expand_info[ i ], "When", (GUIStyle) "foldout", GUILayout.ExpandWidth( false ) );
		info.Self = EditorGUILayout.ObjectField( info.Self, typeof( kissImage ), true ) as kissObject;

		if( i == 0 ) GUI.enabled = false;
		if( GUILayout.Button( "", style_MoveUp, GUILayout.Width( 12 ), GUILayout.Height( 12 ) ) )
			moveUp = i;
		if( i == 0 ) GUI.enabled = origEnabled && true;

		if( i == InfoList.Count-1 ) GUI.enabled = false;
		if( GUILayout.Button( "", style_MoveDown, GUILayout.Width( 12 ), GUILayout.Height( 12 ) ) )
			moveDown = i;
		if( i == InfoList.Count-1 ) GUI.enabled = origEnabled && true;

		if( GUILayout.Button( "", style_Remove, GUILayout.Width( 13 ), GUILayout.Height( 13 ) ) )
			removeAt = i;

		EditorGUILayout.EndHorizontal();
		
		if( expand_info[ i ] )
		{
			EditorGUILayout.BeginHorizontal();

			GUILayout.Space( 11 );

			EditorGUILayout.BeginVertical( (GUIStyle)"helpbox" );

			GUILayout.Space( 3 );

			info.Directions = (kissFocusDirections) EditorGUILayout.EnumPopup( "Directions", info.Directions );

			if( info.Directions == kissFocusDirections.Two )
				DrawTwoDirections( info );
			else if( info.Directions == kissFocusDirections.Four )
				DrawFourDirections( info );

			GUILayout.Space( 3 );

			EditorGUILayout.EndVertical();

			EditorGUILayout.EndHorizontal();

			GUILayout.Space( 1 );
		}

		if( moveUp > 0 && moveDown < InfoList.Count - 1 )
		{
			kissFocusInfo fi = InfoList[ moveUp ];
			InfoList.RemoveAt( moveUp );
			bool isExpanded = expand_info[ moveUp ];
			expand_info.RemoveAt( moveUp );

			InfoList.Insert( moveUp - 1, fi );
			expand_info.Insert( moveUp - 1, isExpanded );
		}

		if( moveDown >= 0 && moveDown < InfoList.Count - 1 )
		{
			kissFocusInfo fi = InfoList[ moveDown ];
			InfoList.RemoveAt( moveDown );
			bool isExpanded = expand_info[ moveDown ];
			expand_info.RemoveAt( moveDown );
			
			InfoList.Insert( moveDown + 1, fi );
			expand_info.Insert( moveDown + 1, isExpanded );
		}

		if( removeAt >= 0 )
		{
			InfoList.RemoveAt( removeAt );
			expand_info.RemoveAt( removeAt );
		}

		GUI.enabled = origEnabled;
	}

	void DrawTwoDirections( kissFocusInfo info )
	{
		info.FocusLeft =	EditorGUILayout.ObjectField( "Tab Previous", info.FocusLeft, typeof( kissImage ), true ) as kissObject;
		info.FocusRight =	EditorGUILayout.ObjectField( "Tab Next", info.FocusRight, typeof( kissImage ), true ) as kissObject;
	}

	void DrawFourDirections( kissFocusInfo info )
	{
		info.FocusLeft =	EditorGUILayout.ObjectField( "Arrow Left", info.FocusLeft, typeof( kissImage ), true ) as kissObject;
		info.FocusRight =	EditorGUILayout.ObjectField( "Arrow Right", info.FocusRight, typeof( kissImage ), true ) as kissObject;
		info.FocusUp =		EditorGUILayout.ObjectField( "Arrow Up", info.FocusUp, typeof( kissImage ), true ) as kissObject;
		info.FocusDown =	EditorGUILayout.ObjectField( "Arrow Down", info.FocusDown, typeof( kissImage ), true ) as kissObject;
	}

//	void DrawEightDirections( kissFocusInfo info )
//	{
//		//..
//	}

}



