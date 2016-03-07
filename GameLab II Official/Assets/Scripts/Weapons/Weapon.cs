/* [Code]
 * Abstract Weapon Class
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class Weapon : WeaponScript {

	void Update() {
		SpawnBullets();
	}

	public override void SpawnBullets() {
		if(Input.GetButtonDown("Fire1")){
//			Debug.DrawRay(transform.position, Vector3.forward, Color.green, 2f);
			Physics.Raycast(transform.position, Vector3.forward, 2f);
			Debug.Log("test");
		}
	}

	public override void Reload() {
		
	}

	public override void AltFire() {
		
	}

	public override void GiveDamage() {

	}

	public override void AmmoPool() {

	}



}
