using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using kissUI;

[ExecuteInEditMode]
public class AllImagesFocusedCheck : MonoBehaviour
{
	public kissImage[] images2;


	// Use this for initialization
	void Start ()
	{
		//images2 = gameObject.GetComponentsInChildren< kissImage >();
	}

	void OnEnable()
	{
		images2 = gameObject.GetComponentsInChildren< kissImage >();

		for( int i = 0; i < images2.Length; i++ )
			images2[ i ].OnFocusReceived += OnFocusReceived;
	}

	void OnDisable()
	{
		for( int i = 0; i < images2.Length; i++ )
			images2[ i ].OnFocusReceived -= OnFocusReceived;
	}

	// Update is called once per frame
	//void Update () {}


	void OnFocusReceived( kissImage img )
	{
		Debug.Log( "OnFocusReceived:  " + img.name );
	}
}
