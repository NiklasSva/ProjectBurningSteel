using UnityEngine;
using System.Collections;

public class BasicVehicleControl : MonoBehaviour 
{

    public float speed = 50.0f;
    public float turnSpeed = 50.0f;
    public float jumpHeight = 20.0f;

    public Transform rayCastObject;
    public LayerMask raycastLayermask;
    public float rayCastDistance;

    private Rigidbody rigidbody;

	// Use this for initialization
	void Awake () 
    {
        rigidbody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        
        VehicleInput();

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

            if (Input.GetKeyDown("space"))
            {
                rigidbody.velocity += transform.up * jumpHeight * Time.deltaTime;
            }
        }
    }

    void VehicleInput()
    {

        float moveDistance = speed * Time.deltaTime;
        
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * moveDistance);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(-Vector3.forward * moveDistance);
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
        
        // Rotation:

        if (Input.GetKey("right"))
        {
            Vector3 rotVector = new Vector3(0.0f, 0.0f, -turnSpeed);
            transform.Rotate(rotVector * Time.deltaTime);
        }
        if (Input.GetKey("left"))
        {
            Vector3 rotVector = new Vector3(0.0f, 0.0f, turnSpeed);
            transform.Rotate(rotVector * Time.deltaTime);
        }
        if (Input.GetKey("up"))
        {
            Vector3 rotVector = new Vector3(turnSpeed, 0.0f, 0.0f);
            transform.Rotate(rotVector * Time.deltaTime);
        }
        if (Input.GetKey("down"))
        {
            Vector3 rotVector = new Vector3(-turnSpeed, 0.0f, 0.0f);
            transform.Rotate(rotVector * Time.deltaTime);
        }

    }  
      
}
