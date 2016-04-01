using UnityEngine;
using System.Collections;

public class Graphic_Options : MonoBehaviour {

	public Rect buttonPos;

	void Start () {
	

	}
	
	void Update () {
	
	}

	public void OnGUI (){

		string[] names = QualitySettings.names;
		GUILayout.BeginArea(buttonPos);
		int i = 0;
		while (i < names.Length){
			if(GUILayout.Button(names[i])){
				QualitySettings.SetQualityLevel(i, true);
			}
			i ++;
		}
		GUILayout.EndArea();
	}

}
