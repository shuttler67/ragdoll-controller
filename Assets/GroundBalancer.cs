using UnityEngine;
using System.Collections;

public class GroundBalancer : MonoBehaviour {

	public GameObject anchor;
	public float SpringBreakForce = Mathf.Infinity;
	public float SpringSpring = 10;
	SpringJoint spring;
	GameObject anchorInstance;
	Vector3 anchorPosition;

	// Use this for initialization
	void Start () {
		//spring = GetComponent<SpringJoint> ();
		CapsuleCollider c = GetComponent<CapsuleCollider> ();
		anchorPosition = new Vector3 (-(c.radius +c.height)/2, 0, 0) + c.center;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	void OnCollisionEnter(Collision coll) {

		if (spring == null && anchorInstance == null) {
		
			spring = gameObject.AddComponent <SpringJoint> ();
			spring.anchor = anchorPosition;
			spring.autoConfigureConnectedAnchor = true;
			anchorInstance = (GameObject)Instantiate (anchor, transform.TransformPoint (anchorPosition), Quaternion.identity);

//			RaycastHit hit;
//			Physics.Raycast (transform.TransformPoint (anchorPosition), -coll.contacts [0].normal, out hit);
//			Debug.DrawRay (hit.point, hit.normal * 2);
//			if (hit) {
//				anchorInstance.GetComponent<MoveToTarget> ().target = hit.point;
//			} else {
//				anchorInstance.GetComponent<MoveToTarget> ().enabled = false;
//			}
			spring.spring = SpringSpring;
			spring.connectedBody = anchorInstance.GetComponent<Rigidbody> ();
			spring.breakForce = SpringBreakForce;
		}
	}

	void OnCollisionExit() {
//		Destroy (spring);
//		Destroy (anchorInstance);
	}
}
