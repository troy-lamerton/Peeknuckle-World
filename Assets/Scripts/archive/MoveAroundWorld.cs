// using System.Collections;
// using System.Collections.Generic;
/*
using UnityEngine;
public class MoveAroundWorld : MonoBehaviour {

	public GameObject WorldPropsParent;
	public float rotateWorldSpeed = 90f;
	public float currentRotationSpeed = 0f;
	public float speedMult = 5f;

	public PlayerMovement player;
	public Rigidbody rbPlayer;
	public Camera playerCamera;

	void Start () {
		if (player == null) {
			GameObject.FindGameObjectWithTag("Player");
		}
		if (player == null) {
			Debug.LogError("PLAYER gameObject == null");
		}
	}
	
	void FixedUpdate () {
		// has player reached boundary?
		var boundaryZMax = GameStatus.GetInstance().playerBoundary.zMax;

		// walk past this point to trigger world moving
		float triggeringValue = boundaryZMax * (0.33f / 2f);
		if (rbPlayer != null) {
			if (rbPlayer.position.z > triggeringValue) {
				// rotate world props parent
				currentRotationSpeed = rotateWorldSpeed * rbPlayer.position.z;
			} else {
				currentRotationSpeed = 0;
				// move player horizontal == z axis [PlayerMovement handles this]
			}
		}

		var angle = -currentRotationSpeed * Time.deltaTime;
		WorldPropsParent.transform.Rotate (angle, 0, 0);
			
	}
}
*/
