//Gemaakt door Harold

using UnityEngine;
using System.Collections;

public class WeaponSelect : MonoBehaviour {

	public GameObject[] weaponBarsObject;
	public string[] weaponNameList;
	public string weaponCounterString, highLighertName;
	public int listCounter, weaponCounter;
	public GameObject currentWeapon;


	void Start () {
		WeaponLister();
		SelectedWeapon();
		//listCounter = 1;

	}

	void Update () {
		if(Input.GetButtonDown("Jump")){

		}
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
			weaponBarsObject[listCounter].transform.FindChild(weaponNameList[listCounter]).gameObject.transform.FindChild(highLighertName).gameObject.SetActive(true);//HighLighter name
		}
	}

	void SetHighlightOff(){
		for(int i = 0; i < weaponBarsObject.Length; i++){
			weaponBarsObject[i].transform.FindChild(weaponNameList[i]).transform.FindChild(highLighertName).gameObject.SetActive(false);//HighLighter name
		}
	}
}