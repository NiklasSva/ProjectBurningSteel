using UnityEngine;
using System.Collections;

public class Type2Gravity : MonoBehaviour 
{

    public float gravitationalAcceleration = 9.81f;
    public Transform gravityObject;

    private Vector3 startPos;

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

            CustomGravityV3();
        }        
	}

    public void ClearGravityObject()
    {
        gravityObject = null;
    }  

    public void SetGravityObjectV2(Transform a_gravityObj,Vector3 a_direction)
    {
        gravityObject = a_gravityObj;
        gravityDir = a_direction;

        startPos = transform.position;
    }

    void CustomGravityV2() // gravity through acceleration
    {
        Vector3 accel = gravitationalAcceleration * Time.deltaTime * gravityDir;

        rigidbody.velocity += accel * 2;
    }

    void CustomGravityV3() // gravity through lerp, not very good, maybe timed loops of this transform will work?
    {
        transform.position = Vector3.Lerp(startPos, gravityObject.transform.position, 1.0f);
    }

    void CustomGravityV4() // gravity through translate
    {
        Vector3 accel = gravitationalAcceleration * Time.deltaTime * gravityDir;

        transform.Translate(accel);
    }
}
