﻿using UnityEngine;

public class CharacterStats : MonoBehaviour {


	public int maxHeatlh = 100;
	public int currentHealth {get; private set; }


	public stat damage;
	public stat armor;


	void Awake()
	{

		currentHealth = maxHeatlh;

	}


	void Update()
	{

		if(Input.GetKey(KeyCode.T))
		{

			TakeDamage(10);
		}
	}

	public void TakeDamage( int damage)
	{

		damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);

		currentHealth -= damage;
//		Debug.Log(transform.name + "takes " + damage + "damage.");

		if (currentHealth <= 0 )
		{

			Die();
		}
	}

	public virtual void Die()
	{
		Debug.Log(transform.name + "died.");
	}


}