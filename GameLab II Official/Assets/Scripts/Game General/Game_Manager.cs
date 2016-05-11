using UnityEngine;
using System.Collections;

public class Game_Manager : MonoBehaviour {

	public GameObject player;
	public GameObject weaponCam;
	public GameObject levelManager;

	public LevelSpawner levelSpawner;

	public Transform spawnPos;

	public int instantiateCounter;

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
			print("Check");
			levelManager = GameObject.Find("LevelSpawnManager");
			levelSpawner = levelManager.GetComponent<LevelSpawner>();
			Instantiate(player, levelSpawner.spawnPosition, Quaternion.identity);
			Instantiate(weaponCam, levelSpawner.spawnPosition, Quaternion.identity);
			//GameObject.Find("ExplodingBarrel").GetComponent<Exploding_Barrels>().player = GameObject.Find("PlayerTest(Clone)");
			instantiateCounter += 1;
		}
		
		if(Application.loadedLevel == 0 && instantiateCounter == 1){
			instantiateCounter = 0;
			Time.timeScale = 1f;
		}
	}
}
