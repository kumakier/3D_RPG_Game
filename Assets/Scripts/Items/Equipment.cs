using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Equipment" , menuName = "Inventory/Equipment")]
public class Equipment : Item {


	public EquipmentSlot equipSlot;
	public SkinnedMeshRenderer mesh;
	public EquipmentMeshRegion[] coveredMeshRegions;


	public int armourModifer;

	public int damageModifer;



	public override void Use()
	{


		base.Use();

		EquipmentManager.instance.Equip(this);
		RemoveFromInventory();

		// Equip the Item
		// Remove it from the inventory

	}


}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield , Feet }
public enum EquipmentMeshRegion{ Legs, ARms , Torso}; // Corresponds to boy blendshapes.





