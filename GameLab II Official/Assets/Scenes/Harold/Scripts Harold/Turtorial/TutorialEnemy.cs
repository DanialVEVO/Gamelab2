using UnityEngine;
using System.Collections;

public class TutorialEnemy : MonoBehaviour {

	public GameObject turtorialEnemy;
	public Vector3 spawnPosition;
	public bool respawn;

	// Use this for initialization
	void Start () {
		respawn = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(respawn){
			float respawntime = 3F;
			if(respawntime >= 0F){
				respawntime-= Time.deltaTime;
			}
			else{
				Respawner();
				respawn = false;
			}
		}
	}

	public void Respawner(){
		Instantiate(turtorialEnemy, spawnPosition, transform.rotation);
	}
}
