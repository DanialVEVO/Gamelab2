using UnityEngine;
using System.Collections;

public class WeaponUpgrade : MonoBehaviour {
	public GameObject player;
	public GameObject spawnCube;
	public FireRateUpGrade fireRateUpGrade;
	public MagazineSizeUrade magazineSizeUpgrade;
	public DamageUpGrade damageUpgrade;
	public int number, maxUpgradeNumber;
	public int payAmountFire, payAmountMagazine, payAmountDamage;
	public int upgradeFire, upgradeMagine, upgradeDamage;
	public int[] payFireList, payMagazineList, payDamageList;
	public int[] upgradeFireList, upgradeMagazineList, upgradeDamageList;
	//public GameObject[] button;
	public int money;
	public int weaponNumber;
	public UpgradeIndex indexScript;

	void Start(){
		money = 99999;
		indexScript = GetComponent<UpgradeIndex>();
		maxUpgradeNumber = (int)DamageUpGrade.DamageUpgrade5 + (int)MagazineSizeUrade.MagazineUpgrade5 + (int)DamageUpGrade.DamageUpgrade5;
	}

	public enum FireRateUpGrade{
		FireRateUpgrade0,
		FireRateUpgrade1,
		FireRateUpgrade2,
		FireRateUpgrade3,
		FireRateUpgrade4,
		FireRateUpgrade5
	}

	public enum MagazineSizeUrade{
		MagazineUpgrade0,
		MagazineUpgrade1,
		MagazineUpgrade2,
		MagazineUpgrade3,
		MagazineUpgrade4,
		MagazineUpgrade5
	}

	public enum DamageUpGrade{
		DamageUpgrade0,
		DamageUpgrade1,
		DamageUpgrade2,
		DamageUpgrade3,
		DamageUpgrade4,
		DamageUpgrade5
	}


	public void PickFireRate(){
		if(money >= payAmountFire){
			number  = (int)fireRateUpGrade;
			int maxTemp = (int)FireRateUpGrade.FireRateUpgrade5;

			if(number < maxTemp)
			{
				number++;
				fireRateUpGrade = (FireRateUpGrade)number;
			}

			CheckFireRate();
			PayingFireRate();
			CheckFull();
		}
	}

	public void PickMagazineSize(){
		if(money >= payAmountMagazine)
		{
			number  = (int)magazineSizeUpgrade;
			int maxTemp = (int)MagazineSizeUrade.MagazineUpgrade5;

			if(number < maxTemp)
			{
				number++;
				magazineSizeUpgrade = (MagazineSizeUrade)number;
			}

			CheckMagazine();
			PayingMagazine();
			CheckFull();

		}
	}

	public void PickDamage(){
		if(money >= payAmountDamage)
		{
			number = (int)damageUpgrade;
			int maxTemp = (int)DamageUpGrade.DamageUpgrade5;

			if(number < maxTemp)
			{
				number++;
				damageUpgrade = (DamageUpGrade)number;
			}

			CheckDamage();
			PayingDamage();
			CheckFull();
		}
	}

	void PayingFireRate(){
		money -= payAmountFire;
		payAmountFire = payFireList[number-1];
	}

	void PayingMagazine(){
		money -= payAmountMagazine;
		payAmountMagazine = payMagazineList[number-1];
	}

	void PayingDamage(){
		money -= payAmountDamage;
		payAmountDamage = payDamageList[number-1];
	}

	void CheckFull(){
		int number1 = (int)fireRateUpGrade;
		int number2  = (int)magazineSizeUpgrade;
		int number3 = (int)damageUpgrade;

		if(number1 + number2 + number3 == maxUpgradeNumber){
			//currentweaponBonus = true;
		}
	}

	public void SaveIndex(int currentWeapon){
		indexScript.fireRateUpgradeNumber[currentWeapon] = (int)fireRateUpGrade;
		indexScript.magazineUpgradeNumbeer[currentWeapon] = (int)magazineSizeUpgrade;
		indexScript.damageUpgradeNumber[currentWeapon] = (int)damageUpgrade;
		indexScript.payAmountFireNumber[currentWeapon] = payAmountFire;
		indexScript.payAmountMagazineNumber[currentWeapon] = payAmountMagazine;
		indexScript.payAmountDamageNumber[currentWeapon] = payAmountDamage;
		indexScript.upgradeFireNumber[currentWeapon] = upgradeFire;
		indexScript.upgradeMagazineNumber[currentWeapon] = upgradeMagine;
		indexScript.upgradeDamageNumber[currentWeapon] = upgradeDamage;
		print(currentWeapon);
	}

	public void IndexLoad(int currentWeapon){
		fireRateUpGrade = (FireRateUpGrade)indexScript.fireRateUpgradeNumber[currentWeapon];
		magazineSizeUpgrade = (MagazineSizeUrade)indexScript.magazineUpgradeNumbeer[currentWeapon];
		damageUpgrade = (DamageUpGrade)indexScript.damageUpgradeNumber[currentWeapon];
		payAmountFire = indexScript.payAmountFireNumber[currentWeapon];
		payAmountMagazine = indexScript.payAmountMagazineNumber[currentWeapon];
		payAmountDamage = indexScript.payAmountDamageNumber[currentWeapon];
		upgradeFire = indexScript.upgradeFireNumber[currentWeapon];
		upgradeMagine = indexScript.upgradeMagazineNumber[currentWeapon];
		upgradeDamage = indexScript.upgradeDamageNumber[currentWeapon];
		print(currentWeapon);

	}
		
	public void PickDone()
	{
		//boostScript.ReStart();
		//windowUpgrade.SetOff();
		//spawnScript.spawnAllow = true;

	}

	void CheckFireRate(){
		//goldScript.getPerMeter = goldIncrease[number-1];
		upgradeFire = upgradeFireList[number-1];

		if(number == 3){
			//button[0].SetActive(false);
		}
	}

	void CheckMagazine(){
		//boostScript.startFuel = fuelIncrease[number-1];
		upgradeMagine = upgradeMagazineList[number-1];

		if(number == 3){

			//button[1].SetActive(false);
		}
	}

	void CheckDamage(){
		//boostScript.rocketBoostStart = boostIncrease[number-1];
		upgradeDamage = upgradeDamageList[number-1];

		if(number == 3){
			//button[2].SetActive(false);
		}
	}

}

