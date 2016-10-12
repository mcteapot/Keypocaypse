using UnityEngine;
using System.Collections;
using kissUI;

[ExecuteInEditMode]
public class ScrollerGutters : MonoBehaviour
{
	public kissScrollbar thumbDrag;
	
	private kissGroup grp;
	
	// Use this for initialization
	//void Start () {}
	
	// Update is called once per frame
	//void Update () {}
	
	void OnEnable()
	{
		//Debug.Log( "ScrollerGutters:  OnEnable()" );
		
		if( grp == null )
			grp = gameObject.GetComponent< kissGroup >();
		
		if( grp != null )
			grp.OnSizeChanged += onGroupResized;
	}
	
	void OnDisable()
	{
		//Debug.Log( "ScrollerGutters:  OnDisable()" );
		
		if( grp != null )
			grp.OnSizeChanged -= onGroupResized;
	}
	
	public void onGroupResized()
	{
		//Debug.Log( "ScrollerGutters:  onGroupResized()" );
		
		if( thumbDrag == null )
			return;
		
		//		if( scrollOrientation == ScrollOrient.Vertical )
		//			imgGutterBottomOrLeft.Height = (int) thumbDrag.PosOffset.y + Mathf.RoundToInt( thumbDrag.Height / 2);
		//		else
		//			imgGutterBottomOrLeft.Width = (int) thumbDrag.PosOffset.x + Mathf.RoundToInt( thumbDrag.Width / 2);
		//			
		//		kissUtility.ReCalculate_SizePosition( imgGutterBottomOrLeft.transform.parent );
		
		if( thumbDrag.ScrollThumb != null )
		{
			thumbDrag.Update_DraggableArea();
			//Refresh_PosOffsets();
		}
		
		if( thumbDrag.onParentResize_ApplyExistingOffsetPercents )
		{
			//ReCalculate_OffsetPercents();
			thumbDrag.SetOffset_usingPercents();
		}
		
		if( thumbDrag.Content != null )
			thumbDrag.Content_UpdatePosOffsets();
		
		if( thumbDrag.imgGutterBottomOrLeft != null )
			thumbDrag.ResizeGutters();
	}
	
}
