using UnityEngine;
using System;
using System.Collections;
using kissUI;

[ExecuteInEditMode]
public class Themes : MonoBehaviour
{
	public kissObject StartingNode;
	public string[] themes = new string[]{ "Windows7", "MacOSX" };
	public delegate void del_ThemeStyles_OnChanged( string BaseDir );
	public static del_ThemeStyles_OnChanged Themes_OnChanged = null;


	void OnEnable()
	{
		//TODO:  Repopulate Themes array from "./Resouces/Themes" directory, exclude "Default".
	}

	void OnDisable()
	{
		//..
	}

	public void ChangeThemeTo( int StyleIndex )
	{
		if( StyleIndex < 0 || StyleIndex >= themes.Length )
		{
			Debug.LogWarning( "kissThemeStyles.ChangeThemeTo()  StyleIndex has to be in Range!  Aborting.", this );
			return;
		}

		string Themes_ResourceDir = themes[ StyleIndex ];
		
		if( Themes_OnChanged != null )
			Themes_OnChanged( Themes_ResourceDir );
	}

}


