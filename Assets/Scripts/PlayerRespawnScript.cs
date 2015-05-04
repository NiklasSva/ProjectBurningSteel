using UnityEngine;

public class PlayerRespawnScript : MonoBehaviour 
{
    private Transform respawnPoint;

    void Start()
    {
        respawnPoint = GetComponent<Transform>();
    }

    public void Checkpoint(Transform newRespawn)
    {
        respawnPoint = newRespawn;
    }

    public void Respawn()
    {
        Debug.Log("respawn");

        GetComponent<Transform>().position = respawnPoint.transform.position;
        GetComponent<Transform>().rotation = respawnPoint.transform.rotation;
        GetComponent<Transform>().Rotate(Vector3.zero);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}