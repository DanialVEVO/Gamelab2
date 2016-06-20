//Gemaakt door Harold mbv tutorial

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RadarObject{
	public Image icon { get; set; }
	public GameObject owner { get; set; }
}

public class MiniMap : MonoBehaviour {
	public Transform playerPos;
	float mapScale = 2.0f;

	public static List<RadarObject> mapObject = new List<RadarObject>();

	public static void RegisterMiniMapObject(GameObject o, Image i){
			Image image = Instantiate(i);
			mapObject.Add(new RadarObject(){owner = o, icon = image});
	}

	public static void RemoveMapObject(GameObject o){
		List<RadarObject> newList = new List<RadarObject>();

		for( int i = 0; i < mapObject.Count; i++){
			if(mapObject[i].owner == o){
				Destroy(mapObject[i].icon);
				continue;
			}
			else{
				newList.Add(mapObject[i]);
			}
		}

		mapObject.RemoveRange(0, mapObject.Count);
		mapObject.AddRange(newList);
	}

	void DrawMapDots(){
		foreach(RadarObject ro in mapObject){
			Vector3 mapPost = (ro.owner.transform.position - playerPos.position);
			float distToObject = Vector3.Distance(playerPos.position, ro.owner.transform.position) * mapScale;
			float deltay = Mathf.Atan2(mapPost.x, mapPost.z) * Mathf.Rad2Deg-270-playerPos.eulerAngles.y;
			mapPost.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
			mapPost.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);

			ro.icon.transform.SetParent(this.transform);
			ro.icon.transform.position = new Vector3(mapPost.x, mapPost.z, 0) + this.transform.position;
		}
	}

	void Update(){
		DrawMapDots();
	}
}
