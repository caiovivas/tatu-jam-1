using UnityEngine;
using System.Collections;

public class AIEntity : MonoBehaviour {
	public enum Action{
		PATROL,
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
	public bool playerSpotted;
	public AIVision vision;
	public Animator anim;

	//Runtime
	public NavMeshAgent agent;
	float activeActionTimer;
	bool moving;
	int currentPatrolNodeIndex;
	float spotForgetTimer;

	void Start(){
		vision = GetComponentInChildren<AIVision> ();
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update(){
		lastSeenPlayerPosition = vision.lastSeen;
		anim.SetFloat ("speed", agent.velocity.magnitude);
		spotForgetTimer -= Time.deltaTime;
		ThinkCycle ();
		if (spotForgetTimer <= 0) {
			playerSpotted = false;
		}
		if (vision.playerOnView)
			playerSpotted = true;
		if (Vector3.Distance (transform.position, agent.destination) <= 1f) {
			moving = false;
		}
	}

	public void ThinkCycle(){
		activeActionTimer -= Time.deltaTime;
		if (activeActionTimer <= 0 || playerSpotted) {
			if (playerSpotted) {
				GoTo (lastSeenPlayerPosition);
				currentAction = Action.HUNT;
				return;
			}
			if (currentAction == Action.IDLE || currentAction == Action.HUNT) {
				GoTo (NextPatrolNode());
				currentAction = Action.PATROL;
				return;
			}

			if (currentAction == Action.PATROL) {
				if (!moving) {
					currentAction = Action.IDLE;
					activeActionTimer = idleTime;
					return;
				}
			}

		}
	}

	void GoTo(Vector3 loc){
		agent.destination = loc;
		moving = true;
	}

	Vector3 NextPatrolNode(){
		if (randomPatrolOrder) {
			return patrolNodes [Random.Range (0, patrolNodes.Length)];
		} else {
			if (currentPatrolNodeIndex == patrolNodes.Length - 1) {
				currentPatrolNodeIndex = 0;
			} else {
				currentPatrolNodeIndex++;
			}
			return patrolNodes [currentPatrolNodeIndex];
		}
		return Vector3.zero;
	}



}
