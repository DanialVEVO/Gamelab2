using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour {

	public GameObject[] weaponList;
	public GameObject[] windowList;
	public GameObject shopWindow;
	public bool shopBool;
	public int weaponCounter;
	public WeaponUpgrade upgradeScript;
	public GameObject upgradeJect;

	void Start () {
		upgradeScript = upgradeJect.GetComponent<WeaponUpgrade>();
	}

	void Update () {
		if(Input.GetButtonDown("Jump")){
			if(shopBool){
				shopWindow.SetActive(false);
				shopBool = false;
			}
			else{
				shopWindow.SetActive(true);
				shopBool = true;
			}
		}

	}

	public void WeaponButton1 (){
		//for (int i = 0; i <= weaponList.Length-1; i++)
		//{
		//	windowList[i].SetActive(false);
		//}
		//windowList[0].SetActive(true);
		upgradeScript.SaveIndex(weaponCounter);
		weaponCounter = 0;
		upgradeScript.IndexLoad(weaponCounter);
		
	}

	public void WeaponButton2 (){
		//for (int i = 0; i <= weaponList.Length-1; i++)
		//{
		//	windowList[i].SetActive(false);
		//}
		//windowList[1].SetActive(true);
		upgradeScript.SaveIndex(weaponCounter);
		weaponCounter = 1;
		upgradeScript.IndexLoad(weaponCounter);



	}

	public void WeaponButton3 (){
		//for (int i = 0; i <= weaponList.Length-1; i++)
		//{
		//	windowList[i].SetActive(false);
		//}
		//windowList[2].SetActive(true);
		upgradeScript.SaveIndex(weaponCounter);
		weaponCounter = 2;
		upgradeScript.IndexLoad(weaponCounter);

	}

	public void WeaponButton4 (){
		//for (int i = 0; i <= weaponList.Length-1; i++)
		//{
		//	windowList[i].SetActive(false);
		//}
		//windowList[3].SetActive(true);
		upgradeScript.SaveIndex(weaponCounter);
		//weaponCounter = 5; moet voor melee weapon
		upgradeScript.IndexLoad(weaponCounter);

	}
}
