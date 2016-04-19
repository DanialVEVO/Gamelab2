﻿using UnityEngine;
using System.Collections;

public class LevelRandomizer : LevelSpawn {

	void Start () {
		
	}

	void Update () {
	
	}

	public void PickRandomLevel(){
		GameObject player = GameObject.FindGameObjectWithTag("LevelManager");
		LevelSpawner levelSpawner = player.GetComponent<LevelSpawner>();

		switch (levelSpawner.levelCounter){
		case 0:
			print("Picked");
			randomNum = Random.Range(0, 2);
			levelSpawner.levelPicks[0] = levelListEasy[randomNum];

			randomNum = Random.Range(0, 2);
			levelSpawner.levelPicks[1] = levelListMedium[randomNum];

			randomNum = Random.Range(0, 2);
			levelSpawner.levelPicks[2] = levelListHard[randomNum];
			break;

		case 1:
			randomNum = Random.Range(0, 2);
			levelSpawner.levelPicks[0] = level2ListEasy[randomNum];

			randomNum = Random.Range(0, 2);
			levelSpawner.levelPicks[1] = level2ListMedium[randomNum];

			randomNum = Random.Range(0, 2);
			levelSpawner.levelPicks[2] = level2ListHard[randomNum];
			break;

		case 2:
			randomNum = Random.Range(0, 2);
			levelSpawner.levelPicks[0] = level3ListEasy[randomNum];

			randomNum = Random.Range(0, 2);
			levelSpawner.levelPicks[1] = level3ListMedium[randomNum];

			randomNum = Random.Range(0, 2);
			levelSpawner.levelPicks[2] = level3ListHard[randomNum];
			break;
		}

		levelSpawner.AddObjects();
	}
}
