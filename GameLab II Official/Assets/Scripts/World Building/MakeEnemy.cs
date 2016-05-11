/* [Code]
 * Enemy Creation Class
 * Scripted by Danial
 */
using UnityEngine;
using System.Collections;

public class MakeEnemy : MonoBehaviour {

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

	public	int		minChance = 0;
	public	int		maxChance = 101;
	public	int		rolledChance;

	[Range(0,100)]
	public	int		chanceMelee;
	[Range(0,100)]
	public	int		chanceShooting;
	
	[Range(0,100)]
	public	int		chanceNormal;
	public	int		weightNormal;
	[Range(0,100)]
	public	int		chanceChampion;
	public	int		weightChampion;
	[Range(0,100)]
	public	int		chanceMidget;

	public	int		weight;
	public	GameObject	levelManager;

	// Use this for initialization
	void Start () {
		RollEnemey();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void RollEnemey (){
		levelManager.GetComponent<Balancer>();
		if(walking == true){

		}
	}

	public void ChooseMovementType (){
		//
	}

	public void ChooseAttackType (){

	}

	public void ChooseType (){

	}

	public void SpawnEnemy(){

	}

	public void SendWeight(){

	}
}
