using UnityEngine;
using System.Collections;

public class LapTimer : MonoBehaviour 
{
    private float timer;
    private string timerText;

    void Start()
    {
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    void OnGUI()
    {
        float guiNumbers = timer;
        
        GUI.Label(new Rect(450, 20, 100, 20), Mathf.Round(guiNumbers).ToString());
    }
}
