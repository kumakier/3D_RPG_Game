using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : BaseCharacter {


	public int curHealth;

	public int maxHealth;

	// Use this for initialization
	void Start () {

	//	GetPrimaryAttribute((int)AttributeName.Constituion).BaseValue = 100;
	//	GetVital((int)VitalName.Health).Update();



		Name = "Cubi Mob";
	}
	
	// Update is called once per frame
	void Update () {



	}

	public void DisplayHealth(){

		Messenger<int,int>.Broadcast("Mob health update", curHealth, maxHealth);
	}
}
