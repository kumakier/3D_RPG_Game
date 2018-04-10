using UnityEngine.EventSystems;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {



	public Interactable focus;

	public LayerMask movementtMask;

	Camera cam;

	PlayerMotor motor;

	// Use this for initialization
	void Start () {


		cam = Camera.main;
		motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {


		if(EventSystem.current.IsPointerOverGameObject())

			return;


		if(Input.GetMouseButtonDown(0))
		{

			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, 100, movementtMask))
			{
				motor.MoveToPoint(hit.point);

				RemoveFocus();

			}

		}

		if(Input.GetMouseButtonDown(1))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, 100))
			{
				
			Interactable interactble = hit.collider.GetComponent<Interactable>();

				if(interactble != null) 

				{

					SetFocus(interactble);

				}


			}



		}
	}

	void SetFocus(Interactable newFocus)
	{

		if(newFocus != focus)
		{

			if ( focus != null)
				
				focus.OnDeFocused();
		

		focus = newFocus;
		motor.FollowTarget(newFocus);


}

	newFocus.OnFocused(transform);

}

	void RemoveFocus()

	{

		if ( focus != null)
		focus.OnDeFocused();


		focus = null;
		motor.StopFollowingTarget();
	}


}
