//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class UpgradeWeapon : MonoBehaviour {

	public int[] upgradeIndex, upgradeCostIndex;
	public int[] currentUpgradeCount;
	public int currentUpgrade;
	public GameObject currentWeapon;
	public int forNumber, afterForNumber, upgradeAmount, currentIndex;
	public int tempAmmo;
	public GameObject shopObject;
	public ShopHud shopChangeScript;

	void Start () {
		//tempAmmo = 9999;
		//shopChangeScript = shopObject.GetComponent<ShopHud>();
	}

	void Update () {

	}

	public void Upgrade(){
		forNumber = currentIndex * upgradeAmount;
		currentUpgradeCount[currentIndex]++;
		for(int i = forNumber; i <= upgradeIndex.Length; i++){
			if(upgradeIndex[i] > currentUpgrade){
				if(tempAmmo >= upgradeIndex[i]){
					currentUpgrade = upgradeIndex[i];
					tempAmmo = upgradeCostIndex[i];//9999 = currentWeapon.ammo
				}
				else{
					currentUpgradeCount[currentIndex]--;
				}
				afterForNumber = i;
				Debug.Log(currentUpgrade);
				break;
			}
		}
		afterForNumber++;
		//shopChangeScript.changeHud(afterForNumber);
	}
}
