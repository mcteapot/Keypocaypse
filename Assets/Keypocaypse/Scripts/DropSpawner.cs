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
		Debug.Log("HI THERE ARE TYOU WORKING");
		Instantiate(_DropPrefab, transform.position, transform.rotation);
	}
}
