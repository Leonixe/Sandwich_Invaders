using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichGenerator : MonoBehaviour {

	public Sandwich sandwich;
	public Column[] columns;
	public float tick = 1f;
	private float currentTime = 0f;
	private float totalTime = 0f;
	public Camera camera;
	public int chance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		totalTime += Time.deltaTime;
		currentTime += Time.deltaTime;

		while (currentTime >= tick / (totalTime*0.05f)) {
			if ((int)(Random.value * chance) == 0) {
				Sandwich newSandwich = Object.Instantiate (sandwich);
				newSandwich.transform.position = new Vector3 (
					this.transform.position.x,
					(2f * camera.orthographicSize)-5,
					this.transform.position.z
				);
				newSandwich.column = columns[(int)(Random.value * columns.Length)];
				newSandwich.speed = sandwich.speed * Mathf.Max(totalTime, 1.0f) * 0.05f;
				//			newSandwich.speed = sandwich.speed * (int)((Random.value + 1) * 5);
				newSandwich.gameObject.SetActive (true);
			}
			currentTime -= tick / (totalTime * 0.05f);
		}


	}

}
