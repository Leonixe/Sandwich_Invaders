using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sandwich : MonoBehaviour {

	public Column column;
	public float speed = 1.0f;
	public Chevre chevre;
	public int scoreValue;
	public UnityEngine.UI.Text scoreText;
	public GameObject fx_GetSandwich;
	public GameObject fx_MissSandwich;
	public UnityEvent onDestroyEvent;
	public UnityEvent onCatchEvent;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (column != null) {
			this.transform.position = new Vector3 (
				this.column.groundLocation.transform.position.x,
				this.transform.position.y,
				this.transform.position.z
			);
		}

		this.transform.position += Vector3.down * speed * Time.deltaTime;

		if (column != null && chevre != null) {
			float offset = (chevre.column == column) ? chevre.GetComponentInChildren<SpriteRenderer>().bounds.size.y - 1 : 0;

			if (this.transform.position.y < column.groundLocation.transform.position.y + offset) {
				if (chevre.column != column) {
					chevre.pv -= 1;
					Object.Instantiate (fx_MissSandwich);
				} else {
					chevre.score += scoreValue;
					chevre.sandwichCounter += 1;
					scoreText.text = chevre.score.ToString();
					Object.Instantiate (fx_GetSandwich);
					onCatchEvent.Invoke ();
				}	
					
				onDestroyEvent.Invoke();

				Object.Destroy (this.gameObject);
			}
		}


	}
}
