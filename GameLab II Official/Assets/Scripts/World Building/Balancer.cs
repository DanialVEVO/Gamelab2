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

	private	int		maxChance = 101;
	public	int		chosenEnemy;
	public	int		weightLimit;
	public	int 	currentWeight;

	public	List<GameObject> enemyList = new List<GameObject>();

	public	GameObject tempSpawnPoint;
	private	int		chanceMelee;
	private	int		chanceChampion;

	// Use this for initialization
	void Start () {
		FindSpawnPoints();

	}
	
	// Update is called once per frame
	void Update () {
		while(currentWeight < weightLimit){
			SetTempObjects ();
			ChooseAttackType ();
			ChooseType ();
			SpawnEnemy ();
			RemoveFromList ();
			DestroyTempObject ();
			ResetBooleans ();
		}	
	}
	
	void FindSpawnPoints () { 
		enemyList.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));
	}

	// Function to choose a transform from the list
	public int ChooseEnemy () {
		chosenEnemy = Random.Range(0, enemyList.Count);
		return chosenEnemy;
	}

	// Set Temp GameObjects
	public void SetTempObjects () {
		tempSpawnPoint = enemyList[ChooseEnemy()];
	}

	// Read & Copy Temp GameObject values

	// Function to roll chance
	int RollChance (){
		int rolledChance = Random.Range(0, maxChance);
		return rolledChance;
	}

	// Set enemytype (melee/shooting, champion)
	public void RollEnemy (){
		ChooseAttackType ();
		ChooseType ();
	}

	public void ChooseAttackType (){
		if(RollChance() <= tempSpawnPoint.GetComponent<MakeEnemy>().chanceMelee){
			melee = true;
		} 
		else{
			shooting = true;
		}		
	}

	public void ChooseType (){
		if(RollChance() <= tempSpawnPoint.GetComponent<MakeEnemy>().chanceMelee){
			champion = true;
		}
	}

	//Instantiate enemy on chosen transform
	public void SpawnEnemy (){
		Transform spawnPoint = tempSpawnPoint.transform;
		if(tempSpawnPoint.GetComponent<MakeEnemy>().walking == true && tempSpawnPoint.GetComponent<MakeEnemy>().flying == false){
			if(melee == true && shooting == false && champion == false){
				Instantiate(walkingMelee, spawnPoint.position, spawnPoint.rotation);
				CalcWeight(normalWalkingMeleeWeight);
			}

			else if(melee == false && shooting == true && champion == false){
				Instantiate(walkingShooting, spawnPoint.position, spawnPoint.rotation);
				CalcWeight(normalWalkingShootingWeight);
			}

			else if(melee == true && shooting == false && champion == true){
				Instantiate(championWalkingMelee, spawnPoint.position, spawnPoint.rotation);
				CalcWeight(championWalkingMeleeWeight);
			}

			else if(melee == false && shooting == true && champion == true){
				Instantiate(championWalkingShooting, spawnPoint.position, spawnPoint.rotation);
				CalcWeight(championWalkingShootingWeight);
			}
		}

		if(tempSpawnPoint.GetComponent<MakeEnemy>().flying == true && tempSpawnPoint.GetComponent<MakeEnemy>().walking == false){
			if(melee == true && shooting == false && champion == false){
				Instantiate(flyingMelee, spawnPoint.position, spawnPoint.rotation);
				CalcWeight(normalFlyingMeleeWeight);

			}
			else if(melee == false && shooting == true && champion == false){
				Instantiate(flyingShooting, spawnPoint.position, spawnPoint.rotation);
				CalcWeight(normalFlyingShootingWeight);

			}
			else if(melee == true && shooting == false && champion == true){
				Instantiate(championFlyingMelee, spawnPoint.position, spawnPoint.rotation);
				CalcWeight(championFlyingMeleeWeight);

			}
			else if(melee == false && shooting == true && champion == true){
				Instantiate(championFlyingShooting, spawnPoint.position, spawnPoint.rotation);
				CalcWeight(championFlyingShootingWeight);

			}
		}
	}

	//Destroy SpawnPoint
	public void DestroyTempObject (){
		Destroy(tempSpawnPoint);
	}

	//Remove chosen transform from list
	public void RemoveFromList (){
		print("blabla " + chosenEnemy);
		enemyList.RemoveAt(chosenEnemy);
	}

	//Reset booleans
	public void ResetBooleans (){
		melee 		= 	false;
		shooting  	= 	false;
		champion 	= 	false;
	}

	// --WhileLOOP-- if maxweight not reached spawn enemies

	//Calculate weight of total enemies
	public void CalcWeight (int weightReceived){
		currentWeight += weightReceived;
		print("weight is calculated");
	}
}
