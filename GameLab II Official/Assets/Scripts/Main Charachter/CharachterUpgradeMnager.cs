using UnityEngine;
using System.Collections;

public class CharachterUpgradeMnager : MonoBehaviour {

	public int upgradeLevelShield;
	public int upgradeLevelCharachter;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void UpgradeShield (){

		if(GameObject.Find("PlayerTest(Clone)").GetComponent<Health_TakeDamage_HitLocation>().mayUpgrade == true && GameObject.Find("PlayerTest(Clone)").GetComponent<Charachter_Controller>().upgradePoints >= 1){
			upgradeLevelShield += 1;
			GameObject.Find("PlayerTest(Clone)").GetComponent<Charachter_Controller>().upgradePoints -= 1;
		}
		GameObject.Find("PlayerTest(Clone)").GetComponent<Health_TakeDamage_HitLocation>().ShieldUpgradeManager(upgradeLevelShield);
	}

	public void UpgradesCharachter (){

		if(GameObject.Find("PlayerTest(Clone)").GetComponent<Charachter_Controller>().mayUpgrade == true && GameObject.Find("PlayerTest(Clone)").GetComponent<Charachter_Controller>().upgradePoints >= 1){
			upgradeLevelCharachter += 1;
			GameObject.Find("PlayerTest(Clone)").GetComponent<Charachter_Controller>().upgradePoints -= 1;
		}
		GameObject.Find("PlayerTest(Clone)").GetComponent<Charachter_Controller>().CharachterUpgradesManager(upgradeLevelCharachter);
	}
}
