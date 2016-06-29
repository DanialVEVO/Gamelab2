using UnityEngine;
using System.Collections;

public class EnemieAnimation : MonoBehaviour {

	public Animator enemyAnim;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void MummyShoot (){

		enemyAnim.SetBool("Spit", true);
	}

	public void MummyMelee (){

		enemyAnim.SetBool("Attack", true);
	}

	public void EnemyDead (){

		enemyAnim.SetBool("Dead", true);
	}

	public void BackToIdle (){

		enemyAnim.SetBool("Spit", false);
		enemyAnim.SetBool("Walk", false);
	}

	public void Walk (){

		enemyAnim.SetBool("Walk", true);
		enemyAnim.SetBool("Spit", false);
	}

	public void EnemyBite (){

		enemyAnim.SetBool("InRangeBite", true);
	}

	public void BatDead (){

		enemyAnim.SetBool("IfDead", true);
	}

	public void BatBackToIdle (){

		enemyAnim.SetBool("InRangeBite", false);
	}
}
