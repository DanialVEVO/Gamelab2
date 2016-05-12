/* [Code]
 * Enemy Creation Class
 * Scripted by Danial
 */
using UnityEngine;
using System.Collections;

public class MakeEnemy : MonoBehaviour {

	public	GameObject	levelManager;

	public	GameObject	walkingShooting;
	public	GameObject	walkingMelee;
	public	GameObject	flyingShooting;
	public	GameObject	flyingMelee;
	public	GameObject	championWalkingShooting;
	public	GameObject	championWalkingMelee;
	public	GameObject	championFlyingShooting;
	public	GameObject	championFlyingMelee;

	public	bool	flying;
	public	bool	walking;
	public	bool	melee;
	public	bool	shooting;
	public	bool	champion;

	[Range(0,100)]
	public	int		chanceMelee;

	[Range(0,100)]
	public	int		chanceNormal;

	public	int		normalWalkingMeleeWeight;
	public	int		normalWalkingShootingWeight;
	public	int		normalFlyingMeleeWeight;
	public	int		normalFlyingShootingWeight;
	public	int		championWalkingMeleeWeight;
	public	int		championWalkingShootingWeight;
	public	int		championFlyingMeleeWeight;
	public	int		championFlyingShootingWeight;

	public	int		myWeight;

//	public	int		minChance = 0;
	public	int		maxChance = 101;
	public	int		rolledChance;

	void Start () {
		RollEnemy();
	}
	
	void Update () {
		if (Input.GetKeyDown("f")){
			RollEnemy();
		}
	}

	public void RollChance (){
		rolledChance = Random.Range(0, maxChance);
	}

	public void RollEnemy(){
		ChooseAttackType ();
		ChooseType ();
	}

	public void ChooseMovementType (){
		//
	}

	public void ChooseAttackType (){
		RollChance();
		if(rolledChance <= chanceMelee){
			melee = true;
		} 
		else{
			shooting = true;
		}
			
	}

	public void ChooseType (){
		RollChance();
		if(rolledChance > chanceNormal){
			champion = true;
		}
	}

	public void SpawnEnemy(){

	}

	public void SendWeight(){
		levelManager.GetComponent<Balancer>().CalcWeight(myWeight);
	}
}
