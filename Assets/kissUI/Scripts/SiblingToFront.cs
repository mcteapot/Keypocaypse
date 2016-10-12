using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using kissUI;
using TS = TransitionStyles;

[ExecuteInEditMode]
public class SiblingToFront : MonoBehaviour
{

	#region 1.Variables

	public List< kissImage > 	setFocused = new List< kissImage >();
	public bool					isFocused = false;
	public int					UIStyleInUse	= 0;
	public string[]				ForegroundStyles = new string[]{ "Windows7", "MacOSX" };
	public string[]				BackgroundStyles = new string[]{ "Windows7 Back", "MacOSX Back" };
	public TS.TransitionType	stylesTransition;
	public float				transitionDuration = 2f;
	public float				transitionSpeed = .2f;

	private List< kissImage >	all_images;
	private kissObject			this_ko;
	private kissRaycast			uiRaycast;
	private kissFocusGroup		this_FocusGroup;

	#endregion



	#region Unity Events

	void Start()
	{
		//Debug.Log( "SiblingToFront.Start()" );

		kissNode root_node = kissUtility.Find_kissUI_Root( this_ko.Node );
		if( root_node != null )
			uiRaycast = root_node.obj.GetComponent< kissRaycast >();

		if( uiRaycast != null && uiRaycast.FocusedGroupIndex < uiRaycast.FocusGroups.Count )
		{	
			kissFocusGroup active_fg = uiRaycast.FocusGroups[ uiRaycast.FocusedGroupIndex ];

			if( active_fg != this_FocusGroup )
				FocusGroup_OnFocusLost( this_FocusGroup );
		}
	}

	void OnEnable()
	{
		//Debug.Log( "SiblingToFront.OnEnable()" );

		this_ko = gameObject.GetComponent< kissObject >();
		this_ko.Node.OthersAdd( this );

		kissImage[] found_images = this_ko.GetComponentsInChildren< kissImage >();
		all_images = new List< kissImage >( found_images );

		for( int i = 0; i < all_images.Count; i++ )
		{
			if( all_images[ i ] == null )
				continue;
			
			all_images[ i ].OnMouseDown += Image_OnMouseDown;
		}

		kissObject.OnObjectCreated += Global_OnObjectCreated;
		kissObject.OnObjectDestroyed += Global_OnObjectDestroyed;
		kissObject.OnParentChanged += Global_OnParentChanged;

		this_FocusGroup = gameObject.GetComponent< kissFocusGroup >();

		if( this_FocusGroup != null )
		{
			this_FocusGroup.OnFocusReceived += FocusGroup_OnFocusReceived;
			this_FocusGroup.OnFocusLost += FocusGroup_OnFocusLost;
		}

		Themes.Themes_OnChanged += Themes_OnChanged;
	}
	
	void OnDisable()
	{
		this_ko.Node.OthersRemove( this );

		for( int i = 0; i < all_images.Count; i++ )
		{
			if( all_images[ i ] == null )
				continue;
			
			all_images[ i ].OnMouseDown -= Image_OnMouseDown;
		}

		kissObject.OnObjectCreated -= Global_OnObjectCreated;
		kissObject.OnObjectDestroyed -= Global_OnObjectDestroyed;
		kissObject.OnParentChanged -= Global_OnParentChanged;

//		if( uiRaycast != null )
//		{
//			uiRaycast.FocusGroup_OnGroupChanged -= FocusGroup_OnGroupChanged;
//			uiRaycast.RemoveFocusGroup( this_FocusGroup );
//		}

		if( this_FocusGroup != null )
		{
			this_FocusGroup.OnFocusReceived -= FocusGroup_OnFocusReceived;
			this_FocusGroup.OnFocusLost -= FocusGroup_OnFocusLost;
		}

		Themes.Themes_OnChanged -= Themes_OnChanged;
	}

