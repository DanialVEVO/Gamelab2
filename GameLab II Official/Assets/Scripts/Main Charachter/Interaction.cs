using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

	public int healthPickup;

	public float rayDis;
	public float shieldAmountPickup;

	public RaycastHit rayHit;
	public string [] tagManager;

	void Start () {
	
	}
	
	void Update () {
	
		InteractionSwitch ();

		if(Input.GetButtonDown("Interact")){
			Debug.DrawRay(transform.position, transform.forward, Color.red, rayDis);
		}

	}

	public void InteractionSwitch (){

		if(Physics.Raycast(transform.position, transform.forward, out rayHit, rayDis)){
			for(int i = 0; i < tagManager.Length; i ++){
				if(rayHit.transform.tag == tagManager[i]){
					if(Input.GetButtonDown("Interact")){
						InteractionManager(i);
						Destroy(rayHit.transform.gameObject);
					}
				}
			}
		}
	}

	public void InteractionManager (int interaction){

		switch (interaction){

			case 1 :
				print ("NPC");
				break;

			case 2 : 
				print ("Shop");
				GameObject shopManager = GameObject.FindGameObjectWithTag("ShopManager");
				shopManager.GetComponent<ShopManager>().ShopOpen();
				break;

			case 3 :
				print("Health Pickup");
				GetComponent<Health_TakeDamage_HitLocation>().playerHealth += healthPickup;
				GameObject.Find("HealthBar").GetComponent<HudBar>().DamageCheck(-healthPickup);
				break;

			case 4 : 
				print("Shield Energy Pickup");
				GetComponent<Health_TakeDamage_HitLocation>().shieldAmount += shieldAmountPickup;
				break;

			case 5 : 
				print("Weapon");
				break;

			case 6 :
				print("Treasure");
				int extraUpgradePoints;
				extraUpgradePoints = Random.Range(0, 2);
				GetComponent<Charachter_Controller>().upgradePoints += extraUpgradePoints;
				break;

			case 7 :
				print("Ammo");
				break;

			case 8 :
				print("Loot Chest");
				rayHit.transform.gameObject.GetComponent<LootChest>().LootChestSelector();
				break;

			case 9 :
				print("Secret Room");
				break;
		}
	}
}
