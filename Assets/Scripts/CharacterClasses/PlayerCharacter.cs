public class PlayerCharacter : BaseCharacter {

	void Update() {

	
		Messenger<int,int>.Broadcast("Player health update", 80, 100);
	}


}
