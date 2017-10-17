using UnityEngine;
using System.Collections;
using MidiJack;

public class MidiControlller : MonoBehaviour {


	public bool _DebugKeyOn;

	public bool _EnableKeyboard;
	public bool _EnableMidi;

	public bool _EnableVR;

	public Transform _VRUI;

	public AudioController _AudioController;

	public int _KnobNumberColor;
	private float knobSetColor;
	public int _KnobNumberWind;
	private float knobSetWind;

	public Animator _cameraAnimator;

	public WindZone _windZones;


	public DropSpawner[] _DropSpawners;

	public UIController _UIController;

	public int keyOffset = 53;


	private bool enableColorChange;
	private float maxWind;

	// Use this for initialization
	void Start () {
		knobSetColor = -1.0f;
		knobSetWind = -1.0f;

		enableColorChange = false;

		Cursor.visible = false;



		if(_EnableVR) {
			
		} else {
			if(_VRUI != null) {
				_VRUI.gameObject.SetActive(false);
			}
		}
			
		if(_EnableKeyboard) {
			_cameraAnimator.speed = 0;
			//_cameraAnimator.speed = .5f;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(_EnableKeyboard) {
			dropKeyPress();
			controlColorKeyboard();
		}

		if(_EnableMidi) {
			controlColor();
			controlWind();	
		}



	}


	void OnEnable()
	{
		MidiMaster.noteOnDelegate += NoteOn;
		MidiMaster.noteOffDelegate += NoteOff;
		MidiMaster.knobDelegate += Knob;
	}

	void OnDisable()
	{
		MidiMaster.noteOnDelegate -= NoteOn;
		MidiMaster.noteOffDelegate -= NoteOff;
		MidiMaster.knobDelegate -= Knob;
	}