	void OnDestroy()
	{
		//Debug.Log( "Destroyed!" );

		if( uiRaycast != null )
			uiRaycast.RemoveFocusGroup( this_FocusGroup );
	}

	#endregion



	#region kissUI Events

	void Image_OnMouseDown( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		//Debug.Log( "SiblingToFront.OnMouseDown()  " + img.name );

		//Debug.Log( "uiRaycast.SetActiveFocusGroupTo()    this_FocusGroup: " + this_FocusGroup );

		uiRaycast.SetActiveFocusGroupTo( this_FocusGroup );

		this_ko.SetSiblingToLast();
	}

	void Global_OnObjectCreated( kissObject ko )
	{
		if( ko.ObjectType != kissObjectType.Image )
			return;

		// is this new Image object Our Descendant? lets find out.
		kissObject found_ko = kissUtility.FindOtherCompInParents( ko, this );

		if( found_ko == this_ko )
		{
			//Debug.Log( "YES!   Newly created Image is our Grand/Child. Adding MouseDown event." );

			kissImage img = ko as kissImage;
			img.OnMouseDown += Image_OnMouseDown;
		}

	}

	void Global_OnObjectDestroyed( kissObject ko )
	{
		if( ko.ObjectType != kissObjectType.Image )
			return;
		
		
		kissObject found_ko = kissUtility.FindOtherCompInParents( ko, this );
		
		if( found_ko == this_ko )
		{
			//Debug.Log( "YES!   Just about to be Destroyed object is a Grand/Child of ours." );

			kissImage img = ko as kissImage;
			img.OnMouseDown -= Image_OnMouseDown;		// might not even need this, sinnce the image is about to be destroyed. :p
		}

	}

	void Global_OnParentChanged( kissObject ko, kissObject oldParent, kissObject newParent )
	{
		//Debug.Log( "S2F:  OnParentChanged()   Name: " + this.name );

		int ours = 0;
		int add = 0;
		int rem = 0;

		if( newParent != null )
		{
			if( newParent == this_ko )
			{
				//Debug.Log( "YES!   newParent is a Grand/Child of ours." );

				ours++;
				add++;
			}
			else
			{
				kissObject found_ko = kissUtility.FindOtherCompInParents( newParent, this );
				if( found_ko == this_ko )
				{
					//Debug.Log( "YES!   newParent is a Grand/Child of ours." );

					ours++;
					add++;
				}
				else
				{
					//Debug.Log( "No!   newParent is Not a Grand/Child of ours." );
				}
			}
		}

		if( oldParent != null )
		{
			if( oldParent == this_ko )
			{
				//Debug.Log( "YES!   oldParent is a Grand/Child of ours." );

				ours++;
				rem++;
			}
			else
			{
				kissObject found_ko = kissUtility.FindOtherCompInParents( oldParent, this );
				if( found_ko == this_ko  )
				{
					//Debug.Log( "YES!   oldParent is a Grand/Child of ours." );

					ours++;
					rem++;
				}
				else
				{
					//Debug.Log( "No!   oldParent is Not a Grand/Child of ours." );
				}
			}
		}


		if( ours == 2 )	{}	// No Change Needed.
		else
		{
			if( add > 0 )
				AddMouseDownHandlerToImageChildren( ko );

			if( rem > 0 )
				RemoveMouseDownHandlerFromImageChildren( ko );
		}

	}

	void FocusGroup_OnFocusReceived( kissFocusGroup fg )
	{
		if( isFocused )
			return;

		//Debug.Log( "FocusGroup_OnFocusReceived()", fg );

		isFocused = true;

		for( int i = 0; i < setFocused.Count; i++ )
		{
			setFocused[ i ].ActiveState = kissState.Focused;
			setFocused[ i ].Update_State();
		}

		this_ko.SetSiblingToLast();

		if( UIStyleInUse < ForegroundStyles.Length )
			TS.ChangeStyles( this_ko, ForegroundStyles[ UIStyleInUse ] );
	}

