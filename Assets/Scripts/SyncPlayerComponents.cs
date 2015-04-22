using UnityEngine;
using System.Collections;

public class SyncPlayerComponents : MonoBehaviour 
{
    public Transform movementCollider;

    void Update()
    {
        Vector3 newPosition = movementCollider.position;
        newPosition.y += 4;
                
    }
}
