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
	public enum DetectionStatus{
		UNDETECTED,
		SUSPICIOUS,
		DETECTED
	}
	public DetectionStatus currentDetectionStatus;


	//Runtime
	public NavMeshAgent agent;
	float activeActionTimer;
	bool moving;
	int currentPatrolNodeIndex;

	void Update(){
		ThinkCycle ();

		if (Vector3.Distance (transform.position, agent.destination) <= 0.3f) {
			moving = false;
		}
	}

	public void ThinkCycle(){
		activeActionTimer -= Time.deltaTime;

		if (currentAction == Action.IDLE) {
			if (activeActionTimer <= 0) {
				if (currentDetectionStatus == DetectionStatus.UNDETECTED) {
				}
				if (currentDetectionStatus == DetectionStatus.SUSPICIOUS) {
				}
				if (currentDetectionStatus == DetectionStatus.DETECTED) {
				}
			}
		}

	}

	void GoTo(Vector3 loc){
		agent.destination = loc;
	}

	Vector3 nextPatrolNode(){
	}



}
