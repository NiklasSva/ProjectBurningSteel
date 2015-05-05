using UnityEngine;

public class PlayerRespawnScript : MonoBehaviour 
{
    private Vector3 respawnPos;
    private Quaternion respawnRot;

    void Start()
    {
        respawnPos = GetComponent<Transform>().position;
        respawnRot = GetComponent<Transform>().rotation;
    }

    public void Checkpoint(Transform newRespawn)
    {
        respawnPos = newRespawn.position;
        respawnRot = newRespawn.rotation;
    }

    public void Respawn()
    {
        GetComponent<EnergyScript>().currentEnergy = GetComponent<EnergyScript>().maxEnergy;

        GetComponent<Transform>().position = respawnPos;
        GetComponent<Transform>().rotation = respawnRot;
        GetComponent<Transform>().Rotate(Vector3.zero);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}