using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSwitchPrototype : MonoBehaviour {

	public List <GameObject> levels = new List <GameObject>();

	public Transform levelSpawn;
	public Transform playerSpawn;

	public int currentKamer;
	public int kamerCheck;
	public int maxCount1, maxCount2, maxCount3;
	public int minCount1, minCount2, minCount3;

	void Start () {
		Instantiate(levels[0], levelSpawn.position, Quaternion.identity);
	}
	
	void Update () {
	
	}

	public void SwitchLevel (int switcher) {
		switch (switcher){
			case 1 : 
				currentKamer = Random.Range(minCount1, maxCount1);
				SpawnLevel();
			break;

			case 2 : 
				currentKamer = Random.Range(minCount2, maxCount2);
				SpawnLevel();
			break;

			case 3 : 
				currentKamer = Random.Range(minCount3, maxCount3);
				SpawnLevel();
			break;
		}
	}

	void SpawnLevel (){
		Instantiate(levels[currentKamer], levelSpawn.position, Quaternion.identity);
		print(currentKamer);
		levels.RemoveAt(currentKamer);
		Destroy(GameObject.FindWithTag("CurrentLevel"));
		transform.position = playerSpawn.transform.position;
	}

	public void OnCollisionEnter (Collision col){
		if(col.transform.name == "NextLevelKamer1"){
			kamerCheck = 1;
			SwitchLevel(kamerCheck);
		}

		if(col.transform.name == "NextLevelKamer2"){
			kamerCheck = 2;
			SwitchLevel(kamerCheck);
		}

		if(col.transform.name == "NextLevelKamer3"){
			kamerCheck = 3;
			SwitchLevel(kamerCheck);
		}
	}
}
