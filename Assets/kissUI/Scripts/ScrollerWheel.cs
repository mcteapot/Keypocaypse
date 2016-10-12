using UnityEngine;
using System.Collections;

public class ScrollerWheel : MonoBehaviour
{
	public kissScrollbar sbThumb;
	
	
//	// Use this for initialization
//	void Start () {}
//	
//	// Update is called once per frame
//	void Update () {}

	public void onScrollWheel( int DeltaY )
	{
		if( sbThumb == null )
			return;
		
		sbThumb.YOffsetPercent += DeltaY;
		sbThumb.YOffsetPercent = Mathf.Clamp( sbThumb.YOffsetPercent, 0f, 100f );
		sbThumb.SetOffset_usingPercents();

		sbThumb.Refresh_PosOffsets();
		sbThumb.Content_UpdatePosOffsets();
	}
	
}
