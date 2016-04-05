using UnityEngine;
using System.Collections;

public class Upgrades : MonoBehaviour {
	public GameObject player;
	public GameObject spawnCube;
	public FireRateUpGrade fireRateUpGrade;
	public MagazineSizeUrade magazineSizeUpgrade;
	public DamageUpGrade damageUpgrade;
	public int number;
	public int payAmountFire, payAmountMagazine, payAmountDamage;
	public int[] payFireList, payMagazineList, payDamageList;
	public GameObject[] button;
	public int money;

	void Start(){
		money = 99999;
	}

	public enum FireRateUpGrade{
		FireRateUpgrade0,
		FireRateUpgrade1,
		FireRateUpgrade2,
		FireRateUpgrade3,
		FireRateUpgrade4
	}

	public enum MagazineSizeUrade{
		MagazineUpgrade0,
		MagazineUpgrade1,
		MagazineUpgrade2,
		MagazineUpgrade3,
		MagazineUpgrade4
	}

	public enum DamageUpGrade{
		DamageUpgrade0,
		DamageUpgrade1,
		DamageUpgrade2,
		DamageUpgrade3,
		DamageUpgrade4
	}


	public void PickFireRate(){
		if(money >= payAmountFire){
			number  = (int)fireRateUpGrade;
			int maxTemp = (int)FireRateUpGrade.FireRateUpgrade4;

			if(number < maxTemp)
			{
				number++;
				fireRateUpGrade = (FireRateUpGrade)number;
			}

			CheckFireRate();
			PayingFireRate();
		}
	}

	public void PickMagazineSize(){
		if(money >= payAmountMagazine)
		{
			number  = (int)magazineSizeUpgrade;
			int maxTemp = (int)MagazineSizeUrade.MagazineUpgrade4;

			if(number < maxTemp)
			{
				number++;
				magazineSizeUpgrade = (MagazineSizeUrade)number;
			}

			CheckMagazine();
			PayingMagazine();

		}
	}

	public void PickDamage(){
		if(money >= payAmountDamage)
		{
			number = (int)damageUpgrade;
			int maxTemp = (int)DamageUpGrade.DamageUpgrade4;

			if(number < maxTemp)
			{
				number++;
				damageUpgrade = (DamageUpGrade)number;
			}

			CheckDamage();
			PayingDamage();
		}
	}

	void PayingFireRate(){
		money -= payAmountFire;
		payAmountFire = payFireList[number-1];
	}

	void PayingMagazine(){
		money -= payAmountFire;
		payAmountFire = payFireList[number-1];
	}

	void PayingDamage(){
		money -= payAmountFire;
		payAmountFire = payFireList[number-1];
	}

	public void PickDone()
	{
		//boostScript.ReStart();
		//windowUpgrade.SetOff();
		//spawnScript.spawnAllow = true;

	}

	void CheckFireRate(){
		//goldScript.getPerMeter = goldIncrease[number-1];

		if(number == 3){
			button[0].SetActive(false);
		}
	}

	void CheckMagazine(){
		//boostScript.startFuel = fuelIncrease[number-1];

		if(number == 3){

			button[1].SetActive(false);
		}
	}

	void CheckDamage(){
		//boostScript.rocketBoostStart = boostIncrease[number-1];

		if(number == 3){
			button[2].SetActive(false);
		}
	}

}

