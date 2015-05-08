using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnergyScript))]
public class NewVehcileMovement : MonoBehaviour 
{
    // References
    private Rigidbody rigidbodyRef;
    private EnergyScript energyScriptRef;

    // Player number
    private int playerNR = 0;

    // Speed, turn, rotation & jump variables
    public float speed = 10000.0f;
    public float turnSpeed = 100.0f;
    public float rotSpeed = 100.0f;
    public float jumpHeight = 10000.0f;
    public float tackleModifier = 1000.0f;

    // In air or on track variables
    public float onTrackModifier = 1.0f;
    public float inAirModifier = 0.01f;
    private float trackOrAirMovement = 1.0f;

    // Boost variables
    public float maxSpeed = 5000.0f;
    public float boostMultiplier = 2.0f;
    public float boostThreshold = 0.1f;
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
        rigidbodyRef = GetComponent<Rigidbody>();
        energyScriptRef = GetComponent<EnergyScript>();

        // Set boost variables
        maxSpeedBoosted = maxSpeed * boostMultiplier;
        maxSpeedDefault = maxSpeed;
    }

    void FixedUpdate()
    {

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

    // -----------------------------------------------------------------------------

    public void SetPlayerNR(int number)
    {
        playerNR = number;
    }
    public int GetPlayerNr()
    {
        return playerNR;
    }


}
