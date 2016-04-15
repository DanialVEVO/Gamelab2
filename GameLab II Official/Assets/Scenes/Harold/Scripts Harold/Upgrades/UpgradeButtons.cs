using UnityEngine;
using System.Collections;

public class UpgradeButtons : MonoBehaviour {

	public UpgradeWeapon upgradeScript;
	public GameObject upgradeManager;
	public GameObject currentWeapon;
	public int temp;

	void Start () {
		upgradeScript = upgradeManager.GetComponent<UpgradeWeapon>();
	}

	void Update () {
	
	}

	public void upgradeFireRate(){
		upgradeScript.currentIndex = 1;// 1 = currentWeapon.fireRate;
		upgradeScript.currentWeapon = currentWeapon;
		upgradeScript.Upgrade();
		temp = upgradeScript.currentIndex; // temp = currentWeapno.firerate
	}

	public void upgradeDamage(){
		upgradeScript.currentIndex = 2;// 2 =currentWeapon.damage;
		upgradeScript.currentWeapon = currentWeapon;
		upgradeScript.Upgrade();
		temp = upgradeScript.currentIndex; // temp = currentWeapno.damage

	}

	public void upgradeMagazine(){
		upgradeScript.currentIndex = 2;// 2 =currentWeapon.magzine;
		upgradeScript.currentWeapon = currentWeapon;
		upgradeScript.Upgrade();
		temp = upgradeScript.currentIndex; // temp = currentWeapno.magazine

	}
}
