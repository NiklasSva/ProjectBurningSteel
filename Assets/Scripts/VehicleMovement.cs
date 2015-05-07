using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnergyScript))]
public class VehicleMovement : MonoBehaviour 
{
    private Rigidbody rigidbodyRef;
    private EnergyScript energyScriptRef;

    // Trying to fix movement
    private Vector3 acceleration        = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 jumpingAndTackling  = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 gravityEffect       = new Vector3(0.0f, 0.0f, 0.0f);

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

    //Tackle
    private float timerLB = 0.0f;
    private float timerRB = 0.0f;

    private float tackleTimer = 0.0f;

    // Raycast
    public Transform rayCastObject;
    public LayerMask raycastLayermask;
    public float rayCastDistance;

    // Input axis
    private float leftStickAxisX = 0.0f; // X axis
    private float leftStickAxisY = 0.0f; // Y axis

    private float triggerAxis = 0.0f; // 3rd axis

    private float rightStickAxisX = 0.0f; // 4th axis
    private float rightStickAxisY = 0.0f; // 5th axis

    private float horizontal_Dpad = 0.0f; // 6th axis
    private float vertical_Dpad = 0.0f; // 7th axis
    
    // Input buttons
    private bool buttonA = false; // 0 button
    private bool buttonB = false; // 1 button
    private bool buttonX = false; // 2 button
    private bool buttonY = false; // 3 button

    private bool leftButton = false; // 4 button
    private bool rightButton = false; // 5 button

    private bool backButton = false; // 6 button
    private bool startButton = false; // 7 button

