using UnityEngine;
using System.Collections;

public class PlayerTakeDamage : MonoBehaviour {

	public int health = 100;
	public Transform playerHealthBar;
	public GameObject gameOverBanner;
	public GameObject playerHealthPanel;
	// Use this for initialization
	void Start () {
	
	}

	public void takeDamage(int damageRate){


		health -= damageRate;
		playerHealthBar.transform.localScale = new Vector3 (playerHealthBar.transform.localScale.x - (float)(damageRate / 100.0f), playerHealthBar.transform.localScale.y, playerHealthBar.transform.localScale.z);

		if (health <= 0) {

			gameOverBanner.SetActive (true);
			playerHealthPanel.SetActive (false);
		}

	}
}
