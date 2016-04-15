using UnityEngine;
using System.Collections;

public class UpgradeWeapon : MonoBehaviour {

	public int[] upgradeIndex, upgradeCostIndex;
	public int currentIndex;
	public GameObject currentWeapon;
	public int forNumber;
	public int tempAmmo;

	void Start () {
		tempAmmo = 9999;
	}

	void Update () {

	}

	public void Upgrade(){
		forNumber = 0 * 10; // 0 = currentWeapon.number;
		for(int i = forNumber; i <= upgradeIndex.Length; i++){
			if(upgradeIndex[i] > currentIndex){
				currentIndex = upgradeIndex[i];
				tempAmmo -= upgradeCostIndex[i];//9999 = currentWeapon.ammo
				break;
			}
		}
	}
}
