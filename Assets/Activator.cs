using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

	public string[] activationButtons;
	private AttachToTrackball[] children;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i<activationButtons.Length; i++) {
			if (Input.GetButtonDown(activationButtons[i])) {
				transform.GetChild(i).position = transform.GetChild(i).GetComponent<FixedJoint>().anchor;
				transform.GetChild(i).gameObject.SetActive(true);
			}
		}
	}
}
