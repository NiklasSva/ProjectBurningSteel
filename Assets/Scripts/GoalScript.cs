using UnityEngine;
using System.Collections.Generic;

public class GoalScript : MonoBehaviour 
{
    public int winScore = 3;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerScore>().laps++;

            if (other.GetComponent<PlayerScore>().laps >= winScore)
            {
                Application.LoadLevel("FirstPlayableWin");
            }
        }
    }
}
