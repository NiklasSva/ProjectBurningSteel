using UnityEngine;

public class LoadTrackLevel : MonoBehaviour 
{
	void Update () 
    {
        if (Input.GetKey("p"))
        {
            Application.LoadLevel("TestingLoopsAndCurves");
        }
	}
}
