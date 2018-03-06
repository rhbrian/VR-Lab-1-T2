using UnityEngine;
using System.Collections;

public class AutoHide : MonoBehaviour {

	public float hideTimeAfter = 0.2f;

	void Start () {
	
		StartCoroutine ("selfHide");
	}
	
	public IEnumerator selfHide(){

		yield return new WaitForSeconds (hideTimeAfter);
		gameObject.SetActive (false);
	}
}
