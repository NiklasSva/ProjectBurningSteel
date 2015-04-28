using UnityEngine;
using System.Collections;

public class SideRoad2 : MonoBehaviour
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
            other.GetComponent<BasicGravity>().SetGravityObject(this.transform, true, true);
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
