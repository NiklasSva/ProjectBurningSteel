using UnityEngine;
using System.Collections;

public class GoBackToAlpha : MonoBehaviour 
{
	void Update () 
    {
        if (Input.GetKey("t"))
        {
            Application.LoadLevel("testingLevel"); // early alpha build scene
        }
	}
}
