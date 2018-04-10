using UnityEngine;
using System.Collections;
using System;

public class GameSettings : MonoBehaviour {

	public const string PLAYER_SPAWN_POINT = "Player Spawn Point"; // This is the name of the game object that player will spawn on at the start of the level


	void Awake() {

		DontDestroyOnLoad(this);

	}


	public void SaveCharacterData(){

		GameObject pc = GameObject.Find("pc");

		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();

		//PlayerPrefs.DeleteAll();

		PlayerPrefs.SetString("Player Name", pcClass.Name );

		for(int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++){
		
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString() + " - Base Value" ,pcClass.GetPrimaryAttribute(cnt).BaseValue);
			PlayerPrefs.SetInt(((AttributeName)cnt).ToString() + " - Exp to Level" , pcClass.GetPrimaryAttribute(cnt).ExpToLevel);

		}

		for(int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++){

			PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Base Value" ,pcClass.GetPrimaryAttribute(cnt).BaseValue);
			PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Exp to Level" , pcClass.GetPrimaryAttribute(cnt).ExpToLevel);
			PlayerPrefs.SetInt(((VitalName)cnt).ToString() + " - Cur Value" , pcClass.GetVital(cnt).Curvalue);

//			PlayerPrefs.SetString(((VitalName)cnt).ToString() + "- Mods", pcClass.GetVital(cnt).GetModifyingAttributesString());

		}

		for(int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++){

			PlayerPrefs.SetInt(((SkillName)cnt).ToString() + " - Base Value" ,pcClass.GetSkill(cnt).BaseValue);
			PlayerPrefs.SetInt(((SkillName)cnt).ToString() + " - Exp to Level" , pcClass.GetSkill(cnt).ExpToLevel);

//		    PlayerPrefs.SetString(((SkillName)cnt).ToString() + "- Mods", pcClass.GetSkill(cnt).GetModifyingAttributesString());



	}



	}

	public void LoadCharacterData(){


		GameObject pc = GameObject.Find("pc");

		PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();
	

		pcClass.Name  = PlayerPrefs.GetString("Player Name" , "Name me");


		for(int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++){

			pcClass.GetPrimaryAttribute(cnt).BaseValue = PlayerPrefs.GetInt(((AttributeName)cnt).ToString() + " - Base Value" , 0);
			pcClass.GetPrimaryAttribute(cnt).ExpToLevel = PlayerPrefs.GetInt(((AttributeName)cnt).ToString() + " - Exp to Level" , Attribute.STARTING_EXP_COST);

		}

		for(int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++){

			pcClass.GetPrimaryAttribute(cnt).BaseValue = PlayerPrefs.GetInt(((VitalName)cnt).ToString() + " - Base Value" , 0);
			pcClass.GetPrimaryAttribute(cnt).ExpToLevel = PlayerPrefs.GetInt(((VitalName)cnt).ToString() + " - Exp to Level"  , 0);



			pcClass.GetVital(cnt).Update();

			pcClass.GetVital(cnt).Curvalue = PlayerPrefs.GetInt(((VitalName)cnt).ToString() + " - Cur Value" , 1);

			}

		for(int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++){

			pcClass.GetSkill(cnt).BaseValue = PlayerPrefs.GetInt(((SkillName)cnt).ToString() + " - Base Value" , 0 );
			pcClass.GetSkill(cnt).ExpToLevel = PlayerPrefs.GetInt(((SkillName)cnt).ToString() + " - Exp to Level" , 0);

	


		}


		for(int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++){
			Debug.Log(((SkillName)cnt).ToString() + " : " + pcClass.GetSkill(cnt).BaseValue + " -  " + pcClass.GetSkill(cnt).ExpToLevel );



				}


}
}
