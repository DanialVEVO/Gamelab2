//Gemaakt door Harold mbv tutorial

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MakeMapObject : MonoBehaviour {

	public Image image;

	void Start () {
		MiniMap.RegisterMiniMapObject(this.gameObject, image);
	}

	void OnDestroy(){
		MiniMap.RemoveMapObject(this.gameObject);
	}
}
