using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using kissUI;

public class Listing : MonoBehaviour
{
	
	public List< kissText > listing = new List< kissText >();
	public int activeItem = 0;
	public string activeItemText = "";

	void Start () {}
	//void Update () {}

	public void SetActiveItem( int item )
	{
		if( item >= listing.Count )
			return;
		
		activeItem = item;
		
		activeItemText = listing[ item ].Text;
	}	
}
