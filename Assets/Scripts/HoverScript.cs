using UnityEngine;
using System.Collections;

public class HoverScript : MonoBehaviour 
{
    public float thrusterDistance = 1.05f;
    public Transform[] thrusters;
    
	
	void FixedUpdate () 
    {
        RaycastHit hit;
        foreach (Transform thruster in thrusters)
        {
            if (Physics.Raycast(thruster.position, thruster.up * -1, out hit, thrusterDistance))
            {
                Vector3 hoveringDistance = transform.up.normalized * thrusterDistance;

                transform.position += hoveringDistance / thrusters.Length;
            }
        }
	}
}
