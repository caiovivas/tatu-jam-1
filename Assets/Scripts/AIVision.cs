using UnityEngine;
using System.Collections;

public class AIVision : MonoBehaviour {

	public LayerMask mask;
	public bool playerOnView;
	public Vector3 lastSeen;


	void OnTriggerStay(Collider other){
		Debug.Log (other.transform.name);
		if (other.tag == "Player") {
			RaycastHit hit;
			Vector3 dir = other.transform.position - transform.position;
			dir = dir.normalized;
			if (Physics.Raycast (transform.position, dir, out hit, 1000f, mask)) {
				Debug.Log (hit.transform.name);
				if (hit.transform.tag == "Player") {
					playerOnView = true;
					lastSeen = hit.point;
				}
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			playerOnView = false;
		}
	}
}
