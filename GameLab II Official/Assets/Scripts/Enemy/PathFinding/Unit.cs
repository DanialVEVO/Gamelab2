using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public Transform target;
	public float speed;
	Vector3[] path;
	int targetIndex;
	public float cooldownPath;

	void Start () {

		StartCoroutine(StartNewPathProcess(cooldownPath));
		
	}

	IEnumerator StartNewPathProcess (float cooldown){

		yield return new WaitForSeconds(cooldown);
		PathRequestManager.RequestPath (transform.position, target.position, OnPathFound);
		cooldown = 0;

	}

	public void OnPathFound (Vector3[] newPath, bool pathSuccesful){
		if (pathSuccesful == true){
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath (){

		Vector3 currentWaypoint = path[0];

		while (true){
			if(transform.position == currentWaypoint){
				targetIndex ++;
				if(targetIndex >= path.Length){
					print("Break");
					print(path.Length);
					print(targetIndex);
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}
			transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
			yield return null;
		}
	}

	public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex) {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}
}