	public void dropKeyPress() {
		if (Input.GetKeyDown(KeyCode.A)) {
			DropObject(0, false);
		}
		if (Input.GetKeyDown(KeyCode.B)) {
			DropObject(1, false);
		}
		if (Input.GetKeyDown(KeyCode.C)) {
			DropObject(2, false);
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			DropObject(26, false);
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			DropObject(4, false);
		}
		if (Input.GetKeyDown(KeyCode.F)) {
			DropObject(5, false);
		}
		if (Input.GetKeyDown(KeyCode.G)) {
			DropObject(6, false);
		}
		if (Input.GetKeyDown(KeyCode.H)) {
			DropObject(7, false);
		}
		if (Input.GetKeyDown(KeyCode.J)) {
			DropObject(8, false);
		}
		if (Input.GetKeyDown(KeyCode.K)) {
			DropObject(9, false);
		}
		if (Input.GetKeyDown(KeyCode.L)) {
			DropObject(10, false);
		}
		if (Input.GetKeyDown(KeyCode.M)) {
			DropObject(11, false);
		}
		if (Input.GetKeyDown(KeyCode.A)) {
			DropObject(12, false);
		}
		if (Input.GetKeyDown(KeyCode.N)) {
			DropObject(13, false);
		}
		if (Input.GetKeyDown(KeyCode.O)) {
			DropObject(14, false);
		}
		if (Input.GetKeyDown(KeyCode.P)) {
			DropObject(15, false);
		}
		if (Input.GetKeyDown(KeyCode.Q)) {
			DropObject(16, false);
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			DropObject(17, false);
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			DropObject(18, false);
		}
		if (Input.GetKeyDown(KeyCode.T)) {
			DropObject(19, false);
		}
		if (Input.GetKeyDown(KeyCode.U)) {
			DropObject(20, false);
		}
		if (Input.GetKeyDown(KeyCode.V)) {
			DropObject(21, false);
		}
		if (Input.GetKeyDown(KeyCode.W)) {
			DropObject(22, false);
		}
		if (Input.GetKeyDown(KeyCode.X)) {
			DropObject(23, false);
		}
		if (Input.GetKeyDown(KeyCode.Y)) {
			DropObject(24, false);
		}
		if (Input.GetKeyDown(KeyCode.Z)) {
			DropObject(25, false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha0)) {
			DropObject(26, false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			DropObject(27, false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			DropObject(28, false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			DropObject(29, false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			DropObject(30, false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha5)) {
			DropObject(31, false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha6)) {
			DropObject(32, false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha7)) {
			DropObject(1, false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha8)) {
			DropObject(2, false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha9)) {
			DropObject(3, false);
		}
	}


	public void controlColor()
	{
		if(knobSetColor != MidiMaster.GetKnob(_KnobNumberColor))
		{
			knobSetColor = MidiMaster.GetKnob(_KnobNumberColor);
			if(_cameraAnimator != null)
			{
				_cameraAnimator.speed = knobSetColor;
			}

		}
	}


	public void controlColorKeyboard()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			if(enableColorChange){
				enableColorChange = false;

				_cameraAnimator.speed = 0;
			} else {
				enableColorChange = true;
				_cameraAnimator.speed = 1.0f;
			}
		}
		
	}

	public void controlWind() 
	{
		if(knobSetWind != MidiMaster.GetKnob(_KnobNumberWind))
		{
			knobSetWind = MidiMaster.GetKnob(_KnobNumberWind);
			if(_DebugKeyOn) {
				Debug.Log(knobSetWind + " KnobColor");
			}
/*

			var resultMain = Mathf.Lerp (-10, 10, Mathf.InverseLerp (0, 1, knobSetWind));
			Debug.Log(resultMain + " resultMain");
			_windZones.windMain = resultMain;
*/
			var resultTurbulence = Mathf.Lerp (0.26f, -80, Mathf.InverseLerp (0, 1, knobSetWind));
			//Debug.Log(resultTurbulence + " resultMain");
			if(_windZones != null) {
				_windZones.windTurbulence = resultTurbulence;
			}

		}


	}
		
	public void DropObject(int note, bool midiDrop)
	{
		int dropNuber = 0;

		if(midiDrop) {
			dropNuber = note - keyOffset;
			_AudioController.PlayAudioKey(note, true);
		} else {
			dropNuber = note;
			_AudioController.PlayAudioKey(note, false);
		}

		if(_DebugKeyOn) {
			Debug.Log("DROPPING: NOTE " + note);
			Debug.Log("DROPPING: Number " + dropNuber);
		}

		if(dropNuber <= _DropSpawners.Length)
		{
			_DropSpawners[dropNuber].dropPrefab();	
		}



	}


	// Deligage functions
	void NoteOn(MidiChannel channel, int note, float velocity)
	{

		if(_EnableMidi) {
			if(_DebugKeyOn) {
				Debug.Log("NoteOn: " + channel + "," + note + "," + velocity);
			}


			//_AudioController.PlayAudioKey(note);

			//_UIController.SetDialogText();

			DropObject(note, true);
		}
/*
		switch (note)
		{
			case 53:
				break;
			case 54:
				break;
			case 55:
				break;
			case 56:
				break;
			case 57:
				break;
			case 58:
				break;
			case 59:
				break;
			case 60:
				break;
			case 61:
				break;
			case 62:
				break;
			case 63:
				break;
			case 64:
				break;
			case 65:
				break;
			case 66:
				break;
			case 67:
				break;
			case 68:
				break;
			case 69:
				break;
			case 70:
				break;
			case 71:
				break;
			case 72:
				break;
			case 73:
				break;
			case 74:
				break;
			case 75:
				break;
			case 76:
				break;
			case 77:
				break;
			case 78:
				break;
			case 79:
				break;
			case 80:
				break;
			case 81:
				break;
			case 82:
				break;
			case 83:
				break;
			case 84:
				break;
			default:
				break;
		}
*/
	}

	void NoteOff(MidiChannel channel, int note)
	{
		if(_DebugKeyOn)
			Debug.Log("NoteOff: " + channel + "," + note);
	}

	void Knob(MidiChannel channel, int knobNumber, float knobValue)
	{
		if(_DebugKeyOn)
			Debug.Log("Knob: " + knobNumber + "," + knobValue);
	}

}
