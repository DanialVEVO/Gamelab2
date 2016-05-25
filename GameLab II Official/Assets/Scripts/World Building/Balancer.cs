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
		
		while(currentWeight < weightLimit){
			print("1");
			SetTempObjects ();
			print("2");
			ChooseAttackType ();
			print("3");
			ChooseType ();
			print("4");
			SpawnEnemy ();
			print("5");
			DestroyTempObject ();
			print("6");
			RemoveFromList ();
			print("7");
			ResetBooleans ();
		}
	}
	
	// Update is called once per frame
	void Update () {

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
		if(tempSpawnPoint.GetComponent<MakeEnemy>().walking == true && tempSpawnPoint.GetComponent<MakeEnemy>() == false){
			if(melee == true && shooting == false && champion == false){
				Transform sp = Instantiate(walkingMelee, spawnPoint.position, spawnPoint.rotation) as Transform;
				CalcWeight(normalWalkingMeleeWeight);
			}

			else if(melee == false && shooting == true && champion == false){
				Transform sp = Instantiate(walkingShooting, spawnPoint.position, spawnPoint.rotation) as Transform;
				CalcWeight(normalWalkingShootingWeight);
			}

			else if(melee == true && shooting == false && champion == true){
				Transform sp = Instantiate(championWalkingMelee, spawnPoint.position, spawnPoint.rotation) as Transform;
				CalcWeight(championWalkingMeleeWeight);
			}

			else if(melee == false && shooting == true && champion == true){
				Transform sp = Instantiate(championWalkingShooting, spawnPoint.position, spawnPoint.rotation) as Transform;
				CalcWeight(championWalkingShootingWeight);
			}
		}

		if(tempSpawnPoint.GetComponent<MakeEnemy>().flying == true && tempSpawnPoint.GetComponent<MakeEnemy>().walking == false){
			if(melee == true && shooting == false && champion == false){
				Transform sp = Instantiate(flyingMelee, spawnPoint.position, spawnPoint.rotation) as Transform;
				CalcWeight(normalFlyingMeleeWeight);

			}
			else if(melee == false && shooting == true && champion == false){
				Transform sp = Instantiate(flyingShooting, spawnPoint.position, spawnPoint.rotation) as Transform;
				CalcWeight(normalFlyingShootingWeight);

			}
			else if(melee == true && shooting == false && champion == true){
				Transform sp = Instantiate(championFlyingMelee, spawnPoint.position, spawnPoint.rotation) as Transform;
				CalcWeight(championFlyingMeleeWeight);

			}
			else if(melee == false && shooting == true && champion == true){
				Transform sp = Instantiate(championFlyingShooting, spawnPoint.position, spawnPoint.rotation) as Transform;
				CalcWeight(championFlyingShootingWeight);

			}
		}
	}

	// Remove chosen transform from list
	public void RemoveFromList (){
		enemyList.RemoveAt(chosenEnemy);
	}

	public void DestroyTempObject (){
		Destroy(tempSpawnPoint);
	}

	// Reset booleans
	public void ResetBooleans (){
		melee 		= 	false;
		shooting  	= 	false;
		champion 	= 	false;
	}

	// --WhileLOOP-- if maxweight not reached spawn enemies

	public void CalcWeight (int weightReceived){
		currentWeight += weightReceived;
		print("weight is calculated");
	}
}
