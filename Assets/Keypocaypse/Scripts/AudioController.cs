using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {

	public AudioClip _AudioShot;
	public int audioKeyOffest;

	private AudioSource audio;
	public List<AudioClip> _AudioShots = new List<AudioClip>();


	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAudioKey(int key)
	{
		int playKey = key - audioKeyOffest;
		Debug.Log("AUDIO KEY IS " + playKey);
		if(playKey <= 21){
			audio.PlayOneShot(_AudioShots[playKey], 0.7F);
		}

		//audio.PlayOneShot(_AudioShot, 0.7F);
	}
}
