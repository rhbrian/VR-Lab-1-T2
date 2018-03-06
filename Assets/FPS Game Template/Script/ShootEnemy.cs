using UnityEngine;
using System.Collections;

public class ShootEnemy : MonoBehaviour {

	public float range = 200.0f;
	public bool showHitObjectName = true;
	public bool showRayCast = true; // You must enable Gizmos in Game view
	public int enemyDamageRate = 20;
	public float impactForce = 50f;
	public AudioClip fireSound;
	public AudioClip deathSound;
	public int damage = 10;
	public bool dead = false;

	public Camera fpsCam;

	// Use this for initialization
	void Start () {
	
	}
	

	void Update () {

		if (Input.GetButtonDown ("Fire1")) { // Mouse Left click button 
			fireNow ();



			if (dead == false) {
				GetComponent<AudioSource> ().PlayOneShot (fireSound, .5f);
			} else {
				GetComponent<AudioSource> ().PlayOneShot (deathSound, .5f);
				dead = false;
			}
		}
	
	}

	private void fireNow(){

		RaycastHit hit;

		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
			Debug.Log (hit.transform.name);

			Target target = hit.transform.GetComponent<Target> ();
			if (target != null) {
				target.TakeDamage (damage);
				if (target.health <= 0)
					dead = true;
			}
		}
	}
}
