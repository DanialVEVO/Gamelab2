using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void QuitToMainMenu (){

		Application.LoadLevel(0);
		GameObject.Find("Pauze Menu").SetActive(false);
		GameObject.Find("GameOverCanvas").SetActive(false);

	}

	public void QuitToDestop (){

		Application.Quit();

	}
}
