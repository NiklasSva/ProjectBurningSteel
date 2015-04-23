using UnityEngine;
using System.Collections;

public class BasicVehicleControlPlayer2 : MonoBehaviour 
{

    public float speed = 50.0f;
    public float turnSpeed = 50.0f;
    public float rotSpeed = 10.0f;
    public float jumpHeight = 20.0f;

    public float maxSpeed = 200.0f;

    public Transform rayCastObject;
    public LayerMask raycastLayermask;
    public float rayCastDistance;

    private Rigidbody rigidbody;

	// Use this for initialization
	void Awake () 
    {
        rigidbody = this.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {

        Rotation();

        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        // On Ground?
        if (Physics.Raycast(rayCastObject.position, rayCastObject.up * -1, rayCastDistance, raycastLayermask))
        {
            Debug.DrawRay(rayCastObject.position, rayCastObject.up * -1, Color.green);

            if (Input.GetButtonDown("A_P2") || Input.GetButtonDown("Space"))
            {
                Debug.Log("JUMP 2!");
                rigidbody.velocity += transform.up * jumpHeight * Time.deltaTime;
            }

            VehicleInput();
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

        if (Input.GetButtonDown("B_all"))
        {
            Debug.Log("lol");
        }


        if (Mathf.Round(Input.GetAxis("Triggers_P2")) < 0)
        {
            Debug.Log("RightTrigger 2!");
            rigidbody.velocity += transform.forward * moveDistance;
        }
        if (Mathf.Round(Input.GetAxis("Triggers_P2")) > 0)
        {
            Debug.Log("RightTrigger 2!");
            rigidbody.velocity += -transform.forward * moveDistance;
        }



        Vector3 _rotVector = new Vector3(0.0f, turnSpeed, 0.0f) * Time.deltaTime * Input.GetAxis("LeftJoystickX_P2");
        transform.Rotate(_rotVector * Time.deltaTime);
               
        
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
        Vector3 _rotVector = new Vector3(0.0f, 0.0f, -turnSpeed) * Time.deltaTime * Input.GetAxis("RightJoystickX_P2");
        transform.Rotate(_rotVector * Time.deltaTime);

        _rotVector = new Vector3(-turnSpeed, 0.0f, 0.0f) * Time.deltaTime * Input.GetAxis("RightJoystickY_P2");
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
}
