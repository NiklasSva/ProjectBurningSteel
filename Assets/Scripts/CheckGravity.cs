using UnityEngine;
using System.Collections.Generic;

public class CheckGravity : MonoBehaviour 
{
    // how many road segment's sphere (or rather box) of influence the player is currently inside.
    private int triggerCount;
	
	
	// Update is called once per frame
	void Update () 
    {
        if (triggerCount > 0)
        {
            if(GetComponent<Rigidbody>())
                GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            if (GetComponent<Rigidbody>())
                GetComponent<Rigidbody>().useGravity = true;
        }
	}

    public void EnteredTrigger()
    {
        triggerCount++;
    }

    public void ExitedTrigger()
    {
        if (triggerCount >= 0)
        {
            triggerCount--;
        }        
    }
}
