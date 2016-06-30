using UnityEngine;
using System.Collections;

public class OpenDoors : MonoBehaviour {

	public	GameObject[] Doors = new GameObject[3];

	// Use this for initialization
	void Start () {
		if(Doors != null){
			Doors = GameObject.FindGameObjectsWithTag("LevelDoor");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenTheGates (){
		
	}
}
