using UnityEngine;
using System.Collections;

public class dontdestrooyonload : MonoBehaviour {

	void Start () {
	
		DontDestroyOnLoad(transform.gameObject);
	
	}
	
	void Update () {
	
	}
}
