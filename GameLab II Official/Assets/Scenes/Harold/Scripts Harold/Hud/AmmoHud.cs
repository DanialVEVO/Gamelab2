using UnityEngine;
using System.Collections;
//using UnityEngine.UI;

public class AmmoHud : MonoBehaviour {

	public GameObject currentweapon;
	public string currentAmmo, ammoPool;
	public RaycastWeapon rayCastClass;
	public ProjectileWeapon projectileClass;

	void Start () {
		int test = 5;
		string tester = "1";
		//tester = test.ToString(test);
		tester = string.Format("{0}", test);
		//GUILayout.Label(test.ToString(tester)); 
		//tester = (string)test;
		print(tester);
	}
	
	// Update is called once per frame
	void Update () {
		CheckHud();
	}

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
			
	}

	public void SetHud(){
		
	}
}
