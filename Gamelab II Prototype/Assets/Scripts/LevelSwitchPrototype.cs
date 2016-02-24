using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSwitchPrototype : MonoBehaviour {

	public List <GameObject> levels = new List <GameObject>();
	public List <GameObject> levels2 = new List <GameObject>();
	public List <GameObject> levels3 = new List <GameObject>();

	public GameObject [] allLevels;

	public Transform levelSpawn;
	public Transform playerSpawn;

	public int currentKamer;
	public int kamerCheck;
	public int maxCountLevel1, maxCountLevel2, maxCountLevel3;
	public int minCountLevel1, minCountLevel2, minCountLevel3;

	void Start () {
		Instantiate(levels[0], levelSpawn.position, Quaternion.identity);
	}
	
	void Update () {
		AddNewLevels ();
	}

	public void SwitchLevel (int switcher) {
		switch (switcher){
			case 1 : 
				currentKamer = Random.Range(minCountLevel1, maxCountLevel1);
				Instantiate(levels[currentKamer], levelSpawn.position, Quaternion.identity);
				levels.RemoveAt(currentKamer);
				maxCountLevel1 -= 1;
				SpawnLevel();
			break;

			case 2 : 
				currentKamer = Random.Range(minCountLevel2, maxCountLevel2);
				Instantiate(levels2[currentKamer], levelSpawn.position, Quaternion.identity);
				levels2.RemoveAt(currentKamer);
				maxCountLevel2 -= 1;
				SpawnLevel();
			break;

			case 3 : 
				currentKamer = Random.Range(minCountLevel3, maxCountLevel3);
				Instantiate(levels3[currentKamer], levelSpawn.position, Quaternion.identity);
				levels3.RemoveAt(currentKamer);
				maxCountLevel3 -= 1;
				SpawnLevel();
			break;
		}
	}

	void SpawnLevel (){
		print(currentKamer);
		Destroy(GameObject.FindWithTag("CurrentLevel"));
		transform.position = playerSpawn.transform.position;
	}

	public void OnCollisionEnter (Collision col){
		if(col.transform.tag == "NextLevelKamer1"){
			print("Kamer");
			kamerCheck = 1;
			SwitchLevel(kamerCheck);
		}

		if(col.transform.tag == "NextLevelKamer2"){
			print("Kamer");
			kamerCheck = 2;
			SwitchLevel(kamerCheck);
		}

		if(col.transform.tag == "NextLevelKamer3"){
			print("Kamer");
			kamerCheck = 3;
			SwitchLevel(kamerCheck);
		}
	}

	public void AddNewLevels (){
		if(maxCountLevel1 == -1  || maxCountLevel2 == -1 || maxCountLevel3 == -1){
			levels.Clear();
			levels2.Clear();
			levels3.Clear();
			levels.InsertRange (levels.Count, new List <GameObject>{allLevels[0], allLevels[1], allLevels[2]});
			levels2.InsertRange (levels2.Count, new List <GameObject>{allLevels[3], allLevels[4], allLevels[5]});
			levels3.InsertRange (levels3.Count, new List <GameObject>{allLevels[6], allLevels[7], allLevels[8]});
			maxCountLevel1 = 2;
			maxCountLevel2 = 2;
			maxCountLevel3 = 2;
		}
	}
}
