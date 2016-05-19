using UnityEngine;
using System.Collections;

public class TutorialText : MonoBehaviour {

	public GameObject[] textList;
	public int textCounter;
	public bool textOn;

	void Start () {
		//movement not allowed
		TextActivator();
	}

	void Update () {
		if(Input.GetButtonDown("Next")){
			if(textCounter < textList.Length){
				TextActivator();
				if(textCounter > 1){
					textList[textCounter-2].SetActive(false);
					if(textCounter == textList.Length){
						//move allowed
					}
				}
			}
		}
	}

	public void TextActivator(){
		print(textCounter);
		textList[textCounter].SetActive(true);
		textCounter++;
	}

}
