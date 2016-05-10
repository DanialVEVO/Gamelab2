using UnityEngine;
using System.Collections;

public class TurorialEnemy : MonoBehaviour {

	public GameObject turtorialEnemy;
	public Vector3 spawnPosition;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void Respawner(){
		Instantiate(turtorialEnemy, spawnPosition, transform.rotation);
	}
}
