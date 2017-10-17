using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public Canvas EndScreen;
	public AudioSource audioManager;
	public UnityEngine.UI.Text finalScoreText;
	public UnityEngine.UI.Text finalSandwichCatchText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private GameObject[] GetRootObjects () {
		return UnityEngine.SceneManagement.SceneManager.GetActiveScene ().GetRootGameObjects ();
	}

	public void SlowDown(float strength) {
		foreach (GameObject root in this.GetRootObjects()) {
			foreach (Sandwich sandwich in root.GetComponentsInChildren<Sandwich>()) {
				sandwich.speed = sandwich.speed * (1 - strength);
			}
		}
	}

	public void ActivateGenerator() {
		foreach (GameObject root in this.GetRootObjects()) {
			foreach (SandwichGenerator generator in root.GetComponentsInChildren<SandwichGenerator>()) {
				generator.gameObject.SetActive (true);
			}
		}
	}

	public void DesactiveGenerator() {
		foreach (GameObject root in this.GetRootObjects()) {
			foreach (Sandwich sandwich in root.GetComponentsInChildren<Sandwich>()) {
//				Object.Destroy (this);
				Sandwich.Destroy (sandwich.gameObject);
			}
			foreach (SandwichGenerator generator in root.GetComponentsInChildren<SandwichGenerator>()) {
				generator.gameObject.SetActive (false);
			}
		}
		EndScreen.gameObject.SetActive (true);
		audioManager.Pause ();
	}

	public void PrintScore (Chevre chevre) {
		finalScoreText.text = chevre.score.ToString();
		finalSandwichCatchText.text = chevre.sandwichCounter.ToString();
	}
}
