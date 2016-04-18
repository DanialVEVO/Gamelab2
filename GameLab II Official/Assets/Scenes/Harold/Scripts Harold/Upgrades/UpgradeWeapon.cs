using UnityEngine;
using System.Collections;

public class UpgradeWeapon : MonoBehaviour {

	public int[] upgradeIndex, upgradeCostIndex;
	public int currentIndex;
	public GameObject currentWeapon;
	public int forNumber;
	public int tempAmmo;
	public GameObject shopObject;
	public ShopHud shopChangeScript;

	void Start () {
		tempAmmo = 9999;
		shopChangeScript = shopObject.GetComponent<ShopHud>();
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
		shopChangeScript.changeCosts(currentIndex);
	}
}
