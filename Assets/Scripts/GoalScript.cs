using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour 
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Win!");

            Application.LoadLevel("FirstPlayableWin");
        }
    }

}
