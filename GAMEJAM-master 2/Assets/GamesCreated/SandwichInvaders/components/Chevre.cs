using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class Chevre : MonoBehaviour {

	public Column column;
	public int pv = 3;
	public int maxPv = 3;
	public int score = 0;
	public int sandwichCounter = 0;
	public UnityEvent gameEndedEvent;
	public UnityEvent gameEndedScorePrintEvent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (column != null) {
			this.gameObject.transform.position = this.column.groundLocation.transform.position;
		}
		if (pv <= 0 ){
			gameEndedEvent.Invoke ();
			gameEndedScorePrintEvent.Invoke ();
		}
	}
}
