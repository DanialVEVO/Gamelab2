using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour {

	public GameObject mainMenuButtons;
	public GameObject optionsMenuButtons;
	public GameObject creditsMenu;
	public GameObject graphicsMenu;

	void Start () {

		AssignButtons();

		mainMenuButtons.SetActive(true);
		optionsMenuButtons.SetActive(false);
		creditsMenu.SetActive(false);
		graphicsMenu.SetActive(false);
	
	}
	
	void Update () {
	
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

	}

	public void ReturnToOptions (){

		optionsMenuButtons.SetActive(true);
		graphicsMenu.SetActive(false);
	}

	public void AssignButtons (){

		mainMenuButtons = GameObject.Find("MainMenuButtons");
		optionsMenuButtons = GameObject.Find("OptionMenuButtons");
		creditsMenu = GameObject.Find("Credits Menu");
		graphicsMenu = GameObject.Find("Graphics Menu");


	}
}
