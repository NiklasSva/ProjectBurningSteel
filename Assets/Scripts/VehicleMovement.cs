using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnergyScript))]
public class VehicleMovement : MonoBehaviour 
{
    private Rigidbody rigidbodyRef;
    private EnergyScript energyScriptRef;

    // Speed, turn, rotation & jump variables
    public float speed      = 50.0f;
    public float turnSpeed  = 50.0f;
    public float rotSpeed   = 10.0f;
    public float jumpHeight = 20.0f;

    // Boost variables
    public float maxSpeed           = 200.0f;
    public float boostMultiplier    = 2.0f;

    private float maxSpeedBoosted;
    private float maxSpeedDefault;

    // Raycast
    public Transform rayCastObject;
    public LayerMask raycastLayermask;
    public float rayCastDistance;

    // Input variables
    private float triggerAxis       = 0.0f;
    private float leftStickAxisX    = 0.0f;


    private bool buttonA = false;
    private bool buttonX = false;

    void Awake()
    {
        rigidbodyRef    = GetComponent<Rigidbody>();
        energyScriptRef = GetComponent<EnergyScript>();

        maxSpeedBoosted = maxSpeed * boostMultiplier;
        maxSpeedDefault = maxSpeed;
    }

    void FixedUpdate()
    {
        // Steering
        Vector3 steeringVector = new Vector3(0.0f, turnSpeed, 0.0f) * Time.deltaTime * leftStickAxisX;

        // 'On track' check
        if (Physics.Raycast(rayCastObject.position, rayCastObject.up * -1, rayCastDistance, raycastLayermask))
        {
            OnTrackMovement();
        }
        else
        {
            // Pitch/Roll

            // Energy attrition
            energyScriptRef.AttritionDamage();
        }

        // Restrict velocity
        Vector3 vel = rigidbodyRef.velocity;
        if (vel.magnitude > maxSpeed)
        {
            vel.Normalize();
            vel *= maxSpeed;
            rigidbodyRef.velocity = vel;
        }

    }

    void OnTrackMovement()
    {
        float move = speed * Time.deltaTime;

        // Jump
        if (buttonA)
        {
            rigidbodyRef.velocity = transform.up * jumpHeight * Time.deltaTime;
        }

        // Boost
        if (buttonX && energyScriptRef.currentEnergy > 0.0f)
        {
            maxSpeed = maxSpeedBoosted;
            rigidbodyRef.AddForce(transform.forward * speed * Time.deltaTime * boostMultiplier);
            energyScriptRef.BoostCost();
        }
        else
        {
            maxSpeed = maxSpeedDefault;
        }

        // Acceleration & deceleration
        if (Mathf.Round(triggerAxis) < 0)
        {
            rigidbodyRef.velocity += transform.forward * move;
        }
        if (Mathf.Round(triggerAxis) > 0)
        {
            rigidbodyRef.velocity -= transform.forward * move;
        }
    }

    // Set axis values
    public void TriggerAxis(float axisValue)
    {
        triggerAxis = axisValue;
    }

    public void LeftStickAxisX(float axisValue)
    {
        leftStickAxisX = axisValue;
    }

    // Set buttons
    public void ButtonA(bool isPressed)
    {
        buttonA = isPressed;
    }
    public void ButtonX(bool isPressed)
    {
        buttonX = isPressed;
    }
}
