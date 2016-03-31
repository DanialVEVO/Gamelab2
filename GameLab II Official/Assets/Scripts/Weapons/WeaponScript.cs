/* [Code]
 * Abstract Weapon Class
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

abstract public class WeaponScript : MonoBehaviour {

	public abstract void CalcRateOfFire();

	public abstract void FireBullets();

	public abstract void Spread();

	public abstract void Cooldown();

	public abstract void Reload();

	public abstract void AltFire();

	public abstract void GiveDamage(int sumDamage);

	public abstract void AmmoPool();

}