	void FocusGroup_OnFocusLost( kissFocusGroup fg )
	{
		if( isFocused == false )
			return;

		//Debug.Log( "FocusGroup_OnFocusLost()", fg );

		isFocused = false;

		for( int i = 0; i < setFocused.Count; i++ )
		{
			setFocused[ i ].ActiveState = kissState.Normal;
			setFocused[ i ].Update_State();
		}

		if( UIStyleInUse < BackgroundStyles.Length )
			TS.ChangeStyles( this_ko, BackgroundStyles[ UIStyleInUse ] );
	}

	void Themes_OnChanged( string BaseDir )
	{
		string NewStylesDir = "";

		for( int i = 0; i < ForegroundStyles.Length; i++ )
		{
			if( ForegroundStyles[ i ] == BaseDir )
			{
				UIStyleInUse = i;
				break;
			}
		}
		
		if( isFocused )
		{
			if( UIStyleInUse < ForegroundStyles.Length )
			{
				NewStylesDir = ForegroundStyles[ UIStyleInUse ];
				DoTransitions( this_ko, NewStylesDir );
			}
		}
		else
		{
			if( UIStyleInUse < BackgroundStyles.Length )
			{
				NewStylesDir = BackgroundStyles[ UIStyleInUse ];
				DoTransitions( this_ko, NewStylesDir );
			}
		}
	}

	#endregion



	#region Styling funcs

	public void DoTransitions( kissObject ko, string Themes_ResourceDir )
	{
		TransitionStyles ts = new TransitionStyles();
		ts.monoBehaviour = this;
		ts.Transition = stylesTransition;
		ts.ThemeDir = Themes_ResourceDir;
		ts.CurrentTime = 0f;
		ts.DurationTime = transitionDuration;
		ts.SpeedTime = transitionSpeed;
		
		StartCoroutine( ts.DoTransitions( ko ) );
	}

	#endregion



	#region Mouse Down Handler funcs
	
	public void AddMouseDownHandlerToImageChildren( kissObject ko )
	{
		if( ko.ObjectType == kissObjectType.Image )
			AddMouseDownHandlerFor( ko as kissImage );
		
		for( int i = 0; i < ko.Node.Children.Count; i++ )
			AddMouseDownHandlerToImageChildren( ko.Node.Children[ i ].obj );
	}
	
	public void RemoveMouseDownHandlerFromImageChildren( kissObject ko )
	{
		if( ko.ObjectType == kissObjectType.Image )
			RemoveMouseDownHandlerFor( ko as kissImage );
		
		for( int i = 0; i < ko.Node.Children.Count; i++ )
			RemoveMouseDownHandlerFromImageChildren( ko.Node.Children[ i ].obj );
	}
	
	public void AddMouseDownHandlerFor( kissImage imgAddHandler )
	{
		bool isImageInListing = false;
		
		for( int i = 0; i < all_images.Count; i++ )
		{
			if( all_images[ i ] == null )
				continue;
			
			if( all_images[ i ].Tran == imgAddHandler.Tran )
			{
				all_images[ i ].OnMouseDown += Image_OnMouseDown;
				isImageInListing = true;
				break;
			}
		}
		
		if( isImageInListing == false )
		{
			imgAddHandler.OnMouseDown += Image_OnMouseDown;
			all_images.Add( imgAddHandler );
		}
	}
	
	public void RemoveMouseDownHandlerFor( kissImage imgRemoveHandler )
	{
		for( int i = 0; i < all_images.Count; i++ )
		{
			if( all_images[ i ] == null )
				continue;
			
			if( all_images[ i ].Tran == imgRemoveHandler.Tran )
			{
				all_images[ i ].OnMouseDown -= Image_OnMouseDown;
				break;
			}
		}
	}

	#endregion
	
}




