using UnityEngine;
using System.Collections;

public class UpgradeButtons : MonoBehaviour {

	public UpgradeWeapon upgradeScript;
	public GameObject upgradeManager;
	public GameObject currentWeapon;
	public RaycastWeapon weaponScript;
	//public int temp;
	public float temper;

	void Start () {
		upgradeScript = upgradeManager.GetComponent<UpgradeWeapon>();

	}

	void Update () {

	}

	public void UpgradeButton(int index){
		weaponScript = currentWeapon.GetComponent<RaycastWeapon>();
		weaponScript.CalcUpgradeArray();
		upgradeScript.currentIndex = index;
		upgradeScript.currentUpgrade = weaponScript.upgradeVariables[index];// 0 = currentWeapon.list[index];
		upgradeScript.currentWeapon = currentWeapon;
		upgradeScript.weaponScript = weaponScript;
		upgradeScript.Upgrade();
		weaponScript.upgradeVariables[index] = upgradeScript.currentUpgrade; // temp = currentenWeapon.list[index];
		weaponScript.SetUpgrades();
	}
}
