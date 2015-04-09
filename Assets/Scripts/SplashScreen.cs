using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public float timer = 2f;
	public string sceneToLoad = "Main";

	// Use this for initialization
	void Start () {
		StartCoroutine ("DisplayScene");
	}

	IEnumerator DisplayScene() {
		yield return new WaitForSeconds(timer);
		Application.LoadLevel (sceneToLoad);
	}
}
