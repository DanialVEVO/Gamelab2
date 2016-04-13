using UnityEngine;
using System.Collections;

public class GameOverCam : MonoBehaviour {

	public bool mayMove;

	public float gameOverCamSpeed;
	
	public Transform maxPos;

	void Start () {
	
	}
	
	void Update () {
		GameOverCamPos ();
	}

	public void GameOverCamPos (){

		float goCamPos = transform.position.z;

		if(mayMove == true){
			transform.Translate(new Vector3(0, 0, goCamPos = gameOverCamSpeed * Time.deltaTime));
		}
	}
}
