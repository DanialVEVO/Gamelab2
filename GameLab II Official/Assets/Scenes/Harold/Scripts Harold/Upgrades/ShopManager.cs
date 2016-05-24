using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour {

	//public GameObject upgradeManager;
	//public UpgradeButtons upgradeButtonScript;
	public GameObject[] shopHudList;
	public int weaponCounter;
	
	public void weaponButton1(int indexer){
		weaponCounter = indexer;
		PutOff();
		shopHudList[indexer].SetActive(true);
		//switchweapon
	}

	void PutOff(){
		for(int i = 0; i < shopHudList.Length; i++){
			shopHudList[i].SetActive(false);
		}
	}
}
