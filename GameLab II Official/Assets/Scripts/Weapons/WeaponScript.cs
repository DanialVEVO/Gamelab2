/* [Code]
 * Abstract Weapon Class
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

abstract public class WeaponScript : MonoBehaviour {

	public abstract void Cooldown();

	public abstract void FireBullets();

	public abstract void FireProjectile(float power, GameObject explosive);

	public abstract void Spread();

	public abstract void SpreadReset();

	public abstract void Reload();

	public abstract void AltFireExecute();

	public abstract void AltFire();

	public abstract void InstantiateParticles();

	public abstract void GiveDamage(int sumDamage);

	public abstract void ExplodeBarrel();

	public abstract void CalcAmmoPool(int ammo);

	public abstract void SetAmmoPool(int poolUpgrade);

	public abstract void CalcRateOfFire();

	public abstract void CalcUpgradeArray();

	public abstract void SetUpgrades();

}