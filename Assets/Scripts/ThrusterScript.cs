using UnityEngine;
using System.Collections;

public class ThrusterScript : MonoBehaviour 
{
    public float thrusterStrenght;
    public float thrusterDistance;
    public Transform[] thrusters;
    
	
	void FixedUpdate () 
    {
        RaycastHit hit;
        foreach (Transform thruster in thrusters)
        {
            Vector3 force;
            float distancePercentage;

            if (Physics.Raycast(thruster.position, thruster.up * -1, out hit, thrusterDistance))
            {
                // check distance from ground. How far?
                distancePercentage = 1 - (hit.distance / thrusterDistance);

                // calculate how much force for push:
                force = transform.up * thrusterStrenght * distancePercentage;

                // correct for vehicle mass and deltatime
                force = force * Time.deltaTime * GetComponent<Rigidbody>().mass;

                // Apply force on thruster position
                GetComponent<Rigidbody>().AddForceAtPosition(force, thruster.position);
            }
        }
	}
}
