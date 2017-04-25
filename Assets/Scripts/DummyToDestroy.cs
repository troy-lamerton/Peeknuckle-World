// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class DummyToDestroy : MonoBehaviour {

	public int health = 3;
	public int previousHealth;
	
	public float destroyDelay = 0.1f;
	public GameObject deathExplosion;
	public GameObject hurtExplosion;

	// public GameObject objectWhilePlayerTouching;
	// private GameObject touchingEffect;
	private GameObject ParticleHolder;

	void Start() {
		ParticleHolder = GameObject.FindGameObjectWithTag("PARTICLE_HOLDER");
	}
	
	void Update () {
		if (health <= 0) {
			this.Kill();
		}
	}

	void FixedUpdate () {
		// position rotation the rigid body
		if (health < previousHealth) {
			// wobble rigidbody
			// damage effects movement etc
		}
	}

	void Damage (int amount = 1) {
		if (amount == 0) return;

		Debug.Log("ouch! " + amount.ToString());
		previousHealth = health;
		health -= amount;
	}

	void Kill () {
		Debug.Log("Dummy die");
		Object.Destroy(this.gameObject, destroyDelay);
		Instantiate(deathExplosion, transform.position, transform.rotation);
	}

	void OnCollisionEnter(Collision other) {
		GameObject specialEffectPrefab = null;

		// player touches me
		if (other.gameObject.tag == "Player") {
			specialEffectPrefab = null;
			// ruffling clothing, smooth stroking, comfortable asmr sound

			// touchingEffect = GameObject.Instantiate(objectWhilePlayerTouching, transform.position, transform.rotation);
		}

		int damageAmount = 0;
		if (other.gameObject.tag == "Weapon") {
			Debug.Log("weapon collide");
			damageAmount = 1;
			specialEffectPrefab = hurtExplosion;

		} else if (other.gameObject.tag == "DeadlyWeapon") {
			Debug.Log("deadly weapon collide");
			damageAmount = this.health;
		}

		this.Damage(damageAmount);

		if (specialEffectPrefab != null) {
			var particleSystem = Instantiate(specialEffectPrefab, transform.position, transform.rotation);
			if (particleSystem != null) {
				particleSystem.transform.SetParent(this.ParticleHolder.transform);
			}
		}
	}

	void OnCollisionExit(Collision other) {
		if (other.gameObject.tag == "Player") {
			// player moved away
			// remove the touching prefab
			// Instantiate touch prefab

			// GameObject.Destroy(touchingEffect);
		}

		if (other.gameObject.tag == "Weapon") {
			// Debug.Log("weapon collide");
			this.Damage(1);

		} 
		// else if (other.gameObject.tag == "DeadlyWeapon") {
			// Debug.Log("deadly weapon collide");
			// this.Damage(this.health);
		// }
	}
	
	void OnDestroy() {
		// Debug.Log("ya got me");

	}

}
