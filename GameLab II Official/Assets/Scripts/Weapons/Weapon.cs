/* [Code]
 * Abstract Weapon Class
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class Weapon : WeaponScript {

	public	enum	WeaponType{
						Fist,
						Revolver,
						SMG,
						Ar,
						Launcher
					}
	public	WeaponType	myWeaponType;
	

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

	public	int			revolverAltFire = 4;

	public	RaycastHit	hit;

	public	Transform	muzzle;

	void Start(){
		CalcRateOfFire();
	}

	void Update(){
		if(Input.GetButton("Fire1")){
			if(allowFire == true){
				SpawnBullets();
			}
			else{
				//
			}

		}
		

		if(allowFire == false){
			Cooldown();
		}


		if(Input.GetButtonDown("Reload")){
			if(reloading == false){
				Reload();
			}
			else{
				//
			}
		}
		
		if( Input.GetButtonDown("Fire2") ){
			switch(myWeaponType){

				case WeaponType.Revolver :
					if(allowAltFire == true ){
						if(loadedMagazine > revolverAltFire){
							AltFire();
						}
					}
					else{
						//
					}
					break;

				case WeaponType.SMG :
					if(allowAltFire == true ){
						if(loadedMagazine > revolverAltFire){
							AltFire();
						}
					}
					else{
						//
					}
					break;
			}
		}
	}

	public override void CalcRateOfFire(){
		print("CalcRateOfFire");
		rateOfFire = 60/fireRatePerMinute;
	}

	public override void SpawnBullets(){
		print("SpawnBullets");
		allowFire = false;
		Debug.DrawRay(muzzle.position, Vector3.forward, Color.green, Mathf.Infinity);
		if(Physics.Raycast(muzzle.position, Vector3.forward, out hit, Mathf.Infinity)){
			if(hit.transform.tag == "Enemy"){
				GiveDamage();
			}
		}
		loadedMagazine --;

			
	}

	public override void Cooldown(){
		print("cooldown");
		if(loadedMagazine > 0){
			print("loadedMagazine check");
			if(!allowFire){
				cooldown -= Time.deltaTime;
				if(cooldown <= 0){
					allowFire = true;
					cooldown = rateOfFire;
				}
			}
		}
	}

	public override void Reload(){
		print("Reload");
		int neededAmmo;
		int projectedTotal;
		reloading = true;
		neededAmmo = (maxMagazineSize-loadedMagazine);
		projectedTotal = (ammoPool-neededAmmo);
		if(neededAmmo < ammoPool){
			ammoPool -= neededAmmo;
			loadedMagazine += neededAmmo;
		}
		else{
			loadedMagazine += ammoPool;
			ammoPool = ammoPool - ammoPool;
		}			
		reloading = false;

	}

	public override void AltFire(){
		print("AltFire");
		for (int i = 0; i < revolverAltFire; i++){
				Debug.Log("wew");
				SpawnBullets();
		}
	}

	public override void GiveDamage(){
		print("GiveDamage");
		hit.transform.GetComponent<EnemyBaseClass>().Health(damage);
	}

	public override void AmmoPool(){
	}
}
