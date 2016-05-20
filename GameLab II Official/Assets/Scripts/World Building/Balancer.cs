/* [Code]
 * Enemy Balancer Class
 * Scripted by Danial
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Balancer : MonoBehaviour {

	public	GameObject	walkingShooting;
	public	GameObject	walkingMelee;
	public	GameObject	flyingShooting;
	public	GameObject	flyingMelee;
	public	GameObject	championWalkingShooting;
	public	GameObject	championWalkingMelee;
	public	GameObject	championFlyingShooting;
	public	GameObject	championFlyingMelee;


	public	bool	melee;
	public	bool	shooting;
	public	bool	champion;

	public	int		normalWalkingMeleeWeight;
	public	int		normalWalkingShootingWeight;
	public	int		normalFlyingMeleeWeight;
	public	int		normalFlyingShootingWeight;
	public	int		championWalkingMeleeWeight;
	public	int		championWalkingShootingWeight;
	public	int		championFlyingMeleeWeight;
	public	int		championFlyingShootingWeight;

	public	int		maxChance = 101;

	public	int	weightLimit;
	public	int currentWeight;
	public	int	chosenEnemy;
	public	List<GameObject> enemyList = new List<GameObject>();

	public GameObject tempSpawnPoint;

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
		
	}

	// Function to choose a transform from the list
	public int ChooseEnemy () {
		int chosenEnemy = Random.Range(0, enemyList.Count);
		return chosenEnemy;
	}

	// Set Temp GameObjects

	// Read & Set Values

	// Function to calc chances

	// Set enemytype (melee/shooting, champion)

	// Instantiate on chosen transform

	// Destroy Transform

	// Remove chosen transform from list
		//list.removeat[1]

	// Reset booleans

	// --LOOP-- if maxweight not reached

	public void CalcWeight (int weightReceived){
		currentWeight += weightReceived;
		print("weight is calculated");
	}
}
