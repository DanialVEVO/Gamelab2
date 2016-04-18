using UnityEngine;
using System.Collections;

public class ShopHud : MonoBehaviour {

	public ShopManager shopManger;
	public GameObject shopManagerObject;
	public GameObject[] costList;

	void Start () {
		shopManger = shopManagerObject.GetComponent<ShopManager>();
	}

	void Update () {
		
	}

	public void changeCosts(int number){
		if(shopManger.weaponCounter == 0){
			//change numbers string

		}

		if(shopManger.weaponCounter == 1){
			//change numbers string
		}

		if(shopManger.weaponCounter == 2){
			//change numbers string
		}
	}
}
