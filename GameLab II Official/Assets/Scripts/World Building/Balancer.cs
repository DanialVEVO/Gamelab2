/* [Code]
 * Enemy Balancer Class
 * Scripted by Danial
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Balancer : MonoBehaviour {

	public	int	weightLimit;
	public	int currentWeight;
	public	int	chosenEnemy;
	public List<Transform> enemyList = new List<Transform>();

	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
		if(currentWeight <= currentWeight){
			Debug.Log(ChooseEnemy());
		}
	}

	public int ChooseEnemy () {
		chosenEnemy = Random.Range(0, enemyList.Count);
		return chosenEnemy;
	}

	public void CalcWeigth (int weightReceived){
		
	}
}
