using UnityEngine;

public class PlayerCameraBehaviour : MonoBehaviour 
{
    public Transform target;
    public float distanceUp;
    public float distanceBack;
    public float minimumHeight;

    // Not used directly:
    private Vector3 positionVelocity;

    void FixedUpdate()
    {
        // Calculate a new position to place the camera:
        Vector3 newPosition = target.transform.position + (target.transform.forward * distanceBack);
        newPosition += transform.up * distanceUp;

        // Move the camera:
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref positionVelocity, Time.deltaTime);

        // Match player rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime);
    }
}


/*
    old code:
 * 
 * // Calculate a new position to place the camera:
        Vector3 newPosition = target.position + (target.forward * distanceBack);
        newPosition.y = Mathf.Max(newPosition.y + distanceUp, minimumHeight);

        // Move the camera:
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref positionVelocity, 0.10f);
 * 
  // Rotate the camera to look at where the player is pointing:
        Vector3 focalPoint = target.position + (target.forward * 5);
        transform.LookAt(focalPoint);

*/