using UnityEngine;
using System.Collections;

public class Trackball : MonoBehaviour {

	public float radius;
	[Range (0,1)]
	public float dampening;
	public float clamp = Mathf.PI*3;
	private Vector3 lastDir;
	private Quaternion rotation;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown ("Fire1")) {
			//lastDir = Vector3.zero;
		} else if (Input.GetButton ("Fire1")) {
			Vector3 dir = Nipple (-(Input.mousePosition - new Vector3 (Screen.width / 2, Screen.height / 2, 0)) / Screen.height).normalized;
			rotation = Quaternion.AngleAxis (Mathf.Clamp (Mathf.Rad2Deg * 2 * Mathf.Acos (Vector3.Dot (lastDir, dir)), -clamp, clamp), Vector3.Cross (lastDir, dir));//Quaternion.FromToRotation(lastDir,dir);
			//Debug.DrawRay(transform.position,Vector3.Cross(dir, lastDir) * 10,Color.cyan,Time.fixedDeltaTime);
			lastDir = dir;
		} else {
			float angle;
			Vector3 axis;
			rotation.ToAngleAxis(out angle, out axis);
			angle *= dampening;
			rotation = Quaternion.AngleAxis(angle, axis);
		}
		transform.rotation = rotation * transform.rotation;
	}

	private Vector3 Nipple(Vector3 pos) {
		float posDotPos = pos.x * pos.x + pos.y * pos.y;
		float radiusp2 = radius * radius;
		if (posDotPos <= radiusp2/2) {
			return new Vector3 (pos.x, pos.y, -Mathf.Sqrt(radiusp2 - posDotPos));
		}else {
			return new Vector3 (pos.x, pos.y, -(radiusp2/2) / Mathf.Sqrt(posDotPos));
		}
	}

	public Quaternion GetRotation(){
		return rotation;
	}

	public Vector3 ApplyRotation(Vector3 worldposition) {
		return transform.TransformPoint(rotation * transform.InverseTransformPoint(worldposition)); 
	}

	public Vector3 GetPointOnSphere(Vector3 worldposition) {
		return transform.TransformPoint(transform.InverseTransformPoint (worldposition).normalized * radius);
//		return point;
	}

//	public Vector3 GetMouseContactPoint() {
//		return transform.TransformPoint(Vector3.Scale(lastDir, new Vector3(1,1,-1)));
//	}
}
