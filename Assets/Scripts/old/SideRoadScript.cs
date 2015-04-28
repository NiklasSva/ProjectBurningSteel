using UnityEngine;
using System.Collections;

public class SideRoadScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<BasicGravity>().SetGravityObject(this.transform, true, false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<BasicGravity>().ClearGravityObject();
        }
    }

}
