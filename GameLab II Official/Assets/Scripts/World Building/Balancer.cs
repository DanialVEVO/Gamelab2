/* [Code]
 * Enemy Balancer Class
 * Scripted by Danial
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Balancer : MonoBehaviour {

	public	int	weightLimit;
	public	int currentWeight;
	public	int	chosenEnemy;
	public	List<GameObject> enemyList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		FindSpawnPoints ();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentWeight <= weightLimit){
			
		}
	}

	void FindSpawnPoints () { 
		enemyList.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));
		//list.removeat[1]
	}

	public int ChooseEnemy () {
		int chosenEnemy = Random.Range(0, enemyList.Count);
		return chosenEnemy;
	}

	public void CalcWeight (int weightReceived){
		currentWeight += weightReceived;
		print("weight is calculated");
	}
}
