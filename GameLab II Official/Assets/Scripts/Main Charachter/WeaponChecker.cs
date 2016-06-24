using UnityEngine;
using System.Collections;

public class WeaponChecker : MonoBehaviour {

	public GameObject currentWeapon;

	public int weaponInt;	

	void Start () {
	
	}
	
	void Update () {

		weaponInt = GetComponent<WeaponSwitch>().curWeapon;
	
	}

	public void CheckWeapon () {

		currentWeapon = GetComponent<WeaponSwitch>().weapons[weaponInt];

	}
}
