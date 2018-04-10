/// <summary>
/// Attribute.cs
/// 9th Feb 2017
/// Daren Smith
/// 
/// This is the class for all of the character attributes in-game
/// </summary>

public class Attribute : BaseStat {

	new public const int STARTING_EXP_COST = 50; //this is the starting cost for all our attributes


	private string _name; // This is the name of the attribute


	/// <summary>
	/// Initializes a new instance of the <see cref="Attribute"/> class.
	/// </summary>


	public Attribute(){

		UnityEngine.Debug.LogError("Attribute Created");

		_name = "";

		ExpToLevel = STARTING_EXP_COST;

		LevelModifer = 1.05f;



	}

	/// <summary>
	/// Gets or sets the _name.
	/// </summary>
	/// <value>
	/// The name.
	/// </value>


	public string Name {

		get{ return _name; }

		set{ _name = value;}
	}
}

/// <summary>
/// This is a list of all the attributes that we will have in-game for our characters
/// </summary>

public enum AttributeName{

	Might,
	Constituion,
	Nimbleness,
	Speed,
	Concentration,
	Willpower,
	Charisma,
}
