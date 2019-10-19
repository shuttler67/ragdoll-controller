using UnityEngine;
using System.Collections;

public class AttachToTrackball : MonoBehaviour {

	public Rigidbody marionette;
	public Trackball trackball;
	private GameObject target;
	private MoveToTarget mover;
//	private Rigidbody body;
	private RigidbodyConstraints marionetteSafe;

	// Use this for initialization
	void Start () {
		target = new GameObject ();
		target.transform.SetParent (trackball.transform);
		mover = GetComponent<MoveToTarget> ();
		mover.target = target.transform;
//		body = GetComponent<Rigidbody> ();
		mover.enabled = false;
		
		marionetteSafe = marionette.constraints;
	}

	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			StartCoroutine(Attach());
		} 
	}

	IEnumerator Attach() {
		target.transform.position = trackball.GetPointOnSphere(transform.position);
//		marionette.constraints = RigidbodyConstraints.FreezePosition;
//		body.constraints = RigidbodyConstraints.FreezePosition;
		mover.enabled = true;
		while (!Input.GetButtonUp ("Fire1")) {
			yield return null;
		}
		yield return new WaitForSeconds(1);
//		body.constraints = RigidbodyConstraints.None;
		yield return new WaitForSeconds(1);
		mover.enabled = false;
		gameObject.SetActive (false);
//		marionette.constraints = marionetteSafe;
		yield return null;
	}
}
