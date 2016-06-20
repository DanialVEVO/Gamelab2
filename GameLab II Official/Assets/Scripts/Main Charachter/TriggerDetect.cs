using UnityEngine;
using System.Collections;

public class TriggerDetect : MonoBehaviour {

	public int switcher;

	public GameObject levelSpawnMNGR;

	void Start () {

		levelSpawnMNGR = GameObject.Find("LevelSpawnManager");
	
	}
	
	void Update () {
	
	}

	void OnCollisionEnter(Collision hit){
		if(hit.transform.tag == "trigger1"){
			switcher = 1;
			levelSpawnMNGR.GetComponent<LevelSpawner>().TriggerDetect(switcher);
		}

		if(hit.transform.tag == "trigger2"){
			switcher = 2;
			levelSpawnMNGR.GetComponent<LevelSpawner>().TriggerDetect(switcher);
		}

		if(hit.transform.tag == "trigger3"){
			switcher = 3;
			levelSpawnMNGR.GetComponent<LevelSpawner>().TriggerDetect(switcher);
		}

		if(hit.transform.tag == "triggerX"){
			switcher = 4;
			levelSpawnMNGR.GetComponent<LevelSpawner>().TriggerDetect(switcher);
		}
	}
}
