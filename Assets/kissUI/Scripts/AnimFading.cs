using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using kissUI;

[ExecuteInEditMode]
public class AnimFading : MonoBehaviour
{
	public Color				Clr = Color.white;
	// ---
	private Color				ClrLast;
	private kissObject			this_ko;
	private List< kissImage >	all_images;

	void OnEnable()
	{
		this_ko = gameObject.GetComponent< kissObject >();
		this_ko.Node.OthersAdd( this );
		
		kissImage[] found_images = this_ko.GetComponentsInChildren< kissImage >();
		all_images = new List< kissImage >( found_images );
		
//		for( int i = 0; i < all_images.Count; i++ )
//		{
//			if( all_images[ i ] == null )
//				continue;
//			
//			all_images[ i ].OnMouseDown += Image_OnMouseDown;
//		}
	}

	void OnDisable()
	{
		this_ko.Node.OthersRemove( this );

//		for( int i = 0; i < all_images.Count; i++ )
//		{
//			if( all_images[ i ] == null )
//				continue;
//			
//			all_images[ i ].OnMouseDown -= Image_OnMouseDown;
//		}
	}

	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update ()
	{
		if( ClrLast != Clr )
		{
			ClrLast = Clr;

			UpdateAlphaValueForAllImages();

			//Debug.Log( "Color Value Differs" );
		}
		
	}


	void UpdateAlphaValueForAllImages()
	{
		for( int i = 0; i < all_images.Count; i++ )
		{
			if( all_images[ i ] == null )
				continue;
			
			kissImage img = all_images[ i ];
			kissImageData state = img.StateData[ (int) img.ActiveState ];

			state.sh_BottomLeft.From.a = Clr.a;
			state.sh_BottomLeft.To.a = Clr.a;

			state.sh_Bottom.From.a = Clr.a;
			state.sh_Bottom.To.a = Clr.a;

			state.sh_BottomRight.From.a = Clr.a;
			state.sh_BottomRight.To.a = Clr.a;

			state.sh_Left.From.a = Clr.a;
			state.sh_Left.To.a = Clr.a;

			state.sh_Middle.From.a = Clr.a;
			state.sh_Middle.To.a = Clr.a;

			state.sh_Right.From.a = Clr.a;
			state.sh_Right.To.a = Clr.a;

			state.sh_TopLeft.From.a = Clr.a;
			state.sh_TopLeft.To.a = Clr.a;

			state.sh_Top.From.a = Clr.a;
			state.sh_Top.To.a = Clr.a;

			state.sh_TopRight.From.a = Clr.a;
			state.sh_TopRight.To.a = Clr.a;

			img.Update_State();
		}
	}

}




