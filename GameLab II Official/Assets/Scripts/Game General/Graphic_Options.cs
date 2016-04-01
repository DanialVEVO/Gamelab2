using UnityEngine;
using System.Collections;

public class Graphic_Options : MonoBehaviour {

	public int qualityLevel;

	void Start () {
	
	qualityLevel = QualitySettings.GetQualityLevel();	

	}
	
	void Update () {
	
	}

	public void QualityUp (){

		string[] names = QualitySettings.names;
		GUILayout.BeginVertical();
		int i = 0;
		while (i < names.Length){
			if(GUILayout.Button(names[1])){
				QualitySettings.SetQualityLevel(i, true);
			}
			i ++;
		}
		GUILayout.EndVertical();
	}

	public void QualityDown (){

		qualityLevel -= 1;
		print(qualityLevel);

	}

}
