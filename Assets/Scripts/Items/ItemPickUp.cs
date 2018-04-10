﻿using UnityEngine;

public class ItemPickUp : Interactable {

	public Item item;

	public override void Interact()
	{

		base.Interact();

		PickUp();
	}



	void PickUp()
	{

	
		Debug.Log("Picked up " + item.name);
		// Add to inventory


		bool wasPickedUp = Inventory.instance.Add(item);
	
		if(wasPickedUp)

		Destroy(gameObject);


	}

}