    private bool leftStickButton = false; // 8 button
    private bool rightStickButton = false; // 9 button

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
        //OldMovement();
        //NewMovement();
        //AltMove();
        RevisedMovement();
    }

    void RevisedMovement()
    {
        // Timers
        if (timerLB > 0.0f)
        {
            timerLB -= Time.deltaTime;
        }
        if(timerRB > 0.0f)
        {
            timerRB -= Time.deltaTime;
        }
        if(tackleTimer > 0.0f)
        {
            tackleTimer -= Time.deltaTime;
        }
        
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
        
        // On track?
        if (Physics.Raycast(rayCastObject.position, rayCastObject.up * -1, rayCastDistance, raycastLayermask))
        {
            trackOrAirMovement = onTrackModifier;
            
            // Steering on track
            if (leftStickAxisX != 0)
            {
                Vector3 steeringVector = new Vector3(0.0f, turnSpeed, 0.0f) * Time.deltaTime * leftStickAxisX;
                transform.Rotate(steeringVector);

                // Correction of direction of movement
                rigidbodyRef.velocity = transform.forward * rigidbodyRef.velocity.magnitude;
            }
            
            // Jump
            if (buttonA)
            {
                rigidbodyRef.velocity += transform.up * jumpHeight;
            }

            // Strafe and tackle left
            if (leftButton)
            {
                //Debug.Log("LB");
                rigidbodyRef.AddForce(-transform.right* tackleModifier);

                if (timerLB <= 0.0f)
                {                   
                    timerLB = 0.5f;
                }
                else
                {
                    //Debug.Log("LB double");
                    if(tackleTimer <= 0.0f)
                    {
                        //Debug.Log("Tackle");
                        tackleTimer = 1.0f;
                        rigidbodyRef.AddForce(-transform.right * tackleModifier * 2);
                        energyScriptRef.Immunity();
                    }
                    else
                    {
                        //Debug.Log("No Tackle");
                        rigidbodyRef.AddForce(-transform.right * tackleModifier);
                    }
                }
            }

            // Strafe and tackle right
            if (rightButton)
            {
                //Debug.Log("RB");
                rigidbodyRef.AddForce(transform.right * tackleModifier);

                if (timerRB <= 0.0f)
                {
                    timerRB = 0.5f;
                }
                else
                {
                    //Debug.Log("RB double");
                    if (tackleTimer <= 0.0f)
                    {
                        //Debug.Log("Tackle");
                        tackleTimer = 1.0f;
                        rigidbodyRef.AddForce(transform.right * tackleModifier * 2);
                        energyScriptRef.Immunity();
                    }
                    else
                    {
                        //Debug.Log("No Tackle");
                        rigidbodyRef.AddForce(transform.right * tackleModifier);
                    }
                }
            }
        }
        else
        {
            trackOrAirMovement = inAirModifier;

            // Steering in air
            if (leftStickAxisX != 0)
            {
                Vector3 steeringVector = new Vector3(0.0f, turnSpeed, 0.0f) * Time.deltaTime * leftStickAxisX;
                transform.Rotate(steeringVector);
            }

            // Roll
            Vector3 rotationVector = new Vector3(0.0f, 0.0f, -rotSpeed) * Time.deltaTime * rightStickAxisX;
            transform.Rotate(rotationVector);
        }

        // Gravity
        rigidbodyRef.AddForce(gravityAcceleration);

        // Acceleration
        if (triggerAxis <= 0.0f)
            rigidbodyRef.AddForce(transform.forward * speed * -triggerAxis * trackOrAirMovement);
        // Break goes here

        // Restrict acceleration
        if (acceleration.magnitude > maxSpeed)
        {
            acceleration.Normalize();
            acceleration *= maxSpeed;
        }
    }

    // -----------------------------------------------------------------------------

    // Jerry's test code:
    public Vector3 testVel;
    void AltMove()
    {
        if (leftStickAxisX != 0)
        {
            Vector3 steeringVector = new Vector3(0.0f, turnSpeed, 0.0f) * Time.deltaTime * leftStickAxisX;
            transform.Rotate(steeringVector);

            // Correction of direction of movement
            Vector3 correction = transform.forward * (rigidbodyRef.velocity.magnitude);
            
            rigidbodyRef.velocity = correction;
        }

        if (Mathf.Round(triggerAxis) < 0)
        {
            rigidbodyRef.AddForce(transform.forward * speed);
        }

        if (Physics.Raycast(rayCastObject.position, rayCastObject.up * -1, rayCastDistance, raycastLayermask))
        {
            if (buttonA)
            {
                rigidbodyRef.velocity += transform.up * jumpHeight;
            }
            if (leftButton)
            {
                rigidbodyRef.AddForce(-transform.right * tackleModifier);
            }
            if (rightButton)
            {
                rigidbodyRef.AddForce(transform.right * tackleModifier);
            }
        }
        rigidbodyRef.AddForce(-transform.up * 1000);
    }

    // -----------------------------------------------------------------------------

    void NewMovement()
    {
        // Steering
        
        if (leftStickAxisX != 0)
        {
            Vector3 steeringVector = new Vector3(0.0f, turnSpeed, 0.0f) * Time.deltaTime * leftStickAxisX;
            transform.Rotate(steeringVector);

            // Correction of direction of movement
            Vector3 correction = transform.forward * (rigidbodyRef.velocity.magnitude / 2);
            rigidbodyRef.velocity = rigidbodyRef.velocity / 2;
            rigidbodyRef.velocity += correction;
        }

        // Reset vectors
        acceleration        = Vector3.zero;
        jumpingAndTackling  = Vector3.zero;
        gravityEffect       = Vector3.zero;

        // speed for this frame
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

        // Acceleration
        if (Mathf.Round(triggerAxis) < 0)
        {
            acceleration = transform.forward * move * trackOrAirMovement;
        }
        if (Mathf.Round(triggerAxis) > 0)
        {
            // break
        }

        // Restrict acceleration
        if (acceleration.magnitude > maxSpeed)
        {
            acceleration.Normalize();
            acceleration *= maxSpeed;
        }

        // 'On track' check
        if (Physics.Raycast(rayCastObject.position, rayCastObject.up * -1, rayCastDistance, raycastLayermask))
        {
            trackOrAirMovement = onTrackModifier;

            // Jump
            if (buttonA)
            {
                jumpingAndTackling += transform.up * jumpHeight;
            }

            // Tackle
            if (leftButton)
            {
                jumpingAndTackling -= transform.right * tackleModifier;
            }


            if (rightButton)
            {
                jumpingAndTackling += transform.right * tackleModifier;
            }
        }
        else
        {
            trackOrAirMovement = inAirModifier;

            // Roll
            Vector3 rotationVector = new Vector3(0.0f, 0.0f, -rotSpeed) * Time.deltaTime * rightStickAxisX;
            transform.Rotate(rotationVector);
        }

        // Gravity
        gravityEffect = gravityAcceleration * Time.deltaTime;

        // Add everything to velocity
        rigidbodyRef.velocity += acceleration + jumpingAndTackling + gravityEffect;
    }

    // -----------------------------------------------------------------------------

    void OldMovement()
    {
        float move = speed * Time.deltaTime;
        //if(tackleTimer > 0.0f)
            //tackleTimer -= Time.deltaTime;



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



        //Strafe & Tackle Left
        if (leftButton)
        {
            rigidbodyRef.velocity -= transform.right * tackleModifier;
        }

        if (rightButton)
        {

            rigidbodyRef.velocity += transform.right * tackleModifier;
        }

        // Tackle
        //if (tackleTimer < 0.0f)
        {
            
        }       
    }

    void InAir()
    {
        trackOrAirMovement = inAirModifier;

        // Roll
        Vector3 rotationVector = new Vector3(0.0f, 0.0f, -rotSpeed) * Time.deltaTime * rightStickAxisX;
        transform.Rotate(rotationVector);

        // Pitch
        rotationVector = new Vector3(-rotSpeed, 0.0f, 0.0f) * Time.deltaTime * rightStickAxisY;
        transform.Rotate(rotationVector);
    }

    public void Gravity(Vector3 directionalAcceleration)
    {
        gravityAcceleration = directionalAcceleration;
    }

    // -----------------------------------------------------------------------------

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
