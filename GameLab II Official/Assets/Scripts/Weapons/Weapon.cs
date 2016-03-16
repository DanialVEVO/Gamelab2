/* [Code]
 * Abstract Weapon Class
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class Weapon : WeaponScript {

	public	bool		allowFire = true;
	public	bool		reloading = false;
	public	bool		allowAltFire = false;

	private float		rateOfFire;
	public	float		fireRatePerMinute;
	public 	float 		cooldown = 0;

	public	int			loadedMagazine = 6;
	public 	int 		maxMagazineSize = 6;
	public	int			ammoPool = 12;
	public	int			damage = 1;

	public	RaycastHit	hit;

	public	enum	WeaponType{
					Fist,
					Revolver,
					Smg,
					Ar,
					Launcher
	}

	public	WeaponType myWeaponType;

	void Start(){
		CalcRateOfFire();
	}

	void Update(){
		if(loadedMagazine > 0){
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
		Reload();
	}

	public override void SpawnBullets(){
		if(Input.GetButton("Fire1")){
			allowFire = false;
			Debug.DrawRay(transform.position, Vector3.forward, Color.green, Mathf.Infinity);
			Physics.Raycast(transform.position, Vector3.forward, out hit, Mathf.Infinity);
			loadedMagazine --;
			GiveDamage();
		}
	}

	public override void CalcRateOfFire(){
		rateOfFire = 60/fireRatePerMinute;
	}

	public override void Reload(){
		if(Input.GetButtonDown("Reload") && reloading == false){
			int neededAmmo;
			int projectedTotal;
			reloading = true;
			neededAmmo = (maxMagazineSize-loadedMagazine);
			projectedTotal = (ammoPool-neededAmmo);
			if(neededAmmo > ammoPool){
				loadedMagazine += ammoPool;
				ammoPool = ammoPool - ammoPool;
			}
			else{
				ammoPool -= neededAmmo;
				loadedMagazine += neededAmmo;
			}			
			reloading = false;
		}
	}

	public override void AltFire(){

		/* if allow fire true and myweapontype = x (doe alt fire)*/
		
	}

	public override void GiveDamage(){
		if(hit.transform.tag == "Enemy"){
			hit.transform.GetComponent<EnemyBaseClass>().Health(damage);
		}

	}

	public override void AmmoPool(){

	}

}
