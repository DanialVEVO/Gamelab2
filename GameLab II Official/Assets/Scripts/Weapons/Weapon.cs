/* [Code]
 * Abstract Raycast Weapon Class
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class RaycastWeapon : WeaponScript {

	public	enum	WeaponType{
						Fist,
						Revolver,
						SMG,
						AR,
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
	public	int			maxPool= 48;
	public	int			damage = 1;

	public	RaycastHit	hit;

	public	Transform	muzzle;

	//Alt fire stats
	public	int			revolverAltFire = 4;
	public	int			rifleAirDamage = 2;
	public	float		smgFireRateMultiplier = 1.3f;

	//Spread stats
	public 	float		xSpreadMin = -.5f;
	public	float		xSpreadMax = .5f;
	public	float		YspreadMin = .5f;
	public	float		YspreadMax = .5f;

	void Start(){
		CalcRateOfFire();
	}

	void Update(){
		if(Input.GetKeyDown("j")){
			CalcAmmoPool(-220);
		}

		if(allowFire == false){
			Cooldown();
		}

		if(Input.GetButton("Fire1")){
			if(allowFire == true){
				allowFire = false;
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
		
		if(Input.GetButton("Fire2")){
			if(allowFire == true){
				AltFireExecute();
			}
		}
	}

	public override void Cooldown(){
		if(loadedMagazine > 0){
			if(!allowFire){
				cooldown -= Time.deltaTime;
				if(cooldown <= 0){
					allowFire = true;
					cooldown = rateOfFire;
				}
			}
		}
	}


	public override void FireBullets(){
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

	public override void FireProjectile(float power, GameObject explosive){

	}

	public override void Spread(){
	}

	public override void SpreadReset(){
	}

	public override void Reload(){
		int neededAmmo;
		reloading = true;
		neededAmmo = (maxMagazineSize-loadedMagazine);
		CalcAmmoPool(neededAmmo);
		loadedMagazine += neededAmmo;
		reloading = false;
	}

	public override void AltFireExecute(){
		switch(myWeaponType){

			case WeaponType.Revolver :
				if(allowAltFire == true){
					if(loadedMagazine > revolverAltFire){
						AltFire();
					}
				}
				else{
					//
				}
				break;

			case WeaponType.SMG :
				// if(allowAltFire == true){
				// 	if(){
				// 	//
				// 	}
				// }
				// else{
				// 	//
				// }
				break;

			case WeaponType.AR :
				// if(allowAltFire == true){
				// if(){
				// 		//
				// 	}
				// }
				// else{
				// 	//
				// }
				break;

			}
	}

	public override void AltFire(){
		switch(myWeaponType){
			
			case WeaponType.Revolver :
				for (int i = 0; i < revolverAltFire; i++)
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
		print("Total damage transferd is " +sumDamage);
		hit.transform.GetComponent<EnemyBaseClass>().Health(sumDamage);
	}

	public override void CalcAmmoPool(int ammo){
		ammoPool -= ammo;
		ammoPool = Mathf.Clamp(ammoPool, 0,maxPool);
	}

	public override void SetAmmoPool(int poolUpgrade){
		ammoPool += poolUpgrade;
	}

	public override void CalcRateOfFire(){
		rateOfFire = 60/fireRatePerMinute;
		cooldown = rateOfFire;
		print("The rate of fire is 1 bullet per " +rateOfFire +" second(s)");
	}
}
