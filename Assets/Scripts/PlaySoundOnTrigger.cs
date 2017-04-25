using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnTrigger : MonoBehaviour {

	public bool onPlayerExit = false;
	public bool onPlayerEnter = true;

	// Use this for initialization
	
	void playAudio () {
		Debug.Log("playsound was triggered");
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}
	// Update is called once per frame
	void OnTriggerExit(Collider collision) {
		if (onPlayerExit && isPlayerCollision(collision)) {
			playAudio();
		}
	}
	void OnTriggerEnter(Collider collision) {
		if (onPlayerEnter && isPlayerCollision(collision)) {
			playAudio();
		}
	}

	bool isPlayerCollision(Collider collision) {
		var other = collision.gameObject;
		// Weapon is player top thumb
		return other.tag == "Player";
		// return other.tag == "Player";
	}
}