public class TransitionStyles
{
	public enum TransitionType
	{
		None		= 0,
		Morph		= 1,
		Fade		= 2,
		AddMoreHere,
	}

	public TransitionType Transition;
	public float DurationTime = 2f;
	public float CurrentTime = 0f;
	public float SpeedTime = .2f;
	public string ThemeDir = "";
	public MonoBehaviour monoBehaviour;

	kissFolderStruc FS = null;
	//kissObject ko_Root = null;
	kissObject ko_Duplicate = null;
	//Dictionary< kissObject, kissStyle > styles = new Dictionary< kissObject, kissStyle >();
	Dictionary< kissObject, TransitionInfo > objects = new Dictionary< kissObject, TransitionInfo >();


	public IEnumerator DoTransitions( kissObject ko )
	{
		string pathToUIStylesFile = "UIStyles/UIStyles";	// + ".txt"
		
		bool isFSGood = kissUtility.PopulateFolderStructure( pathToUIStylesFile, out FS );
		
		if( isFSGood == false )
		{
			Debug.LogWarning( "Resources Folder Structure:  Couldn't be loaded!  Aborting! " + FS.ToString(), ko );
			yield break;	// end this Coroutine
		}

		if( Transition == TransitionType.None )
		{
			ChangeStyles( ko, ThemeDir );
		}
		else if( Transition == TransitionType.Morph )
		{
			//ko_Root = ko;

			ko_Duplicate = MakeDuplicate( ko );

			objects.Clear();

			FindAndLoadStyledObjects( ko, ko_Duplicate );

			// wait for DoMorphTransitions_Recursive() to complete, before continuing
			//yield return monoBehaviour.StartCoroutine( DoMorphTransitions_Recursive( ko, null ) );

			// wait for DoMorphTransitions() to complete, before continuing
			yield return monoBehaviour.StartCoroutine( DoMorphTransitions() );
		}
		else if( Transition == TransitionType.Fade )
		{
			//TODO
		}

		ko.Refresh();
	}

	IEnumerator DoMorphTransitions()
	{
//		if( CurrentTime == 0f )
//		{
//			objects.Clear();
//			
//			ko_clone = ko_Duplicate;
//		}

		while( CurrentTime < DurationTime )
		{
			CurrentTime += SpeedTime;
			
			foreach( KeyValuePair< kissObject, TransitionInfo > p in objects )
			{
				TransitionInfo ti = p.Value;

				DoMorphTransitionStyle_Step( ti );

				yield return null;	//wait for next frame
			}

//			for( int i = 0; i < objects.Count; i++ )
//			{
//				if( ko_clone != null )
//				{
//					kissObject ko_clone_child = ko_clone.Node.Children[ i ].obj;
//					yield return null;	//wait for next frame
//				}
//			}
			
			yield return null;	//wait for next frame
		}
		
		
		if( CurrentTime >= DurationTime )
		{
			CurrentTime = DurationTime;

			foreach( KeyValuePair< kissObject, TransitionInfo > p in objects )
			{
				TransitionInfo ti = p.Value;
				
				ApplyStyleFromResources( ti.ko );
			}

			if( ko_Duplicate != null )
			{
				if( Application.isEditor )
					UnityEngine.Object.DestroyImmediate( ko_Duplicate.gameObject );
				else
					UnityEngine.Object.Destroy( ko_Duplicate.gameObject );
			}
			
			yield break; // return;
		}
		
		
		Debug.Log( "CurrentTime:  " + CurrentTime );
	}

//	IEnumerator DoMorphTransitions_Recursive( kissObject ko, kissObject ko_clone )
//	{
//		if( CurrentTime == 0f )
//		{
//			objects.Clear();
//
//			ko_clone = ko_Duplicate;
//		}
//
//
//		LoadStyleFromResources( ko, ko_clone );
//
//
//		while( CurrentTime < DurationTime )
//		{
//			if( ko == ko_Root )
//				CurrentTime += 0.2f;
//
//			DoMorphTransitionStyle_Step( ko );
//			
//			for( int i = 0; i < ko.Node.Children.Count; i++ )
//			{
//				if( ko_clone != null )
//				{
//					kissObject ko_clone_child = ko_clone.Node.Children[ i ].obj;
//					monoBehaviour.StartCoroutine( 
//					                             DoMorphTransitions_Recursive( ko.Node.Children[ i ].obj, ko_clone_child ) );
//					yield return null;	//wait for next frame
//				}
//			}
//
//			yield return null;	//wait for next frame
//		}
//
//
//		if( CurrentTime >= DurationTime )
//		{
//			CurrentTime = DurationTime;
//			ApplyStyleFromResources( ko );
//
//			if( ko_Duplicate != null )
//			{
//				if( Application.isEditor )
//					UnityEngine.Object.DestroyImmediate( ko_Duplicate.gameObject );
//				else
//					UnityEngine.Object.Destroy( ko_Duplicate.gameObject );
//			}
//
//			yield break; // return;
//		}
//
//
//		Debug.Log( "CurrentTime:  " + CurrentTime );
//	}

