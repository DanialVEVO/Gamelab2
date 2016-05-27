using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmmoHud : MonoBehaviour {

	public GameObject currentweapon;
	public string currentAmmo, ammoPool;
	public RaycastWeapon rayCastClass;
	public ProjectileWeapon projectileClass;
	public GameObject hudAmmoPool, hudCurrentAmmo;

	public void CheckHud(){
		if(currentweapon.GetComponent<RaycastWeapon>() == currentweapon.GetComponent<RaycastWeapon>()){
			rayCastClass = currentweapon.GetComponent<RaycastWeapon>();
			ammoPool = string.Format("{0}", rayCastClass.ammoPool);
			currentAmmo = string.Format("{0}",rayCastClass.loadedMagazine);
		}
		else{
			projectileClass = currentweapon.GetComponent<ProjectileWeapon>();
			ammoPool = string.Format("{0}", projectileClass.ammoPool);
			currentAmmo = string.Format("{0}", projectileClass.loadedMagazine);
		}
		SetHud();
	}

	public void SetHud(){
		hudAmmoPool.GetComponent<Text>().text = ammoPool;
		hudCurrentAmmo.GetComponent<Text>().text = currentAmmo;
	}
}
