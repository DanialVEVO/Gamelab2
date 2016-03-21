using UnityEngine;
using System.Collections;

public class LootChest : MonoBehaviour {

	public int curLootCheck;
	public int minLoot;

	public GameObject [] loot;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void LootChestSelector (){
		curLootCheck = Random.Range(minLoot, loot.Length);

		for(int i = 0; i < loot.Length; i ++){
			if(i == curLootCheck){
				Instantiate(loot[i], transform.position, Quaternion.identity);
			}
		}
	}
}
