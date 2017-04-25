using UnityEngine;

public class AddScoreWhileTriggerStay : MonoBehaviour {

	[System.NonSerializedAttribute]
	public GameStatus ggg;

	void Awake () {
		ggg = GameStatus.GetInstance();
	}

	void OnTriggerStay (Collider other) {
		// if its the player
		if (other.gameObject.tag == "Player") {
			if (ggg == null) {
				ggg = GameStatus.GetInstance();
			}
			ggg.AddScore(Time.deltaTime);
		}
	}
}
