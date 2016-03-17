using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour {

	public int interactionSelector;
	public int healthPickup;

	public float rayDis;
	public float shieldAmountPickup;

	public RaycastHit rayHit;
	public string [] tagManager;

	void Start () {
	
	}
	
	void Update () {
	
		InteractionSwitch ();

	}

	public void InteractionSwitch (){

		if(Input.GetButtonDown("Interact")){
			if(Physics.Raycast(transform.position, transform.forward, out rayHit, rayDis)){
				for(int i = 0; i < tagManager.Length; i ++){
					if(rayHit.transform.tag == tagManager[i])
						interactionSelector = i;
						Destroy(rayHit.transform.gameObject);
				}
			}
			InteractionManager(interactionSelector);
		}
	}

	public void InteractionManager (int interaction){

		switch (interaction){

			case 1 :
				print ("NPC");
				break;

			case 2 : 
				print ("Shop");
				break;

			case 3 :
				print("Health Pickup");
				GetComponent<Health_TakeDamage_HitLocation>().playerHealth += healthPickup;
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
				break;

			case 7 :
				print("Ammo");
				break;

			case 8 :
				print("Loot Chest");
				break;
		}
	}
}
