/* [Code]
 * Abstract Weapon Class
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

abstract public class WeaponScript : MonoBehaviour {

	public abstract void Cooldown();

	public abstract void FireBullets();

	public abstract void Spread();

	public abstract void SpreadReset();

	public abstract void Reload();

	public abstract void AltFireExecute();

	public abstract void AltFire();

	public abstract void GiveDamage(int sumDamage);

	public abstract void AmmoPool();

	public abstract void CalcRateOfFire();

}