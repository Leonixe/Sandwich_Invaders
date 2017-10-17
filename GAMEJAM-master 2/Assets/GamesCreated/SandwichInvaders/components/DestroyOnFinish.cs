using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFinish : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AudioSource audio = this.GetComponent<AudioSource> ();
		if (!audio.isPlaying) {
			Object.Destroy (this.gameObject);
		}
	}
}
