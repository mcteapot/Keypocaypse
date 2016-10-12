using UnityEngine;
using System.Collections;
using System;
using kissUI;

[ExecuteInEditMode]
public class InputHandlingFromCode : MonoBehaviour
{
	kissImage img = null;


	void OnEnable()
	{
		img = GetComponent< kissImage >();

		if( img != null )
		{
			img.OnMouseEnter += onMouseEnter;
			img.OnMouseLeave += onMouseLeave;
			img.OnMouseDown += onMouseDown;
			img.OnMouseHeld += onMouseHeld;
			img.OnMouseDrag += onMouseDrag;
			img.OnMouseDrop += onMouseDrop;
			img.OnMouseMoved += onMouseMoved;
			img.OnMouseUp += onMouseUp;
			img.OnMouseDoubleClick += onMouseDoubleClick;
			img.OnMouseWheel += onMouseWheel;
			img.OnKeyCharDown += onKeyCharDown;
			img.OnKeyCharUp += onKeyCharUp;
			img.OnKeyCharHeld += onKeyCharHeld;
		}
	}

	void OnDisable()
	{
		if( img != null )
		{
			img.OnMouseEnter -= onMouseEnter;
			img.OnMouseLeave -= onMouseLeave;
			img.OnMouseDown -= onMouseDown;
			img.OnMouseHeld -= onMouseHeld;
			img.OnMouseDrag -= onMouseDrag;
			img.OnMouseDrop -= onMouseDrop;
			img.OnMouseMoved -= onMouseMoved;
			img.OnMouseUp -= onMouseUp;
			img.OnMouseDoubleClick -= onMouseDoubleClick;
			img.OnMouseWheel -= onMouseWheel;
			img.OnKeyCharDown -= onKeyCharDown;
			img.OnKeyCharUp -= onKeyCharUp;
			img.OnKeyCharHeld -= onKeyCharHeld;
		}
	}


	// ---------

	public void onMouseEnter( kissImage img )
	{
		//Debug.Log( "InputHandlingFromCode:   onMouseEnter()", img );
	}

	public void onMouseLeave( kissImage img )
	{
		//Debug.Log( "InputHandlingFromCode:   onMouseLeave()", img );
	}

	public void onMouseDown( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		//Debug.Log( "InputHandlingFromCode:   onMouseDown()", img );
	}

	public void onMouseHeld( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		//Debug.Log( "InputHandlingFromCode:   onMouseHeld()", img );
	}

	public void onMouseUp( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos, bool isOver )
	{
		//Debug.Log( "InputHandlingFromCode:   onMouseUp()", img );
	}

	public void onMouseDrag( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		//Debug.Log( "InputHandlingFromCode:   onMouseDrag()", img );
	}

	public void onMouseDrop( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos, kissImage imgSource )
	{
		Debug.Log( "InputHandlingFromCode:   onMouseDrop()", img );
	}

	public void onMouseMoved( kissImage img, Vector2 Pos )
	{
		//Debug.Log( "InputHandlingFromCode:   onMouseMoved()   Pos: " + Pos, img );
	}

	public void onMouseDoubleClick( kissImage img, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos )
	{
		//Debug.Log( "InputHandlingFromCode:   onMouseDoubleClick()", img );
	}

	public void onMouseWheel( kissImage img, int DeltaX, int DeltaY, kissModifier KeyMod )
	{
		//Debug.Log( "InputHandlingFromCode:   onMouseWheel()", img );
	}

	public void onKeyCodeDown( kissImage img, KeyCode code )
	{
		//Debug.Log( "InputHandlingFromCode:   onKeyCodeDown( " + code + " )", img );
	}

	public void onKeyCodeUp( kissImage img, KeyCode code )
	{
		//Debug.Log( "InputHandlingFromCode:   onKeyCodeUp( " + code + " )", img );
	}

	public void onKeyCharDown( kissImage img, char ch )
	{
		//Debug.Log( "InputHandlingFromCode:   onKeyCharDown( " + ch + " )", img );
	}

	public void onKeyCharUp( kissImage img, char ch )
	{
		//Debug.Log( "InputHandlingFromCode:   onKeyCharUp( " + ch + " )", img );
	}

	public void onKeyCharHeld( kissImage img, char ch )
	{
		//Debug.Log( "InputHandlingFromCode:   onKeyCharHeld( " + ch + " )", img );
	}

	// ---------


	public void TestFunc1()
	{
		Debug.Log( "TestFunc1()" );
	}
	
	
	public void testTwo()
	{
		string sPath = GetGameObjectPath( gameObject );
		Debug.Log( "testTwo()  GameObject Path:  " + sPath );
	}
	
	public static string GetGameObjectPath( GameObject obj )
	{
		string path = "/" + obj.name;
		while (obj.transform.parent != null)
		{
			obj = obj.transform.parent.gameObject;
			path = "/" + obj.name + path;
		}
		
		return path;
	}

	public void ManuallyRaiseEvent_OnMouseDown()		// InvokeMulticastDelegate_OnMouseDown
	{
		if( img == null )
			return;

		//		foreach( Action method in img.OnMouseDown )
		//			method.Invoke(...);

		img.OnMouseDown( img, kissMouseButton.Left, kissModifier.None, new Vector2( 10f, 10f ) );
	}
}


