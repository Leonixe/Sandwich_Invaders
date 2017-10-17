using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tuto : MonoBehaviour {

	public Canvas canvas;
	public UnityEvent onStartEvent;
	public AudioSource audioSrc;
	public AudioClip startSong;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1 && canvas.gameObject.activeSelf || Input.GetMouseButtonDown(0) && canvas.gameObject.activeSelf) {
			canvas.gameObject.SetActive (false);
			onStartEvent.Invoke ();
			audioSrc.clip = startSong;
			audioSrc.Play ();
		}	
	}


}
