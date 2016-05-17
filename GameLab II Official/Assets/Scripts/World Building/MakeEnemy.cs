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

	public	bool	walking;
	public	bool	flying;
	public	bool	melee;
	public	bool	shooting;
	public	bool	champion;

	[Range(0,100)]
	public	int		chanceMelee;
	[Range(0,100)]
	public	int		chanceChampion;

	public	int		normalWalkingMeleeWeight;
	public	int		normalWalkingShootingWeight;
	public	int		normalFlyingMeleeWeight;
	public	int		normalFlyingShootingWeight;
	public	int		championWalkingMeleeWeight;
	public	int		championWalkingShootingWeight;
	public	int		championFlyingMeleeWeight;
	public	int		championFlyingShootingWeight;

	public	int		maxChance = 101;
	public	int		rolledChance;

	void Start () {
		if(flying == true || walking == true){
			RollEnemy();
			SpawnEnemy();
		}
	}
	
	void Update () {
		
	}

	public void RollChance (){
		rolledChance = Random.Range(0, maxChance);
	}

	public void RollEnemy(){
		ChooseAttackType ();
		ChooseType ();
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
		if(rolledChance <= chanceChampion){
			champion = true;
		}
	}

	public void SpawnEnemy(){
		if(walking == true && flying == false){
			if(melee == true && shooting == false && champion == false){
				Instantiate(walkingMelee, transform.position, Quaternion.identity);
				SendWeight(normalWalkingMeleeWeight);
				DestroyMe();
			}
			if(melee == false && shooting == true && champion == false){
				Instantiate(walkingShooting, transform.position, Quaternion.identity);
				SendWeight(normalWalkingShootingWeight);
				DestroyMe();
			}
			if(melee == true && shooting == false && champion == true){
				Instantiate(championWalkingMelee, transform.position, Quaternion.identity);
				SendWeight(championWalkingMeleeWeight);
				DestroyMe();
			}
			if(melee == false && shooting == true && champion == true){
				Instantiate(championWalkingShooting, transform.position, Quaternion.identity);
				SendWeight(championWalkingShootingWeight);
				DestroyMe();
			}
		}

		if(flying == true && walking == false){
			if(melee == true && shooting == false && champion == false){
				Instantiate(flyingMelee, transform.position, Quaternion.identity);
				SendWeight(normalFlyingMeleeWeight);
				DestroyMe();
			}
			if(melee == false && shooting == true && champion == false){
				Instantiate(flyingShooting, transform.position, Quaternion.identity);
				SendWeight(normalFlyingShootingWeight);
				DestroyMe();
			}
			if(melee == true && shooting == false && champion == true){
				Instantiate(championFlyingMelee, transform.position, Quaternion.identity);
				SendWeight(championFlyingMeleeWeight);
				DestroyMe();
			}
			if(melee == false && shooting == true && champion == true){
				Instantiate(championFlyingShooting, transform.position, Quaternion.identity);
				SendWeight(championFlyingShootingWeight);
				DestroyMe();
			}
		}
	}

	public void SendWeight(int myWeight){
		levelManager.GetComponent<Balancer>().CalcWeight(myWeight);
	}

	public void DestroyMe(){
		Destroy(gameObject);
	}
}
