using UnityEngine;
using System.Collections;
using kissUI;

[ExecuteInEditMode]
public class AnimOffsetsForZone : MonoBehaviour
{
	public kissImage.SliceZone ZoneArea;
	public float XAnim = 0.01f;
	public float YAnim = 0.00f;
	
	private kissImage _img;
	private kissImageZone _imgMesh;
	private Renderer _imgMeshRend;
	private Vector2 v2_NewOffset = new Vector2();
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateRefrences();
		
		if( _imgMeshRend != null )
		{
			Material mat = null;
			if( Application.isEditor )
				mat = _imgMeshRend.sharedMaterial;
			else
				mat = _imgMeshRend.material;
			
			if( mat != null )
			{
				v2_NewOffset.x += XAnim;
				v2_NewOffset.y += YAnim;
				mat.SetTextureOffset( "_MainTex", v2_NewOffset );
			}
		}
	}
	
	void UpdateRefrences()
	{
		if( _img == null )
			_img = this.GetComponent< kissImage >();
		
		if( _img != null )
		{
			if( _imgMesh == null || _imgMesh.sliceZone != ZoneArea )
			{
				_imgMesh = _img.sliceZones[ (int) ZoneArea ];
				
				if( _imgMesh != null )
				{
					_imgMeshRend = _imgMesh.GetComponent< Renderer >();
				}
			}
		}
	}
}
