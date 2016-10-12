using UnityEngine;
using kissUI;

[ExecuteInEditMode]
public class ReparentSourceOnMouseDrop : MonoBehaviour
{
	kissImage _img = null;


	// ---- Unity Events ----

	void OnEnable()
	{
		_img = GetComponent< kissImage >();
		
		if( _img != null )
		{
			_img.OnMouseDrop += onMouseDrop;
			//Debug.Log( "ReparentSourceOnMouseDrop.OnEnable():   onMouseDrop", _img );

		}
	}
	
	void OnDisable()
	{
		if( _img != null )
		{
			_img.OnMouseDrop -= onMouseDrop;
			//Debug.Log( "ReparentSourceOnMouseDrop.OnDisable():   onMouseDrop", _img );

		}
	}
	
	
	// ---- kissUI Events ----
	
	public void onMouseDrop( kissImage imgDropTarget, kissMouseButton Btn, kissModifier KeyMod, Vector2 Pos, kissImage imgSource )
	{
		//Debug.Log( "ReparentSourceOnMouseDrop:   onMouseDrop()", imgDropTarget );

		bool hasDragSource = HasDragSource( imgDropTarget );
		if( hasDragSource )
		{
			//Debug.Log( "This Drop Target already has a Drag Source.  Aborting Drop!", imgDropTarget );
			return;
		}

		SiblingToFront s2f = imgSource.GetComponentInParent< SiblingToFront >();
		if( s2f != null )
			s2f.RemoveMouseDownHandlerFor( imgSource );

		imgSource.PosOffset = new Vector3( 0f, 0f, -.1f );
		imgSource.ParentTo( imgDropTarget );
		kissUtility.RemoveClipping( imgDropTarget.Node );
		kissUtility.AddClipping( imgDropTarget.Node );

		s2f = imgSource.GetComponentInParent< SiblingToFront >();
		if( s2f != null )
		{
			s2f.AddMouseDownHandlerFor( imgSource );
			kissObject s2f_ko = s2f.GetComponent< kissObject >();

			if( s2f_ko != null )
				s2f_ko.SetSiblingToLast();
		}
		
	}

	// ---- Other Funcs ----

	bool HasDragSource( kissImage imgDropTarget )
	{
		bool hasDragSource = false;

		for( int i = 0; i < imgDropTarget.Node.Children.Count; i++ )
		{
			kissObject ko = imgDropTarget.Node.Children[ i ].obj;

			if( ko.ObjectType == kissObjectType.Image )
			{
				kissImage img = ko as kissImage;
				if( img.DragDropKind == kissImage.DragDropType.DragSource )
				{
					//BINGO! Found One!
					hasDragSource = true;
					break;
				}
			}
		}

		return hasDragSource;
	}
	
}
