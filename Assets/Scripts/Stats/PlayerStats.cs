using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

	// Use this for initialization
	void Start () {
		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

	}		
		void OnEquipmentChanged(Equipment newItem, Equipment oldItem )
		{

			if(newItem != null)
			{
			armor.AddModifier(newItem.armourModifer);
			damage.AddModifier(newItem.damageModifer);

	}

			if(oldItem != null)
			{

				armor.RemoveModifier(oldItem.armourModifer);
				damage.RemoveModifier(oldItem.damageModifer);
			}

	}

	public override void Die()
	{

		base.Die();
		//Kill the player
		PlayerManager.instance.KillPlayer();

	}

	}