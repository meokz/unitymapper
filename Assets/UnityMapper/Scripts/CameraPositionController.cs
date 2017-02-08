using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionController : MonoBehaviour {

	public GameObject CameraCenter;
	public GameObject CameraRight;
	public GameObject CameraLeft;

	private float degree = 10;
	public float Degree {
		get { return degree; }
		set {
			degree = value;
			OnAngleChanged();
		}
	}

	public float Distance = -10.0f;

	void OnAngleChanged() {
		float radian = this.Degree * Mathf.Deg2Rad;

		float x = Distance * Mathf.Sin(radian);
		float d = Distance * Mathf.Cos(radian);

		if(CameraCenter != null) {
			CameraCenter.transform.localPosition = new Vector3(0, 0, Distance);
		}

		if(CameraRight != null) {
			CameraRight.transform.localPosition = new Vector3(x, 0, d);
			CameraRight.transform.localRotation = Quaternion.Euler(0, this.Degree, 0);
		}

		if(CameraLeft != null) {
			CameraLeft.transform.localPosition = new Vector3(-x, 0, d);
			CameraLeft.transform.localRotation = Quaternion.Euler(0, -this.Degree, 0);
		}
	}
}
