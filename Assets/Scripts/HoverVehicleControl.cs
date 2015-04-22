using UnityEngine;
using System.Collections;

public class HoverVehicleControl : MonoBehaviour 
{
    public float acceleration;
    public float rotationRate;

    // Values for faking a nice turn display
    public float turnRotationAngle;
    public float turnRotationSeekSpeed;

    // Reference variables we don't really use
    private float rotationVelocity;
    private float groundAngleVelocity;

    void FixedUpdate()
    {
        // Is the vechicle touching the ground?
        if (Physics.Raycast(transform.position, transform.up * -1, 3f))
        {
            // It is on the ground; enable accelerator and increase drag
            GetComponent<Rigidbody>().drag = 1.0f;

            // Calculate forward force:
            Vector3 forwardForce = transform.forward * acceleration * Input.GetAxis("Vertical");
            // Correct force for deltatime and vehicle mass:
            forwardForce *= Time.deltaTime * GetComponent<Rigidbody>().mass;

            GetComponent<Rigidbody>().AddForce(forwardForce);
        }
        else
        {
            // The vechile is in the air, reduce drag:
            GetComponent<Rigidbody>().drag = 0.0f;
        }

        Vector3 turnTorque = Vector3.up * rotationRate * Input.GetAxis("Horizontal");
        
        // Correct for deltatime and mass:
        turnTorque *= Time.deltaTime * GetComponent<Rigidbody>().mass;
        GetComponent<Rigidbody>().AddTorque(turnTorque);

        /*
        // "Fake" rotate the vehicle when turning
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = Mathf.SmoothDampAngle(newRotation.z, Input.GetAxis("Horizontal") * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        transform.eulerAngles = newRotation;
         * */
    }
	
}
