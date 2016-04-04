using UnityEngine;
using System.Collections;

public class LesScript : MonoBehaviour 
{
	delegate void MyDelegate();
	MyDelegate myDelgate;

	void Start () 
	{
		myDelgate = Test;
		myDelgate();
		myDelgate += Test2;
		myDelgate();
		myDelgate = Test3;
		myDelgate();
	}
		
	void Update () 
	{
	
	}

	void Test()
	{
		print("hoi");
	}

	void Test2()
	{
		print("hoi2");
	}

	void Test3()
	{
		print("hoi3");
	}
}

