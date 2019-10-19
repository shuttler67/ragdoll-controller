using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float rotationSensitivity = 1;
	public Transform target;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Confined;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position;
		if (!Input.GetButton ("Fire1")) {
			transform.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal") * rotationSensitivity, 0));
		}
	}
}
