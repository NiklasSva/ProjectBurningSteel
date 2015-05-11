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
        Vector3 newPosition = target.position + (target.forward * distanceBack);
        newPosition.y = Mathf.Max(newPosition.y + distanceUp, minimumHeight);

        // Move the camera:
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref positionVelocity, 0.18f);

        // Rotate the camera to look at where the car is pointing:
        Vector3 focalPoint = target.position + (target.forward * 5);
        transform.LookAt(focalPoint);
    }


}
