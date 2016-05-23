/* [Code]
 * Enemy Creation Class
 * Scripted by Danial
 */
using UnityEngine;
using System.Collections;

public class MakeEnemy : MonoBehaviour {

	public	GameObject	levelManager;

	public	bool	walking;
	public	bool	flying;
	
	[Range(0,100)]
	public	int		chanceMelee;
	[Range(0,100)]
	public	int		chanceChampion;

}
