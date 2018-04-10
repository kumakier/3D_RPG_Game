/// <summary>
/// Vital bar.cs
/// 1st March 2017
/// Darren Smith
/// 
/// This is class is responsible for displaying a vital for the player character or a mob
/// </summary>
/// 

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VitalBar : MonoBehaviour {


	public bool _isPlayerHealthBar; // this boolean value tells us if this is the player health or the mob health bar

	private int _maxBarLength; // this is how large the vital bar can be if the target is at 100% health


	private int _curBarLength; // this is current length of the vital bar

	private RectTransform _display;


	void Awake()

	{


}

	// Use this for initialization
	void Start () {
	
//		_isPlayerHealthBar = true;
		ToggleDisplay(false);
		_display = gameObject.GetComponent<RectTransform>();  ///instead of GUI texture
		_maxBarLength = (int)_display.rect.width; ///instead of whatever he did

	
		OnEnable();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//This method is called when the gameobject is enabled 

	public void OnEnable()
	{
		
	if(_isPlayerHealthBar)
			Messenger<int, int>.AddListener("Player health update", OnChangeHealthbarSize);

		else


		Messenger<int , int>.AddListener("Mob health update", OnChangeHealthbarSize);
		Messenger<bool>.AddListener("show mob vitalbars", ToggleDisplay);
			

	}
		// this method is called when the gameobject is disabled
		public void OnDisable()
	{

		if(_isPlayerHealthBar)
			
			Messenger<int, int>.RemoveListener("Player health update", OnChangeHealthbarSize);

		else

			Messenger<bool>.RemoveListener("show mob vitalbars", ToggleDisplay);

	}

	//This method will calcuate the total size of the health bar in relation to the % of health the target has left
	public void OnChangeHealthbarSize(int curHealth, int maxHealth)
	{
	//	Debug.Log("We heard an event : curHealth = " + " - maxHealth = " + maxHealth);

		_curBarLength = (int)((curHealth / (float)maxHealth) * _maxBarLength); //this calculates the curent bar on the players health percentage


//	_display.sizeDelta = new Vector2(_curBarLength, _display.rect.height);

		_display.sizeDelta = CalculatePosition();

	}

	public void SetPlayerHealth(bool b){

		_isPlayerHealthBar = b;

	}

	private Vector2 CalculatePosition(){



	

		if(!_isPlayerHealthBar){



			return new Vector2(_curBarLength, _display.rect.height);
		}

		return new Vector2(_curBarLength,  _display.rect.height);
}


	private void ToggleDisplay(bool show)
	{
		gameObject.SetActive(show);
	}
}