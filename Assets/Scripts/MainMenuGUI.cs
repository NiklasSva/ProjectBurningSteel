using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour 
{
    public Texture logo;

    void OnGUI()
    {
        if (!logo)
        {
            Debug.LogError("Assign a texture in the inspector");
            return;
        }
        GUI.DrawTexture(new Rect(0.0f, 0.0f, Screen.width, Screen.height), logo, ScaleMode.ScaleToFit);
    }
}
