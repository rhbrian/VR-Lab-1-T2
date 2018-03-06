using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour {

	public float fireInterval = 2.0f;
	public float shootTime = 2.0f;
	public float range = 100.0f;
	public int PlayerDamageRate = 10;
	public AudioClip fireSound;
	public GameObject muzzleFlash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		shootTime += Time.deltaTime;
		if (shootTime >= fireInterval) {

			autoFire ();
			shootTime = 0;
		}
	
	}

	private void autoFire(){


		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, range)) {

			Debug.DrawRay (transform.position, transform.forward * 100, Color.red, 1.0f);
			PlayerTakeDamage damagePlayer = hit.transform.GetComponent<PlayerTakeDamage> ();

			if (damagePlayer != null) {

				damagePlayer.takeDamage (PlayerDamageRate);

				GetComponent<AudioSource> ().PlayOneShot (fireSound);
				GameObject flash =  Instantiate(muzzleFlash,transform.position,transform.rotation) as GameObject;
				Destroy (flash,0.1f);
			}


		}


		
	}
}
