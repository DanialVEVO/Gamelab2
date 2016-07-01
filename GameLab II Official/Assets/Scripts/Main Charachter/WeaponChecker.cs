using UnityEngine;
using System.Collections;

public class WeaponChecker : MonoBehaviour {

	public GameObject currentWeapon;
	public GameObject shopManager, ammoObject, weaponObject;

	public int weaponInt;	

	void Start () {
	
	}
	
	void Update () {

		CheckWeapon ();

		weaponInt = GetComponent<WeaponSwitch>().curWeapon;
	
	}

	public void CheckWeapon () {

		currentWeapon = GetComponent<WeaponSwitch>().weapons[weaponInt];

		shopManager.GetComponent<UpgradeWeapon>().currentWeapon = currentWeapon;

		ammoObject.GetComponent<AmmoHud>().currentWeapon = currentWeapon;

		weaponObject.GetComponent<WeaponSelect>().currentWeapon = currentWeapon;




	}
}
