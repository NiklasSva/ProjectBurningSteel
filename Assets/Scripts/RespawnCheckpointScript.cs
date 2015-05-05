using UnityEngine;

public class RespawnCheckpointScript : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerRespawnScript>().Checkpoint(this.transform);
        }
    }
}
