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
						AR,
						Launcher
					}
	public	WeaponType	myWeaponType;
	

	public	bool		allowFire = true;
	public	bool		reloading = false;
	public	bool		allowAltFire = false;

	private float		rateOfFire;
	public	float		fireRatePerMinute;
	public 	float 		cooldown = 0;
	public 	float		spreadMin = -.5f;
	public	float		spreadMax = .5f;

	public	int			loadedMagazine = 6;
	public 	int 		maxMagazineSize = 6;
	public	int			ammoPool = 12;
	public	int			damage = 1;

	public	RaycastHit	hit;

	public	Transform	muzzle;

	//Alt fire stats
	public	int			revolverAltFire = 4;
	public	int			rifleAirDamage = 2;
	public	float		smgFireRateMultiplier = 1.3f;

	void Start(){
		CalcRateOfFire();
	}

	void Update(){

		if(allowFire == false){
			Cooldown();
		}

		if(Input.GetButton("Fire1")){
			if(allowFire == true){
				FireBullets();
			}
			else{
				//
			}
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

				case WeaponType.AR :
					if(allowAltFire == true){
						if(false){
							//
						}
					}
					else{
						//
					}
					break;

				case WeaponType.Launcher :
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

	public override void FireBullets(){
		print("FireBullets");
		allowFire = false;
		Debug.DrawRay(muzzle.position, Vector3.forward, Color.green, Mathf.Infinity);
		if(Physics.Raycast(muzzle.position, Vector3.forward, out hit, Mathf.Infinity)){
			if(hit.transform.tag == "Enemy"){
				GiveDamage(damage);
			}
			if(hit.transform.tag == "FlyingEnemy" && allowAltFire == true){
				int airEnemyDamage;
				airEnemyDamage = damage + rifleAirDamage;
				GiveDamage(airEnemyDamage);
			}
		}
		loadedMagazine --;
	}

	public override void Spread(){

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
		switch(myWeaponType){
			
			case WeaponType.Revolver :
			print("AltFire");
			for (int i = 0; i < revolverAltFire; i++)
			Debug.Log("wew");
			FireBullets();
			break;
	
			case WeaponType.SMG : 
				fireRatePerMinute *= smgFireRateMultiplier;
				break;
			

			case WeaponType.AR : 

				break;
		}
	}

	public override void GiveDamage(int sumDamage){
		print("GiveDamage");
		hit.transform.GetComponent<EnemyBaseClass>().Health(sumDamage);
	}

	public override void AmmoPool(){
	}
}
