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
		Doors[0].GetComponent<Animator>().SetBool("MayOpen", true);
		Doors[1].GetComponent<Animator>().SetBool("MayOpen", true);
		Doors[2].GetComponent<Animator>().SetBool("MayOpen", true);
	}
}
