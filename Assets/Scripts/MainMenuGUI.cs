using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour 
{
    public Texture logo;
    public GUIStyle style;

    void OnGUI()
    {
        if (!logo)
        {
            Debug.LogError("Assign a texture in the inspector");
            return;
        }
        GUI.DrawTexture(new Rect(0.0f, 0.0f, Screen.width, Screen.height), logo, ScaleMode.ScaleToFit);

        GUI.Label(new Rect(Screen.width/2, 100, 100, 20), "Press P to start", style);
    }
}
