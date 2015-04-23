using UnityEngine;
using System.Collections;

public class GoToTestScene : MonoBehaviour 
{
    void Update()
    {
        if(Input.GetKey("t"))
        {
            Application.LoadLevel("PreAlpha");
        }
    }	
}