	void DoMorphTransitionStyle_Step( TransitionInfo ti )
	{
		float percent = CurrentTime / DurationTime;

//		if( percent < 0f || percent > 1f )
//			return;

		kissObject ko = ti.ko;

		int Width_Current = (int) Mathf.Lerp( ti.Width_Begin, ti.Width_End, percent );
		int Height_Current = (int) Mathf.Lerp( ti.Height_Begin, ti.Height_End, percent );
		
		ko.Width = Width_Current;
		ko.Height = Height_Current;
		
		ko.Refresh();

//		if( ko.ObjectType == kissObjectType.Camera )
//		{
//			kissCamera.ReCalculate_Size( ko as kissCamera );
//		}
//		else if( ko.ObjectType == kissObjectType.Group )
//		{
//			kissGroup.ReCalculate_Size( ko as kissGroup );
//		}
//		else if( ko.ObjectType == kissObjectType.Layout )
//		{
//			kissLayout.ReCalculate_Size( ko as kissLayout );
//		}
//		else if( ko.ObjectType == kissObjectType.Image )
//		{
//			kissImage.ReCalculate_Size( ko as kissImage );
//		}
//		else if( ko.ObjectType == kissObjectType.Text )
//		{
//			( ko as kissText ).ReCalculate_Size();
//		}

	}

//	void DoMorphTransitionStyle_Step( kissObject ko )
//	{
//		float percent = CurrentTime / DurationTime;
//
//		if( percent < 0f || percent > 1f )
//			return;
//
//		bool wasAlreadyLoaded = objects.ContainsKey( ko );
//
//		if( wasAlreadyLoaded )
//		{
//			TransitionInfo ti = objects[ ko ];
//
//			int Width_Current = (int) Mathf.Lerp( ti.Width_Begin, ti.Width_End, percent );
//			int Height_Current = (int) Mathf.Lerp( ti.Height_Begin, ti.Height_End, percent );
//
//			ko.Width = Width_Current;
//			ko.Height = Height_Current;
//
//			ko.Refresh();
//		}
//	}

	kissObject MakeDuplicate( kissObject ko )
	{
		kissObject ko_Dup = DuplicateObjects( ko, null );
		ChangeStyles( ko_Dup, ThemeDir );	// apply new styles to duplicate
		
		if( ko_Dup.ObjectType == kissObjectType.Image )
			(ko_Dup as kissImage).IsVisible = false;
		else if( ko_Dup.ObjectType == kissObjectType.Text )
			(ko_Dup as kissText).IsVisible = false;
		
		ko_Dup.HideChildren = true;
		ko_Dup.Refresh();
		
		return ko_Dup;
	}

