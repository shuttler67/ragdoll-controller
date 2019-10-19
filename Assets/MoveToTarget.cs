using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour {

	public Transform target;
	public float speed = 1;
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position - transform.position;
		float dirlength = dir.sqrMagnitude;
		if (dirlength <= speed*speed) {
			transform.position = target.position;
		} else {
			transform.position += dir / Mathf.Sqrt(dirlength) * speed * Time.deltaTime;
		}
	}
}
