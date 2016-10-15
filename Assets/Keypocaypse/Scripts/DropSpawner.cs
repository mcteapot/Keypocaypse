using UnityEngine;
using System.Collections;

public class DropSpawner : MonoBehaviour {

	public GameObject _DropPrefab;

	public float _MinFloat;
	public float _MaxFloat;

	private bool canDrop = false;
	private bool isDropping = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(canDrop) {
			if(isDropping == false) {
				float waitTime = Random.Range(_MinFloat, _MaxFloat);
				StartCoroutine(WaitAndDrop(waitTime));				
			}
		}

	}

	public void dropPrefab()
	{
		//Debug.Log("HI THERE ARE TYOU WORKING");
		canDrop = true;

	}



	private IEnumerator WaitAndDrop(float waitTime) {
		isDropping = true;
		Instantiate(_DropPrefab, transform.position, transform.rotation);
		yield return new WaitForSeconds(waitTime);
		//print("WaitAndPrint " + Time.time);
		canDrop = false;
		isDropping = false;

	}
}
