using UnityEngine;
using System.Collections;

public class RelativeFollowTarget : MonoBehaviour {

	public Vector3 pos;
	public Transform target;

	void Update () {
		transform.position = new Vector3 (target.position.x + pos.x, target.position.y + pos.y, target.position.z + pos.z);
	}
}
