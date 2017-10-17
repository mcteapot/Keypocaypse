using UnityEngine;
using System.Collections;

public class SystemsController : MonoBehaviour {

	//public UIController _UIController;

	public float restartTime;
	private float timeLeft = 138.0f;

	public bool enableSpaceRestart;
	public bool enableReturnRestart;
	public bool enableTimerRestart;


	// Use this for initialization
	void Start () {
		timeLeft = restartTime;
	}
	
	// Update is called once per frame
	void Update () {

		if(enableSpaceRestart) {
			resetSpace();
		}

		if(enableReturnRestart) {
			resetReturn();
		}

		if(enableTimerRestart) {
			resetTimer();
		}
	}


	private void resetSpace() 
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			//print("Force Level Rrestart");
			Application.LoadLevel(Application.loadedLevel);
		}
		timeLeft = restartTime;
			
	}

	private void resetReturn() 
	{
		if (Input.GetKeyDown(KeyCode.Return)) {
			//print("Force Level Rrestart");
			Application.LoadLevel(Application.loadedLevel);
		}
		timeLeft = restartTime;

	}


	private void resetTimer() 
	{
		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			//print("Level Rrestart");
			Application.LoadLevel(Application.loadedLevel);
			timeLeft = restartTime;
		}

	}
}
