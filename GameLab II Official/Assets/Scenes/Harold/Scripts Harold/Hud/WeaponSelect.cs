using UnityEngine;
using System.Collections;

public class WeaponSelect : MonoBehaviour {

	public GameObject[] weaponBarsObject;
	public string[] weaponNameList;
	public string weaponCounterString;
	public int listCounter, weaponCounter;
	public GameObject currentWeapon;


	void Start () {
		listCounter = 1;
	}

	void Update () {
	
	}

	public void WeaponLister(){
		weaponCounterString = string.Format("{0}", listCounter);
		if(currentWeapon.tag == weaponCounterString){
			weaponBarsObject[listCounter].transform.FindChild(weaponNameList[listCounter]).gameObject.SetActive(true);
			listCounter++;
		}
	}

	public void SelectedWeapon(){
		SetHighlightOff();
		weaponCounterString = string.Format("{0}", weaponCounter);
		if(currentWeapon.tag == weaponCounterString){
			weaponBarsObject[weaponCounter].transform.FindChild("").gameObject.SetActive(true);//HighLighter name
		}	
	}

	void SetHighlightOff(){
		for(int i = 0; i < weaponBarsObject.Length; i++){
			weaponBarsObject[i].transform.FindChild("").gameObject.SetActive(false);//HighLighter name
		}
	}
}
