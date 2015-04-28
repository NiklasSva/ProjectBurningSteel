using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour 
{
	void Update () 
    {
        if (Input.GetKey("r"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
