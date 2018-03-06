using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	[Header("➨ Automatic follow the Player")]
	[Space(10)]

	[Tooltip("Speed of the object while following")]
	public float speed = 1;
	[Tooltip("Rotation of the object while following")]
	public float rotateSpeed = 1;
	public Quaternion Rot;
	private int cwaypoint;
	public bool moveLoop = true;
	public bool stopLoop = false;
	public Transform Target;
	public Transform[] waypoint = new Transform[1];



	void Awake () {


		Target = GameObject.FindGameObjectWithTag ("Player").transform;
		waypoint [0] = Target;



	}
   
	void LateUpdate(){


			//------------------------------

			if (moveLoop == true) {

				if(cwaypoint<waypoint.Length){
					Vector3 other =waypoint[cwaypoint].position;
					Vector3 moveDirection =other-transform.position;   
					//move towards waypoint
					if(moveDirection.magnitude<1){
						cwaypoint++;
						// Debug.Log("Waypoint no : " + cwaypoint);
					}

					else {
						var delta = other - transform.position;
						delta.Normalize();
						var moveSpeed = speed * Time.deltaTime;
						transform.position = transform.position + (delta * moveSpeed);
						//Rotate Towards
						Rot = Quaternion.LookRotation(other - transform.position,Vector3.up);
						transform.rotation = Quaternion.Slerp(transform.rotation, Rot,Time.deltaTime * rotateSpeed);   

					}
				}

				if(cwaypoint >= waypoint.Length){
					cwaypoint = 0;
					if (stopLoop == true) {

						moveLoop = false;
					}
				}
			}


		}





	}