	int FindAndLoadStyledObjects( kissObject ko, kissObject ko_clone )
	{
		int countStyled = 0;

		if( ko.Style != null )
		{
			countStyled++;
			LoadStyleFromResources( ko, ko_clone );
		}

		for( int i = 0; i < ko.Node.Children.Count; i++ )
		{
			kissObject ko_child = ko.Node.Children[ i ].obj;
			kissObject ko_clone_child = ko_clone.Node.Children[ i ].obj;
			countStyled += FindAndLoadStyledObjects( ko_child, ko_clone_child );
		}

		return countStyled;
	}

	void LoadStyleFromResources( kissObject ko, kissObject ko_clone )
	{
		bool wasAlreadyLoaded = objects.ContainsKey( ko );

		if( wasAlreadyLoaded == false && ko.Style != null && ko.Style.AssetPath != "" )
		{
			string[] StylePath = ko.Style.AssetPath.Split( "/"[0] );
			StylePath[ 2 ] = ThemeDir;
			string ResourceStylePath = String.Join( "/", StylePath ).Replace( "Resources/", "" ).Replace( ".asset", "" );

			TransitionInfo ti = new TransitionInfo();

			if( ko.ObjectType == kissObjectType.Camera )
			{
				kissStyleCamera camStyle = Resources.Load( ResourceStylePath ) as kissStyleCamera;
				if( camStyle != null )
				{
					ti.Style_Begin = (ko as kissCamera).Style;
					ti.Style_End = camStyle;

					(ko as kissCamera).Style = null;
				}
			}
			else if( ko.ObjectType == kissObjectType.Group )
			{
				kissStyleGroup grpStyle = Resources.Load( ResourceStylePath ) as kissStyleGroup;
				if( grpStyle != null )
				{
					ti.Style_Begin = (ko as kissGroup).Style;
					ti.Style_End = grpStyle;

					(ko as kissGroup).Style = null;
				}
			}
			else if( ko.ObjectType == kissObjectType.Layout )
			{
				kissStyleLayout loStyle = Resources.Load( ResourceStylePath ) as kissStyleLayout;
				if( loStyle != null )
				{
					ti.Style_Begin = (ko as kissLayout).Style;
					ti.Style_End = loStyle;

					(ko as kissLayout).Style = null;
				}
			}
			else if( ko.ObjectType == kissObjectType.Image )
			{
				kissStyleImage imgStyle = Resources.Load( ResourceStylePath ) as kissStyleImage;
				if( imgStyle != null )
				{
					ti.Style_Begin = (ko as kissImage).Style;
					ti.Style_End = imgStyle;

//					if( ko_clone != null )
//					{
//						if( ti.Style_End == ko_clone.Style )
//							Debug.Log( "ti.Style_End == ko_clone.Style" );
//						else
//							Debug.Log( "ti.Style_End != ko_clone.Style" );
//					}

					(ko as kissImage).Style = null;
				}
			}
			else if( ko.ObjectType == kissObjectType.Text )
			{
				kissStyleText txtStyle = Resources.Load( ResourceStylePath ) as kissStyleText;
				if( txtStyle != null )
				{
					ti.Style_Begin = (ko as kissText).Style;
					ti.Style_End = txtStyle;
					
					(ko as kissText).Style = null;
				}
			}

			ti.ko_clone = ko_clone;

			if( ti.ko_clone != null )
			{
				ti.Width_Begin = ko.Width;
				ti.Width_End = ti.ko_clone.Width;
				
				ti.Height_Begin = ko.Height;
				ti.Height_End = ti.ko_clone.Height;
			}

			ti.ko = ko;

			objects.Add( ko, ti );
			
		}
	}

