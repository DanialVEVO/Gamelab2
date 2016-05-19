using UnityEngine;
using System.Collections;

public class UpgradeButtons : MonoBehaviour {

	public UpgradeWeapon upgradeScript;
	public GameObject upgradeManager;
	public GameObject currentWeapon;
	//public RaycastWeapon weaponScript;
	public Upgraders upgradeIndexer;
	//public int temp;
	public float temper;

	void Start () {
		upgradeScript = upgradeManager.GetComponent<UpgradeWeapon>();
		upgradeIndexer = upgradeManager.GetComponent<Upgraders>();

	}

	void Update () {

	}

	public void UpgradeButton(int index){
		currentWeapon = upgradeScript.currentWeapon;
		//weaponScript = currentWeapon.GetComponent<RaycastWeapon>();
		//weaponScript.CalcUpgradeArray();
		upgradeIndexer.GetVariables(currentWeapon);
		upgradeScript.currentIndex = index;
		upgradeScript.currentUpgrade = upgradeIndexer.upgradeVariables[index]; //weaponScript.upgradeVariables[index];// 0 = currentWeapon.list[index];
		//upgradeScript.currentWeapon = currentWeapon;
		//upgradeScript.weaponScript = weaponScript;
		upgradeScript.Upgrade();
		upgradeIndexer.upgradeVariables[index] = upgradeScript.currentUpgrade; // temp = currentenWeapon.list[index];
		upgradeIndexer.SetVariables(currentWeapon);
		//weaponScript.SetUpgrades();
	}
}
