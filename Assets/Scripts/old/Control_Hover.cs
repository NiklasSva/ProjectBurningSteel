using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Control_Hover : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		float rot = CrossPlatformInputManager.GetAxis("Roll");

		//rigidbody.velocity *= 0.9999f;
		rigidbody.AddRelativeForce(transform.forward * (-1) * v);
		rigidbody.AddTorque(transform.forward * h);
		rigidbody.AddTorque(transform.up * rot);
	}
}
