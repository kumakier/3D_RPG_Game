﻿/// <summary>
/// Target mob.cs
/// 25thMay 2017
/// Darren Smith
/// 
/// This script can be attached to any permanent gameobject and is responsible forallowing the player to target different mobs that are with in range
/// 
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class TargetMob : MonoBehaviour {

	public List<Transform> targets;
	public Transform selectedTarget;


	private Transform myTransform;



	// Use this for initialization
	void Start () {


		targets = new List<Transform>();
		selectedTarget = null;
		myTransform = transform;


		AddAllEnemies();

	}


	public void AddAllEnemies()

	{

		GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

		foreach(GameObject enemy in go)
			AddTarget(enemy.transform);


	}

	public void AddTarget(Transform enemy)
	{

		targets.Add(enemy);

	}


	private void SortTargetByDistance()
	{

		targets.Sort(delegate(Transform t1 , Transform t2){
			return Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position));
		});




	}

	private void TargetEnemy()

	{

		if(selectedTarget == null)
		{

			SortTargetByDistance();
			selectedTarget = targets[0];


		}
		else
		{

			int index = targets.IndexOf(selectedTarget);

			if(index < targets.Count - 1)
			{

				index++;

			}


			else
			{
				index = 0;

			}

			DeSelectTarget();
			selectedTarget = targets[index];

		}

		SelectTarget();
	}


	private void SelectTarget()
	{

		Transform name = selectedTarget.Find("Name");


		if(name == null) {
			Debug.LogError("Could not find the Name on " +  selectedTarget.name);

			return;

		}


		name.GetComponent<TextMesh>().text = selectedTarget.GetComponent<Mob>().Name;

		name.GetComponent<MeshRenderer>().enabled = true;

		selectedTarget.GetComponent<Mob>().DisplayHealth();

		Messenger<bool>.Broadcast("show mob vitalbars", true);
	
	}

	private void DeSelectTarget()
	{

		selectedTarget.Find("Name").GetComponent<MeshRenderer>().enabled = false;
	

		selectedTarget = null;

		Messenger<bool>.Broadcast("show mob vitalbars", false);
	}


	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Tab))
		{

			TargetEnemy();
		}

	}
}
