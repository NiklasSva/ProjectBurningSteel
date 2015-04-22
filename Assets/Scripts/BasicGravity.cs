using UnityEngine;
using System.Collections;

public class BasicGravity : MonoBehaviour 
{

    public float gravitationalAcceleration = 9.81f;
    public float gravityMultiplier = 2;
    public Transform gravityObject;
    
    private Rigidbody rigidbody;
    private bool sideRoad = false;
    private bool sideRoadZ = false;

    private Vector3 gravityDir;


	// Use this for initialization
	void Start () 
    {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (gravityObject == null)
        {
            rigidbody.useGravity = true;
        }
        else
        {
            rigidbody.useGravity = false;

            CustomGravityV2();
        }        
	}
        
    void CustomGravity()
    {
        Vector3 accel = gravitationalAcceleration * Time.deltaTime * (gravityObject.position - transform.position);

        if (sideRoad)
        {
            if (sideRoadZ)
            {
                accel.x = 0;
                accel.y = 0;
            }
            else
            {
                accel.y = 0;
                accel.z = 0;
            }
        }
        else
        {
            accel.x = 0;
            accel.z = 0;
        }
        
        rigidbody.velocity += accel;
    }

    public void SetGravityObject(Transform a_transform, bool a_sideroad, bool a_ZAXIS)
    {
        gravityObject = a_transform;
        sideRoad = a_sideroad;
        sideRoadZ = a_ZAXIS;
    }

    public void ClearGravityObject()
    {
        gravityObject = null;
    }


    void CustomGravityV2()
    {
        Vector3 accel = gravitationalAcceleration * Time.deltaTime * gravityDir;

        rigidbody.velocity += accel * gravityMultiplier;
    }

    public void SetGravityObjectV2(Transform a_gravityObj,Vector3 a_direction)
    {
        gravityObject = a_gravityObj;
        gravityDir = a_direction;
    }
}
