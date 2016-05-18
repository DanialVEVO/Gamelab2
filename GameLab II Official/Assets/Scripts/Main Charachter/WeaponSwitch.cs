using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSwitch : MonoBehaviour {

	public int curWeapon;
	public int arAmmoStore, revolverAmmoStore, smgAmmoStore, launcherAmmoStore;
	public int ammoPickupCount;
	public int checkAmmo;


	public GameObject weaponManager;

	public List <GameObject> weapons = new List <GameObject>();


	void Start () {
	
		weapons[0].SetActive(true);

		weaponManager = GameObject.Find("WeaponUpgradeManager");

	}
	
	void Update () {
		
		WeaponSwitcher ();

	}

	public void WeaponSwitcher () {

		if(Input.GetButtonDown("SwitchWeapon")){
			curWeapon ++;
			for(int i = 0; i < weapons.Count; i ++){
				if(curWeapon == weapons.Count){
					curWeapon = 0;
					i = curWeapon;
				}
				if(i == curWeapon){
					weapons[i].SetActive(true);
					weaponManager.GetComponent<WeaponUpgrade>().currentWeapon = weapons[i];
				}
				else{
					weapons[i].SetActive(false);
				}
			}
		}
	}

	public void AmmoPickup (int wichAmmo){

		switch (wichAmmo){

			case 1 :

			break;

			case 2 :

			break;

			case 3 :

			break;

			case 4 :

			break;


		}

	}


	void OnTriggerEnter (Collider trigger){

		if(trigger.transform.tag == "ARAmmo"){
			AmmoPickup (1);
		}

		if(trigger.transform.tag == "SMGAmmo"){
			AmmoPickup (2);
		}

		if(trigger.transform.tag == "RevolverAmmo"){
			AmmoPickup (3);
		}

		if(trigger.transform.tag == "LauncherAmmo"){
			AmmoPickup (4);
		}

	}
}
