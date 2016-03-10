/* [Code]
 * Abstract Weapon Class
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class Weapon : WeaponScript {

	public	bool	allowFire = true;
	public	float	rateOfFire;
	public	float	fireRatePerMinute;
	public 	float 	cooldown = 0;
	public	int		loadedMagazine = 6;
	public 	int 	maxMagazineSize = 6;
	public	int		ammoPool = 12;

	void Start(){
		CalcRateOfFire();
	}

	void Update(){
		if(!allowFire){
			cooldown -= Time.deltaTime;
			if(cooldown <= 0){
				allowFire = true;
				cooldown = rateOfFire;
			}
		}
		else{
			SpawnBullets();
		}
		
		
	}

	public override void SpawnBullets(){
		if(Input.GetButton("Fire1")){
			allowFire = false;
			Debug.DrawRay(transform.position, Vector3.forward, Color.green, 2f);
			Physics.Raycast(transform.position, Vector3.forward, 2f);
			loadedMagazine --;
			Debug.Log("Fired!");
		}
	}

	public override void CalcRateOfFire(){
		rateOfFire = 60/fireRatePerMinute;
	}

	public override void Reload(){
		
	}

	public override void AltFire(){
		
	}

	public override void GiveDamage(){

	}

	public override void AmmoPool(){

	}
}
