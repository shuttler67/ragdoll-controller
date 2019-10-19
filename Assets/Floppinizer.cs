using UnityEngine;
using System.Collections;

public class Floppinizer : MonoBehaviour {

	public bool flop;

	/*Animator anim;

	CharacterJoint leftFoot;
	CharacterJoint rightFoot;
	CharacterJoint leftHand;
	CharacterJoint rightHand;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		leftHand = anim.GetBoneTransform (HumanBodyBones.LeftHand).gameObject.GetComponent<CharacterJoint>();
		leftFoot = anim.GetBoneTransform (HumanBodyBones.LeftFoot).gameObject.GetComponent<CharacterJoint>();
		rightFoot = anim.GetBoneTransform (HumanBodyBones.RightFoot).gameObject.GetComponent<CharacterJoint>();
		rightHand = anim.GetBoneTransform (HumanBodyBones.RightHand).gameObject.GetComponent<CharacterJoint>();*/
	void Start() {
		Rigidbody[] rgbds = GetComponentsInChildren<Rigidbody> ();
		for (int i = 0; i < rgbds.Length; i++) {
			rgbds[i].isKinematic = !flop;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {

	}
	void OnMouseDown() {
		
	}
}
