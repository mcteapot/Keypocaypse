using UnityEngine;
using System.Collections;
using kissUI;

public class kissMenuItemToggle : MonoBehaviour
{
	public kissImage imgCheckBack;
	public kissImage imgCheck;
	public kissGroup wasHiddenBy;
	
	void Start () {}
	//void Update () {}
	
	public void onMouseUp()
	{
		if( imgCheckBack != null )
		{
			for( int i = 0; i < imgCheckBack.HiddenBy.Count; i++ )
			{
				if( imgCheckBack.HiddenBy[i].source == wasHiddenBy.Tran )
				{
					imgCheckBack.HiddenBy[i].enabled = !imgCheckBack.HiddenBy[i].enabled;
				}
			}
			
			kissImage.ReCalculate_Visibility( imgCheckBack );
		}
		
		if( imgCheck != null )
		{
			for( int i = 0; i < imgCheck.HiddenBy.Count; i++ )
			{
				if( imgCheck.HiddenBy[i].source == wasHiddenBy.Tran )
				{
					imgCheck.HiddenBy[i].enabled = !imgCheck.HiddenBy[i].enabled;
				}
			}
			
			kissImage.ReCalculate_Visibility( imgCheck );
		}
	}
	
}

