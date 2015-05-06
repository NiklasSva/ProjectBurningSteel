using UnityEngine;

[RequireComponent(typeof(VehicleMovement))]
public class InputPlayer2 : MonoBehaviour 
{
    private VehicleMovement vehicleMovementRef;
    private EnergyScript energyScriptRef;

    void Start()
    {
        vehicleMovementRef = GetComponent<VehicleMovement>();
        energyScriptRef = GetComponent<EnergyScript>();
    }

    void Update()
    {
        vehicleMovementRef.RightStickAxisX(Input.GetAxis("RightJoystickX_P2"));
        vehicleMovementRef.RightStickAxisY(Input.GetAxis("RightJoystickY_P2"));

        vehicleMovementRef.TriggerAxis(Input.GetAxis("Triggers_P2"));
        vehicleMovementRef.LeftStickAxisX(Input.GetAxis("LeftJoystickX_P2"));  
  
        vehicleMovementRef.ButtonA(Input.GetButton("A_P2"));
        vehicleMovementRef.ButtonX(Input.GetButton("X_P2"));

        vehicleMovementRef.LeftButton(Input.GetButtonDown("LB_P2"));
        vehicleMovementRef.RightButton(Input.GetButtonDown("RB_P2"));
    }

        // Move this to another script?
    void OnGUI()
    {
        GUI.Label(new Rect(200, 400, 100, 20), "Energy 2: " + Mathf.Round(energyScriptRef.currentEnergy).ToString());
                                                   // ^ add player number here!
    }
}
