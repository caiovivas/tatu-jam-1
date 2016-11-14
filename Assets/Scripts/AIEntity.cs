using UnityEngine;
using System.Collections;

public class AIEntity : MonoBehaviour {
	public enum Action{
		PATROL,
		INVESTIGATE,
		HUNT,
		IDLE,
		STUNNED
	}
	public Action currentAction;
	public float idleTime;
	public bool idleTimeRandom;
	public Vector3[] patrolNodes;
	public bool randomPatrolOrder;
	public Vector3 lastSeenPlayerPosition;


	//Runtime
	float activeActionTimer;

	void Update(){
		ThinkCycle ();
	}

	public void ThinkCycle(){
		activeActionTimer -= Time.deltaTime;
		if (currentAction == Action.IDLE) {
			if (activeActionTimer <= 0) {
				
			}

		}

	}



}
