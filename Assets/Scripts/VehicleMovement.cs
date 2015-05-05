using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnergyScript))]
public class VehicleMovement : MonoBehaviour 
{
    private Rigidbody rigidbodyRef;
    private EnergyScript energyScriptRef;

    // Gravity

    private Vector3 gravityAcceleration;

    // Speed, turn, rotation & jump variables
    public float speed          = 10000.0f;
    public float turnSpeed      = 100.0f;
    public float rotSpeed       = 100.0f;
    public float jumpHeight     = 10000.0f;
    public float tackleModifier = 1000.0f;

    // In air or on track variables
    public float onTrackModifier        = 1.0f;
    public float inAirModifier          = 0.01f;
    private float trackOrAirMovement    = 1.0f;

    // Boost variables
    public float maxSpeed           = 5000.0f;
    public float boostMultiplier    = 2.0f;
    public float boostThreshold     = 0.1f;

    public float maxSpeedBoosted;
    private float maxSpeedDefault;

    // Raycast
    public Transform rayCastObject;
    public LayerMask raycastLayermask;
    public float rayCastDistance;

    // Input axis
    private float leftStickAxisX    = 0.0f; // X axis
    private float leftStickAxisY    = 0.0f; // Y axis

    private float triggerAxis   = 0.0f; // 3rd axis

    private float rightStickAxisX   = 0.0f; // 4th axis
    private float rightStickAxisY   = 0.0f; // 5th axis

    private float horizontal_Dpad   = 0.0f; // 6th axis
    private float vertical_Dpad     = 0.0f; // 7th axis
    
    // Input buttons
    private bool buttonA = false; // 0
    private bool buttonB = false; // 1
    private bool buttonX = false; // 2
    private bool buttonY = false; // 3

    private bool leftButton     = false; // 4
    private bool rightButton    = false; // 5

    private bool backButton     = false; // 6
    private bool startButton    = false; // 7

    private bool leftStickButton    = false; // 8
    private bool rightStickButton   = false; // 9

    //---------------------------------------------------------------------------------------

    void Awake()
    {
        rigidbodyRef    = GetComponent<Rigidbody>();
        energyScriptRef = GetComponent<EnergyScript>();

        // Boost variables
        maxSpeedBoosted = maxSpeed * boostMultiplier;
        maxSpeedDefault = maxSpeed;
    }

    void FixedUpdate()
    {
        float move = speed * Time.deltaTime;

        // Boost
        if (buttonX)
        {
            if (energyScriptRef.currentEnergy >= (energyScriptRef.maxEnergy * boostThreshold)) // If under a certain threshold of energy reserves, boost is locked
            {
                maxSpeed = maxSpeedBoosted;
                energyScriptRef.BoostCost();
            }
        }
        else
        {
            maxSpeed = maxSpeedDefault;
        }
        
        // Steering
        Vector3 steeringVector = new Vector3(0.0f, turnSpeed, 0.0f) * Time.deltaTime * leftStickAxisX;
        transform.Rotate(steeringVector);
        //rigidbodyRef.velocity = transform.forward * rigidbodyRef.velocity.magnitude; // <- gives better respons to the steering but impedes jumping, rotation and gravity as they are all put into the same magnitud and directed forward

        // Acceleration & deceleration
        if (Mathf.Round(triggerAxis) < 0)
        {           
            rigidbodyRef.velocity += transform.forward * move * trackOrAirMovement;
        }
        if (Mathf.Round(triggerAxis) > 0)
        {
            rigidbodyRef.velocity -= transform.forward * move * trackOrAirMovement; // change to be more like breaks
        }
        
        // 'On track' check
        if (Physics.Raycast(rayCastObject.position, rayCastObject.up * -1, rayCastDistance, raycastLayermask))
        {
            OnTrackMovement();
        }
        else
        {
            // Roll
            InAir();
            // Energy attrition
            energyScriptRef.AttritionDamage();
        }
        
        // Gravity
        rigidbodyRef.velocity += gravityAcceleration * Time.deltaTime;

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
        trackOrAirMovement = onTrackModifier;

        // Jump
        if (buttonA)
        {
            rigidbodyRef.AddForce(transform.up * jumpHeight);
        }

        // Tackle
        if (leftButton)
        {
            rigidbodyRef.velocity -= transform.right * tackleModifier;
        }
        if (rightButton)
        {
            rigidbodyRef.velocity += transform.right * tackleModifier;
        }
    }

    void InAir()
    {
        trackOrAirMovement = inAirModifier;

        // Roll
        Vector3 rotationVector = new Vector3(0.0f, 0.0f, -rotSpeed) * Time.deltaTime * rightStickAxisX;
        transform.Rotate(rotationVector);
        
        // Pitch
        //rotationVector = new Vector3(-rotSpeed, 0.0f, 0.0f) * Time.deltaTime * rightStickAxisY;
        //transform.Rotate(rotationVector);
    }

    public void Gravity(Vector3 directionalAcceleration)
    {
        gravityAcceleration = directionalAcceleration;
    }

    // Input values:

    // Left stick
    public void LeftStickAxisX(float value)
    {
        leftStickAxisX = value;
    }
    public void LeftStickAxisY(float value)
    {
        leftStickAxisY = value;
    }

    // Triggers
    public void TriggerAxis(float value)
    {
        triggerAxis = value;
    }

    // Right stick
    public void RightStickAxisX(float value)
    {
        rightStickAxisX = value;
    }
    public void RightStickAxisY(float value)
    {
        rightStickAxisY = value;
    }

    // DPAD
    public void HorizontalDPAD(float value)
    {
        horizontal_Dpad = value;
    }
    public void VerticalDPAD(float value)
    {
        vertical_Dpad = value;
    }

    // Face buttons
    public void ButtonA(bool isPressed)
    {
        buttonA = isPressed;
    }
    public void ButtonB(bool isPressed)
    {
        buttonB = isPressed;
    }
    public void ButtonX(bool isPressed)
    {
        buttonX = isPressed;
    }
    public void ButtonY(bool isPressed)
    {
        buttonY = isPressed;
    }

    // LB & RB
    public void LeftButton(bool isPressed)
    {
        leftButton = isPressed;
    }
    public void RightButton(bool isPressed)
    {
        rightButton = isPressed;
    }

    // Back & Start
    public void StartButton(bool isPressed)
    {
        startButton = isPressed;
    }
    public void BackButton(bool isPressed)
    {
        backButton = isPressed;
    }

    // Left & Right stick buttons
    public void LeftStickButton(bool isPressed)
    {
        leftStickButton = isPressed;
    }
    public void RightStickButton(bool isPressed)
    {
        rightStickButton = isPressed;
    }
}
