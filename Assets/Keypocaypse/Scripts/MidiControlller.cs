using UnityEngine;
using System.Collections;
using MidiJack;

public class MidiControlller : MonoBehaviour {

	public bool _DebugKeyOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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


	// Deligage functions
	void NoteOn(MidiChannel channel, int note, float velocity)
	{
		if(_DebugKeyOn)
			Debug.Log("NoteOn: " + channel + "," + note + "," + velocity);
		
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
