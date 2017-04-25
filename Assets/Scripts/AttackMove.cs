// does nothing atm
using UnityEngine;

public class AttackMove : MonoBehaviour {

	public Rigidbody lowerLimb;
	public Rigidbody flappyLimb;
	
	public Transform lowerLimbT;
	public Transform upperLimbT;
	
	public Collider parentContainer;

	public Vector3 flappyLimbAttackRotation;

	public float speedOfAttack = 13.5f;

	public Vector3 attackDirection = -Vector3.forward;

	Quaternion defaultRotLT;
	Quaternion defaultRotUT;

	Animator anim;

	// float mouseHeldDownFor = 0;

	// Use this for initialization
	void Start () {
		defaultRotLT = lowerLimb.rotation = Quaternion.Euler(flappyLimbAttackRotation);
		defaultRotUT = flappyLimb.rotation;

		// thumb no colliding with box please!
        Physics.IgnoreCollision(lowerLimb.GetComponent<Collider>(), parentContainer);
        Physics.IgnoreCollision(flappyLimb.GetComponent<Collider>(), parentContainer);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		AudioSource audio = GetComponent<AudioSource>();

		var attackButtonDown = Input.GetMouseButton(0);

		var attackButtonDownNow = Input.GetMouseButtonDown(0);
		if (attackButtonDownNow) {
		}

		if (attackButtonDown) {
			var toRotation = Quaternion.FromToRotation(transform.up, attackDirection);

			var rotationSpeed = Mathf.Sqrt(speedOfAttack) * Time.deltaTime;
			lowerLimb.rotation = Quaternion.Slerp(lowerLimb.rotation, toRotation, rotationSpeed * Time.time);
			flappyLimb.rotation = Quaternion.Slerp(flappyLimb.rotation, toRotation, rotationSpeed * Time.time);

		} else if (ShouldDoSpecial()){
			// thumb goes floppy
			// when there is no codes in here
			if (!audio.isPlaying) {
				audio.Play();
			}
		} else {
			lowerLimb.rotation = defaultRotLT; 
			flappyLimb.rotation = defaultRotUT;
		}
		lowerLimbT.rotation = lowerLimb.rotation;
	}

	bool ShouldDoSpecial () {
		// var isShiftDown = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);
		var rightMouseIsDown = Input.GetMouseButton(1);
		return rightMouseIsDown;
	}
}
