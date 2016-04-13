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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
