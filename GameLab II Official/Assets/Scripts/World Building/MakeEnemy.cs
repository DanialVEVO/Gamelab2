﻿/* [Code]
 * Enemy Creation Class
 * Scripted by Danial
 */
using UnityEngine;
using System.Collections;

public class MakeEnemy : MonoBehaviour {

	public	bool	flying;
	public	bool	walking;
	public	bool	melee;
	public	bool	shooting;

	public	int		minChance = 0;
	public	int		maxChance = 100;
	public	int		rolledChance;

	public	int		chanceMelee;
	public	int		chanceShooting;

	public	int		chanceChampion;
	public	int		chanceNormal;
	public	int		chanceMidget;

	public	int		weight;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void RollEnemey (){
		if(walking == true){

		}
	}
}
