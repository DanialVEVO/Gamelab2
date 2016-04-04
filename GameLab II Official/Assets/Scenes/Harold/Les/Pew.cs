using UnityEngine;
using System.Collections;

public class Pew : MonoBehaviour 
{
	public GameObject arm, legg;

	void Start () 
	{
		arm.SendMessage("ApplyDamage", 5.0F);
		legg.SendMessage("ApplyDamage", 7.0F);
		//SendMessageUpwards check all parents of the object
	}

	void Update () 
	{
	
	}



}
