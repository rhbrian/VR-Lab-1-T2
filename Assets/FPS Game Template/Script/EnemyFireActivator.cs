using UnityEngine;
using System.Collections;

public class EnemyFireActivator : MonoBehaviour {

	public GameObject parentObject;
	public GameObject gunObject;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other) {


		if (other.GetComponent<Collider>().gameObject.tag == "Player") {

			gunObject.SetActive (true);

			FollowPlayer follower = parentObject.GetComponent<FollowPlayer> ();
			if (follower != null) {

				follower.enabled = false;
			}



		}


	}

	void OnTriggerExit(Collider other) {


		if (other.GetComponent<Collider>().gameObject.tag == "Player") {

			gunObject.SetActive (false);

			FollowPlayer follower = parentObject.GetComponent<FollowPlayer> ();
			if (follower != null) {

				follower.enabled = true;
			}

		}


	}



}
