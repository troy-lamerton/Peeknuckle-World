using UnityEngine;

public class ConstantRotate : MonoBehaviour {
	public float degreesPerSecond = 50f;

	void Update () {
		// rotate around y axis
		transform.Rotate (0, degreesPerSecond * Time.deltaTime, 0); 
	}
}
