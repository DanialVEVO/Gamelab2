using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSwitch : MonoBehaviour {

	public int curWeapon;

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
}