	void ApplyStyleFromResources( kissObject ko )
	{
		bool wasAlreadyLoaded = objects.ContainsKey( ko );

		if( wasAlreadyLoaded )
		{
			TransitionInfo ti = objects[ ko ];

			if( ko.ObjectType == kissObjectType.Camera )
			{
				(ko as kissCamera).Style = ti.Style_End as kissStyleCamera;
			}
			else if( ko.ObjectType == kissObjectType.Group )
			{
				(ko as kissGroup).Style = ti.Style_End as kissStyleGroup;
			}
			else if( ko.ObjectType == kissObjectType.Layout )
			{
				(ko as kissLayout).Style = ti.Style_End as kissStyleLayout;
			}
			else if( ko.ObjectType == kissObjectType.Image )
			{
				(ko as kissImage).Style = ti.Style_End as kissStyleImage;
			}
			else if( ko.ObjectType == kissObjectType.Text )
			{
				(ko as kissText).Style = ti.Style_End as kissStyleText;
			}
		}
	}

	kissObject DuplicateObjects( kissObject ko, kissObject ko_parent )
	{
		kissObject ko_dup = kissUtility.DuplicateObjectTree( ko );
		//ko_dup.HideChildren = true;
		
		return ko_dup;
	}

	public static void ChangeStyles( kissObject ko, string BaseDir )
	{
		kissFolderStruc UIStylesFolderStruc;
		string pathToUIStylesFile = "UIStyles/UIStyles";	// + ".txt"
		
		bool isGood = kissUtility.PopulateFolderStructure( pathToUIStylesFile, out UIStylesFolderStruc );
		
		if( isGood == false )
		{
			Debug.LogWarning( "Resources Folder Structure couldnt be loaded!  Aborting!", ko );
			return;
		}
		
		ChangeStyles_Recursive( ko, UIStylesFolderStruc, BaseDir );
		
		ko.Refresh();
	}
	
	static void ChangeStyles_Recursive( kissObject ko, kissFolderStruc FS, string BaseDir )
	{
		if( ko.Style != null && ko.Style.AssetPath != "" )
		{
			string[] StylePath = ko.Style.AssetPath.Split( "/"[0] );
			StylePath[ 2 ] = BaseDir;
			string ResourceStylePath = String.Join( "/", StylePath ).Replace( "Resources/", "" ).Replace( ".asset", "" );
			
			if( ko.ObjectType == kissObjectType.Camera )
			{
				kissStyleCamera camStyle = Resources.Load( ResourceStylePath ) as kissStyleCamera;
				if( camStyle != null )
					(ko as kissCamera).Style = camStyle;
			}
			else if( ko.ObjectType == kissObjectType.Group )
			{
				kissStyleGroup grpStyle = Resources.Load( ResourceStylePath ) as kissStyleGroup;
				if( grpStyle != null )
					(ko as kissGroup).Style = grpStyle;
			}
			else if( ko.ObjectType == kissObjectType.Layout )
			{
				kissStyleLayout loStyle = Resources.Load( ResourceStylePath ) as kissStyleLayout;
				if( loStyle != null )
					(ko as kissLayout).Style = loStyle;
			}
			else if( ko.ObjectType == kissObjectType.Image )
			{
				kissStyleImage imgStyle = Resources.Load( ResourceStylePath ) as kissStyleImage;
				if( imgStyle != null )
					(ko as kissImage).Style = imgStyle;
			}
			else if( ko.ObjectType == kissObjectType.Text )
			{
				kissStyleText txtStyle = Resources.Load( ResourceStylePath ) as kissStyleText;
				if( txtStyle != null )
					(ko as kissText).Style = txtStyle;
			}
		}
		
		for( int i = 0; i < ko.Node.Children.Count; i++ )
			ChangeStyles_Recursive( ko.Node.Children[ i ].obj, FS, BaseDir );
	}
}



public struct TransitionInfo
{
	public int Width_Begin;
	public int Width_End;
	public int Height_Begin;
	public int Height_End;

	public kissStyle Style_Begin;
	public kissStyle Style_End;

	public kissObject ko;
	public kissObject ko_clone;
}


