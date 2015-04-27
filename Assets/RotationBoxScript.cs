using UnityEngine;

public class RotationBoxScript : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.rotation = this.transform.rotation;
        }
    }
}
