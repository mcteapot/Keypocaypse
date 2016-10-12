using UnityEngine;
using System.Collections;
using kissUI;

[ExecuteInEditMode]
public class kissDragToResize : MonoBehaviour
{
	public kissRaycast		uiRaycast;
	public kissObject		objectToResize;
	public bool				resizeWidth = true;
	public bool				resizeHeight = true;
	public bool				repositionX = true;
	public bool				repositionY = true;
	public bool				invertHeight = false;
	// ---
	private kissImage		img = null;
	private HitInfo			hi = null;
	private int				mouseDown_OffsetX = 0;
	private int				mouseDown_OffsetY = 0;
	private int				mouseDown_X = 0;
	private int				mouseDown_Y = 0;
	private int				mouseDown_W = 0;
	private int				mouseDown_H = 0;
	private int				max_OffsetX = 0;
	private int				max_OffsetY = 0;
	
	void Start()
	{
		if( uiRaycast == null )
		{
			Transform tran_Root = kissUtility.Find_kissUI_Root( transform );
			uiRaycast = tran_Root.GetComponent< kissRaycast >();
		}
	}
	
	public void onMouseDown()
	{
		if( uiRaycast == null )
		{
			Debug.LogWarning( "uiRaycast not set for '" + this.name + "'.  Abort!" );
			return;
		}
		
		if( objectToResize == null )
		{
			Debug.LogWarning( "objectToResize not set for '" + this.name + "'.  Abort!" );
			return;
		}

		hi = uiRaycast.GetHitInfo( transform );
		
		if( hi == null )
			hi = uiRaycast.hitInfo;

		mouseDown_X = (int) hi.MousePos.x;
		mouseDown_Y = (int) hi.MousePos.y;

		if( resizeWidth )
			mouseDown_W = objectToResize.Width;
		
		if( resizeHeight )
			mouseDown_H = objectToResize.Height;
		
		if( repositionX || repositionY )
		{
			mouseDown_OffsetX = (int) objectToResize.PosOffset.x;
			mouseDown_OffsetY = (int) objectToResize.PosOffset.y;

			max_OffsetX = (mouseDown_W + mouseDown_OffsetX) - objectToResize.WidthMin;
			max_OffsetY = 0 - ((mouseDown_H - mouseDown_OffsetY) - objectToResize.HeightMin);

			if( img == null )
				img = gameObject.GetComponent< kissImage >();
		}

	}

	public void onMouseUp()
	{
		//Transform parent_tran = LayoutToResize.transform.parent == null ? LayoutToResize.transform : LayoutToResize.transform.parent;
		//kissUtility.ReCalculate_SizePosition( parent_tran, cParentToResize );
	}

	public void onMouseDrag()
	{
		if( uiRaycast == null )
			return;
		
		if( objectToResize == null )
			return;
		
		int diff_X = 0;
		int diff_Y = 0;
		
		int new_OffsetX = mouseDown_OffsetX;
		int new_OffsetY = mouseDown_OffsetY;
		float new_OffsetZ = objectToResize.PosOffset.z;
		
		if( resizeWidth )
		{
			int new_W = 0;
			int diff_W = mouseDown_X - (int) hi.MousePos.x;

			if( repositionX )		new_W = mouseDown_W + diff_W;
			else					new_W = mouseDown_W - diff_W;

			new_W = Mathf.Clamp( new_W, objectToResize.WidthMin, objectToResize.WidthMax );
			objectToResize.Width = new_W;
		}
		
		if( resizeHeight )
		{
			int new_H = 0;
			int diff_H = mouseDown_Y - (int) hi.MousePos.y;

			if( repositionY )
			{
				if( invertHeight )		new_H = mouseDown_H - diff_H;
				else					new_H = mouseDown_H + diff_H;
			}
			else
			{
				if( invertHeight )		new_H = mouseDown_H + diff_H;
				else					new_H = mouseDown_H - diff_H;
			}

			new_H = Mathf.Clamp( new_H, objectToResize.HeightMin, objectToResize.HeightMax );
			objectToResize.Height = new_H;
		}
		
		if( repositionX )
		{
			diff_X = mouseDown_X - (int) hi.MousePos.x;
			new_OffsetX = mouseDown_OffsetX - diff_X;
			new_OffsetX = Mathf.Min( new_OffsetX, max_OffsetX );
		}
		
		if( repositionY )
		{
			diff_Y = mouseDown_Y - (int) hi.MousePos.y;
			new_OffsetY = mouseDown_OffsetY - diff_Y;
			new_OffsetY = Mathf.Max( new_OffsetY, max_OffsetY );
		}
		
		if( repositionX || repositionY )
		{
			objectToResize.PosOffset = new Vector3( new_OffsetX, new_OffsetY, new_OffsetZ );
		}
		
		if( repositionX || repositionY || resizeWidth || resizeHeight )
		{
			kissUtility.ReCalculate_SizePosition( objectToResize.Node.Parent );
		}
		
	}

}



