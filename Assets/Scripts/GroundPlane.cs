using UnityEngine;

public class GroundPlane : MonoBehaviour {

	public Vector3 translation;
	public float baseSpeed = 0.1f;
	public float forwardsMultiplier = 5f;

	// for restting the speed back top roiginal
	// private Vector3 _translation;
	
	Vector3 _translation;
	// like sprinting
	Vector3 fasterTranslation;

	// instance of global game status
	[System.NonSerializedAttribute]
	public GameStatus ggg;

	// Use this for initialization
	void Start () {
		_translation = new Vector3(translation.x, translation.y, translation.z);
		fasterTranslation = translation * 1.5f;
	}

	void Awake () {
		ggg = GameStatus.GetInstance();
	}

	void OnTriggerStay (Collider other) {
		// if its the player
		if (other.gameObject.tag == "Player") {
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var inputV = Input.GetAxis("Vertical");
		var inputAdjusted = inputV * forwardsMultiplier;

		var speedUp = baseSpeed;

		if (Mathf.Sign(inputAdjusted) == 1) {
			// input is forwards
			speedUp = baseSpeed + inputAdjusted;
		}

		// var couldUseTryThis = Vector3.Max(translation * speedUp, _translation);

		// is doing special move?
		if (Input.GetMouseButtonDown(1)) {
			// speed up
			translation = fasterTranslation;
		}
		if (Input.GetMouseButtonUp(1)) {
			translation = _translation;
		}

		var translateDelta = translation * speedUp;
		this.transform.Translate(translateDelta);

		// increase score
		if (ggg == null) {
			ggg = GameStatus.GetInstance();
		}
		ggg.AddScore(translateDelta.magnitude);
	}

	public void SetBaseSpeed() {

	}
}
