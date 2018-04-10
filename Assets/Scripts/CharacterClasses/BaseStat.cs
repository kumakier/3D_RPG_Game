/// <summary>
/// Base stat.cs
/// Darren Smith
/// 12th January 2017
/// 
/// This is the base class for stats in game
/// </summary>


public class BaseStat {
	public const int STARTING_EXP_COST = 100;// publicly accessible value for all base satts to start at 


	private int _baseValue;     	 // base value of this statl
	private int _buffValue;      	 // amout of the buff to this stat;
	private int _expToLevel;      	 // the total amount of exp needed to raise this skill
	private float _levelModifer; 	// the modufer applied to the exp needed to raise the skil

	/// <summary>
	/// Initializes a new instance of the <see cref="BaseStat"/> class.
	/// </summary>



	public BaseStat() {

		UnityEngine.Debug.LogError("Base Stat Created");

		_baseValue = 0;
		_buffValue = 0;
		_levelModifer = 1.1f;
		_expToLevel = STARTING_EXP_COST;


	}

	#region Basic Setters and Getters
	 
	/// <summary>
	/// Gets or sets the _baseValue.
	/// </summary>
	/// <value>
	/// The _baseValue.
	/// </value>

	public int BaseValue{

		get{ return _baseValue; }
		set{  _baseValue = value; }
	}

	/// <summary>
	/// Gets or sets the _buffValue.
	/// </summary>
	/// <value>
	/// The _buffValue.
	/// </value>


	public int BuffValue{

		get{ return _buffValue; }
		set{  _buffValue = value; }
}
	/// <summary>
	/// Gets or sets the _expToLevel.
	/// </summary>
	/// <value>
	/// The _expToLevel.
	/// </value>


	public int ExpToLevel{

		get{ return _expToLevel; }
		set{  _expToLevel = value; }
	}

	/// <summary>
	/// Gets or sets the _levelModifer.
	/// </summary>
	/// <value>
	/// The _levelModifer.
	/// </value>

	public float LevelModifer {

		get{ return _levelModifer; }
		set{  _levelModifer = value; }
	}

	#endregion


	/// <summary>
	/// ReCalcuate the adjusted base value and return it.
	/// </summary>
	/// <value>
	/// The adjusted base value.
	/// </value>


	public int AdjustedBaseValue{


		get{ return _baseValue + _buffValue; }
	}


	/// <summary>
	/// Calculates the exp to level.
	/// </summary>
	/// <returns>
	/// The exp to level.
	/// </returns>


	private int CalcuatedExpoToLevel(){

		return(int)(_expToLevel * _levelModifer);

	}

	/// <summary>
	/// Assign the new value to _expToLevel and then increase the _baseValue by one.
	/// </summary>

	public void LevelUp() {

		_expToLevel = CalcuatedExpoToLevel();
		_baseValue++;

	}



}