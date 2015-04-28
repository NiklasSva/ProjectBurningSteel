using UnityEngine;
using System.Collections.Generic;

public class Recharge : MonoBehaviour 
{
    private Dictionary<int, Transform> enteredObjects = new Dictionary<int, Transform>(); // Instance ID, Transform

    void Update()
    {
        foreach (KeyValuePair<int, Transform> keyValuePair in enteredObjects)
        {
            keyValuePair.Value.GetComponent<EnergyScript>().Recharge();
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
