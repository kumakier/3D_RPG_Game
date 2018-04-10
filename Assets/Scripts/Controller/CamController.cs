using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {



	public Transform target;

	public Vector3 offset;

	public float zoomSpeed = 4f;

	public float minZoom = 5F;

	public float maxZoom = 15f;

	public float pitch = 2f;

	private float currentZoom = 10f;

	private float yawSpeed = 100f;

	private float currentYaw = 0f;

	void Update () {


		currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
		currentZoom = Mathf.Clamp(currentZoom, minZoom , maxZoom);


		currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;

	}

	void LateUpdate()

	{

		transform.position = target.position - offset * currentZoom;
		transform.LookAt(target.position + Vector3.up * pitch) ;


		transform.RotateAround(target.position, Vector3.up, currentYaw);

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

}
