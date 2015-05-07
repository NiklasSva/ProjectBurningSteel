using UnityEngine;
using System.Collections.Generic;

public class RotationBoxScript : MonoBehaviour 
{
    public float rotationModifier = 1.0f;
    private Dictionary<int, Transform> enteredObjects = new Dictionary<int, Transform>(); // Instance ID, Transform

    void Update()
    {
        foreach (KeyValuePair<int, Transform> pair in enteredObjects)
        {
            // NOTE: 't' should be static or calculated dynamically.

            //pair.Value.rotation = Quaternion.RotateTowards(pair.Value.rotation, this.transform.rotation, Time.deltaTime * t); 
            
            //pair.Value.rotation = Quaternion.Slerp(pair.Value.rotation, this.transform.rotation, Time.deltaTime * t);
            pair.Value.rotation = Quaternion.Lerp(pair.Value.rotation, this.transform.rotation, Time.deltaTime * rotationModifier); //faster but may look awkward depending on angle difference
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enteredObjects.Add(other.GetInstanceID(), other.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enteredObjects.Remove(other.GetInstanceID());
        }
    }
}