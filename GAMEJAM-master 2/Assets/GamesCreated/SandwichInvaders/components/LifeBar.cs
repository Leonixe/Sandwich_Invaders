using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour {

	public Chevre chevre;
	public Animator bar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float full = chevre.pv / (float) chevre.maxPv;

		bar.Play ("lifeBar", -1, 1 - full);
	}
}
