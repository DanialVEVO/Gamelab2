/* [no code]
 * Particle Destroyer Script
 * Scripted by Danial
 */
using UnityEngine;
using System.Collections;

public class ParticleDestroyScript : MonoBehaviour {
	
	void Start () {
		ParticleDestroy();
	}
	
	public void ParticleDestroy () {
		Destroy(gameObject, GetComponent<ParticleSystem>().duration);
	}
}
