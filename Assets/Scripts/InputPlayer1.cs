using UnityEngine;

[RequireComponent(typeof(VehicleMovement))]
public class InputPlayer1 : MonoBehaviour 
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
        vehicleMovementRef.RightStickAxisX(Input.GetAxis("RightJoystickX"));
        vehicleMovementRef.RightStickAxisY(Input.GetAxis("RightJoystickY"));

        vehicleMovementRef.TriggerAxis(Input.GetAxis("Triggers"));
        vehicleMovementRef.LeftStickAxisX(Input.GetAxis("LeftJoystickX"));  
  
        vehicleMovementRef.ButtonA(Input.GetButton("A"));
        vehicleMovementRef.ButtonX(Input.GetButton("X"));

        vehicleMovementRef.LeftButton(Input.GetButton("LB"));
        vehicleMovementRef.RightButton(Input.GetButton("RB"));
    }

        // Move this to another script?
    void OnGUI()
    {
        GUI.Label(new Rect(100, 300, 100, 20), "Energy: " + Mathf.Round(energyScriptRef.currentEnergy).ToString());
                                                   // ^ add player number here!
    }
}
