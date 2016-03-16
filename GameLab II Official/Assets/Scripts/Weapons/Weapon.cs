/* [Code]
 * Abstract Weapon Class
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class Weapon : WeaponScript {

	public	bool	allowFire = true;
	public	bool	reloading = false;
	private float	rateOfFire;
	public	float	fireRatePerMinute;
	public 	float 	cooldown = 0;
	public	int		loadedMagazine = 6;
	public 	int 	maxMagazineSize = 6;
/*	private	int		tempAmmo;*/
	public	int		ammoPool = 12;

	void Start(){
		CalcRateOfFire();
	}

	void Update(){
		if(loadedMagazine > 0){
			if(!allowFire /*&& loadedMagazine > 0*/){
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
		Reload();
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
		if(Input.GetButtonDown("Reload") /*&& ammoPool >= 1*/ && reloading == false){
			int neededAmmo;
			int projectedTotal;
			reloading = true;
			neededAmmo = (maxMagazineSize-loadedMagazine);
			projectedTotal = (ammoPool-neededAmmo);
			Debug.Log(neededAmmo);
			Debug.Log(projectedTotal);
			if(neededAmmo > ammoPool){
				loadedMagazine += ammoPool;
				ammoPool = ammoPool - ammoPool;
			}
			else{
				/*doe normale reload*/ Debug.Log("wew");
				loadedMagazine = maxMagazineSize;
				ammoPool -= loadedMagazine;
			}			
			reloading = false;
			Debug.Log("Reloaded!");
		}
	}

	public override void AltFire(){
		
	}

	public override void GiveDamage(){

	}

	public override void AmmoPool(){

	}
}
