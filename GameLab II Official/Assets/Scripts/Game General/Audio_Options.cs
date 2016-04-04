using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Audio_Options : MonoBehaviour {

	public Slider masterVolume;

	void Start () {

		masterVolume.value = 0.5f;

	}
	
	void Update () {
	
	}

	public void MasterVolume (){

		 AudioListener.volume = masterVolume.value;

	}
}
