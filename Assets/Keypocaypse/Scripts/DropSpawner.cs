using UnityEngine;
using System.Collections;

public class DropSpawner : MonoBehaviour {

	public GameObject _DropPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void dropPrefab()
	{
		Instantiate(_DropPrefab, transform.position, transform.rotation);
	}
}
