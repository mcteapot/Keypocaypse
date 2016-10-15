using UnityEngine;
using System.Collections;

public class DaddyTextController : MonoBehaviour {

	public Transform[] textPositions;
	public Vector3[] textStartPositions;
	public Vector3[] textStartRotations;

	public Vector2 textResetTime;

	private bool isTextResetting;

	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {

		storeText();
		isTextResetting = false;

		StartCoroutine(resetText(getRangeTime()));
	}
	
	// Update is called once per frame
	void Update () {
		if(isTextResetting == false) {
			StartCoroutine(resetText(getRangeTime()));
		}
	}


	// API //
	private void storeText()
	{
		int i = 0;
		textStartPositions = new Vector3[textPositions.Length]; 
		textStartRotations = new Vector3[textPositions.Length]; 
		foreach(Transform textPos in textPositions)
		{
			textStartRotations[i] = textPos.rotation.eulerAngles;

			textStartPositions[i] = textPos.position;
			i++;
		}		
	}

	private IEnumerator resetText(float waitTime) {
		isTextResetting = true;
		//print("WaitTime " + waitTime);
		yield return new WaitForSeconds(waitTime);
		//print("WaitAndPrint " + Time.time);
		//Debug.Log("POSITON RESET");
		int i = 0;
		foreach(Transform textPos in textPositions)
		{

			//rigidbody.velocity = Vector3.zero;
			//rigidbody.angularVelocity = Vector3.zero;



			textPos.GetComponent<Rigidbody>().velocity = Vector3.zero;
			textPos.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			textPos.position =	textStartPositions[i];
			if(getRandomPrecent() < 0.3f) {
				Vector3 tempVector = textStartRotations[i];
				textPos.eulerAngles  =	tempVector;
			}
			//textPos.rotation.eulerAngles =	tempVector;

			i++;
		}
		isTextResetting = false;
	}

	private float getRangeTime()
	{
		return Random.Range(textResetTime.x, textResetTime.y);
	}

	private float getRandomPrecent()
	{
		return Random.Range(0,1.0f);
	}


}
