using UnityEngine;
using System.Collections;

public class KillFloorScript : MonoBehaviour 
{
    public Transform startPosition;


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = startPosition.transform.position;
            other.transform.rotation = startPosition.transform.rotation;
            other.transform.Rotate(Vector3.zero);
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
