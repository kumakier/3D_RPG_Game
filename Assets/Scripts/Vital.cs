/// <summary>
/// Vital.cs
/// 24th May 2017
/// Darren Smith
/// 
/// 
/// This class contains all the extra functions for a charactters vitals
/// </summary>

public class Vital : ModifiedStat {


	private int _curValue; // this is the current value if this vital


	/// <summary>
	///  Intialize a new instance of the <see cref="Vital"/> class.
	/// </summary>


	public Vital(){

		_curValue = 0;
		ExpToLevel = 50;
		LevelModifer = 1.1f;



	}

	/// <summary>
	/// When getting the _curValue, make sure that it is not greater than our AdjustedBaseValue
	/// If it is, make it the same as our AdjustedBaseValue
	/// </summary>
	/// <value>
	/// The current value.
	/// </value>


	public int Curvalue{

		get{

			if(_curValue > AdjustedBaseValue)

				_curValue = AdjustedBaseValue;

			return _curValue;

		}

		set{ _curValue = value;   }

	}

}

/// <summary>
/// This emunerations is just a little list of the characters will have.
/// </summary>

public enum VitalName {

	Health,
	Energy,
	Mana,



}
