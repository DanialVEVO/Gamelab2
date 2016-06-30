using UnityEngine;
using System.Collections;

public class SoundSystem : MonoBehaviour {

	public float repeatRateAmbient, initialAmbientDelay;
	public float volume;

	public int randomAmbient;

	public AudioClip [] ambientSounds;
	public AudioSource audio;

	void Start () {

		audio = GetComponent<AudioSource>();

		InvokeRepeating("AmbientSound", initialAmbientDelay, repeatRateAmbient);
	}
	
	void Update () {
	
	}

	void AmbientSound () {

		randomAmbient = Random.Range(0, ambientSounds.Length);
		print(randomAmbient);
		//audio.PlayOneShot(ambientSounds[randomAmbient], volume);

	}

	
}
