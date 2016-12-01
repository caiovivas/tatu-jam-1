using UnityEngine;
using System.Collections;

public class AIVision : MonoBehaviour {

	public LayerMask mask;
	public bool playerOnView;
	public Vector3 lastSeen;
	Transform aiBody;

	void Start(){
		aiBody = transform.parent;
		lastSeen = Vector3.zero;
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			Vector3 aiPos = new Vector3 (aiBody.position.x, aiBody.position.y + 1.5f, aiBody.position.z);
			RaycastHit hit;
			Vector3 dir = other.transform.position - aiPos;
			dir = dir.normalized;
			if (Physics.Raycast (aiPos, dir, out hit, 1000f, mask)) {
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
