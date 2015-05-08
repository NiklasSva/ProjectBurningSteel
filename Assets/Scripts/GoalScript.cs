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
                if(other.GetComponent<VehicleMovement>().GetPlayerNr() == 1)
                {
                    Application.LoadLevel("Player1Win");
                }
                else if(other.GetComponent<VehicleMovement>().GetPlayerNr() == 2)
                {
                    Application.LoadLevel("Player2Win");
                }
            }
        }
    }
}
