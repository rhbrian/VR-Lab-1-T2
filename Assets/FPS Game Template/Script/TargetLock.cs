using UnityEngine;
using System.Collections;

public class TargetLock : MonoBehaviour {

	public Transform Player;

	// Use this for initialization
	void Start () {

		Player = GameObject.FindGameObjectWithTag ("Player").transform;

	}


	void FixedUpdate(){



		transform.LookAt (Player);
		//print ("Looking At player");

	}
}
