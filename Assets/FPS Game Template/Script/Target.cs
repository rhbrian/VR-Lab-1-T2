using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
	public int health = 50;
	public GameObject ps;

	public void TakeDamage (int amount) {
		health -= amount;
		SumScore.Add (amount);

		if (health <= 0) {
			Die ();
		}
	}

	void Die () {
		Instantiate (ps, gameObject.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}

