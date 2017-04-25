using UnityEngine;

public class Killzone : MonoBehaviour {

	void Start () {
		
	}
	
	void OnTriggerExit(Collider collision) {
		var other = collision.gameObject;

		if (other.tag == "Player") {
			Object.Destroy(other);
			GameStatus.RestartScene();
			return;
		} else {
			Object.Destroy(other);
		}
	}
}
