using UnityEngine;
using System.Collections;

public class UpgradeButtons : MonoBehaviour {

	public UpgradeWeapon upgradeScript;
	public GameObject upgradeManager;
	public GameObject currentWeapon;
	public int temp;
	public float temper;

	void Start () {
		upgradeScript = upgradeManager.GetComponent<UpgradeWeapon>();
	}

	void Update () {

	}

	public void UpgradeButton(int index){
		//putIn();
		upgradeScript.currentUpgrade = index;
		upgradeScript.currentIndex = 0;// 0 = currentWeapon.list[index];
		upgradeScript.currentWeapon = currentWeapon;
		upgradeScript.Upgrade();
		temp = upgradeScript.currentIndex; // temp = currentenWeapon.list[index];
		//pullOut();
	}
}
