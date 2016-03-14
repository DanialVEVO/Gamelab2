using UnityEngine;
using System.Collections;

public class WeaponSwitch : MonoBehaviour {

	public int curWeapon;

	public GameObject [] weapons;


	void Start () {
	
		weapons[0].SetActive(true);

	}
	
	void Update () {
		
		WeaponSwitcher ();

	}

	public void WeaponSwitcher () {

		if(Input.GetButtonDown("SwitchWeapon")){
			curWeapon ++;
			for(int i = 0; i < weapons.Length; i ++){
				if(curWeapon == i){
					weapons[i].SetActive(true);
					print(i);
				}
				else{
					weapons[i].SetActive(false);
				}
			}
			if(curWeapon == weapons.Length){
				curWeapon = 0;
			}
		}
	}
}
