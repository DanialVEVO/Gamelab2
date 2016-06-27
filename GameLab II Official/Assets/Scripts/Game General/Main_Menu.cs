using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour {

	public GameObject mainMenuButtons;
	public GameObject optionsMenuButtons;
	public GameObject creditsMenu;
	public GameObject graphicsMenu;
	public GameObject audioMenu;
	public GameObject pauzeMenu;
	public GameObject gameManager;
	public GameObject backGround;

	public int checkLevel;

	public bool pauzeCheck;

	public static Main_Menu Instance { get; private set; }

	void Awake () {

		if(Instance != null && Instance != this){
			Destroy(gameObject);
		}

		Instance = this;

		DontDestroyOnLoad(gameObject);
	}

	void Start () {

		if(Application.loadedLevel == 0){

			print(Application.loadedLevel);

			AssignButtons();

			mainMenuButtons.SetActive(true);
			optionsMenuButtons.SetActive(false);
			creditsMenu.SetActive(false);
			graphicsMenu.SetActive(false);
			audioMenu.SetActive(false);
			pauzeMenu.SetActive(false);

		}
	
	}
	
	void Update () {

		OpenPauzeMenu ();

		if(Application.loadedLevel == 1 && checkLevel == 0){

			print(Application.loadedLevel);

			checkLevel ++;

			mainMenuButtons.SetActive(false);
			optionsMenuButtons.SetActive(false);
			creditsMenu.SetActive(false);
			graphicsMenu.SetActive(false);
			audioMenu.SetActive(false);
			backGround.SetActive(false);

		}

		if(Application.loadedLevel == 0 && checkLevel == 1){

			print(Application.loadedLevel);

			checkLevel --;

			mainMenuButtons.SetActive(true);
			backGround.SetActive(true);
			optionsMenuButtons.SetActive(false);
			creditsMenu.SetActive(false);
			graphicsMenu.SetActive(false);
			audioMenu.SetActive(false);
			pauzeMenu.SetActive(false);

		}
	}

	public void StartGame (){

		Application.LoadLevel(1);
		
	}

	public void OpenOptions (){

		mainMenuButtons.SetActive(false);
		optionsMenuButtons.SetActive(true);

	}

	public void ReturnToMainMenu (){

		mainMenuButtons.SetActive(true);
		optionsMenuButtons.SetActive(false);
		creditsMenu.SetActive(false);

	}

	public void OpenCredits (){

		creditsMenu.SetActive(true);
		mainMenuButtons.SetActive(false);

	}

	public void QuitToDestop (){

		Application.Quit();
		print("QuitToDestop");
	}

	public void OpenGraphics (){

		graphicsMenu.SetActive(true);
		optionsMenuButtons.SetActive(false);
		pauzeMenu.SetActive(false);

	}

	public void OpenAudio (){
		audioMenu.SetActive(true);
		optionsMenuButtons.SetActive(false);
		pauzeMenu.SetActive(false);
	}

	public void ReturnToOptions (){

		if(Application.loadedLevel == 0){
			optionsMenuButtons.SetActive(true);
			graphicsMenu.SetActive(false);
			audioMenu.SetActive(false);
		}

		if(Application.loadedLevel == 1){
			pauzeMenu.SetActive(true);
			graphicsMenu.SetActive(false);
			audioMenu.SetActive(false);
		}

	}

	public void QuitToMainMenu (){

		Application.LoadLevel(0);
		pauzeMenu.SetActive(false);

	}

	public void AssignButtons (){

		mainMenuButtons = GameObject.Find("MainMenuButtons");
		optionsMenuButtons = GameObject.Find("OptionMenuButtons");
		creditsMenu = GameObject.Find("Credits Menu");
		graphicsMenu = GameObject.Find("Graphics Menu");
		audioMenu = GameObject.Find("Audio Menu");
		pauzeMenu = GameObject.Find("Pauze Menu");
		gameManager = GameObject.Find("_GameManager");
		backGround = GameObject.Find("Background");


	}

	public void ReturnToGame (){

		pauzeMenu.SetActive(false);
		if(pauzeCheck == true){
			Screen.lockCursor = true;
			Time.timeScale = 1f;
			pauzeCheck = false;
			GameObject.Find("PlayerTest(Clone)").GetComponent<Charachter_Controller>().enabled = true;
		}

	}

	public void OpenPauzeMenu (){

		if(Input.GetButtonDown("Cancel")){
			if(pauzeCheck == false){
				Screen.lockCursor = false;
				Time.timeScale = 0f;
				pauzeCheck = true;
				GameObject.Find("PlayerTest(Clone)").GetComponent<Charachter_Controller>().enabled = false;
				if(Application.loadedLevel == 1){
					pauzeMenu.SetActive(true);
				}
			}
		}
	}
}
