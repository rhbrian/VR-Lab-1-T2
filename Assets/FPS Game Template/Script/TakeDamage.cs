using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	public Transform TargetLock;
	public int health = 100;
	public GameObject lifePanel;
	public Transform lifeBar;

	void Start(){

		TargetLock = GameObject.FindGameObjectWithTag ("Player").transform;
	}



	void FixedUpdate(){

		if (GetComponent<Rigidbody> () == null) {
			
			transform.LookAt (TargetLock);
		}
		//
		//transform.rotation = Quaternion.Euler(transform.rotation.x, TargetLock.rotation.y+270, transform.rotation.z);
	}


	public void damage(int damageRate ){

		health -= damageRate;

		lifePanel.SetActive (true);
		lifeBar.transform.localScale = new Vector3 (lifeBar.transform.localScale.x - (float)(damageRate / 100.0f), lifeBar.transform.localScale.y, lifeBar.transform.localScale.z);
		if (health <= 0) {
         
			Destroy (this.gameObject);
			

		}
	}

	IEnumerator destroyNow(){

		yield return new WaitForSeconds (3.0f);
		Destroy (this.gameObject);
	}
}
