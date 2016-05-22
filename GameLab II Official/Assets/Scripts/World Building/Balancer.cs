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
		SetTempObjects ();
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
		if(tempSpawnPoint.GetComponent<MakeEnemy>().walking == true && tempSpawnPoint.GetComponent<MakeEnemy>() == false){
			if(melee == true && shooting == false && champion == false){
				Instantiate(walkingMelee, tempSpawnPoint.transform.position, Quaternion.identity);
				CalcWeight(normalWalkingMeleeWeight);
			}

			if(melee == false && shooting == true && champion == false){
				Instantiate(walkingShooting, tempSpawnPoint.transform.position, Quaternion.identity);
				CalcWeight(normalWalkingShootingWeight);
			}

			if(melee == true && shooting == false && champion == true){
				Instantiate(championWalkingMelee, tempSpawnPoint.transform.position, Quaternion.identity);
				CalcWeight(championWalkingMeleeWeight);
			}

			if(melee == false && shooting == true && champion == true){
				Instantiate(championWalkingShooting, tempSpawnPoint.transform.position, Quaternion.identity);
				CalcWeight(championWalkingShootingWeight);
			}
		}

		if(tempSpawnPoint.GetComponent<MakeEnemy>().flying == true && tempSpawnPoint.GetComponent<MakeEnemy>().walking == false){
			if(melee == true && shooting == false && champion == false){
				Instantiate(flyingMelee, tempSpawnPoint.transform.position, Quaternion.identity);
				CalcWeight(normalFlyingMeleeWeight);

			}
			if(melee == false && shooting == true && champion == false){
				Instantiate(flyingShooting, tempSpawnPoint.transform.position, Quaternion.identity);
				CalcWeight(normalFlyingShootingWeight);

			}
			if(melee == true && shooting == false && champion == true){
				Instantiate(championFlyingMelee, tempSpawnPoint.transform.position, Quaternion.identity);
				CalcWeight(championFlyingMeleeWeight);

			}
			if(melee == false && shooting == true && champion == true){
				Instantiate(championFlyingShooting, tempSpawnPoint.transform.position, Quaternion.identity);
				CalcWeight(championFlyingShootingWeight);

			}
		}
	}

	// Remove chosen transform from list
		//list.removeat[1]
	public void RemoveFromList (){
		enemyList.RemoveAt(chosenEnemy);
	}

	public void DestroyTempObject(){
		Destroy(tempSpawnPoint);
	}

	// Reset booleans
	public void ResetBooleans (){
		melee 		= 	false;
		shooting  	= 	false;
		champion 	= 	false;
	}

	// --LOOP-- if maxweight not reached

	public void CalcWeight (int weightReceived){
		currentWeight += weightReceived;
		print("weight is calculated");
	}
}
