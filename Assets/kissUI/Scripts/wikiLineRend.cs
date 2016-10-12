using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class wikiLineRend : MonoBehaviour {

	
	public GameObject start;
	public GameObject middle;
	public GameObject end;
	
	public Color color = Color.white;
	public Color color2 = Color.white;
	public float width = 0.2f;
	public int numberOfPoints = 20;
	
	LineRenderer lineRenderer = null;
	
	// Use this for initialization
	void Start( )
	{
		lineRenderer = GetComponent< LineRenderer >();
		if( lineRenderer == null )
			lineRenderer = gameObject.AddComponent< LineRenderer >();
		//lineRenderer = GetComponent< LineRenderer >();
		lineRenderer.useWorldSpace = true;
		lineRenderer.material = new Material( Shader.Find("Particles/Additive") );
	}
	
	// Update is called once per frame
	void Update( )
	{
		// check parameters and components
		if( lineRenderer == null )
			lineRenderer = GetComponent< LineRenderer >();
		
		if( null == lineRenderer || null == start || null == middle || null == end )
			return; // no points specified
		
		// update line renderer
		lineRenderer.SetColors(color, color2);
		lineRenderer.SetWidth(width, width);
		if (numberOfPoints > 0)
			lineRenderer.SetVertexCount(numberOfPoints);
		
		// set points of quadratic Bezier curve
		Vector3 p0 = start.transform.position;
		Vector3 p1 = middle.transform.position;
		Vector3 p2 = end.transform.position;
		float t; 
		Vector3 position;
		
		for(int i = 0; i < numberOfPoints; i++) 
		{
			t = i / (numberOfPoints - 1.0f);
			position = (1.0f - t) * (1.0f - t) * p0
				+ 2.0f * (1.0f - t) * t * p1
				+ t * t * p2;
			lineRenderer.SetPosition( i, position );
		}
	}
}

