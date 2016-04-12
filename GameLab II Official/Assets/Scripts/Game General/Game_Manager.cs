using UnityEngine;
using System.Collections;

public class Game_Manager : MonoBehaviour {

	public GameObject player;

	public Transform spawnPos;

	private int instantiateCounter;

	public static Game_Manager Instance { get; private set; }

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
	
		InstantiatePlayer ();

	}

	public void InstantiatePlayer () {

		if(Application.loadedLevel == 1 && instantiateCounter == 0){
			Instantiate(player, spawnPos.position, Quaternion.identity);
			GameObject.Find("ExplodingBarrel").GetComponent<Exploding_Barrels>().player = GameObject.Find("PlayerTest(Clone)");
			instantiateCounter += 1;
		}
	}
}
