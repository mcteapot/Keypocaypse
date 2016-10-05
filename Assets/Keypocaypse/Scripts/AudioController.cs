using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {

	public AudioClip _AudioShot;
	public int audioKeyOffest;

	private AudioSource audio;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAudio(int key)
	{


		audio.PlayOneShot(_AudioShot, 0.7F);
	}
}
