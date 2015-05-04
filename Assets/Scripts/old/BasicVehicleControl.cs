using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof (EnergyScript))]
public class BasicVehicleControl : MonoBehaviour 
{
    public float speed = 50.0f;
    public float turnSpeed = 50.0f;
    public float rotSpeed = 10.0f;
    public float jumpHeight = 20.0f;

    public float maxSpeed = 200.0f;
    public float boostMultiplier = 2.0f;
    private float maxSpeedBoosted;
    private float oldMaxSpeed;

    public Transform rayCastObject;
    public LayerMask raycastLayermask;
    public float rayCastDistance;

    private Rigidbody rigidbody;
    private EnergyScript energyScript;

	// Use this for initialization
	void Awake () 
    {
        energyScript = GetComponent<EnergyScript>();
        rigidbody = GetComponent<Rigidbody>();
        maxSpeedBoosted = maxSpeed * boostMultiplier;
        oldMaxSpeed = maxSpeed;
	}

    // Update is called once per frame
    void Update()
    {
        // quit
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        // Steering
        Vector3 _rotVector = new Vector3(0.0f, turnSpeed, 0.0f) * Time.deltaTime * Input.GetAxis("LeftJoystickX");
        transform.Rotate(_rotVector * Time.deltaTime);

        // On Ground?
        if (Physics.Raycast(rayCastObject.position, rayCastObject.up * -1, rayCastDistance, raycastLayermask))
        {
            //Debug.DrawRay(rayCastObject.position, rayCastObject.up * -1, Color.green);

            if (Input.GetButtonDown("A"))
            {
                rigidbody.velocity += transform.up * jumpHeight * Time.deltaTime;
            }

            VehicleInput();
        }
        else
        {
            Rotation();

            GetComponent<EnergyScript>().AttritionDamage();
        }

        Vector3 vel = rigidbody.velocity;
        if (vel.magnitude > maxSpeed)
        {
            vel.Normalize();
            vel *= maxSpeed;
            rigidbody.velocity = vel;
        }
    }

    void VehicleInput()
    {
        float moveDistance = speed * Time.deltaTime;

        // Boost
        if (Input.GetButton("X") && energyScript.currentEnergy > 0.0f)
        {
            maxSpeed = maxSpeedBoosted;
            rigidbody.AddForce(transform.forward * speed * 2);
            energyScript.BoostCost();
        }
        else
        {
            maxSpeed = oldMaxSpeed;
        }

        // Accelerate and Decelerate
        if (Mathf.Round(Input.GetAxis("Triggers")) < 0)
        {
            rigidbody.velocity += transform.forward * moveDistance;
        }
        if (Mathf.Round(Input.GetAxis("Triggers")) > 0)
        {
            rigidbody.velocity += -transform.forward * moveDistance;
        }

        // Keyboard input       
        if (Input.GetKey("w"))
        {
            //transform.Translate(Vector3.forward * moveDistance);
            rigidbody.velocity += transform.forward * moveDistance;
        }
        if (Input.GetKey("s"))
        {
            //transform.Translate(-Vector3.forward * moveDistance);
            rigidbody.velocity += -transform.forward * moveDistance;
        }

        if (Input.GetKey("a"))
        {
            Vector3 rotVector = new Vector3(0.0f, -turnSpeed, 0.0f);
            transform.Rotate(rotVector * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            Vector3 rotVector = new Vector3(0.0f, turnSpeed, 0.0f);
            transform.Rotate(rotVector * Time.deltaTime);
        }
    }

    void Rotation()
    {
        Vector3 _rotVector = new Vector3(0.0f, 0.0f, -turnSpeed) * Time.deltaTime * Input.GetAxis("RightJoystickX");
        transform.Rotate(_rotVector * Time.deltaTime);

        _rotVector = new Vector3(-turnSpeed, 0.0f, 0.0f) * Time.deltaTime * Input.GetAxis("RightJoystickY");
        transform.Rotate(_rotVector * Time.deltaTime);


        // Rotation:
        if (Input.GetKey("right"))
        {
            Vector3 rotVector = new Vector3(0.0f, 0.0f, -rotSpeed);
            transform.Rotate(rotVector * Time.deltaTime);
        }
        if (Input.GetKey("left"))
        {
            Vector3 rotVector = new Vector3(0.0f, 0.0f, rotSpeed);
            transform.Rotate(rotVector * Time.deltaTime);
        }
        if (Input.GetKey("up"))
        {
            Vector3 rotVector = new Vector3(rotSpeed, 0.0f, 0.0f);
            transform.Rotate(rotVector * Time.deltaTime);
        }
        if (Input.GetKey("down"))
        {
            Vector3 rotVector = new Vector3(-rotSpeed, 0.0f, 0.0f);
            transform.Rotate(rotVector * Time.deltaTime);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(200, 200, 100, 20), "Energy: " + Mathf.Round(energyScript.currentEnergy).ToString());
    }
}
