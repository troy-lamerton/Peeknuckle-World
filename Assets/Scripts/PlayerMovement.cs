using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float walkSpeed = 5f;
	public Boundary boundary;

	float curSpeed;

	// TODO: add strafe move or quick dodge move
	float burstSpeed;
	float burstSpeedDuration = 0.3f; // seconds
	Rigidbody rb;
 
	void Start() {
		rb = GetComponent<Rigidbody>();
		burstSpeed = walkSpeed + (walkSpeed / 2);
	}

	void FixedUpdate() {
		curSpeed = walkSpeed;

		//Normalize movement vector so diagonal movement is not twice as fast.
		float xDir = Input.GetAxisRaw("Horizontal");
		float zDir = 0;
		Vector2 movement = new Vector2(xDir,zDir).normalized;
		
		// the movement magic
		rb.velocity = new Vector3(
			Mathf.Lerp(0, movement.x * curSpeed, 0.8f),
			rb.velocity.y,
			Mathf.Lerp(0, movement.y * curSpeed, 0.8f)
		);
		if (xDir + zDir > 0.1f) {
			// ya moving more than a little
			// rb.AddForce(0, -3f, 0);
		}
    
		// clamp position inside a rectangle
		rb.position = new Vector3(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			rb.position.y,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);
	}

	void OnDestroy () {
		// var ggg = GameStatus.GetInstance();
		// // reset scpre before dying
		// if (ggg != null) {
		// 	ggg.AddScore(-ggg.GetScore());
		// }
	}
}

[System.Serializable]
public struct Boundary {
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
}
