using UnityEngine;
using System.Collections;
using kissUI;

[ExecuteInEditMode]
public class FocusHighlight : MonoBehaviour
{
	public kissImage		Highlight;
	public kissFocusGroup	FocusGroup;
	// --
	private kissImage		img_Self;

	void OnEnable()
	{
		//Debug.Log( "FocusHighlite:  OnEnable()" );
		
		if( img_Self == null )
			img_Self = gameObject.GetComponent< kissImage >();
		
		if( img_Self != null )
		{
			img_Self.OnFocusReceived += Self_OnFocusReceived;
			img_Self.OnFocusLost += Self_OnFocusLost;

			FocusGroup = img_Self.GetComponentInParent< kissFocusGroup >();
			if( FocusGroup != null )
			{
				FocusGroup.OnFocusReceived +=	FocusGroup_OnFocusReceived;
				FocusGroup.OnFocusLost +=		FocusGroup_OnFocusLost;
			}
		}

	}
	
	void OnDisable()
	{
		//Debug.Log( "FocusHighlite:  OnDisable()" );
		
		if( img_Self != null )
		{
			img_Self.OnFocusReceived -= Self_OnFocusReceived;
			img_Self.OnFocusLost -= Self_OnFocusLost;

			if( FocusGroup != null )
			{
				FocusGroup.OnFocusReceived -=	FocusGroup_OnFocusReceived;
				FocusGroup.OnFocusLost -= 		FocusGroup_OnFocusLost;
			}
		}
	}
	
	void Self_OnFocusReceived( kissImage img )
	{
		//Debug.Log( "FocusHighlite:  Self_OnFocusReceived()   Name: " + img.name );

		Highlight.IsVisible = true;
		Highlight.Refresh();
	}

	void Self_OnFocusLost( kissImage img )
	{
		//Debug.Log( "FocusHighlite:  Self_OnFocusLost()  Name: " + img.name );
		
		Highlight.IsVisible = false;
		Highlight.Refresh();
	}

	void FocusGroup_OnFocusReceived( kissFocusGroup fg )
	{
		//Debug.Log( "FocusGroup_OnFocusReceived()   Name: " + fg.name );

		Highlight.ActiveState = kissState.Focused;
		Highlight.Update_State();
	}

	void FocusGroup_OnFocusLost( kissFocusGroup fg )
	{
		//Debug.Log( "FocusGroup_OnFocusLost()   Name: " + fg.name );

		Highlight.ActiveState = kissState.Normal;
		Highlight.Update_State();
	}
	
}



