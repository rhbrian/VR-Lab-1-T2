using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {


	public float destroyTime = 0.2f;
	// Use this for initialization
	void Start () {

		StartCoroutine ("destroy");
	
	}
	
	public IEnumerator destroy(){

		yield return new WaitForSeconds (destroyTime);
		Destroy (gameObject);
	}
}
