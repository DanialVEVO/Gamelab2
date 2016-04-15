using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour {

	public GameObject upgradeManager;
	public UpgradeButtons upgradeButtonScript;
	public int weaponCounter;
	
	void weaponButton1(){
		weaponCounter = 0;
		//switchweapon
	}

	void weaponButton2(){
		weaponCounter = 1;
		//switchweapon
	}

	void weaponButton3(){
		weaponCounter = 2;
		//switchweapon
	}
}
