using UnityEngine;
using System.Collections;

public class SingletonScript : MonoBehaviour {

	public static SingletonScript Instance { get; private set; }

	void Awake () {

		if(Instance != null && Instance != this){
			Destroy(gameObject);
		}

		Instance = this;

		DontDestroyOnLoad(gameObject);
	}

	void Start () {
	
	}
	
	void Update () {
	
	}
}
