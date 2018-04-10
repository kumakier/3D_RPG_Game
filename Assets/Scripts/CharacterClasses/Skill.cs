/// <summary>
/// Skill.cs
/// 24th May 2017
/// Darren Smith
/// 
/// This class contains all the extra functions that are needed for a skill
/// </summary>

public class Skill : ModifiedStat {


	private bool _known; //a boolean variable to toogle if a character knows a skill


	/// <summary>
	/// Initializes a new instance of the <see cref="Skill"/> class.
	/// </summary>

	public Skill() {


		UnityEngine.Debug.Log("Skill Created");
	
		_known = false;
		ExpToLevel = 25;


		LevelModifer = 1.1f;

	}

	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="Skill"/> is known.
	/// </summary>
	/// <value><c>true</c> if known; otherwise, <c>false</c>.
	/// </value>

	public bool Known {

		get{ return _known; }
		set { _known = value; }

	}
}

/// <summary>
/// This emunartion is just a list of skills that the player can learn.
/// </summary>

public enum SkillName {

	Melee_Offence,
	Melee_Defence,
	Ranged_Offence,
	Ranged_Defence,
	Magic_Offence,
	Magic_Defence,

}
