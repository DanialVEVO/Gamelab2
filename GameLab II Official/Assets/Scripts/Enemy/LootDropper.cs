/* [Code]
 * Loot Dropper - Drops loot when an enemy dies
 * Scripted by Danial
 */
using UnityEngine;
using System.Collections;

public class LootDropper : MonoBehaviour {

	public	GameObject[] Pickups = new GameObject[5];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	int ChooseDrop () {
		int myDrop = Random.Range(0, Pickups.Length);
		return myDrop;
	}

	public void Drop (Vector3 dropLocation ){
		Instantiate(Pickups[ChooseDrop()], dropLocation, Quaternion.identity);
	}
}
