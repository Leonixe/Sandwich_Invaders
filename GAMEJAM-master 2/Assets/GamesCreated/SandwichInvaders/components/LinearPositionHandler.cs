using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LinearPositionHandler : MonoBehaviour {

	public Column[] columns;
	public int cursor = 0;
	public Chevre chevre;
	public Camera camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (columns != null && columns.Length > 0) {
			float height = 2f * camera.orthographicSize;
			float width = height * camera.aspect;
			if (Input.GetKeyDown(KeyCode.LeftArrow) && cursor > 0) {
				cursor--;
				chevre.GetComponentInChildren<SpriteRenderer> ().flipX = false;
			}

			if (Input.GetKeyDown(KeyCode.RightArrow) && cursor < columns.Length-1) {
				cursor++;
				chevre.GetComponentInChildren<SpriteRenderer> ().flipX = true;
			}

			foreach (Touch touch in Input.touches) {
				if (touch.position.x < width/2) {
					cursor--;
					chevre.GetComponentInChildren<SpriteRenderer> ().flipX = false;				}
				else if (touch.position.x > width/2) {
					cursor++;
					chevre.GetComponentInChildren<SpriteRenderer> ().flipX = true;
				} 
			}
			chevre.column = columns [cursor % columns.Length];
		}
	}
}
