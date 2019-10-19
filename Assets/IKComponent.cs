using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))] 

public class IKComponent : MonoBehaviour {

	protected Animator animator;
	
	public bool ikActive = false;
	public Transform leftFoot = null;
	public Transform leftHand = null;
	public Transform rightFoot = null;
	public Transform rightHand = null;
	public Transform seeMe = null;
	
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	//a callback for calculating IK
	void OnAnimatorIK()
	{
		if(animator) {
			
			//if the IK is active, set the position and rotation directly to the goal. 
			if(ikActive) {

				if (seeMe != null) {
					animator.SetLookAtWeight(0.5f,1);
					animator.SetLookAtPosition(seeMe.position);
				}
				// Set the right hand target position and rotation, if one has been assigned
				if(leftFoot != null) {
					animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot,1);
					animator.SetIKPosition(AvatarIKGoal.LeftFoot,leftFoot.position);
				}
				if(leftHand != null) {
					animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
					animator.SetIKPosition(AvatarIKGoal.LeftHand,leftHand.position);
				}
				if(rightFoot != null) {
					animator.SetIKPositionWeight(AvatarIKGoal.RightFoot,1);
					animator.SetIKPosition(AvatarIKGoal.RightFoot,rightFoot.position);
				}
				if(rightHand != null) {
					animator.SetIKPositionWeight(AvatarIKGoal.RightHand,1);
					animator.SetIKPosition(AvatarIKGoal.RightHand,rightHand.position);
				}
			}
			
			//if the IK is not active, set the position and rotation of the hand and head back to the original position
			else {          
				animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot,0);
			}
		}
	}    
}
