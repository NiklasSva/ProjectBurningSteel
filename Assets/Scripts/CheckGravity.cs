using UnityEngine;
using System.Collections.Generic;

public class CheckGravity : MonoBehaviour 
{
    // how many road segment's sphere (or rather box) of influence the player is currently inside.
    public int triggerCount = 0;

    public float gravityMultiplier = 1.0f;
	
	// Update is called once per frame
	void Update () 
    {
        if (triggerCount > 0)
        {
         /*   if(GetComponent<Rigidbody>())
                GetComponent<Rigidbody>().useGravity = false;*/
        }
        else
        {
          /*  if (GetComponent<Rigidbody>())
                GetComponent<Rigidbody>().useGravity = true;*/

            GetComponent<Rigidbody>().velocity += Vector3.down * 9.81f * Time.deltaTime * GetComponent<Rigidbody>().mass * gravityMultiplier;
        }
	}

    public void Plus()
    {
        triggerCount++;
    }

    public void Minus()
    {
        if (triggerCount > 0)
        {
            triggerCount--;
        }        
    }
}
