using UnityEngine;
using System.Collections;

public class RotateAndFloat : MonoBehaviour {

	public float speed = 400f;
	public float openneer = 0f;

	void Update (){
		SineBounce();
	}

	public void SineBounce () {
		Vector3 nextRotate = Vector3.zero;

		nextRotate.y = speed * Time.deltaTime;
		nextRotate.z = speed * Time.deltaTime;   

		transform.Rotate(nextRotate);

		openneer+=Time.deltaTime;
		gameObject.transform.position=new Vector3(gameObject.transform.position.x, (Mathf.Sin(openneer)*0.1f)+0.85f, gameObject.transform.position.z);
	}
}