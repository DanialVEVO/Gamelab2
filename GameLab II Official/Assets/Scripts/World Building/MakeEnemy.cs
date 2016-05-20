/* [Code]
 * Enemy Creation Class
 * Scripted by Danial
 */
/*using UnityEngine;
using System.Collections;

public class MakeEnemy : MonoBehaviour {

	public	GameObject	levelManager;

	public	bool	walking;
	public	bool	flying;
	
	[Range(0,100)]
	public	int		chanceMelee;
	[Range(0,100)]
	public	int		chanceChampion;



	void Start () {
		if(flying == true || walking == true){
			RollEnemy();
			SpawnEnemy();
		}
	}
	
	void Update () {
		
	}

	public void CreateMe() {
		if(flying == true || walking == true){
			RollEnemy();
			SpawnEnemy();
		}
	}

	int RollChance (){
		int rolledChance = Random.Range(0, maxChance);
		return rolledChance;
	}

	public void RollEnemy (){
		ChooseAttackType ();
		ChooseType ();
	}

	public void ChooseAttackType (){
		if(RollChance() <= chanceMelee){
			melee = true;
		} 
		else{
			shooting = true;
		}
			
	}

	public void ChooseType (){
		if(RollChance() <= chanceChampion){
			champion = true;
		}
	}

	public void SpawnEnemy (){
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

	public void SendWeight (int myWeight){
		levelManager.GetComponent<Balancer>().CalcWeight(myWeight);
	}

	public void DestroyMe (){
		Destroy(gameObject);
	}
}
*/