using UnityEngine;
using System.Collections;

public class ExplosiveProjectileScript : MonoBehaviour {

	public	enum		Explosives{
							Grenade,
							Rocket,
						}
	public	Explosives	myExplosiveType;

	public	float		fuseTimer;

	public	RaycastHit	hit;


	// Use this for initialization
	void Start () {

		IdentifyMe();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void IdentifyMe () {
		switch(myExplosiveType){

			case Explosives.Grenade :
				Grenade();

				break;

			case Explosives.Rocket :
				Rocket();

				break;
		}

	}

	void Grenade () {
		print("myExplosiveType");
	}

	void Rocket (){
		print("myExplosiveType");
	}
}
