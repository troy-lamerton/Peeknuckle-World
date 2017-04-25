using UnityEngine;

public class TriggerHasWonGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collision) {
		if (isPlayerCollision(collision)) {
			var ggg = GameStatus.GetInstance();
			ggg.WonGame();
		}
	}

	bool isPlayerCollision(Collider collision) {
		var other = collision.gameObject;
		// Weapon is player top thumb
		return other.tag == "Player";
		// return other.tag == "Player";
	}
}
