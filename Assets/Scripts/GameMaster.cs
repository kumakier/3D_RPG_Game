using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {


	public GameObject playerCharacter;

	public GameObject gameSettings;

	public Camera mainCamera;


	public float zOffset;
	public float yOffeset;

	public float xRotOffset;



	private GameObject _pc;
	private PlayerCharacter _pcScript;

	private Vector3 _playerSpawnPointPos; // this is the place in 3D space where i want my player to spawn

	// Use this for initialization
	void Start () {

		_playerSpawnPointPos = new Vector3(1307,20,720); // the default postion for our player spawn spot

		GameObject go = GameObject.Find(GameSettings.PLAYER_SPAWN_POINT);

			if(go == null){

				Debug.LogWarning("Can not find Player Spawn Point");

			go = new GameObject(GameSettings.PLAYER_SPAWN_POINT);

			Debug.Log("Created Player Spawn Point");

			go.transform.position = _playerSpawnPointPos;

			Debug.Log("Moved Player Spawn Point");

			}

		_pc = Instantiate(playerCharacter, go.transform.position , Quaternion.identity) as GameObject;

		_pc.name = "pc";

		_pcScript = _pc.GetComponent<PlayerCharacter>();



		zOffset = -2.81f;
		yOffeset = 2.04f;
		xRotOffset = 9.463f;

		mainCamera.transform.position = new Vector3(_pc.transform.position.x,_pc.transform.position.y + yOffeset, _pc.transform.position.z + zOffset);

		mainCamera.transform.Rotate(xRotOffset, 0, 0);

		LoadCharacter();

	}

	public void LoadCharacter() {

		GameObject gs = GameObject.Find("Game Settings");


		if(gs == null) {

			GameObject gs1 = Instantiate(gameSettings , Vector3.zero, Quaternion.identity) as GameObject;
			gs1.name = "Game Settings";

		}


		GameSettings gsScript = GameObject.Find("Game Settings").GetComponent<GameSettings>();


		//Loading the character data

		gsScript.LoadCharacterData();

	}
}
